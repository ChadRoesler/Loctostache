// Ignore Spelling: Loctostache

using System.Diagnostics.CodeAnalysis;


namespace LoctostacheTests.CustomComparer
{
    public class DictionaryComparer : IEqualityComparer<Dictionary<string, string>>
    {
        public bool Equals(Dictionary<string, string>? sourceDictionary, Dictionary<string, string>? targetDictionary)
        {
            if (null == sourceDictionary || null == targetDictionary)
            {
                return false;
            }
            if (sourceDictionary.Count != targetDictionary.Count)
            {
                return false;
            }
            if (sourceDictionary.Keys.Except(targetDictionary.Keys).Any())
            {
                return false;
            }
            if (targetDictionary.Keys.Except(sourceDictionary.Keys).Any())
            {
                return false;
            }
            foreach (KeyValuePair<string, string> pair in sourceDictionary)
            {
                string xValue = pair.Value;
                string yValue = targetDictionary[pair.Key];
                if (xValue.Length != yValue.Length)
                {
                    return false;
                }
                char[] xArray = xValue.ToArray();
                char[] yArray = yValue.ToArray();
                return xArray.SequenceEqual(yArray);
            }
            return true;
        }

        public int GetHashCode([DisallowNull] Dictionary<string, string> obj)
        {
            unchecked
            {
                int hash = 17;
                foreach (string key in obj.Keys)
                {
                    hash = hash * 23 + key.GetHashCode();
                }
                return hash;
            }
        }
    }
}
