using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Congress
{
    public class BasicReponse
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

    }

    public class BasicRequest
    {
        [JsonProperty("count")]
        public int? Count { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

    }

    public class Page
    {
        [JsonProperty("per_page")]
        public int? PerPage { get; set; }

        [JsonProperty("page")]
        public int? PageNumber { get; set; }

        [JsonProperty("count")]
        public int? Count { get; set; }
    }

    public class Operator
    {
        public static string GreaterThan = "GreaterThan";
        public static string GreaterThanOrEquals = "GreaterThanOrEquals";
        public static string LessThan = "LessThan";
        public static string LessThanOrEquals = "LessThanOrEquals";
        public static string Not = "Not";
        public static string All = "All";
        public static string In = "In";
        public static string NotIn = "NotIn";
        public static string Exists = "Exists";
        public static string NotExists = "NotExists";
    }

    public class Filter<T>
    {

        public T[] Values { get; set; }
        public bool? GreaterThan { get; set; }
        public bool? GreaterThanOrEquals { get; set; }
        public bool? LessThan { get; set; }
        public bool? LessThanOrEquals { get; set; }
        public bool? Not { get; set; }
        public bool? All { get; set; }
        public bool? In { get; set; }
        public bool? NotIn { get; set; }
        public bool? Exists { get; set; }
    }

    public class DateFilter : Filter<DateTime>
    {
        public DateFilter(DateTime value) { Values = new DateTime[] { new DateTime(value.Ticks) }; }
        public DateFilter(DateTime[] values) { Values = values; }
        public DateFilter(DateTime value, string @operator)
        {
            Values = new DateTime[] { new DateTime(value.Ticks) };
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
        public DateFilter(DateTime[] values, string @operator)
        {
            Values = values;
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
    }

    public class IntFilter : Filter<int>
    {
        public IntFilter(int value) { Values = new int[] { value }; }
        public IntFilter(int[] values) { Values = values; }
        public IntFilter(int value, string @operator)
        {
            Values = new int[] { value };
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
        public IntFilter(int[] values, string @operator)
        {
            Values = values;
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
    }

    public class StringFilter : Filter<string>
    {
        public StringFilter(string value) { Values = new string[] { value }; }
        public StringFilter(string[] values) { Values = values; }
        public StringFilter(string value, string @operator)
        {
            Values = new string[] { value };
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
        public StringFilter(string[] values, string @operator)
        {
            Values = values;
            switch (@operator)
            {
                case "GreaterThan":
                    GreaterThan = true;
                    break;
                case "GreaterThanOrEquals":
                    GreaterThanOrEquals = true;
                    break;
                case "LessThan":
                    LessThan = true;
                    break;
                case "LessThanOrEquals":
                    LessThanOrEquals = true;
                    break;
                case "Not":
                    Not = true;
                    break;
                case "All":
                    All = true;
                    break;
                case "In":
                    In = true;
                    break;
                case "NotIn":
                    NotIn = true;
                    break;
                case "Exists":
                    Exists = true;
                    break;
                case "NotExists":
                    Exists = false;
                    break;
            }
        }
    }
}
