set dll="RomanNumbersCalculator.Tests\bin\Debug\RomanNumbersCalculator.Tests.dll"
set opencover_exe="packages\OpenCover.4.5.2506\OpenCover.Console.exe"
set reportgenerator_exe="packages\ReportGenerator.1.9.1.0\ReportGenerator.exe"
set test_exe="C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe"

set opencoverfile="test_report\opencover.xml"
set reportfolder="test_report\codecoverage_report"

if exist test_report (goto RUN) else (mkdir test_report)
if exist test_report\codecoverage_report (goto RUN) else (mkdir test_report\codecoverage_report)

:RUN

%opencover_exe% -register:user -target:%test_exe% -targetargs:%dll% -filter:"+[*]*" -output:%opencoverfile%
%reportgenerator_exe% -reports:%opencoverfile% -targetdir:%reportfolder%
call %reportfolder%"\index.htm"

PAUSE 