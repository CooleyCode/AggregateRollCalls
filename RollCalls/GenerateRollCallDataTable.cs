using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RollCalls
{
    class GenerateRollCallDataTable
    {
        /// <summary>
        /// This is the main data restructuring logic. The goal of the project was to take a 
        /// few different roll calls and combine them into a single spreadsheet for data analysis.
        /// </summary>
        /// <param name="rollcallvotes"></param>
        /// <returns></returns>
        public static DataTable BuildTable(IEnumerable<rollcallvote> rollcallvotes)
        {
            var dt = new DataTable("Roll Call Votes");
            string[] legislatorIds = rollcallvotes
                .SelectMany(rc => rc.votedata)      // Each roll call has a collection of legislators and how they voted
                .Select(vd => vd.legislator.nameid) // Just need the id for reference
                .Distinct()                         // need distinct list since the legislators span multiple roll calls
                .ToArray();

            // The goal is a human readable spreadsheet, so we want more information on the legislators. Name, state, and party.
            dt.Columns.Add("Legislator Ids", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("State", typeof(string));
            dt.Columns.Add("Party", typeof(string));

            // fill out all the legislators data columns
            foreach (var legislatorId in legislatorIds)
            {
                var legislator = rollcallvotes.SelectMany(rc => rc.votedata).Select(vd => vd.legislator)
                    .FirstOrDefault(l => l.nameid == legislatorId);
                dt.Rows.Add(legislatorId, legislator.Value, legislator.state, legislator.party);
            }

            // Add each roll call as a new column
            foreach (var rollcallvote in rollcallvotes)
            {
                dt.Columns.Add(rollcallvote.RollCallId);
                for (int n = 0; n < legislatorIds.Count(); n++)
                {
                    var vote = rollcallvote.votedata.Where(vd => vd.legislator.nameid == legislatorIds[n]).FirstOrDefault();
                    dt.Rows[n][rollcallvote.RollCallId] = vote?.vote ?? string.Empty; 
                }
            }

            return dt;
        }
    }
}
