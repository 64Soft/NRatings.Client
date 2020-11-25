#Requires -Version 2.0
<#
.SYNOPSIS
   This script updates the ClickOnce version in a project file (.csproj or .vbproj), and may update the MinimumRequiredVersion to be this same version.

.DESCRIPTION
   This script updates the current ClickOnce version in a project file (.csproj or .vbproj), and may update the MinimumRequiredVersion to be this same version.
   Setting the MinimumRequiredVersion property forces the ClickOnce application to update automatically without prompting the user.

.PARAMETER ProjectFilePath
	(required) Path of the .csproj and .vbproj file to process.

.PARAMETER Version
	The Version to update the ClickOnce version number to. This version must be of the format Major.Minor.Build or Major.Minor.Build.Revision.
	The Build and Revision parts will be overridden by the BuildSystemsBuildId parameter, if it is provided.
	The Revision parts will be overriden by the IncrementProjectFilesRevision parameter, if it is provided.

.PARAMETER BuildSystemsBuildId
	The build system's unique and auto-incrementing Build ID. This will be used to generate the Build and Revision parts of the new Version number.
	This will override the Build and Revision specified in the Version parameter, if it was provided.
	This parameter cannot be used with the IncrementProjectFilesRevision parameter.

.PARAMETER IncrementProjectFilesRevision
	If this switch is provided, the Revision from the project file will be incremented and used in the new ClickOnce Version.
	This will override the Revision specified in the Version parameter, if it was provided.
	This parameter cannot be used with the BuildSystemsBuildId parameter.

.PARAMETER UpdateMinimumRequiredVersionToCurrentVersion
	If this switch is provided, the ClickOnce MinimumRequiredVersion will be updated to match the new Version.
	Setting the MinimumRequiredVersion property forces the ClickOnce application to update automatically without prompting the user.

.PARAMETER PublishUrl
	If this string is provided, it will update the PublishUrl. If it is not provided, the PublishUrl will remain what it is currently. This should be a UNC type file path (e.g. \\servername\foldername)

