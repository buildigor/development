sc create "CsvWatcherService" binPath= "%~dp0CsvWatcherService.exe"
sc config "CsvWatcherService"  start= auto 
sc failure "CsvWatcherService"  actions= restart/0/restart/0/restart/0/ reset= 86400 
net start "CsvWatcherService"
pause