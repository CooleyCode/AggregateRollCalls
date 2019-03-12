using RollCalls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BillSponsors
{
    class LoadBillStatuses
    {
        /// <summary>
        /// Iterate across all files matching pattern in specified path and produce a collection 
        /// of billStatus objects.
        /// </summary>
        /// <param name="path">Path to directory caontaining XML files</param>
        /// <param name="searchPattern">Search pattern for file names in the path</param>
        /// <returns></returns>
        public static IEnumerable<billStatus> GetBillStatuses(string path, string searchPattern)
        {
            var rollCalls = new List<billStatus>();

            string[] files = Directory.GetFiles(path, searchPattern);
            foreach (var file in files)
            {
                string content = File.ReadAllText(file);
                if (content.Length == 0)
                {
                    Console.WriteLine($"File: {file} was skipped because it was empty");
                }
                else
                {
                    try
                    {
                        rollCalls.Add(XmlSerialization.DeSerialize<billStatus>(RemoveProblematicXml(content)));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"File: {file} had a formatting exception");
                    }
                }
            }
            return rollCalls;
        }

        /// <summary>
        /// The DeSerialize process was failing when the dublinCore XML data was left in the file.
        /// The data contained in that node was not required for this analysis.
        /// </summary>
        /// <param name="text">XML text</param>
        /// <returns></returns>
        private static string RemoveProblematicXml(string text)
        {
            var pre = text.IndexOf("dubliCore");
            var rx = new Regex(@"<dublinCore.*dublinCore>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var result = rx.Replace(text, string.Empty);
            var post = result.IndexOf("dublinCore");
            if (pre != post)
            {
                //Console.WriteLine("Dublincore removed");
            }
            if (text != result)
            {
                //Console.WriteLine("text updated");
            }
            return result;
        }
    }
}
