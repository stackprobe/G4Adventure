C:\Factory\Tools\RDMD.exe /RC out

C:\Factory\SubTools\makeDDResourceFile.exe ^
	C:\Dat\Resource ^
	/SD Fairy\Donut3\General ^
	/SD Etoile\G4Adventure ^
	out\Resource.dat ^
	C:\Factory\Program\MaskGZDataForDonut3\MaskGZData.exe

C:\Factory\SubTools\CallConfuserCLI.exe G4Adventure\G4Adventure\bin\Release\G4Adventure.exe out\G4Adventure.exe
rem COPY /B G4Adventure\G4Adventure\bin\Release\G4Adventure.exe out
COPY /B G4Adventure\G4Adventure\bin\Release\Chocolate.dll out
COPY /B G4Adventure\G4Adventure\bin\Release\DxLib.dll out
COPY /B G4Adventure\G4Adventure\bin\Release\DxLib_x64.dll out
COPY /B G4Adventure\G4Adventure\bin\Release\DxLibDotNet.dll out

C:\Factory\Tools\xcp.exe doc out
C:\Factory\Tools\xcp.exe C:\Dev\Fairy\Donut3\doc out

C:\Factory\SubTools\zip.exe /PE- /RVE- /G out G4Adventure
C:\Factory\Tools\summd5.exe /M out

IF NOT "%1" == "/-P" PAUSE
