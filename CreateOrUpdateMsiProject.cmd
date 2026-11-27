cd /d "%~dp0"
CreateMsiFromFolder --releasedir Template\bin\Release --outputdir Template.Setup --wixproj Template.Setup.wixproj --startupproj Template.csproj --wxsfile Template.wxs --licencefile license.rtf --applicationname Template --skippdb yes
pause
