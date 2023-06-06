# Rhino Command Manager
A Rhino Plugin for hot reload dll(.rhp) file.
This tool use Reflection to load and unload external library dynamically.

## how to use
1. Download and install the plugin using PlugInManager.(CommandMnager.rhp)
2. Input "CommandManager" to call the dialog.
<div align="center">
    <img src="https://github.com/Tanc60/GrasshopperPlugins/blob/main/CommandManager/CommandManager/resouces/Snipaste_2023-06-06_15-34-04.png"  width="450">
</div>
click "load" to load dll(rhp) file
click "RunDll" to run.

## Note
1. Currently only support single RunCommand method in target assembly, other overwrite of the Rhino Command class have not been considered.
2. Only for test.

