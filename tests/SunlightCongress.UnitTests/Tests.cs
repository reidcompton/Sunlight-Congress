using Xunit;
using SunlightCongress;
using System.Linq;
using System;

namespace UnitTests
{
    public class Tests
    {
        // Amendment All
        [Fact]
        public void AmendmentsAll()
        {
            Client client = new Client("Your API Key");
            Amendment[] result = client.Amendments.ToArray();
            Assert.True(result.Length > 0);
        }

        [Fact]
        public void AmendmentsFilter() {
            Client client = new Client("Your API Key");
            // Amendment Filter
            Amendment[] result = client.Amendments.Where(x =>
                        x.PerPage == 3 &&
                        x.AmendmentId == "samdt2921-114" &&
                        x.Congress == 114 &&
                        x.Number == 2921 &&
                        x.Chamber == "senate" &&
                        x.AmendmentType == "samdt" &&
                        x.IntroducedOn > new DateTime(2015, 12, 7) &&
                        x.SponsorType == "person" &&
                        x.SponsorId == "C001070" &&
                        x.AmendsBillId == "sres207-114"
                    ).ToArray();
            Assert.True(result.Length > 0);

        }

        // Bill All
        [Fact]
        public void BillAll()
        {
            Client client = new Client("Your API Key");
            Bill[] result = client.Bills.ToArray();
            Assert.True(result.Length > 0);
        }

        // Bill Filter
        [Fact]
        public void BillFilter()
        {
            Client client = new Client("Your API Key");
            Bill[] result = client.Bills.Where(x =>
                    x.BillId == "hr4193-114" &&
                    x.BillType == "hr" &&
                    x.Chamber == "house" &&
                    x.CommitteeIds == new string[] { "HSII" } &&
                    x.Congress == 114 &&
                    x.CoSponsorsCount == 0 &&
                    x.History.Active == false &&
                    x.History.AwaitingSignature == false &&
                    x.History.Enacted == false &&
                    x.History.Vetoed == false &&
                    x.IntroducedOn == new DateTime(2015, 12, 8) &&
                    x.Number == 4193 &&
                    x.Sponsor != null &&
                    x.SponsorId == "Y000033"
                ).ToArray();
            Assert.True(result.Length > 0);
        }

