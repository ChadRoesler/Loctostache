// Ignore Spelling: Json Loctostache

using CommandLine;
using Loctostache.Helpers;

namespace Loctostache.Commands
{
    [Verb("file", HelpText = "Loctostache processing on files")]
    internal class FileVerb : LoctostacheCommand
    {
        [Option('f', "files", HelpText = "A comma separated list of files read and replace text in", Separator = ',', Required = true)]
        public IEnumerable<string> Files { get; set; }
        [Option("verbose", HelpText = "Verbosity when processing.")]
        public bool Verbose { get; set; } = false;

        internal void FileProcessing()
        {
            var varDict = VarDictProcessing();
            var fileCount = Files.Count();
            var currentCount = 1;
            foreach (var file in Files)
            {
                if (Verbose)
                {
                    Console.WriteLine($"Processing file {currentCount}/{fileCount}..........{file}");
                }
                if (File.Exists(file))
                {
                    var bom = File.ReadAllBytes(file).Take(4).ToArray();
                    var fileEncoding = EncodingHelper.GetEncodingFromBom(bom);
                    File.WriteAllText(file, varDict.Evaluate(File.ReadAllText(file)), fileEncoding);
                }
                else
                {
                    Console.Error.WriteLine($"[ERROR] Failed to locate file at: {file}");
                }
                currentCount++;
            }
            Console.WriteLine("Complete!");
        }
    }
}
