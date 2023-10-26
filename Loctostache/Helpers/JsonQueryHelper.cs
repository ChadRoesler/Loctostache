// Ignore Spelling: Loctostache

using Loctostache.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LoctostacheTests")]
namespace Loctostache.Helpers
{
    internal static class JsonQueryHelper
    {
        internal static Dictionary<string, string> QueriesObjectToDict(string varString, IEnumerable<string> jsonQueries)
        {
            var dict = new Dictionary<string, string>();
            var jobj = JObject.Parse(varString);
            foreach (var jsonQuery in jsonQueries)
            {
                var tokenString = jobj.SelectToken(jsonQuery);
                dict.AddOrUpdate(tokenString.ToObject<Dictionary<string, string>>());
            }
            return dict;
        }
    }
}
