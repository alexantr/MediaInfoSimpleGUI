# MediaInfoSimpleGUI

Simple GUI for MediaInfo

## How to add MediaInfo to context menu

REG file example:

```
Windows Registry Editor Version 5.00

[HKEY_CLASSES_ROOT\*\shell\MediaInfoSimpleGUI]
@="MediaInfo"
"Icon"="\"C:\\Programs\\MediaInfoSimpleGUI\\MediaInfoSimpleGUI.exe\",0"

[HKEY_CLASSES_ROOT\*\shell\MediaInfoSimpleGUI\command]
@="\"C:\\Programs\\MediaInfoSimpleGUI\\MediaInfoSimpleGUI.exe\" \"%1\""


```
