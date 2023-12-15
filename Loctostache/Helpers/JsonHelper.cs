// Ignore Spelling: Loctostache

using Loctostache.Constants;
using Loctostache.ExtensionMethods;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(ResourceStrings.TestProjectName)]
namespace Loctostache.Helpers
{
    internal static class JsonHelper
    {
        internal static Dictionary<string, string> QueriesObjectToDict(string varString, IEnumerable<string> jsonQueries)
        {
            Dictionary<string, string> dict = new();
            JObject jobj = JObject.Parse(varString);
            foreach (string jsonQuery in jsonQueries)
            {
                JToken tokenString = jobj.SelectToken(jsonQuery);
                dict.AddOrUpdate(tokenString.ToObject<Dictionary<string, string>>());
            }
            return dict;
        }

        internal static Dictionary<string, string> GetJsonRootDictionary(string varString)
        {
            Dictionary<string, string> dict = new();
            JObject jobjroot = JObject.Parse(varString);
            List<JProperty> rootObjects = jobjroot.Descendants().OfType<JProperty>().Where(x => x.Value.Type == JTokenType.Object || x.Value.Type == JTokenType.Array).ToList();
            foreach (JProperty? rootObject in rootObjects)
            {
                rootObject.Remove();
            }
            Dictionary<string, string> rootStringDict = (Dictionary<string, string>)jobjroot.ToObject(typeof(Dictionary<string, string>));
            if (rootStringDict != null && rootStringDict.Count > 0)
            {
                dict.AddOrUpdate(rootStringDict);
            }
            return dict;
        }
    }
}
