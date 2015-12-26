using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Congress
{
    public class Congress
    {
        public Legislator[] Legislators { get; set; }
        public Bill[] Bills { get; set; }

        private Congress _congress = new Congress();
        public Congress GetLegislators()
        {
            this.Legislators = Legislator.Search(60657).ToArray();
            return this;
        }

        public Congress GetBills()
        {
            this.Bills = Bill.Search(new FilterBy.Bill() {
                SponsorId = new StringFilter(this.Legislators.Select(x => x.BioguideID).ToArray())
            }).ToArray();
            return this;
        }
    }
}
