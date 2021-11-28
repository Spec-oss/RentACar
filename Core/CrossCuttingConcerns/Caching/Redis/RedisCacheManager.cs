using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private readonly RedisEndpoint _redisEndpoint;

        public RedisCacheManager()
        {
            _redisEndpoint = new RedisEndpoint("localhost", 6379);
        }

        public void Add(string key, object value, int duration)
        {
            RedisInvoker(x => x.Add(key, value, TimeSpan.FromMinutes(duration)));
        }

        public T Get<T>(string key)
        {
            var result = default(T);
            RedisInvoker(x => { result = x.Get<T>(key); });
            return result;
        }

        public object Get(string key)
        {
            var result = default(object);
            RedisInvoker(x => { result = x.Get<object>(key); });
            return result;
        }

        public bool IsAdd(string key)
        {
            var isAdded = false;
            RedisInvoker(x => isAdded = x.ContainsKey(key));
            return isAdded;
        }

        public void Remove(string key)
        {
            RedisInvoker(x => x.Remove(key));
        }

        public void RemoveByPattern(string pattern)
        {
            RedisInvoker(x => x.RemoveByPattern(pattern));
        }
        private void RedisInvoker(Action<RedisClient> redisAction)
        {
            using (var client = new RedisClient(_redisEndpoint))
            {
                redisAction.Invoke(client);
            }
        }
    }
}
