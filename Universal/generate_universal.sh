#!/bin/bash
IFS=$(echo -en "\n\b")

case $1 in
	help | -help | --help | -h)
		echo "Usage: generate_universal.sh [path to Quartzified Unity solution directory]"
		;;
	"")
		echo "No path given! Defaulting to ../Unity"
		solutionPath="../Unity"
		;;
esac

[ -z $solutionPath ] && solutionPath=$1

# Get current directory to be used as a working directory
workDir=$(pwd)

# Go to the solution directory
cd $solutionPath

# Go to the src directory
cd "Quartzified-Unity"

# Get all files with .cs extension and ignore some files
srcFiles=$(find ./ -maxdepth 1 -iname "*.cs" | sed '/Inputs/d; /Sound/d')
echo -e "Files:\n$srcFiles"

# Create directory for universal version to the workdir. If it already exists, purge it's contents
universalPath="$workDir/Universal_Generated"
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
mkdir "$universalPath" &>/dev/null || _overWriteWorkDir

# Copy src files
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
echo '    <DocumentationFile>bin\Release\Quartzified-Universal.xml</DocumentationFile>' >> $csProjPath
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

# Attempt to compile and get error messages
echo "Attempting to compile"
compilationOutput=$(dotnet build $csProjPath)
echo "Following errors detected:"
echo "$compilationOutput" | grep "could not be found"


_removeMethod()
{
	errorFile=$1
	search=$2

	echo "Patching $errorFile. (Vector methods and classes)"
	temp=$(cat "$errorFile")
	rm $errorFile
	methodFound="false"

	for i in $temp
	do
		# Found { of the method
		if [[ "$methodFound" == "true" ]] && [[ $(echo $i | grep "{") ]]
		then
			continue
		fi

		# Found } of the method
		if [[ "$methodFound" == "true" ]] && [[ $(echo $i | grep "}") ]]
		then
			methodFound="false"
			continue
		fi

		# Removing lines between { } of the method
		if [[ "$methodFound" == "true" ]]
		then
			continue
		fi

		if [[ $(echo $i | grep "$search") ]]
		then
			echo "Found Vector method! Removing it..."
			methodFound="true"
		else
			echo "$i" >> $errorFile
		fi
	done
}

echo "Patching source files until no errors exist"
errorFile=$(echo "$compilationOutput" | grep -w "error" | head -n 1 | awk '{print $1}' | sed 's/(.*)://g')
error=$(echo "$compilationOutput" | grep -w "error" | head -n 1 | awk '{print $9}' | sed "s/'//g")
echo "Filename: $errorFile"
echo "Error: $error"

case $error in
	Vector2 | Vector3)
		echo "Removing Vector methods"
		_removeMethod $errorFile "public static Vector"

		echo "Removing Vector class"
		_removeMethod $errorFile "public class Vector"
		;;
esac

echo -e "Compiling fixed version!"
dotnet build $csProjPath && echo -e "\e[1mBuild successfull!\e[0m" || echo -e "\e[1mSomething went wrong... Contact ToasterBirb!\e[0m"