.PARAMETER InstallUrl
	If this string is provided, it will update the InstallUrl. If it is not provided the InstallUrl will remain what it is currently. This should be a URL type path (e.g. http://servername/foldername)

.EXAMPLE
	Update a project file's ClickOnce version to the specified version.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -Version '1.2.3.4'

.EXAMPLE
	Update the Build and Revision parts of a project file's ClickOnce version, based on a unique, auto-incrementing integer, such as a build system's Build ID.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -BuildSystemsBuildId 123456

.EXAMPLE
	Increment the Revision of a project file's ClickOnce version.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -IncrementProjectFilesRevision

.EXAMPLE
	Update a project file's ClickOnce Minimum Required Version to match its current version.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -UpdateMinimumRequiredVersionToCurrentVersion

.EXAMPLE
	Update a project file's ClickOnce version, ignoring the Revision part and incrementing the Revision stored in the file, and update the Minimum Required Version to be this new version.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -Version '1.2.3' -IncrementProjectFilesRevision -UpdateMinimumRequiredVersionToCurrentVersion

.EXAMPLE
	Update a project file's ClickOnce version using both Version and a unique, auto-incrementing integer, such as a build system's Build ID. This will keep the major and minor versions you specify but update the build and revision (e.g. 1.0.1.5745)

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -Version 1.0.0.0 -BuildSystemBuildId 123456

.EXAMPLE
	Update a project file's ClickOnce version and its install and publish url values.

	& .\Set-ProjectFilesClickOnceVersion.ps1 -ProjectFilePath "C:\SomeProject.csproj" -Version 1.0.1.9 -PublishUrl "\\fileshare\foldername" -InstallUrl "http://fileshare/foldername"


.LINK
	Project Home: https://github.com/deadlydog/Set-ProjectFilesClickOnceVersion

.NOTES
	Author: Daniel Schroeder
	Version: 2.1.0
#>
[CmdletBinding(DefaultParameterSetName="UseBuildSystemsBuildId")]
Param
(
	[Parameter(Mandatory=$true,HelpMessage="The project file to update the ClickOnce Version in.")]
	[string]$ProjectFilePath = [string]::Empty,

	[Parameter(Mandatory=$false,HelpMessage="The new version number to use for the ClickOnce application.")]
	[ValidatePattern('(?i)(^(\d+(\.\d+){2,3})$)')]
	[string]$Version = [string]::Empty,

	[Parameter(Mandatory=$false,HelpMessage="The build system's unique, auto-incrementing Build ID. This will be used to generate the Build and Revision version parts.",ParameterSetName="UseBuildSystemsBuildId")]
	[Alias("BuildId")]
	[Alias("Id")]
	[int]$BuildSystemsBuildId = -1,

	[Parameter(Mandatory=$false,HelpMessage="Use and increment the Revision part of the version number stored in the project file.",ParameterSetName="UseFilesRevision")]
	[Alias("IncrementRevision")]
	[switch]$IncrementProjectFilesRevision = $false,

	[Parameter(Mandatory=$false,HelpMessage="When the switch is provided, the ClickOnce Minimum Required Version will be updated to this new version.")]
	[switch]$UpdateMinimumRequiredVersionToCurrentVersion = $false,

	[Parameter(Mandatory = $false, HelpMessage="The Publish URL to update to.")]
	[string]$PublishUrl = [string]::Empty,

	[Parameter(Mandatory = $false, HelpMessage="The Install URL to update to.")]
	[string]$InstallUrl = [string]::Empty
)

# If we can't find the project file path to update, exit with an error.
$ProjectFilePath = Resolve-Path -Path $ProjectFilePath
if (!(Test-Path $ProjectFilePath -PathType Leaf))
{
	throw "Could not locate the project file to update at the path '$ProjectFilePath'."
}

# If there are no changes to make, just exit.
if ([string]::IsNullOrEmpty($Version) -and $BuildSystemsBuildId -lt 0 -and !$IncrementProjectFilesRevision -and !$UpdateMinimumRequiredVersionToCurrentVersion -and [string]::IsNullOrEmpty($InstallUrl) -and [string]::IsNullOrEmpty($PublishUrl))
{
	Write-Warning "None of the following parameters were provided, so nothing will be changed: Version, BuildSystemsBuildId, IncrementProjectFilesRevision, UpdateMinimumRequiredVersionToCurrentVersion, InstallUrl, and PublishUrl"
	return
}

function Get-XmlNamespaceManager([xml]$XmlDocument, [string]$NamespaceURI = "")
{
    # If a Namespace URI was not given, use the Xml document's default namespace.
	if ([string]::IsNullOrEmpty($NamespaceURI)) { $NamespaceURI = $XmlDocument.DocumentElement.NamespaceURI }

	# In order for SelectSingleNode() to actually work, we need to use the fully qualified node path along with an Xml Namespace Manager, so set them up.
	[System.Xml.XmlNamespaceManager]$xmlNsManager = New-Object System.Xml.XmlNamespaceManager($XmlDocument.NameTable)
	$xmlNsManager.AddNamespace("ns", $NamespaceURI)
    return ,$xmlNsManager		# Need to put the comma before the variable name so that PowerShell doesn't convert it into an Object[].
}

function Get-FullyQualifiedXmlNodePath([string]$NodePath, [string]$NodeSeparatorCharacter = '.')
{
    return "/ns:$($NodePath.Replace($($NodeSeparatorCharacter), '/ns:'))"
}

function Get-XmlNode([xml]$XmlDocument, [string]$NodePath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	$xmlNsManager = Get-XmlNamespaceManager -XmlDocument $XmlDocument -NamespaceURI $NamespaceURI
	[string]$fullyQualifiedNodePath = Get-FullyQualifiedXmlNodePath -NodePath $NodePath -NodeSeparatorCharacter $NodeSeparatorCharacter

	# Try and get the node, then return it. Returns $null if the node was not found.
	$node = $XmlDocument.SelectSingleNode($fullyQualifiedNodePath, $xmlNsManager)
	return $node
}

function Get-XmlNodes([xml]$XmlDocument, [string]$NodePath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	$xmlNsManager = Get-XmlNamespaceManager -XmlDocument $XmlDocument -NamespaceURI $NamespaceURI
	[string]$fullyQualifiedNodePath = Get-FullyQualifiedXmlNodePath -NodePath $NodePath -NodeSeparatorCharacter $NodeSeparatorCharacter

	# Try and get the nodes, then return them. Returns $null if no nodes were found.
	$nodes = $XmlDocument.SelectNodes($fullyQualifiedNodePath, $xmlNsManager)
	return $nodes
}

function Get-XmlElementsTextValue([xml]$XmlDocument, [string]$ElementPath, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	# Try and get the node.
	$node = Get-XmlNode -XmlDocument $XmlDocument -NodePath $ElementPath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter

	# If the node already exists, return its value, otherwise return null.
	if ($node) { return $node.InnerText } else { return $null }
}

function Set-XmlElementsTextValue([xml]$XmlDocument, [string]$ElementPath, [string]$TextValue, [string]$NamespaceURI = "", [string]$NodeSeparatorCharacter = '.')
{
	# Try and get the node.
	$node = Get-XmlNode -XmlDocument $XmlDocument -NodePath $ElementPath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter

	# If the node already exists, update its value.
	if ($node)
	{
		$node.InnerText = $TextValue
	}
	# Else the node doesn't exist yet, so create it with the given value.
	else
	{
		# Create the new element with the given value.
		$elementName = $ElementPath.Substring($ElementPath.LastIndexOf($NodeSeparatorCharacter) + 1)
 		$element = $XmlDocument.CreateElement($elementName, $XmlDocument.DocumentElement.NamespaceURI)
		$textNode = $XmlDocument.CreateTextNode($TextValue)
		$element.AppendChild($textNode) > $null

		# Try and get the parent node.
		$parentNodePath = $ElementPath.Substring(0, $ElementPath.LastIndexOf($NodeSeparatorCharacter))
		$parentNode = Get-XmlNode -XmlDocument $XmlDocument -NodePath $parentNodePath -NamespaceURI $NamespaceURI -NodeSeparatorCharacter $NodeSeparatorCharacter

		if ($parentNode)
		{
			$parentNode.AppendChild($element) > $null
		}
		else
		{
			throw "$parentNodePath does not exist in the xml."
		}
	}
}

function Set-XmlNodesElementTextValue([xml]$xml, $node, $elementName, $textValue)
{
	if ($null -eq $node.($elementName))
	{
		$element = $xml.CreateElement($elementName, $xml.DocumentElement.NamespaceURI)
		$textNode = $xml.CreateTextNode($textValue)
		$element.AppendChild($textNode) > $null
		$node.AppendChild($element) > $null
	}
	else
	{
		$node.($elementName) = $textValue
	}
}

# Define the max value that a version part is allowed to have (16-bit int).
[int]$maxVersionPartValueAllowed = 65535

# The regex used to obtain the Major.Minor.Build.Revision parts from a version number (revision is optional).
$versionNumberRegex = New-Object System.Text.RegularExpressions.Regex "(?<MajorMinor>^\d+\.\d+)\.(?<Build>\d+)(\.(?<Revision>\d+))?", SingleLine

# Open the Xml file and get the <PropertyGroup> elements with the ClickOnce properties in it.
[xml]$xml = Get-Content -Path $ProjectFilePath
$propertyGroups = Get-XmlNodes -XmlDocument $xml -NodePath 'Project.PropertyGroup'
[Array]$clickOncePropertyGroups = $propertyGroups | Where-Object {
	try
	{
		return ($_.ApplicationVersion -ne $null)
	}
	catch { return $false }
}

# If no ClickOnce deployment settings were found throw an error.
if ($null -eq $clickOncePropertyGroups -or $clickOncePropertyGroups.Count -eq 0)
{
	throw "'$ProjectFilePath' does not appear to have any ClickOnce deployment settings in it. You must publish the project at least once to create the ClickOnce deployment settings."
}

# Iterate over each <PropertyGroup> that has ClickOnce deployment settings and update them.
$numberOfClickOncePropertyGroups = $clickOncePropertyGroups.Length
$numberOfClickOncePropertyGroupsProcessed = 0
foreach ($clickOncePropertyGroup in $clickOncePropertyGroups)
{
	$numberOfClickOncePropertyGroupsProcessed++
	Write-Verbose "Processing ClickOnce property group $numberOfClickOncePropertyGroupsProcessed of $numberOfClickOncePropertyGroups in file '$ProjectFilePath'."

	# If publish url is provided, update it.
	if (![string]::IsNullOrEmpty($PublishUrl))
	{
		Write-Verbose "Publish Url is '$PublishUrl'"
		Write-Output "Updating PublishUrl to be '$PublishUrl'"
		Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'PublishUrl' -textValue "$PublishUrl"
	}

	# If install url is provided, update it.
	if (![string]::IsNullOrEmpty($InstallUrl))
	{
		Write-Verbose "Install Url is '$InstallUrl'"
		Write-Output "Updating Install Url to be '$InstallUrl'"
		Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'InstallUrl' -textValue "$InstallUrl"
	}

	# If the Version to use was not provided, get it from the project file.
	$appVersion = $Version
	if ([string]::IsNullOrEmpty($appVersion))
	{
		$appVersion = $clickOncePropertyGroup.ApplicationVersion
	}

	# Get the Major, Minor, and Build parts of the version number.
	$majorMinorBuildMatch = $versionNumberRegex.Match($appVersion)
	if (!$majorMinorBuildMatch.Success)
	{
		throw "The version number '$appVersion' does not seem to have valid Major.Minor.Build version parts."
	}
	$majorMinor = $majorMinorBuildMatch.Groups["MajorMinor"].Value
	[int]$build = $majorMinorBuildMatch.Groups["Build"].Value
	[int]$revision = -1

	# If a Revision was specified in the Version, get it.
	if (![string]::IsNullOrWhiteSpace($majorMinorBuildMatch.Groups["Revision"]))
	{
		$revision = [int]::Parse($majorMinorBuildMatch.Groups["Revision"])
	}

	# If we should be using the BuildSystemsBuildId for the Build and Revision.
	if ($BuildSystemsBuildId -gt -1)
	{
		# Use a calculation for the Build and Revision to prevent the Revision value from being too large, and to increment the Build value as the BuildSystemsBuildId continues to grow larger.
		$build = [int][Math]::Floor($BuildSystemsBuildId / $maxVersionPartValueAllowed)
		$revision = $BuildSystemsBuildId % $maxVersionPartValueAllowed

		Write-Verbose "Translated BuildSystemsBuildId '$BuildSystemsBuildId' into Build.Revision '$build.$revision'."
	}

	# Else if we should be incrementing the file's revision, or we don't have the revision yet, get the Revision from the project file.
	if ($IncrementProjectFilesRevision -or $revision -eq -1)
	{
		# If the Revision is missing from the file, or not in a valid format, throw an error.
		$applicationRevisionString = $clickOncePropertyGroup.ApplicationRevision
		if ($null -eq $applicationRevisionString)
		{
			throw "Could not find the <ApplicationRevision> element in the project file '$ProjectFilePath'."
		}
		if (!($applicationRevisionString -imatch '^\d+$'))
		{
			throw "The <ApplicationRevision> elements value '$applicationRevisionString' in the file '$ProjectFilePath' does not appear to be a valid integer."
		}

		$revision = [int]::Parse($applicationRevisionString)

		# If the Revision should be incremented, do it.
		if ($IncrementProjectFilesRevision)
		{
			$revision = $revision + 1

			# Make sure the Revision version part is not greater than the max allowed value.
			if ($revision -gt $maxVersionPartValueAllowed)
			{
				Write-Warning "The Revision value '$revision' to use for the last part of the version number is greater than the max allowed value of '$maxVersionPartValueAllowed'. The modulus will be used for the revision instead. If this results in your ClickOnce deployment not downloading the latest update and giving an error message like 'Cannot activate a deployment with earlier version than the current minimum required version of the application.' then you will need to increment the Build part of the ClickOnce <ApplicationVersion> value stored in the project file."
				$revision %= $maxVersionPartValueAllowed
			}
		}
	}

	# Create the version number to use for the ClickOnce version.
	$newMajorMinorBuild = "$majorMinor.$build"
	$newVersionNumber = "$newMajorMinorBuild.$revision"
	Write-Output "Updating version number to be '$newVersionNumber'."

	# Write the new values to the file.
	Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'ApplicationVersion' -textValue "$newMajorMinorBuild.%2a"
	Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'ApplicationRevision' -textValue $revision.ToString()
	if ($UpdateMinimumRequiredVersionToCurrentVersion)
	{
		Write-Output "Updating minimum required version to be '$newVersionNumber'."
		Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'MinimumRequiredVersion' -textValue "$newVersionNumber"
		Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'UpdateRequired' -textValue 'true'
		Set-XmlNodesElementTextValue -xml $xml -node $clickOncePropertyGroup -elementName 'UpdateEnabled' -textValue 'true'
	}
}

# Save the changes.
$xml.Save($ProjectFilePath)
