using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets
{
    class Program
    {
        static void Main(string[] args)
        {
            AssetGrid grid = new AssetGrid();
            ConnectionService.Connect("79.125.80.209", 4092);
            ConnectionService.Read(grid);
        }
    }
}
