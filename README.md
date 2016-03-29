Sunlight Congress implements an IQueryable pattern for interacting with the web service. This means that you can use standard Lambda expressions inside of a where clause on each of the queryable objects.

Before we get started, you'll need to register for an API key with the Sunlight Foundation - 
http://sunlightfoundation.com/api/accounts/register/

First, create your client.
`Congress.Congress client = new Congress.Congress(Settings.SunlightCongressApiKey);`

The Congress object contains 12 queryable objects
- Amendments
- Bills
- Committees
- CongressionalDocuments
- Districts
- Documents
- FloorUpdates
- Hearings
- Legislators
- Nominations
- UpcomingBills
- Votes

Let's get all of the Senate votes that happened in 2016 -

`Vote[] a = client.Votes.Where(x => x.Year >= 2016 && x.Chamber == "senate").ToArray();`

Once you have this array, you can manipulate it as you could any other IEnumerable, with further Lambda queries on the dataset.

Here's a few more examples - 

// all bills

```Bill[] b = congress.Bills.ToArray();```

// all congressional votes where more than 30 Republicans voted Yea

```Vote[] c = congress.Votes.Where(xy => xy.Breakdown.Party.Republican.Yea > 30).ToArray();```

// all legislators in Beverly Hills

```Legislator[] q = congress.Legislators.Where(x => x.Zip == 90210).ToArray();```

// all bills containing the following phrase

```Bill[] e = congress.Bills.Where(x => x.Query == "To authorize the expansion of an existing hydroelectric project.").ToArray();```

Many more examples in the [Example.cs]() file
