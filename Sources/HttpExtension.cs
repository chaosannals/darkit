using System.IO;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Darkit
{
    public static class HttpExtension
    {
        public static T JsonAs<T>(this Stream body) where T : class
        {
            using (var reader = new StreamReader(body, Encoding.UTF8))
            {
                var data = reader.ReadToEnd();
                return JsonSerializer.Deserialize(data, typeof(T)) as T;
            }
        }

        public static int AsInt(this IQueryCollection query, string key)
        {
            return int.Parse(query[key]);
        }

        public static int AsInt(this IQueryCollection query, string key, int value)
        {
            if (query.ContainsKey(key))
            {
                return int.Parse(query[key]);
            }
            return value;
        }
    }
}
