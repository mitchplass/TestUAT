# Define AVD names to target
$targetAvds = @("Android10", "Android11")

# Get list of running emulators
$devices = & adb devices | Select-String "emulator-"

foreach ($avdName in $targetAvds) {
    $serial = "0"

    foreach ($device in $devices) {
        $serialCandidate = $device.ToString().Split("`t")[0]
        $runningAvd = adb -s $serialCandidate emu avd name 2>$null

        if ($runningAvd -eq $avdName) {
            $serial = $serialCandidate
            break
        }
    }

    if ($serial -eq "0") {
        Write-Host "No running emulator found for AVD '$avdName'. Skipping..."
        continue
    }

    # Check if AVD exists
    $avdList = & avdmanager list avd
    if ($avdList -match $avdName) {
        Write-Host "AVD '$avdName' exists."
    } else {
        Write-Host "AVD '$avdName' not found. Skipping..."
        continue
    }

    # Kill running emulator process
    Write-Host "Killing running emulator for '$avdName'..."
    & adb -s $serial emu kill

    # Kill adb server
    Write-Host "Killing adb server..."
    & adb kill-server

    # Delete emulator
    Write-Host "Deleting AVD '$avdName'..."
    & avdmanager delete avd -n $avdName

    Write-Host "AVD '$avdName' deleted successfully!"
}

Write-Host "All done!"
