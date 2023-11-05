// Ignore Spelling: Json Loctostache

using CommandLine;
using Loctostache.ExtensionMethods;
using Loctostache.Helpers;
using Octostache;

namespace Loctostache.Commands
{
    internal class LoctostacheCommand
    {
        [Option('d', "dictionary", HelpText = "A json string dictionary of keys and their values", Group = "variables", Required = true)]
        public string? Variables { get; set; }
        [Option('v', "varFile", HelpText = "A json file that contains the diction of keys", Group = "variables", Required = true)]
        public string? VariableFile { get; set; }
        [Option('q', "jsonQueries", HelpText = "A comma separated list of json queries to execute against a dictionary", Separator = ',')]
        public IEnumerable<string>? JsonQueries { get; set; }

        internal VariableDictionary VarDictProcessing()
        {
            VariableDictionary varDict = new();
            Dictionary<string, string> dict = new();
            Dictionary<string, string> stringDict = new();
            if (VariableFile != null && VariableFile.Any())
            {
                if (File.Exists(VariableFile))
                {
                    var fileText = File.ReadAllText(VariableFile);
                    dict = JsonHelper.GetJsonRootDictionary(fileText);
                    if (JsonQueries != null && JsonQueries.Any())
                    {
                        dict.AddOrUpdate(JsonHelper.QueriesObjectToDict(fileText, JsonQueries));
                    }
                }
                else
                {
                    Console.Error.WriteLine($"[ERROR] Failed to locate file at: {VariableFile}");
                }
            }
            else if (Variables != null && Variables.Any())
            {
                stringDict = JsonHelper.GetJsonRootDictionary(Variables);
                if (JsonQueries != null && JsonQueries.Any())
                {
                    stringDict.AddOrUpdate(JsonHelper.QueriesObjectToDict(Variables, JsonQueries));
                }
            }
            dict.AddOrUpdate(stringDict);
            foreach (var key in dict.Keys)
            {
                varDict.Set(key, dict.GetValueOrDefault(key));
            }
            return varDict;
        }
    }
}
