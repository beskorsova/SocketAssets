﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketAssets.Formatter
{
    interface IFormatter<T>
    {
       List<T> FromString(string result);
    }
}