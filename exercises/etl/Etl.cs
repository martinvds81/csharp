using System;
using System.Collections.Generic;
using System.Linq;
public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        return old
              .SelectMany(o => o.Value.Select(p => new { key = p, value = o.Key }))
              .ToDictionary(k => k.key.ToLower(), v => v.value);

    }
}