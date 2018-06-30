using System;
using System.Collections.Generic;

namespace SocketAssets.Formatter
{
    class AssetFormatter : IFormatter<Asset>
    {
        private readonly string dateFormat = "dd/MM/yyyy-HH:mm:ss.fff";

        public List<Asset> FromString(string result)
        {
            List<Asset> asserts = new List<Asset>();
            
            string[] lineSeparators = new string[] { "\r\n" };
            char valueSplitter = ' ';
            string[] lines = result.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] values = line.Split(valueSplitter);
                asserts.Add(new Asset(values, dateFormat));
            }
            return asserts;
        }
    }
}
