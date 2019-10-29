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
360Cmd.exe -f "[PATH TO amcv-result file]\2019-09-05.json" -c charge<br><br>

# BeispielCode für NodeJS (bzw Iobroker)
```javascript
const https = require('https');
var postData = "yourReadOutCommand";
const options = {
  hostname: 'q.smart.360.cn',
  port: 443,
  path: '/clean/cmd/send',
  method: 'POST',
  headers: {
    'Content-Type': 'application/x-www-form-urlencoded',
    'Content-Length': Buffer.byteLength(postData,'utf8'),
    'Cookie': 'yourReadOutCookie',
    'Accept-Language': 'de-DE;q=1',
    'Accept-Encoding': 'br, gzip, deflate'

  }
};

const req = https.request(options, (res) => {
  console.log('statusCode:'+ res.statusCode);
  //console.log('headers:'+ res.headers);

  res.on('data', (d) => {
     //console.log(d);
  });
});

req.on('error', (e) => {
  console.error(e);
});
req.write(postData);
req.end();

```


