#!/bin/bash
IFS=$(echo -en "\n\b")
reroute="3>&1 1>&2 2>&3"

# Functions
_checkSDKs()
{
	echo "Checking available SDKs"
	SDKlist=$(dotnet --list-sdks | awk '{print $1}')
	echo "$SDKlist"
}

_PathQuit()
{
	echo "Path is still invalid.. Quitting"
	exit 0
}

_wrongPath()
{
	echo "Invalid path"
	defaultPath=$(whiptail --inputbox --nocancel "The default path (../Unity) wasn't valid. Please input valid path to the Quartzified Unity git directory" 10 50 3>&1 1>&2 2>&3)

	# Get list of components
	components=$(ls $defaultPath | sed '/-/d')

	# Check if the path was correct
	echo "$components" | grep "Quartzified" || _PathQuit
}

# Ask what version to compile (unity / universal)
version=$(whiptail --radiolist --notags "Select version" 10 30 2 "unity" "Unity" 1 "universal" "Universal" 0 3>&1 1>&2 2>&3)

# Ask if the user wants to customize components
whiptail --yesno "By default the library file will contain everything. If you want to, you can customize the components. Do you want to compile with default settings?" 10 50 3>&1 1>&2 2>&3 && isDefault="yes" || isDefault="no"

# Get path to Unity directory
defaultPath="../Unity"

# Get list of components
components=$(ls $defaultPath | sed '/-/d')

# Check if the path was correct
echo "$components" | grep "Quartzified" && _wrongPath

# Customize components
if [[ "$isDefault" == "no" ]]
then
	compClean=$(echo "$components" | sed 's/\./_/g')
	selectList=""
	for ELEMENT in $compClean
	do
		selectList+="${ELEMENT} ${ELEMENT} 1 "
	done

	selectedComponents=$(echo $selectList | xargs whiptail --nocancel --notags --checklist "Select components" 14 50 6 3>&1 1>&2 2>&3)
fi

# Check if dotnet is installed and if it is, check what SDKs are available
_checkSDKs || echo dotnet is required for compiling || exit 0

# Generate args from SDK list
SDKarg=""
firstSDK="true"
for i in $SDKlist
do
	# Set the first SDK in the list automatically enabled
	if [[ "$firstSDK" == "true" ]]
	then
		SDKarg+="${i} ${i} 1 "
		firstSDK="false"
	else
		SDKarg+="${i} ${i} 0 "
	fi
done

# Select SDK
echo $SDKarg | xargs whiptail --notags --nocancel --radiolist "Select target SDK" 12 40 3

## Argument handling
#case $1 in
#	help | -help | --help | -h)
#		echo "Usage: generate_universal.sh [path to Quartzified Unity solution directory]"
#		;;
#	"")
#		#echo "No path given! Defaulting to ../Unity"
#		#solutionPath="../Unity"
#		exit 0
#		;;
#esac

# If there's a path given, set the path to given path
[ -z $solutionPath ] && solutionPath=$1

# Get current directory to be used as a working directory
workDir=$(pwd)

# Go to the solution directory
cd $solutionPath

# Go to the src directory
cd "Quartzified-Unity"

# Get all files with .cs extension and ignore some files
srcFiles=$(find ./ -maxdepth 1 -iname "*.cs")
ignorePath="$workDir/.ignorelist"
ignoreList="$(cat $ignorePath)"
echo -e "Ignorelist:\n$ignoreList"

# Go through ignore list and remove ignored .cs files from the $srfFiles
# The ignore list is called .ignorelist and should be created into the same directory as the script
# Example .ignorelist:
# ./Sound.cs
# ./Inputs.cs

for i in $ignoreList
do
	# Read $srcFiles to temporary variable and remove the line that contains the ignored line
	temp=$(echo "$srcFiles" | sed "s|$i||g" | sed '/^$/d')

	srcFiles=$temp
done

echo -e "Files:\n$srcFiles"

# Set the path for the directory, where the script will generate Universal sources and compile the DLL
universalPath="$workDir/Universal-Generated"
_overWriteWorkDir()
{
	echo -n "Universal already exists in the working directory. Overwrite it? [Y/n] "
	read answer
	case $answer in
		y | Y | "")
			echo "Overwriting..."
			rm -rf $universalPath
			mkdir $universalPath
			;;

		n | N)
			echo "Cancelled"
			exit 0
			;;
	esac
}

# Create directory for universal version to the workdir. If it already exists, purge it's contents
mkdir "$universalPath" &>/dev/null || _overWriteWorkDir

# Copy src files to Universal path
echo "Copying source files"
cp $srcFiles $universalPath
cd $universalPath

# Generate csproj file
echo "Generating csproj file"
csProjPath="./Quartzified.csproj"
touch $csProjPath

echo '<Project Sdk="Microsoft.NET.Sdk">' >> $csProjPath
echo '    ' >> $csProjPath
echo '  <PropertyGroup>' >> $csProjPath
echo '    <TargetFramework>netstandard2.0</TargetFramework>' >> $csProjPath
echo '    <AssemblyName>Quartzified-Universal</AssemblyName>' >> $csProjPath
echo '    <RootNamespace>Quartzified</RootNamespace>' >> $csProjPath
echo '    <Company>Quartzified</Company>' >> $csProjPath
echo '    <Authors>Quartzi, ToasterBirb</Authors>' >> $csProjPath
echo '    <DocumentationFile>bin\Release\netstandard2.0\Quartzified-Universal.xml</DocumentationFile>' >> $csProjPath
echo '  </PropertyGroup>' >> $csProjPath
echo '    ' >> $csProjPath
echo '</Project>' >> $csProjPath

# Remove UnityEngine.dll reference
srcFiles="$(find ./ -maxdepth 1 -iname "*.cs")"

echo "Removing UnityEngine.dll reference"
for i in $srcFiles
do
	echo "> $i"
	temp=$(cat $i | sed '/UnityEngine/d')
	echo "$temp" > $i
done



_removeMethod()
{
	errorFile=$1

	echo "Patching $errorFile. (Vector methods and classes)"
	temp=$(cat "$errorFile")

	# Remove the original file and reconstruct it line by line
	rm $errorFile
	methodFound="false"

	for i in $temp
	do
		# Found the start of Unity method
		if [[ "$methodFound" == "false" ]] && [[ "$i" == "//(Unity)" ]]
		then
			echo "Found method! Removing it..."
			methodFound="true"
			continue
		fi

		# Found the end of Unity method
		if [[ "$methodFound" == "true" ]] && [[ "$i" == "//(!Unity)" ]]
		then
			methodFound="false"
			continue
		fi

		# Removing lines inside method
		if [[ "$methodFound" == "true" ]]
		then
			continue
		fi

		# Normal non Unity line. Add to source file
		if [[ "$methodFound" == "false" ]]
		then
			echo "$i" >> $errorFile
		fi
	done
}

# Loop trough all source files, and remove Unity methods from files that contain Unity code identifiers
for i in $srcFiles
do
	if [[ $(grep -G "Unity" $i) ]]
	then
		_removeMethod "$i"
	fi
done

# Compile the final Release DLL
echo -e "Compiling fixed version!"
dotnet build --configuration Release $csProjPath && echo -e "\e[1mBuild successfull!\e[0m" || echo -e "\e[1mSomething went wrong... Contact ToasterBirb!\e[0m"
