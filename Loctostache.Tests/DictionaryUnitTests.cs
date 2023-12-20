using Loctostache.ExtensionMethods;
using LoctostacheTests.CustomComparer;

namespace Loctostache.Tests
{
    public class DictionaryUnitTests
    {
        [Fact]
        public void ValidateDictionaryAdd()
        {
            var testDict = new Dictionary<string, string>() 
            { 
                { "key1", "value1" } 
            };
            var addDict = new Dictionary<string, string>() 
            { 
                { "key2", "value2" } 
            };
            var validDict = new Dictionary<string, string>() { { "key1", "value1" }, { "key2", "value2" } };
            testDict.AddOrUpdate(addDict);
            Assert.Equal(validDict, testDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateDictionaryUpdate()
        {
            var testDict = new Dictionary<string, string>()
            {
                { "key1", "value1" }
            };
            var addDict = new Dictionary<string, string>()
            {
                { "key1", "value2" }
            };
            var validDict = new Dictionary<string, string>() { { "key1", "value2" } };
            testDict.AddOrUpdate(addDict);
            Assert.Equal(validDict, testDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateDictionaryAddUpdate()
        {
            var testDict = new Dictionary<string, string>()
            {
                { "key1", "value1" }
            };
            var addDict = new Dictionary<string, string>()
            {
                { "key1", "value2" },
                { "key2", "value2" }
            };
            var validDict = new Dictionary<string, string>() { { "key1", "value2" }, { "key2", "value2" } };
            testDict.AddOrUpdate(addDict);
            Assert.Equal(validDict, testDict, new DictionaryComparer());
        }
    }
}
