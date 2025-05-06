param (
	[string]$avdName
)

$device = "pixel"

# validate avdName
if ($PSBoundParameters.ContainsKey('avdName')) {
    Write-Host "AVD Name was passed: $avdName"
} else {
    Write-Host "An AVD name must be passed as a parameter"
	exit 1
}

$port = if ($avdName -like "*Android10*") { 5554 } else { 5556 }

# get correct system image
if ($avdName -like "*Android10*") {
    $systemImage = "system-images;android-29;google_apis;x86"
}
elseif ($avdName -like "*Android11*") {
    $systemImage = "system-images;android-30;google_apis;x86"
}
else {
    throw "Unknown AVD version in name '$avdName'. Please include 'Android10' or 'Android11' in the name."
}

# check if avd exists
& adb start-server
Write-Host "Checking if AVD '$avdName' exists..."
$avdList = & avdmanager list avd

if (-not ($avdList -match $avdName)) {
	Write-Host "AVD '$avdName' not found. Creating..."

	& avdmanager create avd -n $avdName -k $systemImage --device $device --force
} else {
	Write-Host "AVD '$avdName' already exists."
}

# start emulator
Write-Host "Starting emulator '$avdName'..."
Start-Process "$env:ANDROID_HOME\emulator\emulator.exe" -ArgumentList "-avd $avdName", "-port $port", "-no-audio", "-no-snapshot"#, "-no-window", "-gpu off"

# wait for ready
Write-Host "Waiting for emulator to boot..."
$serial = "emulator-$port"
& adb -s $serial wait-for-device
while ((& adb -s $serial shell getprop sys.boot_completed).Trim() -ne "1") {
    Start-Sleep -Seconds 1
    Write-Host "Still booting..."
}
Write-Host "Emulator booted and ready!"