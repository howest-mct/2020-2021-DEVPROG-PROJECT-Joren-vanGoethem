using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace EindProject.Models
{
    // Class for caching pages into memory
    public class CacheProvider
    {
        List<string> keys = new List<string>();
        private IMemoryCache cache;

        public CacheProvider()
        {
            this.cache = new MemoryCache(new MemoryCacheOptions { });
        }

        // get cached page from memory using the key
        internal T Get<T>(string key)
        {
            if (this.cache.TryGetValue(key, out T value))
                return value;
            else
                return default(T);
        }

        // remove specific page from memory using the key
        internal void Remove(string key)
        {
            this.keys.Remove(key);
            this.cache.Remove(key);
        }

        // clear entire cache
        internal void RemoveAll()
        {
            foreach (string item in this.keys)
            {
                this.cache.Remove(item);
            }
            this.keys.Clear();
        }

        // adds a page into cache memory with a string key
        internal void Set<T>(string key, T value)
        {
            DateTimeOffset expiry = DateTimeOffset.Now.AddHours(2);

            this.keys.Add(key);
            this.cache.Set(key, value, expiry);
        }
    }
}