using System;
using System.Collections.Generic;
using System.Globalization;

namespace SocketAssets.Formatter
{
    class AssetFormatter : IFormatter<Asset>
    {
        private readonly string[] lineSeparators = new string[] { "\r\n" };

        private readonly char valueSplitter = ' ';

        public readonly string DateFormat = "dd/MM/yyyy-HH:mm:ss.fff";

        public IEnumerable<Asset> FromString(string result)
        {
            string[] lines = result.Split(lineSeparators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                string[] values = line.Split(valueSplitter);
                yield return new Asset()
                {
                    Name = values[0],
                    Time = DateTime.ParseExact(values[1], DateFormat, CultureInfo.InvariantCulture),
                    Bid = double.Parse(values[2]),
                    Ask = double.Parse(values[3])
                };
            }
        }
    }
}
