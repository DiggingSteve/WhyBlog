using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.Infrastructure.Core
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }

        public static T Get<T>(this ISession session, string key)
        {
            bool value = session.TryGetValue(key, out byte[] a);
            return value ? JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(a)) : default(T);

        }
    }
}
