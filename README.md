# Loctostache

A simple octostache for linux tool.

Example Usage:
loctostache -d "{\"doing\":\"testing var replacement\"}" -t "We are #{doing}"
Outputs: 
We are testing var replacement



Loctostache 1.2210.1401.5526
Copyright (C) 2022 Chad Roesler

  -d, --dictionary    Required. The dictionary of to consume, as a json string object

  -t, --text          Required. The text to replace

  -f, --files         Required. The path of a file to Repalce

  --help              Display this help screen.

  --version           Display version information.
