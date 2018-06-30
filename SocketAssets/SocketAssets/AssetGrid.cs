﻿using SocketAssets.Formatter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets
{
    class AssetGrid : List<Asset>
    {
        private AssetFormatter formatter = new AssetFormatter();
        public void AddOrUpdateItems(string item)
        {
            var assets = formatter.FromString(item);
            foreach(var asset in assets)
            {
               bool found = false;
               foreach(var originalAsset in this)
                {
                    if(originalAsset.Name == asset.Name)
                    {
                        originalAsset.Time = asset.Time;
                        originalAsset.Bid = asset.Bid;
                        originalAsset.Ask = asset.Ask;

                        found = true;
                        break;
                    }
                }
               if(!found)
                {
                    this.Add(asset);
                }
            }
        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Name\tTime\tBid\tAsk");
            foreach(var asset in this)
            {
                result.Append(asset + "\n");
            }
            return result.ToString();
        }
    }
}