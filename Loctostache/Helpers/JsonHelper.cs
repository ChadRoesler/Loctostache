// Ignore Spelling: Loctostache

using Loctostache.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LoctostacheTests")]
namespace Loctostache.Helpers
{
    internal static class JsonHelper
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

        internal static Dictionary<string, string> GetJsonRootDictionary(string varString)
        {
            var dict = new Dictionary<string, string>();
            var jobjroot = JObject.Parse(varString);
            var rootObjects = jobjroot.Descendants().OfType<JProperty>().Where(x => x.Value.Type == JTokenType.Object || x.Value.Type == JTokenType.Array).ToList();
            foreach (var rootObject in rootObjects)
            {
                rootObject.Remove();
            }
            var rootStringDict = (Dictionary<string, string>)jobjroot.ToObject(typeof(Dictionary<string, string>));
            if (rootStringDict != null && rootStringDict.Count > 0)
            {
                dict.AddOrUpdate(rootStringDict);
            }
            return dict;
        }
    }
}
