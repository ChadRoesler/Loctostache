// Ignore Spelling: dict Loctostache

using Loctostache.Constants;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo(ResourceStrings.TestProjectName)]
namespace Loctostache.ExtensionMethods
{
    internal static class DictionaryExtensions
    {
        internal static void AddOrUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dict, Dictionary<TKey, TValue> dictionaryToAdd)
        {
            if (null == dict)
            {
                throw new ArgumentNullException(nameof(dict));
            }

            if (null == dictionaryToAdd)
            {
                throw new ArgumentNullException(nameof(dictionaryToAdd));
            }

            foreach (TKey? key in dictionaryToAdd.Keys)
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