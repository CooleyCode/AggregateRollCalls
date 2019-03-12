@echo off

REM This batch file will read the list of roll calls specified in 
REM getxmls.txt and download the corresponding XML file. The output file 
REM is overridden to include the year to make it a unique value

REM This file requires that "wget" be in your path.
REM https://www.gnu.org/software/wget/

FOR /F "skip=1 tokens=1,2" %%a IN (%~n0.txt) DO @call :DownloadFile %%a %%b

GOTO :EOF

:DownloadFile
call wget http://clerk.house.gov/evs/%1/roll%2.xml -O %1_roll%2.xml
GOTO :EOF
