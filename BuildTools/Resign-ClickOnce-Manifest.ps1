$mage = Get-ChildItem "C:\Program Files (x86)\Microsoft SDKs\Windows" -Recurse -Filter "mage.exe" -ErrorAction SilentlyContinue | 
    Sort-Object FullName -Descending | 
    Select-Object -First 1

if (-not $mage) {
    Write-Error "mage.exe not found on this agent"
    exit 1
}

Write-Host "Using mage.exe from: $($mage.FullName)"

$publishDir = (Get-ChildItem "$env:BUILD_SOURCESDIRECTORY\src\NRatings.Client\bin\$env:BUILDCONFIGURATION\app.publish\Application Files\NRatings.Client_*" -Directory).FullName
$manifestPath = "$publishDir\NRatings.Client.exe.manifest"
$appManifest = "$env:BUILD_SOURCESDIRECTORY\src\NRatings.Client\bin\$env:BUILDCONFIGURATION\app.publish\NRatings.Client.application"

# Temporarily remove .deploy extensions
Get-ChildItem "$publishDir" -Recurse -Filter "*.deploy" | Rename-Item -NewName { $_.Name -replace '\.deploy$', '' }

# Re-sign manifest
Push-Location $publishDir
& $mage.FullName -Update $manifestPath
Pop-Location

# Restore .deploy extensions
Get-ChildItem "$publishDir" -Recurse -File | Where-Object { $_.Name -ne "NRatings.Client.exe.manifest" } | Rename-Item -NewName { $_.Name + ".deploy" }

# Update deployment manifest
& $mage.FullName -Update $appManifest -AppManifest $manifestPath
