using BillSponsors.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillSponsors
{
    class Program
    {
        /// <summary>
        /// Load billStatus into memory then export a list of sponsors and cosponsors that have not withdrawn their support.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var billStatuses = LoadBillStatuses.GetBillStatuses(Settings.Default.XmlPath, Settings.Default.searchPattern);
            foreach ( var billStatus in billStatuses)
            {
                //Console.WriteLine($"{billStatus.bill.billNumber} - {billStatus.bill.congress}");
                //foreach (var sponsor in billStatus.bill.sponsors)
                //    Console.WriteLine($" Sponsor: {sponsor.bioguideId}: {sponsor.lastName}");
                //foreach (var cosponsor in billStatus.bill.cosponsors.Where(c => c.sponsorshipWithdrawnDate == string.Empty))
                //    Console.WriteLine($"  Cosponsor {cosponsor.bioguideId}: {cosponsor.lastName}\t{cosponsor.sponsorshipDate.ToShortDateString()}");
                
                // TODO - export to a file and not to the screen, at least support the option.
                foreach (var sponsor in billStatus.bill.sponsors)
                    Console.WriteLine($"{billStatus.bill.billNumber}\t{billStatus.bill.congress}\tSponsor\t{sponsor.bioguideId}\t{sponsor.lastName}");
                foreach (var cosponsor in billStatus.bill.cosponsors.Where(c => c.sponsorshipWithdrawnDate == string.Empty))
                    Console.WriteLine($"{billStatus.bill.billNumber}\t{billStatus.bill.congress}\tCosponsor\t{cosponsor.bioguideId}\t{cosponsor.lastName}\t{cosponsor.sponsorshipDate.ToShortDateString()}");
            }
        }
    }
}
