# Loctostache

A simple octostache for Linux tool.

Example Usage:
loctostache text -d "{\"doing\":\"testing var replacement\"}" -t "We are #{doing}"

Outputs: 
We are testing var replacement


## Base Help
Loctostache 1.2311.0316.0
Copyright (C) 2023 Chad Roesler

  file       Loctostache processing on files

  text       Loctostache processing on text

  help       Display more information on a specific command.

  version    Display version information.


## Text Help
Loctostache 1.2311.0316.0
Copyright (C) 2023 Chad Roesler

  -t, --text           Required. Text to search and replace against

  -n, --no-newline     Prevents appending a new line at the end of the text return

  -d, --dictionary     (Group: variables) A json string dictionary of keys and their values

  -v, --varFile        (Group: variables) A json file that contains the diction of keys

  -q, --jsonQueries    A comma separated list of json queries to execute against a dictionary

  --help               Display this help screen.

  --version            Display version information.


## File Help
Loctostache 1.2311.0316.0
Copyright (C) 2023 Chad Roesler

  -f, --files          Required. A comma separated list of files read and replace text in

  --verbose            Verbosity when processing files

  -d, --dictionary     (Group: variables) A json string dictionary of keys and their values

  -v, --varFile        (Group: variables) A json file that contains the diction of keys

  -q, --jsonQueries    A comma separated list of json queries to execute against a dictionary

  --help               Display this help screen.

  --version            Display version information.