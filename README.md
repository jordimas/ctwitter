Requirements:

* Visual Studio 2015

Execution:

1. Start CoduranceTwitter.WebApi.exe self-containing web service (it listens to http://localhost:8080)
2. Run CoduranceTwitter.Client.exe

Sample

 CoduranceTwitter.Client.exe -c posting -u jordi -m "Hello world - jordi"
 
 CoduranceTwitter.Client.exe -c posting -u joan -m "Hello world - joan"
 
 CoduranceTwitter.Client.exe -c reading -u jordi
 
 CoduranceTwitter.Client.exe -c reading -u joan
 
 CoduranceTwitter.Client.exe -c following  -u jordi -f joan
 
 CoduranceTwitter.Client.exe -c wall -u jordi
