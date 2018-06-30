using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets
{
    public class Asset
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }

        private string dateFormat;

        public Asset(string[] values, string dateFormat)
        {
            this.dateFormat = dateFormat;

            Name = values[0];
            Time = DateTime.ParseExact(values[1], dateFormat, CultureInfo.InvariantCulture);
            Bid = double.Parse(values[2]);
            Ask = double.Parse(values[3]);
        }

        public override string ToString()
        {
            return $"{Name} {Time.ToString(dateFormat)} {Bid} {Ask}";
        }
    }
}
