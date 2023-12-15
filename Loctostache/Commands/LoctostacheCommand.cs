// Ignore Spelling: Json Loctostache

using CommandLine;
using Loctostache.Constants;
using Loctostache.ExtensionMethods;
using Loctostache.Helpers;
using Octostache;
using System.Globalization;

namespace Loctostache.Commands
{
    internal class LoctostacheCommand
    {
        [Option(CommandStrings.DictionaryOption, CommandStrings.DictionaryOptionLong, HelpText = CommandStrings.DictionaryOptionHelp, Group = CommandStrings.VariablesGroupName, Required = true)]
        public string? Variables { get; set; }
        [Option(CommandStrings.VarFileOption, CommandStrings.VarFileOptionLong, HelpText = CommandStrings.VarFileOptionHelp, Group = CommandStrings.VariablesGroupName, Required = true)]
        public string? VariableFile { get; set; }
        [Option(CommandStrings.JsonQueriesOption, CommandStrings.JsonQueriesOptionLong, HelpText = CommandStrings.JsonQueriesOptionHelp, Separator = CommandStrings.StandardSeperator)]
        public IEnumerable<string>? JsonQueries { get; set; }

        internal VariableDictionary VarDictProcessing()
        {
            VariableDictionary varDict = new();
            Dictionary<string, string> dict = new();
            Dictionary<string, string> stringDict = new();
            try
            {
                if (VariableFile != null && VariableFile.Any())
                {
                    if (File.Exists(VariableFile))
                    {
                        string fileText = File.ReadAllText(VariableFile);
                        dict = JsonHelper.GetJsonRootDictionary(fileText);
                        if (JsonQueries != null && JsonQueries.Any())
                        {
                            dict.AddOrUpdate(JsonHelper.QueriesObjectToDict(fileText, JsonQueries));
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine(string.Format(CultureInfo.CurrentCulture, ErrorStrings.VarFileLocation, VariableFile));
                    }
                }
                if (Variables != null && Variables.Any())
                {
                    stringDict = JsonHelper.GetJsonRootDictionary(Variables);
                    if (JsonQueries != null && JsonQueries.Any())
                    {
                        stringDict.AddOrUpdate(JsonHelper.QueriesObjectToDict(Variables, JsonQueries));
                    }
                }
                dict.AddOrUpdate(stringDict);
                foreach (string key in dict.Keys)
                {
                    varDict.Set(key, dict.GetValueOrDefault(key));
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(string.Format(CultureInfo.CurrentCulture, ErrorStrings.VarDictionaryProcessing, ex.Message));
                Environment.Exit(209);
            }
            return varDict;
        }
    }
}
