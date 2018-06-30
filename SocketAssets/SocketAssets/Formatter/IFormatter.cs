using System.Collections.Generic;

namespace SocketAssets.Formatter
{
    interface IFormatter<T>
    {
       IEnumerable<T> FromString(string result);
    }
}
