@echo off

REM http://clerk.house.gov/evs/2017 710

call :DownloadFile 2017 690
call :DownloadFile 2018 442
call :DownloadFile 2017 686
call :DownloadFile 2017 208
call :DownloadFile 2017 693
call :DownloadFile 2018 284
call :DownloadFile 2017 700
call :DownloadFile 2017 206
call :DownloadFile 2018 288
call :DownloadFile 2018 149
call :DownloadFile 2018 321
call :DownloadFile 2018 448
call :DownloadFile 2017 409
call :DownloadFile 2018 459
call :DownloadFile 2017 391
call :DownloadFile 2018 238
call :DownloadFile 2018 294
call :DownloadFile 2017 598
call :DownloadFile 2018 101
call :DownloadFile 2017 606
call :DownloadFile 2017 175
call :DownloadFile 2018 441
call :DownloadFile 2018 099
call :DownloadFile 2017 649
call :DownloadFile 2018 385
call :DownloadFile 2017 282
call :DownloadFile 2017 181
call :DownloadFile 2018 129
call :DownloadFile 2016 298
call :DownloadFile 2015 258
call :DownloadFile 2016 592
call :DownloadFile 2016 070
call :DownloadFile 2015 687
call :DownloadFile 2015 121
call :DownloadFile 2015 673
call :DownloadFile 2015 672
call :DownloadFile 2015 010
call :DownloadFile 2016 466
call :DownloadFile 2016 301
call :DownloadFile 2015 088
call :DownloadFile 2015 262
call :DownloadFile 2015 082
call :DownloadFile 2015 649
call :DownloadFile 2016 614
call :DownloadFile 2016 133
call :DownloadFile 2015 125
call :DownloadFile 2016 622
call :DownloadFile 2016 335
call :DownloadFile 2015 173
call :DownloadFile 2016 238
call :DownloadFile 2015 170
call :DownloadFile 2016 134
call :DownloadFile 2015 267
call :DownloadFile 2016 572
call :DownloadFile 2016 354
call :DownloadFile 2015 423
call :DownloadFile 2015 335
call :DownloadFile 2016 042
call :DownloadFile 2015 447
call :DownloadFile 2016 139
call :DownloadFile 2016 282
call :DownloadFile 2016 101
call :DownloadFile 2016 606
call :DownloadFile 2015 219
call :DownloadFile 2016 123
call :DownloadFile 2016 067
call :DownloadFile 2016 503
call :DownloadFile 2015 695
call :DownloadFile 2015 458
call :DownloadFile 2015 428
call :DownloadFile 2015 384
call :DownloadFile 2016 084
call :DownloadFile 2016 153
call :DownloadFile 2016 547
call :DownloadFile 2016 109
call :DownloadFile 2016 237
call :DownloadFile 2016 181
call :DownloadFile 2018 351
call :DownloadFile 2018 246
call :DownloadFile 2017 479
call :DownloadFile 2017 492
call :DownloadFile 2018 245
call :DownloadFile 2017 490
call :DownloadFile 2017 482
call :DownloadFile 2018 203
call :DownloadFile 2017 488
call :DownloadFile 2018 346
call :DownloadFile 2017 386
call :DownloadFile 2017 472
call :DownloadFile 2018 344
call :DownloadFile 2017 473
call :DownloadFile 2017 388
call :DownloadFile 2017 122
call :DownloadFile 2017 475
call :DownloadFile 2018 347
call :DownloadFile 2015 202
call :DownloadFile 2016 254
call :DownloadFile 2015 290
call :DownloadFile 2016 446
call :DownloadFile 2015 256
call :DownloadFile 2016 411
call :DownloadFile 2016 456
call :DownloadFile 2016 453
call :DownloadFile 2016 121
call :DownloadFile 2016 425
call :DownloadFile 2015 620
call :DownloadFile 2016 455
call :DownloadFile 2015 123
call :DownloadFile 2015 431
call :DownloadFile 2015 432
call :DownloadFile 2015 199
call :DownloadFile 2015 669
call :DownloadFile 2016 429
call :DownloadFile 2015 453
call :DownloadFile 2015 456
call :DownloadFile 2016 279
call :DownloadFile 2016 199
call :DownloadFile 2015 295
call :DownloadFile 2016 463
call :DownloadFile 2016 427
call :DownloadFile 2016 457
call :DownloadFile 2015 396
call :DownloadFile 2015 401

GOTO :EOF

:DownloadFile
call wget http://clerk.house.gov/evs/%1/roll%2.xml -O %1_roll%2.xml
GOTO :EOF
