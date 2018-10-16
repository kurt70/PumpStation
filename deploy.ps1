cd C:\Users\Admin\Source\Repos\PumpStation\PumpStation
dotnet publish -r linux-arm
rem cd C:\Users\Admin\Source\Repos\PumpStation\PumpStation\bin\Debug\netcoreapp2.0\linux-arm\publish
rem psftp -pw bsdit001 pi@10.0.0.195 -b C:\Users\Admin\Source\Repos\PumpStation\PumpStation\transfercmds.txt -bc
cd C:\Users\Admin\Source\Repos\PumpStation\PumpStation
