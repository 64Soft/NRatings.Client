$publishDir = (Get-ChildItem "$(Build.SourcesDirectory)\src\NRatings.Client\bin\$(BuildConfiguration)\app.publish\Application Files\NRatings.Client_*" -Directory).FullName
$manifestPath = "$publishDir\NRatings.Client.exe.manifest"
$appManifest = "$(Build.SourcesDirectory)\src\NRatings.Client\bin\$(BuildConfiguration)\app.publish\NRatings.Client.application"

# Temporarily remove .deploy extensions
Get-ChildItem "$publishDir" -Recurse -Filter "*.deploy" | Rename-Item -NewName { $_.Name -replace '\.deploy$', '' }

# Re-sign manifest
Push-Location $publishDir
& "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8.1 Tools\mage.exe" -Update $manifestPath
Pop-Location

# Restore .deploy extensions
Get-ChildItem "$publishDir" -Recurse -File | Where-Object { $_.Name -ne "NRatings.Client.exe.manifest" } | Rename-Item -NewName { $_.Name + ".deploy" }

# Update deployment manifest
& "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8.1 Tools\mage.exe" -Update $appManifest -AppManifest $manifestPath
