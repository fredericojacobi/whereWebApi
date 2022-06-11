using System.Collections;

namespace Extensions;

public static class Extensions
{
    public static bool IsEmpty(this ICollection collection) => collection.Count == 0;

    public static bool IsEmpty<T>(this ICollection<T> collection) => !collection.Any();
}