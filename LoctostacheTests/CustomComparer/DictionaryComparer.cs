// Ignore Spelling: Loctostache

using System.Diagnostics.CodeAnalysis;


namespace LoctostacheTests.CustomComparer
{
    public class DictionaryComparer : IEqualityComparer<Dictionary<string, string>>
    {
        private readonly IEqualityComparer<string> _valueComparer;
        public DictionaryComparer(IEqualityComparer<string>? valueComparer = null)
        {
            _valueComparer = valueComparer ?? EqualityComparer<string>.Default;
        }
        public bool Equals(Dictionary<string, string>? x, Dictionary<string, string>? y)
        {
            if (x.Count != y.Count) return false;
            if (x.Keys.Except(y.Keys).Any()) return false;
            if (y.Keys.Except(x.Keys).Any()) return false;
            foreach (var pair in x)
            {
                var xValue = pair.Value;
                var yValue = y[pair.Key];
                if (xValue.Length != yValue.Length) return false;
                var xArray = xValue.ToArray();
                var yArray = yValue.ToArray();
                return xArray.SequenceEqual(yArray);
            }
            return true;
        }

        public int GetHashCode([DisallowNull] Dictionary<string, string> obj)
        {
            unchecked
            {
                var hash = 17;

                foreach (var key in obj.Keys)
                {
                    hash = hash * 23 + key.GetHashCode();
                }

                return hash;
            }
        }
    }
}
