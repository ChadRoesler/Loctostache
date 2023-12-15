// Ignore Spelling: Json Loctostache

using CommandLine;
using Loctostache.Constants;
using Octostache;
using System.Globalization;

namespace Loctostache.Commands
{
    [Verb(CommandStrings.TextVerb, HelpText = CommandStrings.TextVerbHelp)]
    internal class TextVerb : LoctostacheCommand
    {
        [Option(CommandStrings.TextOption, CommandStrings.TextOptionLong, HelpText = CommandStrings.TextOptionHelp, Required = true)]
        public string? Text { get; set; }
        [Option(CommandStrings.NoNewLineOption, CommandStrings.NoNewLineOptionLong, HelpText = CommandStrings.NoNewLineOptionHelp)]
        public bool NoNewline { get; set; } = false;

        internal void TextProcessing()
        {
            VariableDictionary varDict = VarDictProcessing();
            try
            {
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
                else
                {
                    Console.Error.WriteLine(ErrorStrings.NoText);
                    Environment.Exit(291);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(string.Format(CultureInfo.CurrentCulture, ErrorStrings.TextProcessing, ex.Message));
                Environment.Exit(291);
            }
        }
    }
}
