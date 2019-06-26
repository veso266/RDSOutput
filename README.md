#RDSOutput

###SDR# plugin for "RDS Spy" program.

Maybe someone want to try my plugin for SDR#. The connection with RDSSpy is through socket TCP/IP ( No virtual audio cable). You have to add manually the line:

`<add key="RDS Output" value="SDRSharp.RDSOutput.RDSOutput,SDRSharp.RDSOutput" />`

in **Plugins.xml** file in your SDR# program directory and configure RDSSpy for TCP/IP connection with IP host: localhost and port: 23

Also you have to copy the file **SDRSharp.RDSOutput.dll** in your SDR# program directory. You can get the file** SDRSharp.RDSOutput.dll** from:

https://github.com/sergionavarrog/RDSOutput

No need to compile it, get the file from RDSOutput/RDSOutput/bin/Debug/ directory.

Now with RFtap output: https://rftap.github.io/blog/2016/08/27/decoding-rds-with-rftap.html

[demo](https://github.com/sergionavarrog/RDSOutput/raw/master/rdsoutput.gif)

[demo](https://github.com/sergionavarrog/RDSOutput/raw/master/v1.0.0.1491.png)