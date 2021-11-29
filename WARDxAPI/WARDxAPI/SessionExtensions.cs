using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WARDxAPI
{
    public static class SessionExtensions
    {
        /// <summary>
        /// The generic object type will be serialized and stored as session data
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void Set<T>(this ISession session, string key, T value)
        {
            // set object key and data
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// The generic object type will be retrieved from the session and deserialized
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T Get<T>(this ISession session, string key)
        {
            // get object data using key
            var value = session.GetString(key);
            // return object as specified type
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
