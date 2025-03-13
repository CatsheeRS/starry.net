@ECHO off
:menu
echo what build 2???!?!/3/45:
echo 1. windows
echo 2. linux
echo[
set /p choice="select an option: "

if "%choice%"=="1" (
    echo building for windows
    dotnet publish -r win-x64 -c Release
    goto end
)

if "%choice%"=="2" (
    echo building for linux
    dotnet publish -r linux-x64 -c Release
    goto end
)

echo invalid option
goto menu

:end