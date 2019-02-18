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
