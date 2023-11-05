// Ignore Spelling: Json Loctostache

using CommandLine;

namespace Loctostache.Commands
{
    [Verb("text", HelpText = "Loctostache processing on text")]
    internal class TextVerb : LoctostacheCommand
    {
        [Option('t', "text", HelpText = "Text to search and replace against", Required = true)]
        public string? Text { get; set; }
        [Option('n', "no-newline", HelpText = "Prevents appending a new line at the end of the text return")]
        public bool NoNewline { get; set; } = false;

        internal void TextProcessing()
        {
            var varDict = VarDictProcessing();
            if (!string.IsNullOrWhiteSpace(Text))
            {
                if (NoNewline)
                {
                    Console.Write(varDict.Evaluate(Text));
                }
                else
                {
                    Console.WriteLine(varDict.Evaluate(Text));
                }
            }
        }
    }
}
