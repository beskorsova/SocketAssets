using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets
{
    class Program
    {

        static AssetGrid grid = new AssetGrid();

        static void Main(string[] args)
        {
            ConnectionService.Connect("79.125.80.209", 4092);
            ConnectionService.Read(grid.DataSize, ShowGrid);
        }

        static void ShowGrid(string result)
        {
            grid.AddOrUpdateItems(result);
            Console.Clear();
            Console.WriteLine(grid);
        }
    }
}
