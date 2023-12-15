namespace Loctostache.Constants
{
    internal class CommandStrings
    {
        internal const string FileVerb = "file";
        internal const string TextVerb = "text";
        internal const string FileVerbHelp = "Loctostache processing on files";
        internal const string TextVerbHelp = "Loctostache processing on text";
        internal const char TextOption = 't';
        internal const string TextOptionLong = "text";
        internal const string TextOptionHelp = "Text to search and replace against";
        internal const char NoNewLineOption = 'n';
        internal const string NoNewLineOptionLong = "no-newline";
        internal const string NoNewLineOptionHelp = "Prevents appending a new line at the end of the text return";
        internal const char FilesOption = 'f';
        internal const string FilesOptionLong = "files";
        internal const string FilesOptionHelp = "A comma separated list of files read and replace text in";
        internal const char StandardSeperator = ',';
        internal const char StopOnFailureOption = 'x';
        internal const string StopOnFailureOptionLong = "stop-on-failure";
        internal const string StopOnFailureOptionHelp = "Stops the entire process when a single file fails";
        internal const string VerboseOption = "Verbose";
        internal const string VerboseOptionHelp = "Verbosity when processing files";
        internal const char DictionaryOption = 'd';
        internal const string DictionaryOptionLong = "dictionary";
        internal const string DictionaryOptionHelp = "A JSON string dictionary of keys and their values";
        internal const char VarFileOption = 'v';
        internal const string VarFileOptionLong = "varFile";
        internal const string VarFileOptionHelp = "A JSON file that contains the diction of keys";
        internal const char JsonQueriesOption = 'q';
        internal const string JsonQueriesOptionLong = "jsonQueries";
        internal const string JsonQueriesOptionHelp = "A comma separated list of JSON queries to execute against a dictionary";
        internal const string VariablesGroupName = "variables";
    }
}
