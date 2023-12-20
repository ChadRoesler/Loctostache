// Ignore Spelling: Json Loctostache

using CommandLine;
using Loctostache.Constants;
using Loctostache.Helpers;
using Octostache;
using System.Globalization;

namespace Loctostache.Commands
{
    [Verb(CommandStrings.FileVerb, HelpText = CommandStrings.FileVerbHelp)]
    internal class FileVerb : LoctostacheCommand
    {
        [Option(CommandStrings.FilesOption, CommandStrings.FilesOptionLong, HelpText = CommandStrings.FilesOptionHelp, Separator = CommandStrings.StandardSeperator, Required = true)]
        public IEnumerable<string> Files { get; set; }
        [Option(CommandStrings.StopOnFailureOption, CommandStrings.StopOnFailureOptionLong, HelpText = CommandStrings.StopOnFailureOptionHelp, Default = false)]
        public bool StopOnFailure { get; set; } = false;
        [Option(CommandStrings.VerboseOption, HelpText = CommandStrings.VerboseOptionHelp)]
        public bool Verbose { get; set; } = false;

        internal void FileProcessing()
        {
            VariableDictionary varDict = VarDictProcessing();
            int fileCount = Files.Count();
            int currentCount = 1;
            foreach (string file in Files)
            {
                if (Verbose)
                {
                    Console.WriteLine(string.Format(CultureInfo.CurrentCulture, MessageStrings.FileProcessing, currentCount.ToString(string.Format(CultureInfo.CurrentCulture, ResourceStrings.FileNumberPadding, fileCount.ToString(CultureInfo.CurrentCulture).Length)), fileCount, file));
                }
                try
                {
                    if (File.Exists(file))
                    {
                        byte[] bom = File.ReadAllBytes(file).Take(4).ToArray();
                        System.Text.Encoding fileEncoding = EncodingHelper.GetEncodingFromBom(bom);
                        File.WriteAllText(file, varDict.Evaluate(File.ReadAllText(file)), fileEncoding);
                    }
                    else
                    {
                        throw new FileNotFoundException();
                    }
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(string.Format(CultureInfo.CurrentCulture, ErrorStrings.FileProcessing, file, ex.Message));
                    if (StopOnFailure)
                    {
                        Environment.Exit(863);
                    }
                }
                currentCount++;
            }
            Console.WriteLine(MessageStrings.CompletedProcessing);
        }
    }
}
