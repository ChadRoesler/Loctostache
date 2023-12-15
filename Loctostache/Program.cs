// Ignore Spelling: Loctostache

using CommandLine;
using Loctostache.Commands;

namespace Loctostache
{
    class Program
    {
        static void Main(string[] args)
        {
            ParserResult<object> commands = Parser.Default.ParseArguments<FileVerb, TextVerb>(args)
                .WithParsed<FileVerb>(opts =>
                {
                    opts.FileProcessing();
                })
                .WithParsed<TextVerb>(opts =>
                {
                    opts.TextProcessing();
                });
        }
    }
}