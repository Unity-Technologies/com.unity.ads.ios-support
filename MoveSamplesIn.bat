@echo off
echo Moving samples from project to package.
REM Clean out what was in there
rmdir /S /Q com.unity.ads.ios-support\Samples

REM Copy over from the Samples folder in the unity project
xcopy /S /I /Q SampleProject~\Assets\Samples com.unity.ads.ios-support\Samples
