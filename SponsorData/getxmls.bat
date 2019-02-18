@echo off

REM ex https://www.govinfo.gov/bulkdata/BILLSTATUS/115/hr/BILLSTATUS-115hr999.xml

call :DownloadFile 114	1	hr	1020
call :DownloadFile 114	1	hr	1029
call :DownloadFile 114	1	hr	1030
call :DownloadFile 115	2	hr	1119
call :DownloadFile 115	1	hr	1159
call :DownloadFile 115	1	hr	1252
call :DownloadFile 115	1	hr	1297
call :DownloadFile 114	1	hr	1335
call :DownloadFile 115	1	hr	1430
call :DownloadFile 115	1	hr	1431
call :DownloadFile 114	1	hr	1560
call :DownloadFile 114	2	hr	1567
call :DownloadFile 115	2	hr	1635
call :DownloadFile 114	2	hr	1644
call :DownloadFile 114	1	hr	1731
call :DownloadFile 114	1	hr	1732
call :DownloadFile 114	1	hr	1734
call :DownloadFile 114	1	hr	1806
call :DownloadFile 115	2	hr	1917
call :DownloadFile 115	2	hr	2
call :DownloadFile 115	2	hr	200
call :DownloadFile 114	1	hr	2042
call :DownloadFile 115	2	hr	2083
call :DownloadFile 114	2	hr	212
call :DownloadFile 114	1	hr	22
call :DownloadFile 114	1	hr	2262
call :DownloadFile 114	2	hr	2285
call :DownloadFile 114	1	hr	23
call :DownloadFile 114	2	hr	2406
call :DownloadFile 114	2	hr	2576
call :DownloadFile 114	2	hr	2646
call :DownloadFile 114	1	hr	2647
call :DownloadFile 114	1	hr	2820
call :DownloadFile 114	1	hr	2898
call :DownloadFile 115	1	hr	2936
call :DownloadFile 115	1	hr	3017
call :DownloadFile 115	1	hr	3218
call :DownloadFile 114	2	hr	3293
call :DownloadFile 114	2	hr	34
call :DownloadFile 114	1	hr	3578
call :DownloadFile 114	2	hr	3797
call :DownloadFile 115	1	hr	3922
call :DownloadFile 114	1	hr	4127
call :DownloadFile 115	1	hr	4254
call :DownloadFile 115	1	hr	4323
call :DownloadFile 115	1	hr	4375
call :DownloadFile 114	2	hr	4470
call :DownloadFile 114	2	hr	4557
call :DownloadFile 114	2	hr	4570
call :DownloadFile 114	2	hr	4742
call :DownloadFile 114	2	hr	4755
call :DownloadFile 114	2	hr	4775
call :DownloadFile 114	1	hr	5
call :DownloadFile 114	2	hr	5049
call :DownloadFile 114	2	hr	5052
call :DownloadFile 115	2	hr	5086
call :DownloadFile 115	2	hr	5089
call :DownloadFile 114	2	hr	5303
call :DownloadFile 114	2	hr	5312
call :DownloadFile 114	1	hr	5388
call :DownloadFile 115	2	hr	5509
call :DownloadFile 114	2	hr	5587
call :DownloadFile 115	2	hr	6
call :DownloadFile 114	2	hr	6076
call :DownloadFile 115	2	hr	6227
call :DownloadFile 114	1	hr	636
call :DownloadFile 114	2	hr	6416
call :DownloadFile 115	2	hr	7279
call :DownloadFile 114	1	hr	8
call :DownloadFile 115	2	hr	8
call :DownloadFile 115	1	hr	806
call :DownloadFile 114	2	hr	897
call :DownloadFile 115	1	hr	953
call :DownloadFile 114	2	s	1252
call :DownloadFile 114	2	s	612
call :DownloadFile 115	2	s	756
call :DownloadFile 114	2	s	764

GOTO :EOF

:DownloadFile
call wget https://www.govinfo.gov/bulkdata/BILLSTATUS/%1/%3/BILLSTATUS-%1%3%4.xml
GOTO :EOF