        //// Bill Search
        [Fact]
        public void BillSearch()
        {
            Client client = new Client("Your API Key");
            Bill[] result = client.Bills.Where(x => x.Query == "To authorize the expansion of an existing hydroelectric project.").ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Committee All
        [Fact]
        public void CommitteeAll()
        {
            Client client = new Client("Your API Key");
            Committee[] result = client.Committees.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Committee Filter
        [Fact]
        public void CommitteeFilter()
        {
            Client client = new Client("Your API Key");
            Committee[] result = client.Committees.Where(x =>
            x.Chamber == "senate" &&
            x.CommitteeId == "SSGA19" &&
            x.ParentCommitteeId == "SSGA" &&
            x.SubCommittee == true
        ).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Congressional Document All
        [Fact]
        public void CongressionalDocumentAll()
        {
            Client client = new Client("Your API Key");
            CongressionalDocument[] result = client.CongressionalDocuments.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// District Locate by Zip
        [Fact]
        public void DistrictLocateZip()
        {
            Client client = new Client("Your API Key");
            District[] result = client.Districts.Where(x => x.Zip == 60657).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// District Locate By Lat/Long
        [Fact]
        public void DistrictLocateLatLong()
        {
            Client client = new Client("Your API Key");
            District[] result = client.Districts.Where(x => x.Latitude == 42.96 && x.Longitude == -108.09).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Document All
        [Fact]
        public void DocumentAll()
        {
            Client client = new Client("Your API Key");
            Document[] result = client.Documents.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Floor Update All
        [Fact]
        public void FloorUpdateAll()
        {
            Client client = new Client("Your API Key");
            FloorUpdate[] result = client.FloorUpdates.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Floor Update Filter
        [Fact]
        public void FloorUpdateFilter()
        {
            Client client = new Client("Your API Key");
            FloorUpdate[] result = client.FloorUpdates.Where(x =>
                x.Chamber == "senate" &&
                x.Congress == 114 &&
                x.LegislativeDay == new DateTime(2015, 12, 9)
            ).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Hearing All
        [Fact]
        public void HearingAll()
        {
            Client client = new Client("Your API Key");
            Hearing[] result = client.Hearings.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Hearing Filter 
        [Fact]
        public void HearingFilter()
        {
            Client client = new Client("Your API Key");
            Hearing[] result = client.Hearings.Where(x =>
                x.CommitteeId == "HSSM" &&
                x.Chamber == "house" &&
                x.Dc == true &&
                x.Congress == 114 &&
                x.HearingType == "Hearing"
            ).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Legislator All
        [Fact]
        public void LegislatorAll()
        {
            Client client = new Client("Your API Key");
            Legislator[] result = client.Legislators.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Legislator Locate by Zip
        [Fact]
        public void LegislatorLocateZip()
        {
            Client client = new Client("Your API Key");
            Legislator[] result = client.Legislators.Where(x => x.Zip == 60657).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Legislator Locate by Lat/Long
        [Fact]
        public void LegislatorLocateLatLong()
        {
            Client client = new Client("Your API Key");
            Legislator[] result = client.Legislators.Where(x => x.Latitude == 42.96 && x.Longitude == -108.09).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Legislator Filter
        [Fact]
        public void LegislatorFilter()
        {
            Client client = new Client("Your API Key");
            Legislator[] result = client.Legislators.Where(x =>
                x.BioguideID == "L000585" &&
                x.Birthday > new DateTime(1968, 7, 4) &&
                x.Chamber == "house" &&
                x.CrpId == "N00037031" &&
                x.District == 18 &&
                x.FecIds == new string[] { "H6IL18088" } &&
                x.FirstName == "Darin" &&
                x.Gender == "M" &&
                x.GovTrackId == "412674" &&
                x.InOffice == true &&
                x.LastName == "LaHood" &&
                x.Party == "R" &&
                x.State == "IL" &&
                x.VoteSmartId == 128760
            ).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Nomination All
        [Fact]
        public void NominationAll()
        {
            Client client = new Client("Your API Key");
            Nomination[] result = client.Nominations.ToArray();
            Assert.True(result.Length > 0);
        }


        // Nomination Filter
        [Fact]
        public void NominationFilter()
        {
            Client client = new Client("Your API Key");
            Nomination[] result = client.Nominations.Where(x =>
                x.NominationId == "PN951-02-114" &&
                x.Congress == 114 &&
                x.Number == "951-02" &&
                x.Organization == "Foreign Service" &&
                x.CommitteeIds.Contains("SSFR") &&
                x.LastActionAt == new DateTime(2015, 11, 19)
            ).ToArray();
            Assert.True(result.Length > 0);
        }

        //// Upcoming Bill All
        [Fact]
        public void UpcomingBillAll()
        {
            Client client = new Client("Your API Key");
            UpcomingBill[] result = client.UpcomingBills.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Upcoming Bill Filter
        [Fact]
        public void UpcomingBillFilter()
        {
            Client client = new Client("Your API Key");
            UpcomingBill[] result = client.UpcomingBills.Where(x =>
                x.BillId == "s1177-114" &&
                x.Chamber == "senate" &&
                x.Congress == 114 &&
                x.LegislativeDay == new DateTime(2015, 12, 9) &&
                x.Range == "day" &&
                x.SourceType == "senate_daily"
            ).ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Vote All
        [Fact]
        public void VoteAll()
        {
            Client client = new Client("Your API Key");
            Vote[] result = client.Votes.ToArray();
            Assert.True(result.Length > 0);
        }
        

        //// Vote Filter
        [Fact]
        public void VoteFilter()
        {
            Client client = new Client("Your API Key");
            Vote[] result = client.Votes.Where(x =>
                    x.BillId == "hr2130-114" &&
                    x.Chamber == "house" &&
                    x.Congress == 114 &&
                    x.Number == 684 &&
                    x.Required == "1/2" &&
                    x.RollId == "h684-2015" &&
                    x.VoteType == "amendment"
                ).ToArray();
            Assert.True(result.Length > 0);
        }
        
        // Vote Filter by Breakdown
        [Fact]
        public void VoteFilterBreakdown()
        {
            Client client = new Client("Your API Key");
            Vote[] result = client.Votes.Where(x => x.Breakdown.Party.Republican.Yea > 30).ToArray();
            Assert.True(result.Length > 0);
        }
    }
}
