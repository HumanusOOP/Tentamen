using System;
using System.Collections.Generic;

namespace Dijkstra
{
    public interface IGraph<T> : IEnumerable<char>
    {
        From<T> From(char from);
        Func<T, bool> IsConnected { get; }
        int NodeCount { get; }
    }
}
