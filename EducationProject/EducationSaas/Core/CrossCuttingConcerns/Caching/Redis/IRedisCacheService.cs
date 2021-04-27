using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public interface IRedisCacheService
    {
        void Set(string key, string value);
        void Set<T>(string key, T value) where T : class;
        Task SetAsync(string key, object value);
        void Set(string key, object value, TimeSpan expiration);
        Task SetAsync(string key, object value, TimeSpan expiration);
        T Get<T>(string key) where T : class;
        string Get(string key);
        void Remove(string key);
        bool IsAdd(string key);
        Task<string> GetAsync<T>(string key) where T : class;
        //Task<T> GetAsync<T>(string key) where T : class;
    }
}
