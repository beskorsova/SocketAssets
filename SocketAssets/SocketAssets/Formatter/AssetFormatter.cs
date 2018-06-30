using System;
using System.Collections.Generic;

namespace SocketAssets.Formatter
{
    class AssetFormatter: IFormatter<Asset>
    {
        public List<Asset> FromString(string result)
        {
            List<Asset> asserts = new List<Asset>();
            
            string[] lineSeparators = new string[] { "\r\n" };
            char valueSplitter = ' ';
            string[] lines = result.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach(var line in lines)
            {
                string[] values = line.Split(valueSplitter);
                asserts.Add(new Asset() { Name = values[0], Time = values[1], Bid = values[2], Ask = values[3]  });
            }
            return asserts;
        }
    }
}
