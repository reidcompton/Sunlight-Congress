using System;
using System.Linq;
using System.Linq.Expressions;

namespace SunlightCongress
{
    public class Tests
    {
        public static void Examples()
        {

            Client congress = new Client("Your API Key Here");

            // Amendment All
            Amendment[] a = congress.Amendments.ToArray();

            // Amendment Filter
            Amendment[] b = congress.Amendments.Where(x =>
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


            //// Bill All
            Bill[] c = congress.Bills.ToArray();

            //// Bill Filter
            Bill[] d = congress.Bills.Where(x =>
                        x.BillId == "hr4193-114" &&
                        x.BillType == "hr" &&
                        x.Chamber == "house" &&
                        x.CommitteeIds == new string[] { "HSII", "HSII10", "HSII13" } &&
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

            //// Bill Search
            Bill[] e = congress.Bills.Where(x => x.Query == "To authorize the expansion of an existing hydroelectric project.").ToArray();

            //// Committee All
            Committee[] f = congress.Committees.ToArray();

            //// Committee Filter
            Committee[] g = congress.Committees.Where(x =>
                x.Chamber == "senate" &&
                x.CommitteeId == "SSGA19" &&
                x.ParentCommitteeId == "SSGA" &&
                x.SubCommittee == true
            ).ToArray();

            //// Congressional Document All
            CongressionalDocument[] h = congress.CongressionalDocuments.ToArray();

            //// District Locate by Zip
            District[] i = congress.Districts.Where(x => x.Zip == 60657).ToArray();

            //// District Locate By Lat/Long
            District[] j = congress.Districts.Where(x => x.Latitude == 42.96 && x.Longitude == -108.09).ToArray();

            //// Document All
            Document[] k = congress.Documents.ToArray();

            //// Floor Update All
            FloorUpdate[] l = congress.FloorUpdates.ToArray();

            //// Floor Update Filter
            FloorUpdate[] m = congress.FloorUpdates.Where(x =>
                x.Chamber == "senate" &&
                x.Congress == 114 &&
                x.LegislativeDay == new DateTime(2015, 12, 9)
            ).ToArray();

            //// Hearing All
            Hearing[] n = congress.Hearings.ToArray();

            //// Hearing Filter 
            Hearing[] o = congress.Hearings.Where(x =>
                x.CommitteeId == "HSSM" &&
                x.Chamber == "house" &&
                x.Dc == true &&
                x.Congress == 114 &&
                x.HearingType == "Hearing"
            ).ToArray();

            //// Legislator All
            Legislator[] p = congress.Legislators.ToArray();

            //// Legislator Locate by Zip
            Legislator[] q = congress.Legislators.Where(x => x.Zip == 60657).ToArray();

            //// Legislator Locate by Lat/Long
            Legislator[] r = congress.Legislators.Where(x => x.Latitude == 42.96 && x.Longitude == -108.09).ToArray();

            //// Legislator Filter
            Legislator[] s = congress.Legislators.Where(x =>
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

            //// Nomination All
            Nomination[] t = congress.Nominations.ToArray();

            // Nomination Filter
            Nomination[] u = congress.Nominations.Where(xy =>
                xy.NominationId == "PN951-02-114" &&
                xy.Congress == 114 &&
                xy.Number == "951-02" &&
                xy.Organization == "Foreign Service" &&
                xy.CommitteeIds.Contains("SSFR") &&
                xy.LastActionAt == new DateTime(2015, 11, 19)
            ).ToArray();

            //// Upcoming Bill All
            UpcomingBill[] v = congress.UpcomingBills.ToArray();

            //// Upcoming Bill Filter
            UpcomingBill[] w = congress.UpcomingBills.Where(xy =>
                xy.BillId == "s1177-114" &&
                xy.Chamber == "senate" &&
                xy.Congress == 114 &&
                xy.LegislativeDay == new DateTime(2015, 12, 9) &&
                xy.Range == "day" &&
                xy.SourceType == "senate_daily"
            ).ToArray();

            //// Vote All
            Vote[] xyz = congress.Votes.ToArray();

            //// Vote Filter
            Vote[] y = congress.Votes.Where(xy =>
                        xy.BillId == "hr2130-114" &&
                        xy.Chamber == "house" &&
                        xy.Congress == 114 &&
                        xy.Number == 684 &&
                        xy.Required == "1/2" &&
                        xy.RollId == "h684-2015" &&
                        xy.VoteType == "amendment"
                    ).ToArray();

            // Vote Filter by Breakdown
            Vote[] z = congress.Votes.Where(xy => xy.Breakdown.Party.Republican.Yea > 30).ToArray();
        }
    }
}
