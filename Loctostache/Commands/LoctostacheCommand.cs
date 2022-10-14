using CommandLine;

namespace Loctostache.Commands
{
    internal class LoctostacheCommand
    {
        [Option('d', "dictionary", HelpText = "A json string dictionary of keys and their values", Required = true)]
        public string? Variables { get; set; }
        [Option('t', "text", HelpText = "Text to search and replace against", SetName = "text", Required = true)]
        public string? Text { get; set; }
        [Option('f', "files", HelpText = "A comma separated list of files read and replace text in", Separator = ',', SetName = "file", Required = true)]
        public IEnumerable<string>? Files { get; set; }
    }
}
