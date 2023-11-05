// Ignore Spelling: Loctostache

using CommandLine;
using Loctostache.Commands;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("LoctostacheTests")]
namespace Loctostache
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Parser.Default.ParseArguments<FileVerb, TextVerb>(args)
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