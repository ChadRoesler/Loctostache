using CommandLine;
using Loctostache.Commands;
using Newtonsoft.Json;
using Octostache;
using System.Text;

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
                    var varDict = new VariableDictionary();
                    var deptObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(opts.Variables);
                    foreach (var key in deptObj.Keys)
                    {
                        varDict.Add(key, deptObj.GetValueOrDefault(key));
                    }
                    if (!string.IsNullOrWhiteSpace(opts.Text))
                    {
                        Console.WriteLine(varDict.Evaluate(opts.Text));
                    }
                    if (opts.Files != null && opts.Files.Any())
                    {
                        foreach (var file in opts.Files)
                        {
                            Console.WriteLine(file);
                            if (File.Exists(file))
                            {
                                var fileEncoding = Encoding.ASCII;
                                var bom = File.ReadAllBytes(file).Take(4).ToArray();
                                if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76)
                                {
#pragma warning disable SYSLIB0001 // Type or member is obsolete
                                    fileEncoding = Encoding.UTF7;
#pragma warning restore SYSLIB0001 // Type or member is obsolete
                                }
                                if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
                                {
                                    fileEncoding = Encoding.UTF8;
                                }

                                if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0)
                                {
                                    fileEncoding = Encoding.UTF32;
                                }
                                if (bom[0] == 0xff && bom[1] == 0xfe)
                                {
                                    fileEncoding = Encoding.Unicode;
                                }
                                if (bom[0] == 0xfe && bom[1] == 0xff)
                                {
                                    fileEncoding = Encoding.BigEndianUnicode;
                                }
                                if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff)
                                {
                                    fileEncoding = new UTF32Encoding(true, true);
                                }
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