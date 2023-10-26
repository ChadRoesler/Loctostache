// Ignore Spelling: Json Loctostache

using CommandLine;

namespace Loctostache.Commands
{
    internal class LoctostacheCommand
    {
        [Option('d', "dictionary", HelpText = "A json string dictionary of keys and their values", SetName = "dictionary", Required = true)]
        public string? Variables { get; set; }
        [Option('v', "varFile", HelpText = "A json file that contains the diction of keys", SetName = "varfile", Required = true)]
        public string? VariableFile { get; set; }
        [Option('q', "jsonQueries", HelpText = "a comma separated list of json queries to execute against a dictionary", Separator = ',')]
        public IEnumerable<string>? JsonQueries { get; set; }
        [Option('t', "text", HelpText = "Text to search and replace against", SetName = "text", Required = true)]
        public string? Text { get; set; }
        [Option('f', "files", HelpText = "A comma separated list of files read and replace text in", Separator = ',', SetName = "file", Required = true)]
        public IEnumerable<string>? Files { get; set; }
        [Option('n', "no-newline", HelpText = "Prevents appending a new line at the end of the text return", SetName = "text"),]
        public bool NoNewline { get; set; } = false;
    }
}
