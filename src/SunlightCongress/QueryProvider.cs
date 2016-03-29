using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace Congress
{
    public class QueryProvider : IQueryProvider
    {
        private string _apiKey;
        public QueryProvider(string apiKey)
        {
            _apiKey = apiKey;
        }
        public object Execute (Expression expression)
        {
            throw new NotImplementedException();
        }
        public TResult Execute<TResult>(Expression expression)
        {
            using (WebClient client = new WebClient())
            {
                string response = string.Empty;
                MethodCallExpression methodCall = expression as MethodCallExpression;
                string operation = ExpressionConverter<MethodCallExpression>(methodCall);

                var constant = (methodCall != null) ?
                                (methodCall.Arguments.FirstOrDefault(x => x.NodeType == ExpressionType.Constant) as ConstantExpression).Value.GetType() :
                                expression.Type;
                string path = string.Empty;
                if (constant == typeof(Amendments))
                    path = Settings.AmendmentsUrl;
                else if (constant == typeof(Bills) && operation.Contains("query"))
                    path = Settings.BillsSearchUrl;
                else if (constant == typeof(Bills))
                    path = Settings.BillsUrl;
                else if (constant == typeof(Committees))
                    path = Settings.CommitteesUrl;
                else if (constant == typeof(CongressionalDocuments))
                    path = Settings.CongressionalDocumentsSearchUrl;
                else if (constant == typeof(Districts))
                    path = Settings.DistrictsLocateUrl;
                else if (constant == typeof(Documents))
                    path = Settings.DocumentsSearchUrl;
                else if (constant == typeof(FloorUpdates))
                    path = Settings.FloorUpdatesUrl;
                else if (constant == typeof(Hearings))
                    path = Settings.HearingsUrl;
                else if (constant == typeof(Legislators) && (operation.Contains("zip") || operation.Contains("longitude") || operation.Contains("latitude")))
                    path = Settings.LegislatorsLocateUrl;
                else if (constant == typeof(Legislators))
                    path = Settings.LegislatorsUrl;
                else if (constant == typeof(Nominations))
                    path = Settings.NominationsUrl;
                else if (constant == typeof(UpcomingBills))
                    path = Settings.UpcomingBillsUrl;
                else if (constant == typeof(Votes))
                    path = Settings.VotesUrl;
                client.BaseAddress = string.Format("{0}?apikey={1}&{2}", path, _apiKey, operation);
                response = client.DownloadString(client.BaseAddress);
                var typedResponse = JsonConvert.DeserializeObject<SunlightResponse<TResult>>(response);
                return typedResponse.Results;
            }
        }


        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new SunlightData<TElement>(_apiKey, expression);
        }

        private static void VisitMethodCall(MethodCallExpression m, StringBuilder operation)
        {
            ExtractJsonProperties(operation, m.Arguments[0] as MemberExpression);
            if (m.Method.Name == "Contains")
                operation.AppendFormat("__in={0}&", string.Join("|", m.Arguments.Skip(1)));
            else
                throw new Exception(string.Format("Unable to perform {0} action", m.Method.Name));
        }

        private static void ParseBinary(BinaryExpression b, List<Tuple<MemberExpression, Expression, BinaryExpression>> membersandUnarysAndBinarys, List<BinaryExpression> binarys, StringBuilder operation)
        {
            BinaryExpression left = b.Left as BinaryExpression;
            if (b.Right.NodeType.ToString() == "Call")
                VisitMethodCall(b.Right as MethodCallExpression, operation);
            else
                binarys.Add(b.Right as BinaryExpression);
            if (left.NodeType == ExpressionType.AndAlso || left.NodeType == ExpressionType.OrElse)
                ParseBinary(left, membersandUnarysAndBinarys, binarys, operation);
            else
            {
                binarys.Add(b.Left as BinaryExpression);
                foreach (BinaryExpression binary in binarys)
                {
                    membersandUnarysAndBinarys.Add(new Tuple<MemberExpression, Expression, BinaryExpression>(binary.Left as MemberExpression, binary.Right as Expression, binary));
                }
            }

        }

        internal static object GetRightValue(Expression unary, string type)
        {
            if (type == "Nullable`1")
            {
                if (unary.Type.FullName.ToLower().Contains("datetime"))
                    return Expression.Lambda<Func<DateTime?>>(unary).Compile().Invoke();
                else if (unary.Type.FullName.ToLower().Contains("int"))
                    return Expression.Lambda<Func<int?>>(unary).Compile().Invoke();
                else if (unary.Type.FullName.ToLower().Contains("bool"))
                    return Expression.Lambda<Func<bool?>>(unary).Compile().Invoke();
                else if (unary.Type.FullName.ToLower().Contains("double"))
                    return Expression.Lambda<Func<double?>>(unary).Compile().Invoke();
            }
            else if (type.ToLower() == "string[]")
                return Expression.Lambda<Func<string[]>>(unary).Compile().Invoke();
            else if (type.ToLower() == "string")
                return Expression.Lambda<Func<string>>(unary).Compile().Invoke();
            else if (type.ToLower() == "object")
                return null;

            throw new Exception("not a base type");
        }

        internal static string FormatRightValueAsString(object rightValue, string type)
        {
            if (type == "Nullable`1")
            {
                if (rightValue as DateTime? != null)
                {
                    DateTime? newValue = rightValue as DateTime?;
                    return newValue.Value.ToString("yyyy-MM-dd");
                }
                else if (rightValue as int? != null)
                {
                    int? newValue = rightValue as int?;
                    return newValue.Value.ToString();
                }
                else if (rightValue as bool? != null)
                {
                    bool? newValue = rightValue as bool?;
                    return newValue.Value.ToString().ToLower();
                }
            }
            else if (type == "String")
            {
                string newValue = rightValue as string;
                if (Regex.IsMatch(newValue, @"^\d+$")) // check if it's a number, and wrap in quotes (bug in Sunlight)
                    return string.Format("%22{0}%22", newValue);
                else
                    return newValue;
            }
            else if (type == "String[]")
            {
                string[] newValue = rightValue as string[];
                return string.Join("|", newValue);
            }
            return rightValue.ToString().ToLower();
        }

        private static StringBuilder ExtractJsonProperties(StringBuilder operation, MemberExpression item1 = null)
        {
            if (item1.Expression.GetType().Name == "PropertyExpression")
            {
                MemberExpression expression = item1.Expression as MemberExpression;
                ExtractJsonProperties(operation, expression);
                operation.Append(".");
            }
            var attr = item1.Member.GetCustomAttributes(true).ToDictionary(a => a.GetType().Name, a => a);
            if (attr.Keys.Contains("JsonPropertyAttribute"))
            {
                JsonPropertyAttribute attribute = attr["JsonPropertyAttribute"] as JsonPropertyAttribute;
                operation.Append(attribute.PropertyName);
            }
            else
                operation.Append(item1.Member.Name);
            return operation;
        }

        private static string ExpressionConverter<T>(MethodCallExpression methodCall)
        {
            if (methodCall == null)
                return string.Empty;
            //Convert expressions to query strings.
            UnaryExpression unary = methodCall.Arguments.FirstOrDefault(x => x.NodeType == ExpressionType.Quote) as UnaryExpression;

            StringBuilder operation = new StringBuilder();
            if (unary.Operand.NodeType == ExpressionType.Lambda)
            {
                LambdaExpression l = unary.Operand as LambdaExpression;
                BinaryExpression b = l.Body as BinaryExpression;
                List<Tuple<MemberExpression, Expression, BinaryExpression>> membersAndUnarysAndBinarys = new List<Tuple<MemberExpression, Expression, BinaryExpression>>();
                if (b.NodeType == ExpressionType.AndAlso || b.NodeType == ExpressionType.OrElse)
                {
                    List<BinaryExpression> binarys = new List<BinaryExpression>();
                    ParseBinary(b, membersAndUnarysAndBinarys, binarys, operation);
                }
                else
                    membersAndUnarysAndBinarys.Add(new Tuple<MemberExpression, Expression, BinaryExpression>(b.Left as MemberExpression, b.Right as Expression, b));

                foreach (Tuple<MemberExpression, Expression, BinaryExpression> item in membersAndUnarysAndBinarys)
                {
                    string type = item.Item2.Type.Name;
                    var rightValue = GetRightValue(item.Item2, type);

                    //Pull the JsonProperty off of the class and use that for serialization.
                    ExtractJsonProperties(operation, item.Item1);

                    //https://sunlightlabs.github.io/congress/#operators
                    if (item.Item3.NodeType == ExpressionType.GreaterThan)
                        operation.Append("__gt");
                    if (item.Item3.NodeType == ExpressionType.GreaterThanOrEqual)
                        operation.Append("__gte");
                    if (item.Item3.NodeType == ExpressionType.LessThan)
                        operation.Append("__lt");
                    if (item.Item3.NodeType == ExpressionType.LessThanOrEqual)
                        operation.Append("__lte");
                    if (item.Item3.NodeType == ExpressionType.NotEqual)
                        operation.Append("__not");
                    if (item.Item3.NodeType == ExpressionType.NotEqual && item.Item3.Right.Type.ToString() == "String[]")
                        operation.Append("__nin");
                    if (item.Item3.NodeType == ExpressionType.NotEqual && item.Item3.Right == null)
                        operation.Append("__exists=true");
                    if (item.Item3.NodeType == ExpressionType.Equal && item.Item3.Right.Type.ToString() == "String[]")
                        operation.Append("__all");
                    if (item.Item3.NodeType == ExpressionType.Equal && item.Item3.Right == null)
                        operation.Append("__exists=false");

                    if (item.Item3.Right.ToString() != "null")
                        operation.AppendFormat("={0}{1}", FormatRightValueAsString(rightValue, type), item == membersAndUnarysAndBinarys.Last() ? "" : "&");
                    else
                        operation.Append(item == membersAndUnarysAndBinarys.Last() ? "" : "&");
                }
            }
            return operation.ToString();
        }
    }

    public class SunlightData<T> : IQueryable<T>, IOrderedQueryable<T>
    {
        protected string _apiKey;
        protected Expression _expression;

        public SunlightData(string apiKey, Expression expression)
        {
            _apiKey = apiKey;
            _expression = expression;
        }

        public SunlightData(string apiKey)
        {
            _apiKey = apiKey;
            _expression = Expression.Constant(this);
        }

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return new QueryProvider(_apiKey);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (Provider.Execute<IEnumerable<T>>(Expression)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute<System.Collections.IEnumerable>(Expression)).GetEnumerator();
        }
    }
}