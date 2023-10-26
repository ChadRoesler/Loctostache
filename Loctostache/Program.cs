// Ignore Spelling: Loctostache

using CommandLine;
using Loctostache.Commands;
using Loctostache.Helpers;
using Newtonsoft.Json;
using Octostache;

namespace Loctostache
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = Parser.Default.ParseArguments<LoctostacheCommand>(args).WithParsed(opts =>
            {
                try
                {
                    VariableDictionary varDict = new();
                    string? varString = string.Empty;
                    Dictionary<string, string> dict = new();

                    if (opts.VariableFile != null)
                    {
                        if (File.Exists(opts.VariableFile))
                        {
                            varString = File.ReadAllText(opts.VariableFile);
                        }
                        else
                        {
                            Console.Error.WriteLine($"[ERROR] Failed to locate file at: {opts.VariableFile}");
                        }
                    }
                    else
                    {
                        varString = opts.Variables;
                    }
                    if (opts.JsonQueries != null && opts.JsonQueries.Any())
                    {
                        dict = JsonQueryHelper.QueriesObjectToDict(varString, opts.JsonQueries);
                    }
                    else
                    {
                        dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(varString);
                    }
                    foreach (var key in dict.Keys)
                    {
                        varDict.Add(key, dict.GetValueOrDefault(key));
                    }
                    if (!string.IsNullOrWhiteSpace(opts.Text))
                    {
                        if (opts.NoNewline)
                        {
                            Console.Write(varDict.Evaluate(opts.Text));
                        }
                        else
                        {
                            Console.WriteLine(varDict.Evaluate(opts.Text));
                        }
                    }
                    if (opts.Files != null && opts.Files.Any())
                    {
                        foreach (var file in opts.Files)
                        {
                            Console.WriteLine(file);
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
                        }
                        Console.WriteLine("Complete!");
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.Message);
                }
            });
        }
    }
}