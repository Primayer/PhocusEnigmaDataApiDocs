# Primayer Phocus/Enigma Data API documentation

Questions? Find us at [development@ovarro.com](mailto:development@primayer.co.uk)

# Phocus/Enigma Data Access

This API provides access to the data recorded by a Phocus/Enigma logger. To use the API third parties must provide an authorization token with each request. The authorization token can be found within the account management section of [Atrium](https://atriumiot.com).

# Methods

- [*logger*](#loggerserial-begin-end-token): Returns data for logger specified by date time range.
- [*loggerinfo*](#loggerinfoserial-begin-end-token): Returns info for logger specified by date time range.
- [*signal*](#signalserial-begin-end-token): Returns signal for logger specified by date time range.
- [*summary*](#summarydate-token): Returns all Enigma groups with leak count.
- [*group*](#groupid-date-token): Returns leak summary for group.
- [*groupaudio*](#groupaudioid-date-token): Returns audio for group.
- [*loggerreport*](#loggerreportdate-token): CSV logger report.
- [*dmareport*](#dmareportbegin-end-token): CSV Phocus Dma report.
# API


## logger(serial, begin, end, token)

##### Purpose
Returns all data for the logger within the date range

##### Signature
  1. Endpoint
    - https://leakvisiondata.atriumiot.com/logger/serial/begin/end/token
  2. Params
   - serial: (string)
     - logger serial number
   - begin: (string - yyyy-MM-dd)
     - Date at which to start querying logger data.
   - end: (string - yyyy-MM-dd)
     - Date at which to finish querying logger data.
   - token: (string)
     - api authorization token.
      
##### Return Value

<pre>
[{
  serial: string,
  epochs: [
    {
      battery: double,
      cnv: int,
      lcf: int,
      latitude: double,
      longitude: double,
      temperature: double,
      timestamp: string,
      histograms: [
        {
          timestamp: string,
          bins: [int]
        }
      ]
    }
  ]
}]
</pre>
##### Example

https://leakvisiondata.atriumiot.com/logger/12345/2021-01-01/2021-01-02/00000000-0000-0000-0000-000000000000

Example Output:

<pre>
[{
  "serial": "123456",
  "epochs": [
    {
      "battery": 99.9,
      "cnv": 10,
      "lcf": 1,
      "latitude": 50.1,
      "longitude": -1.1,
      "temperature": 24.65,
      "timestamp": "2022-03-25 12:00",
      "histograms": [
        {
          "timestamp": "2022-03-25 12:00",
          "bins": [0,1,2,3,4,5,6,7,8,9]
        }
      ]
    }
  ]
}]
</pre>

<br />

## loggerinfo(serial, begin, end, token)

##### Purpose
Returns all info for the logger within the date range

##### Signature
  1. Endpoint
    - https://leakvisiondata.atriumiot.com/logger/info/serial/begin/end/token
  2. Params
   - serial: (string)
     - logger serial number
   - begin: (string - yyyy-MM-dd)
     - Date at which to start querying logger data.
   - end: (string - yyyy-MM-dd)
     - Date at which to finish querying logger data.
   - token: (string )
     - api authorization token.
      
##### Return Value

<pre>
[{
  serial: string,
  epochs: [
    {
      battery: double,
      cnv: int,
      lcf: int,
      timestamp: string
    }
  ]
}]
</pre>

##### Example

https://leakvisiondata.atriumiot.com/logger/info/12345/2021-01-01/2021-01-02/00000000-0000-0000-0000-000000000000

<pre>
[{
  "serial": "123456",
  "epochs": [
    {
      "battery": 99.9,
      "cnv": 10,
      "lcf": 1,
      "timestamp": "2022-03-25 12:00"
    }
  ]
}]
</pre>

<br />

## signal(serial, begin, end, token)

##### Purpose
Returns signal data for the logger within the date range

##### Signature
  1. Endpoint
    - https://leakvisiondata.atriumiot.com/logger/signal/serial/begin/end/token
  2. Params
   - serial: (string)
     - logger serial number
   - begin: (string - yyyy-MM-dd)
     - Date at which to start querying logger data.
   - end: (string - yyyy-MM-dd)
     - Date at which to finish querying logger data.
   - token: (string)
     - api authorization token.
      
##### Return Value

<pre>
[{
  serial: string
  signals: [
    {
      name: string,
      signal: string,
      type: string,
      timestamp: string
    }
  ]
}]
</pre>

##### Example

https://leakvisiondata.atriumiot.com/logger/signal/12345/2021-01-01/2021-01-02/00000000-0000-0000-0000-000000000000

<pre>
[{
  "serial": "123456",
  "signals": [
    {
      "name": "network name",
      "signal": "35%",
      "type": "network type",
      "timestamp": "2022-03-25 12:00"
    }
  ]
}]
</pre>

<br />

## summary(date, token)

##### Purpose
Returns Enigma groups with leak count

##### Signature
   1. Endpoint
    - https://leakvisiondata.atriumiot.com/group/summary/date/token
   2. Params
   - date: (string - yyyy-MM-dd)
     - Date at which to get summary
   - token: (string)
     - api authorization token
     
##### Return Value

<pre>
[{
  id: long,
  groupName: string,
  leaks: int,
  timestamp: string
}]
</pre>

##### Example

https://leakvisiondata.atriumiot.com/group/summary/2021-01-01/00000000-0000-0000-0000-000000000000

<pre>
[{
  "id": 123456,
  "groupName": "Group 1%",
  "leaks": 5,
  "timestamp": "2022-03-25 12:00"
}]
</pre>

<br />

## group(id, date, token)

##### Purpose
Returns leak summary for group

##### Signature
   1. Endpoint
    - https://leakvisiondata.atriumiot.com/group/id/date/token
  2. Params
   - id: (Int)
     - group Id (returned in the summary)
   - date: (string - yyyy-MM-dd)
     - Date at which to get summary.
   - token: (string)
     - api authorization token.
     
##### Return Value

<pre>
[{
  left: string,
  right: string,
  confidence: int,
  distanceFromLeft: double
  date: string
}]
</pre>

##### Example

https://leakvisiondata.atriumiot.com/group/1234/2021-01-01/00000000-0000-0000-0000-000000000000

<pre>
[{
  "left": 123456,
  "right": 654321,
  "confidence": 41,
  "distanceFromLeft": 150.5,
  "timestamp": "2022-03-25"
}]
</pre>

<br />

## groupaudio(id, date, token)

##### Purpose
Returns audio data for group

##### Signature
   1. Endpoint
    - https://leakvisiondata.atriumiot.com/group/audio/id/date/token
  2. Params
   - id: (Int)
     - group Id (returned in the summary)
   - date: (string - yyyy-MM-dd)
     - Date at which to get audio.
   - token: (string)
     - api authorization token.
     
##### Return Value

<pre>
[{
  logger: string,
  timestamp: string,
  audio: [byte]
}]
</pre>

##### Example

https://leakvisiondata.atriumiot.com/group/audio/1234/2021-01-01/00000000-0000-0000-0000-000000000000

<pre>
[{
  "logger": 123456,
  "timestamp": "2022-03-25",
  "audio": [0,0,0,0,0,0,0,0,0,0,0]
}]
</pre>

<br />

## loggerreport(date, token)

##### Purpose
Returns logger report csv

##### Signature
   1. Endpoint
    - https://leakvisiondata.atriumiot.com/report/logger/date/token
  2. Params
   - date: (string - yyyy-MM-dd)
     - Date at which to run the report.
   - token: (string)
     - api authorization token.
     
##### Return Value
  csv report

##### Example

https://leakvisiondata.atriumiot.com/report/logger/2021-01-01/00000000-0000-0000-0000-000000000000

<br />

## dmareport(begin, end, token)

##### Purpose
Returns Phocus DMA report csv

##### Signature
   1. Endpoint
    - https://leakvisiondata.atriumiot.com/report/dma/begin/end/token
  2. Params
   - begin: (string - yyyy-MM-dd HH:mm )
     - Date at which to start querying.
   - end: (string - yyyy-MM-dd HH:mm )
     - Date at which to finish querying.
   - token: (string)
     - api authorization token.
     
##### Return Value
  csv report

##### Example

https://leakvisiondata.atriumiot.com/report/dma/2021-01-01%2000:00/2021-01-02%2000:00/00000000-0000-0000-0000-000000000000

<br />
