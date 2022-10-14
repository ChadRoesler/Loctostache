using CommandLine;

namespace Loctostache.Commands
{
    internal class LoctostacheCommand
    {
        [Option('d', "dictionary", HelpText = "The dictionary of to consume, as a json string object", Required = true)]
        public string? Variables { get; set; }
        [Option('t', "text", HelpText = "The text to replace", SetName = "text", Required = true)]
        public string? Text { get; set; }
        [Option('f', "files", HelpText = "The path of a file to Repalce", Separator = ',', SetName = "file", Required = true)]
        public IEnumerable<string>? Files { get; set; }
    }
}
