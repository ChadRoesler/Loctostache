# Loctostache

A simple octostache for linux tool.

Example Usage:
loctostache -d "{\"doing\":\"testing var replacement\"}" -t "We are #{doing}"

Outputs: 
We are testing var replacement





Loctostache 1.2310.2602.5419
Copyright (C) 2023 Chad Roesler

  -d, --dictionary     Required. A json string dictionary of keys and their values

  -v, --varFile        Required. A json file that contains the diction of keys

  -q, --jsonQueries    a comma separated list of json queries to execute against a dictionary

  -t, --text           Required. Text to search and replace against

  -f, --files          Required. A comma separated list of files read and replace text in

  -n, --no-newline     Prevents appending a new line at the end of the text return

  --help               Display this help screen.

  --version            Display version information.