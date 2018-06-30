using System;

namespace SocketAssets
{
    class Program
    {

        static AssetGrid grid = new AssetGrid();

        static void Main(string[] args)
        {
            ConnectionService service = new ConnectionService();
            service.Connect("79.125.80.209", 4092);
            service.Read(grid.DataSize, ShowGrid);
        }

        static void ShowGrid(string result)
        {
            grid.AddOrUpdateItems(result);
            Console.Clear();
            Console.WriteLine(grid);
        }
    }
}
