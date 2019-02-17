using System;
using System.Collections.Generic;
using System.IO;

namespace RollCalls
{
    class LoadXmlData
    {
        /// <summary>
        /// We are going to use the searchPattern o grab all the XML files in the specified path, deserialize and return the data
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <returns></returns>
        public static IEnumerable<rollcallvote> GetRollcallvotes(string path, string searchPattern)
        {
            var rollCalls = new List<rollcallvote>();

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
                    rollCalls.Add(XmlSerialization.DeSerialize<rollcallvote>(content));
                }
            }
            return rollCalls;
        }
    }
}
