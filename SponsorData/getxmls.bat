@echo off

REM This batch file will read the list of bill statuses specified in 
REM getxmls.txt and download the corresponding XML file. The output file 
REM is overridden to make it a unique value

REM This file requires that "wget" be in your path.
REM https://www.gnu.org/software/wget/

FOR /F "tokens=1,2,3,4" %%a IN (%~n0.txt) DO @call :DownloadFile %%a %%b %%c %%d

GOTO :EOF

:DownloadFile
call wget https://www.govinfo.gov/bulkdata/BILLSTATUS/%1/%3/BILLSTATUS-%1%3%4.xml
GOTO :EOF
