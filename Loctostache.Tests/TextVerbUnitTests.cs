// Ignore Spelling: Dict

using Loctostache.Commands;

namespace Loctostache.Tests
{
    public class TextVerbUnitTests
    {
        [Fact]
        public void ValidateVarDictTextReplacement()
        {
            var textCommand = new TextVerb()
            {
                Text = "Here is some text to #{Variable1}",
                Variables = @"{""Variable1"":""Replace!""}"
            };
            var validText = "Here is some text to Replace!\r\n";
            var output = new StringWriter();
            Console.SetOut(output);
            textCommand.TextProcessing();
            Assert.Equal(validText, output.ToString());
        }

        [Fact]
        public void ValidateVarDictTextReplacementNoNewLine()
        {
            var textCommand = new TextVerb()
            {
                Text = "Here is some text to #{Variable1}",
                Variables = @"{""Variable1"":""Replace!""}",
                NoNewline = true
            };
            var validText = "Here is some text to Replace!";
            var output = new StringWriter();
            Console.SetOut(output);
            textCommand.TextProcessing();
            Assert.Equal(validText, output.ToString());
        }

        [Fact]
        public void ValidateFileTextReplacement()
        {
            var textCommand = new TextVerb()
            {
                Text = "Here is some text to #{Variable1}",
                VariableFile = "TestFiles\\testFileVarDict.json"
            };
            var validText = "Here is some text to Replace!\r\n";
            var output = new StringWriter();
            Console.SetOut(output);
            textCommand.TextProcessing();
            Assert.Equal(validText, output.ToString());
        }

        [Fact]
        public void ValidateFileTextReplacementNoNewLine()
        {
            var textCommand = new TextVerb()
            {
                Text = "Here is some text to #{Variable1}",
                VariableFile = "TestFiles\\testFileVarDict.json",
                NoNewline = true
            };
            var validText = "Here is some text to Replace!";
            var output = new StringWriter();
            Console.SetOut(output);
            textCommand.TextProcessing();
            Assert.Equal(validText, output.ToString());
        }
    }
}
