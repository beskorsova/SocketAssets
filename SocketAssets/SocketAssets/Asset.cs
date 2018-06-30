using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets
{
    public class Asset
    {
       public string Name { get; set; }
       public string Time { get; set; }
       public string Bid { get; set; }
       public string Ask { get; set; }

        public override string ToString()
        {
            return $"{Name} {Time} {Bid} {Ask}";
        }
    }
}
