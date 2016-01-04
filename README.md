# Sunlight-Congress

##### There are 12 queryable classes 
[View examples](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Examples/Examples.cs)
- Amendment
  - Methods
    - `All()`
    - `Search(FilterBy.Amendment args)`
      - Accepts FilterBy.Amendment object as parameter. Populate the fields you want to filter on.
- Bill
  - Methods
    - `All()`
    - `Search(FilterBy.Bill args)`
      - Accepts FilterBy.Bill object as parameter. Populate the fields you want to filter on.
    - `Search(string query, FilterBy.Bill args)`
      - Allows you to query by string, as well as passing along a FilterBy.Bill object to filter on.
- Committee
  - Methods
    - `All()`
    - `Search(FilterBy.Committee args)`
      - Accepts FilterBy.Committee object as parameter. Populate the fields you want to filter on.
- CongressionalDocument
  - Methods
    - `All()`
- District
  - Methods
    - `Search(int zip)`
      - Gets all Congressional District(s) inside zip code
    - `Search(double longitude, double latitude)`
      - Gets the Congressional District(s) located at a lat/long intersection
- Document
  - Methods
    - `All()`
- FloorUpdate
  - Methods
    - `All()`
    - `Search(FilterBy.FloorUpdate args)`
      - Accepts FilterBy.FloorUpdate object as parameter. Populate the fields you want to filter on.
- Hearing
  - Methods
    - All()
    - Search(FilterBy.Hearing args)
      - Accepts FilterBy.Hearing object as parameter. Populate the fields you want to filter on.
- Legislator
  - Methods
    - `All()`
    - `Search(int zip)`
      - Gets the Legislator(s) who represent the zip code
    - `Search(double longitude, double latitude)`
      - Gets  the Legislator(s) who represent the lat/long intersection
    - `Search(FilterBy.Legislator args)`
      - Accepts FilterBy.Legislator object as parameter. Populate the fields you want to filter on.
- Nomination
  - Methods
    - `All()`
    - `Search(FilterBy.Nomination args)`
      - Accepts FilterBy.Nomination object as parameter. Populate the fields you want to filter on.
- UpcomingBill
  - Methods
    - `All()`
    - `Search(FilterBy.UpcomingBill args)`
      - Accepts FilterBy.UpcomingBill object as parameter. Populate the fields you want to filter on.
- Vote
  - Methods
    - `All()`
    - `Search(FilterBy.UpcomingBill args)`
      - Accepts FilterBy.UpcomingBill object as parameter. Populate the fields you want to filter on.

##### Namespaces
  - Congress
    - This namespace holds all of the classes that receive data from the API
  - Congress.FilterBy
    - This namespace holds all of the classes that send data to the API. These are used exclusively in `Search()` methods


##### Filters
  - API fields that are of type int, string, or DateTime are stored as `IntFilter`, `StringFilter` and `DateFilter` respectively in the Congress.FilterBy namespace. For requests, you will use these, and it will allow you to optionally pass in Operators to refine your search.
- IntFilter(int, Operator)
- StringFilter(string, Operator)
- DateFilter(DateTime, Operator)

##### Operators
- GreaterThan
- GreaterThanOrEquals
- LessThan
- LessThanOrEquals
- Not
- All
- In
- NotIn
- Exists
- NotExists
