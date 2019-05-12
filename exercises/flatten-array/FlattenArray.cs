using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        foreach (var item in input)
        {
            if (item != null)
            {
                if (item is IEnumerable)
                {
                    foreach(var child in Flatten((IEnumerable)item))
                    {
                        yield return child;
                    }
                }
                else
                {
                    yield return item;
                }
            }
        }
    }
}