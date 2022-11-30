# Get the file name from the C# project name
$ProjectName = Get-Item ../src/*.csproj | % {$_.Name -replace $_.Extension}

$Dll = Get-ChildItem -Recurse "..\src\bin\Release\*\$ProjectName.dll"

Copy-Item $Dll -Destination .
Compress-Archive -Path "$ProjectName.dll" -Force -DestinationPath ./$ProjectName.zip
