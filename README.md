# Sunlight-Congress

##### There are 12 queryable classes 
[View examples](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Examples/Examples.cs)
- [Amendment](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Amendment.cs)
  - Methods
    - All()
    - Search([FilterBy.Amendment](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/AmendmentFilters.cs) args)
      - Accepts FilterBy.Amendment object as parameter. Populate the fields you want to filter on.
- [Bill](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Bill.cs)
  - Methods
    - All()
    - Search([FilterBy.Bill](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/BillFilters.cs) args)
      - Accepts FilterBy.Bill object as parameter. Populate the fields you want to filter on.
    - Search(string query, [FilterBy.Bill](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/BillFilters.cs) args)
      - Allows you to query by string, as well as passing along a FilterBy.Bill object to filter on.
- [Committee](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Committee.cs)
  - Methods
    - All()
    - Search([FilterBy.Committee](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/CommitteeFilters.cs) args)
      - Accepts FilterBy.Committee object as parameter. Populate the fields you want to filter on.
- [CongressionalDocument](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/CongressionalDocument.cs)
  - Methods
    - All()
- [District](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/District.cs)
  - Methods
    - Search(int zip)
      - Gets all Congressional District(s) inside zip code
    - Search(double longitude, double latitude)
      - Gets the Congressional District(s) located at a lat/long intersection
- [Document](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Document.cs)
  - Methods
    - All()
- [FloorUpdate](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/FloorUpdate.cs)
  - Methods
    - All()
    - Search([FilterBy.FloorUpdate](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/FloorUpdateFilters.cs) args)
      - Accepts FilterBy.FloorUpdate object as parameter. Populate the fields you want to filter on.
- [Hearing](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Hearing.cs)
  - Methods
    - All()
    - Search([FilterBy.Hearing](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/HearingFilters.cs) args)
      - Accepts FilterBy.Hearing object as parameter. Populate the fields you want to filter on.
- [Legislator](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Legislator.cs)
  - Methods
    - All()
    - Search(int zip)
      - Gets the Legislator(s) who represent the zip code
    - Search(double longitude, double latitude)
      - Gets  the Legislator(s) who represent the lat/long intersection
    - Search([FilterBy.Legislator](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/LegislatorFilters.cs) args)
      - Accepts FilterBy.Legislator object as parameter. Populate the fields you want to filter on.
- [Nomination](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Nomination.cs)
  - Methods
    - All()
    - Search([FilterBy.Nomination](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/NominationFilters.cs) args)
      - Accepts FilterBy.Nomination object as parameter. Populate the fields you want to filter on.
- [UpcomingBill](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/UpcomingBill.cs)
  - Methods
    - All()
    - Search([FilterBy.UpcomingBill](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/UpcomingBillFilters.cs) args)
      - Accepts FilterBy.UpcomingBill object as parameter. Populate the fields you want to filter on.
- [Vote](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Classes/Vote.cs)
  - Methods
    - All()
    - Search([FilterBy.Vote](https://github.com/reidcompton/Sunlight-Congress/blob/master/src/SunlightCongress/Filters/VoteFilter.cs) args)
      - Accepts FilterBy.Vote object as parameter. Populate the fields you want to filter on.

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
