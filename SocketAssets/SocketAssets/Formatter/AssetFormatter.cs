using System;
using System.Collections.Generic;

namespace SocketAssets.Formatter
{
    class AssetFormatter : IFormatter<Asset>
    {
        private readonly string dateFormat = "dd/MM/yyyy-HH:mm:ss.fff";

        private readonly string[] lineSeparators = new string[] { "\r\n" };

        private readonly char valueSplitter = ' ';

        public List<Asset> FromString(string result)
        {
            List<Asset> asserts = new List<Asset>();
            
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
