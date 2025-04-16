$avdAndroid10Name = "Android10"
$systemImageAndroid10 = "system-images;android-30;google_apis;x86"
$device = "pixel"

# check if it exists
Write-Host "Checking if AVD '$avdAndroid10Name' exists..."
$avdList = & avdmanager list avd

if (-not ($avdList -match $avdAndroid10Name)) {
	Write-Host "AVD '$avdName' not found. Creating..."

	& avdmanager create avd -n $avdAndroid10Name -k $systemImageAndroid10 --device $device --force
} else {
	Write-Host "AVD '$avdAndroid10Name' already exists."
}

# start emulator
Write-Host "Starting emulator '$avdAndroid10Name'..."
Start-Process "$env:ANDROID_HOME\emulator\emulator.exe" -ArgumentList "-avd $avdAndroid10Name"

# wait for ready
Write-Host "Waiting for emulator to boot..."
& adb wait-for-device
while ((& adb shell getprop sys.boot_completed).Trim() -ne "1") {
    Start-Sleep -Seconds 1
    Write-Host "Still booting..."
}
Write-Host "Emulator booted and ready!"
Read-Host