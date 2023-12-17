using System;
using System.Collections.Generic;

namespace Lab_6_task_3
{
    public class FunctionCache<TKey, TResult>
    {
        private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

        public delegate TResult FuncDelegate(TKey key);

        private class CacheItem
        {
            public TResult Result { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        public TResult GetOrAdd(TKey key, FuncDelegate function, TimeSpan cacheDuration)
        {
            if (cache.TryGetValue(key, out var cacheItem) && DateTime.Now < cacheItem.ExpirationTime)
            {
                return cacheItem.Result; 
            }
            else
            {
                TResult result = function(key);
                cache[key] = new CacheItem { Result = result, ExpirationTime = DateTime.Now.Add(cacheDuration) };
                return result;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Минко Ярослав");

            FunctionCache<int, string> stringCache = new FunctionCache<int, string>();

            FunctionCache<int, string>.FuncDelegate function = key => key.ToString();

            string result1 = stringCache.GetOrAdd(5, function, TimeSpan.FromSeconds(5));
            Console.WriteLine(result1); 

            System.Threading.Thread.Sleep(3000);

            string result2 = stringCache.GetOrAdd(5, function, TimeSpan.FromSeconds(5));
            Console.WriteLine(result2); 

            System.Threading.Thread.Sleep(3000);

            string result3 = stringCache.GetOrAdd(5, function, TimeSpan.FromSeconds(5));
            Console.WriteLine(result3); 
        }
    }

}