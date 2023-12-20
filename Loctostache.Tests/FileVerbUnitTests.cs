// Ignore Spelling: Dict

using CommandLine;
using Loctostache.Commands;

namespace Loctostache.Tests
{
    public class FileVerbUnitTests
    {
        [Fact]
        public void ValidateVarDictFileReplacement()
        {
            var args = new string[]
            {
                "-f",
                "TestFiles\\testFile.txt",
                "-d",
                @"{""Variable1"":""Replace!"",""Variable2"":""Okay Here?"",""Variable3"":""And here as well.""}",
                "--verbose"
            };
            var commands = Parser.Default.ParseArguments<FileVerb>(args)
            .WithParsed(opts =>
            {
                opts.FileProcessing();
            });
            var testFile = File.ReadAllText("TestFiles\\testFile.txt");
            var validFile = File.ReadAllText("TestFiles\\validTestFile.txt");
            Assert.Equal(validFile, testFile);
        }
    }
}
