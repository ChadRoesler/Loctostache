// Ignore Spelling: dict Loctostache

using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LoctostacheTests")]
namespace Loctostache.ExtensionMethods
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, Dictionary<TKey, TValue> dictionaryToAdd)
        {
            if (dict is null)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (dictionaryToAdd is null)
            {
                throw new ArgumentNullException(nameof(dictionaryToAdd));
            }

            foreach (var key in dictionaryToAdd.Keys)
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = dictionaryToAdd[key];
                }
                else
                {
                    dict.Add(key, dictionaryToAdd[key]);
                }
            }
        }
    }
}