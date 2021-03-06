﻿using SocketAssets.Formatter;
using System.Collections.Generic;
using System.Text;

namespace SocketAssets
{
    class AssetGrid : List<Asset>, IGrid, ISocketData
    {
        private AssetFormatter formatter = new AssetFormatter();

        public int dataSize = 1024;
        
        public int DataSize => dataSize;

        public void AddOrUpdateItems(string item)
        {
            var assets = formatter.FromString(item);
            foreach (var asset in assets)
            {
                bool found = false;
                foreach (var originalAsset in this)
                {
                    if (originalAsset.Name == asset.Name)
                    {
                        originalAsset.Time = asset.Time;
                        originalAsset.Bid = asset.Bid;
                        originalAsset.Ask = asset.Ask;

                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    this.Add(asset);
                }
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Name\t\tTime\t\tBid\tAsk\n");
            foreach (var asset in this)
            {
                result.Append(asset.FormattedString(formatter.DateFormat) + "\n");
            }
            return result.ToString();
        }
    }
}
