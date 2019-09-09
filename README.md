# amcv360RequestRecorder

This Windows Forms application should help you to form webrequests to integrate the 360 S6 vacuum robot into other applications like openhab, iobroker, alexa-skill, etc.

You can record the webrequests that are sent from the iOS or Android app. After recording you'll be able to replay those requests to control the robot.

Currently supported commands are: StartCleaning, StopCleaning and GoCharging.

If you want to help me, please send me the resulting .json-file to amcv@mnetworx.de. I'll use it with care and i'll not use the requests to control your device :) !!


# 360Cmd.exe
360Cmd can be executed from commandline or be called from any thirdparty application (like iobroker, openhab, fhem, etc.) 
This commandline application can be compiled on Windows, Linux and MacOS.

**StartCleaning**<br>
360Cmd.exe -f "[PATH TO amcv-result file]\2019-09-05.json" -c start<br><br>
**StopCleaning**<br>
360Cmd.exe -f "[PATH TO amcv-result file]\2019-09-05.json" -c stop<br><br>
**GoCharging**<br>
360Cmd.exe -f "[PATH TO amcv-result file]\2019-09-05.json" -c charge<br>br>


