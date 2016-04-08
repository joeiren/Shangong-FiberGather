using System.Collections.Generic;

namespace Corp.ShanGong.FiberInstrument.Common
{
    public static class ObjectInitializeExtension
    {
        public static void Init<T>(this IList<T> collection, int size) where T : new()
        {
            if (collection == null)
            {
                return;
            }
            for (var i = 0; i < collection.Count; i++)
            {
                collection[i] = new T();
            }
        }
    }
}