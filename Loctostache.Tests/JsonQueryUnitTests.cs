// Ignore Spelling: Loctostache Json

using Loctostache.Helpers;
using LoctostacheTests.CustomComparer;

namespace LoctostacheTests
{
    public class JsonUnitTests
    {
        [Fact]
        public void ValidateJSonQuery()
        {
            string testVarString = @"{
	""TestObj1"":{
		""Var1_1"":""Output1_1"",
		""Var1_2"":""Output1_2"",
		""Var1_3"":""Output1_3""
	},
	""TestObj2"":{
		""Var2_1"":""Output2_1"",
		""Var2_2"":""Output2_2"",
		""Var2_3"":""Output2_3""
	}
}";
            string[] testJsonQuery = new string[1] { "TestObj1" };
            Dictionary<string, string> validDict = new() {
                { "Var1_1", "Output1_1" },
                { "Var1_2", "Output1_2" },
                { "Var1_3", "Output1_3" }
            };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateJsonQueryWithRoot()
        {
            string testVarString = @"{
	""Var1_1"":""Output1_1"",
	""Var1_2"":""Output1_2"",
	""Var1_3"":""Output1_3"",
	""TestObj2"":{
		""Var2_1"":""Output2_1"",
		""Var2_2"":""Output2_2"",
		""Var2_3"":""Output2_3""
	},
    ""TestObj3"":{
		""Var3_1"":""Output3_1"",
		""Var3_2"":""Output3_2"",
		""Var3_3"":""Output3_3""
	}
}";
            string[] testJsonQuery = new string[1] { "TestObj3" };
            Dictionary<string, string> validDict = new() {
                { "Var3_1", "Output3_1" },
                { "Var3_2", "Output3_2" },
                { "Var3_3", "Output3_3" }
            };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateJsonRootExtraction()
        {
            string testVarString = @"{
	""Var1_1"":""Output1_1"",
	""Var1_2"":""Output1_2"",
	""Var1_3"":""Output1_3"",
	""TestObj2"":{
		""Var2_1"":""Output2_1"",
		""Var2_2"":""Output2_2"",
		""Var2_3"":""Output2_3""
	},
    ""TestObj3"":{
		""Var1_1"":""Output3_1"",
		""Var3_2"":""Output3_2"",
		""Var3_3"":""Output3_3""
	}
}";
            Dictionary<string, string> validDict = new() {
                { "Var1_1", "Output1_1" },
                { "Var1_2", "Output1_2" },
                { "Var1_3", "Output1_3" },
            };
            Dictionary<string, string> outputDict = JsonHelper.GetJsonRootDictionary(testVarString);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateJsonQueryMultiQuery()
        {
            string testVarString = @"{
	""TestObj1"":{
		""Var1_1"":""Output1_1"",
		""Var1_2"":""Output1_2"",
		""Var1_3"":""Output1_3""
	},
	""TestObj2"":{
		""Var2_1"":""Output2_1"",
		""Var2_2"":""Output2_2"",
		""Var2_3"":""Output2_3""
	},
    ""TestObj3"":{
		""Var3_1"":""Output3_1"",
		""Var3_2"":""Output3_2"",
		""Var3_3"":""Output3_3""
	}
}";
            string[] testJsonQuery = new string[2] { "TestObj1", "TestObj3" };
            Dictionary<string, string> validDict = new() {
                { "Var1_1", "Output1_1" },
                { "Var1_2", "Output1_2" },
                { "Var1_3", "Output1_3" },
                { "Var3_1", "Output3_1" },
                { "Var3_2", "Output3_2" },
                { "Var3_3", "Output3_3" }
            };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateJsonQueryMultiQueryUpdate()
        {
            string testVarString = @"{
	""TestObj1"":{
		""Var1_1"":""Output1_1"",
		""Var1_2"":""Output1_2"",
		""Var1_3"":""Output1_3""
	},
    ""TestObj3"":{
		""Var1_1"":""Output3_1"",
		""Var3_2"":""Output3_2"",
		""Var3_3"":""Output3_3""
	}
}";
            string[] testJsonQuery = new string[2] { "TestObj1", "TestObj3" };
            Dictionary<string, string> validDict = new() {
                { "Var1_1", "Output3_1" },
                { "Var1_2", "Output1_2" },
                { "Var1_3", "Output1_3" },
                { "Var3_2", "Output3_2" },
                { "Var3_3", "Output3_3" }
            };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }

        [Fact]
        public void ValidateJsonQueryMultiQueryUpdateValue()
        {
            string testVarString = @"{
	""TestObj1"":{
		""Var1_1"":""Output1_1"",
	},
    ""TestObj3"":{
		""Var1_1"":""Output3_1"",
	}
}";
            string[] testJsonQuery = new string[2] { "TestObj1", "TestObj3" };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal("Output3_1", outputDict["Var1_1"]);
        }

        [Fact]
        public void ValidateJsonDeepQuery()
        {
            string testVarString = @"{
	""TestObj1"":{
        ""TestInnerObj1"":{
		    ""Var1_1_1"":""Output1_1_1"",
		    ""Var1_1_2"":""Output1_1_2"",
		    ""Var1_1_3"":""Output1_1_3""
        },
        ""TestInnerObj2"":{
		    ""Var1_2_1"":""Output1_2_1"",
		    ""Var1_2_2"":""Output1_2_2"",
		    ""Var1_2_3"":""Output1_2_3""
        }
	},
	""TestObj2"":[
        {
		    ""Var2_L0_1"":""Output2_L0_1"",
		    ""Var2_L0_2"":""Output2_L0_2"",
		    ""Var2_L0_3"":""Output2_L0_3""
        },
        {
		    ""Var2_L1_1"":""Output2_L1_1"",
		    ""Var2_L1_2"":""Output2_L1_2"",
		    ""Var2_L1_3"":""Output2_L1_3""
        },
	],
    ""TestObj3"":{
		""Var3_1"":""Output3_1"",
		""Var3_2"":""Output3_2"",
		""Var3_3"":""Output3_3""
	}
}";
            string[] testJsonQuery = new string[3] { "TestObj1.TestInnerObj1", "TestObj2[1]", "TestObj3" };
            Dictionary<string, string> validDict = new() {
                { "Var1_1_1", "Output1_1_1" },
                { "Var1_1_2", "Output1_1_2" },
                { "Var1_1_3", "Output1_1_3" },
                { "Var2_L1_1", "Output2_L1_1" },
                { "Var2_L1_2", "Output2_L1_2" },
                { "Var2_L1_3", "Output2_L1_3" },
                { "Var3_1", "Output3_1" },
                { "Var3_2", "Output3_2" },
                { "Var3_3", "Output3_3" }
            };
            Dictionary<string, string> outputDict = JsonHelper.QueriesObjectToDict(testVarString, testJsonQuery);
            Assert.Equal(validDict, outputDict, new DictionaryComparer());
        }
    }
}