using System;

namespace SocketAssets
{
    public class Asset
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public double Bid { get; set; }
        public double Ask { get; set; }

        public string FormattedString ( string dateFormat = "")
        {
            return $"{Name} {Time.ToString(dateFormat)} {Bid} {Ask}";
        }

        public override string ToString()
        {
            return FormattedString();
        }
    }
}
