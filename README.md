# Loctostache

A simple octostache for linux tool.

Example Usage:
loctostache -d "{\"doing\":\"testing var replacement\"}" -t "We are #{doing}"
Outputs: 
We are testing var replacement



Loctostache 1.2210.1401.5526
Copyright (C) 2022 Chad Roesler

  -d, --dictionary    Required. A json string dictionary of keys and their values

  -t, --text          Required. Text to search and replace against

  -f, --files         Required. A comma separated list of files read and replace text in

  --help              Display this help screen.

  --version           Display version information.
