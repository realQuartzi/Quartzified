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



_removeMethod()
{
	errorFile=$1

	echo "Patching $errorFile. (Vector methods and classes)"
	temp=$(cat "$errorFile")
	rm $errorFile
	methodFound="false"

	for i in $temp
	do
		# Found { of the method
		if [[ "$methodFound" == "false" ]] && [[ "$i" == "//(Unity)" ]]
		then
			echo "Found method! Removing it..."
			methodFound="true"
			continue
		fi

		# Found } of the method
		if [[ "$methodFound" == "true" ]] && [[ "$i" == "//(!Unity)" ]]
		then
			methodFound="false"
			continue
		fi

		# Removing lines between { } of the method
		if [[ "$methodFound" == "true" ]]
		then
			continue
		fi

		# Normal line. Add to source file
		if [[ "$methodFound" == "false" ]]
		then
			echo "$i" >> $errorFile
		fi
	done
}

echo "Patching source files until no errors exist"

for i in $srcFiles
do
	if [[ $(grep -G "Unity" $i) ]]
	then
		_removeMethod "$i"
	fi
done

echo -e "Compiling fixed version!"
dotnet build $csProjPath && echo -e "\e[1mBuild successfull!\e[0m" || echo -e "\e[1mSomething went wrong... Contact ToasterBirb!\e[0m"
