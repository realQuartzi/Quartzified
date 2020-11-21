#!/bin/bash
# This script is responsible for generating the documentation for each script. It looks for method summaries and names and then creates markdown files from that information.
IFS=$(echo -en "\n\b")

# Path to the unity directory
qPath="../Unity/Quartzified-Unity"

# Get all .cs files
srcFiles=$(find $qPath/ -maxdepth 1 -iname "*.cs")

# List src files it found
echo -e "\e[1mSource files:\e[0m\n$srcFiles"

# Generate markdown files according to method summaries
echo -e "\n\e[1mStarting docs generation\e[0m"
tempPath="./Temp"
mkdir $tempPath &>/dev/null || rm -rf $tempPath && mkdir $tempPath

for i in $srcFiles
do
	# Remove everything before the last slash to get the file name
	fileName=$(echo "$i" | sed 's|\.\./Unity/Quartzified-Unity/||g')

	# Create md file for the script
	echo "Filename: $fileName"
	#touch $fileName

	# Read file content
	data="$(cat $i)"

	# Loop trough the file and find summary blocks
	count=0
	summaryFound="null"
	for j in $data
	do
		# Found the method name
		if [[ "$summaryFound" == "method" ]]
		then
			# Read the temp file
			temp=$(cat $sumTempPath)
			
			# Replace the title line with the method name and remove unused param lines
			title="### $(echo "$(echo $j | awk '{print $4}' | sed 's/(.*//g')") [Method]"

			[ -z $title ] && title="### $(echo "$(echo $j | awk '{print $3}' | sed 's/(.*//g')") [Class]"

			echo "$(echo "$temp" | sed "s/title/$title/; /<param>$/d")" > $sumTempPath

			summaryFound="null"
			continue
		fi


		# Found the beginning of the summary
		if [[ $(echo $j | grep "<summary>") ]]
		then
			# Unfinished summary detected. Maybe it was a class summary?
			if [[ "$summaryFound" == "param" ]]
			then
				summaryFound="method"
				continue
			fi

			let count+=1
			echo -en "\rFound summaries: $count"
			summaryFound="summary"

			# Create temp file for this summary
			sumTempPath="$tempPath/sum_($fileName)_$count.tmp"
			touch $sumTempPath

			echo "title" >> $sumTempPath
			echo "#### <file>" >> $sumTempPath
			echo "<summary>" >> $sumTempPath
			echo "" >> $sumTempPath
			echo "#### Parameters:" >> $sumTempPath
			echo "**name**: <param>" >> $sumTempPath
			echo "**name**: <param>" >> $sumTempPath
			echo "**name**: <param>" >> $sumTempPath
			echo "**name**: <param>" >> $sumTempPath

			continue
		elif [[ $(echo $j | grep "</summary>") ]] && [[ "$summaryFound" == "summary" ]]
		then
			summaryFound="param"
			continue
		fi

		# Invalid summary
		if [[ "$summaryFound" == "param" ]] && [[ "$j" == "//(Unity)" ]]
		then
			summaryFound="null"
			rm $sumTempPath
			continue
		fi

		if [[ "$summaryFound" == "summary" ]]
		then
			# Read the temp file
			temp=$(cat $sumTempPath)

			summary=$(echo $j | sed 's|/// ||g; s|^[[:space:]]*||g')

			# Replace summary line with the summary
			echo "$(echo "$temp" | sed "s|<summary>|$summary|g")" > $sumTempPath
			continue
		fi

		if [[ $(echo $j | grep "<param name") ]] && [[ "$summaryFound" == "param" ]]
		then
			param=$(echo "$j" | sed 's|/// ||g; s/<param name=".*">//g; s|</param>||g; s/^[[:space:]]*//g')
			paramName=$(echo "$j" | sed 's|/// <param name="||g; s/">.*//g; s/^[[:space:]]*//g')

			# Read the temp file
			temp=$(cat $sumTempPath)
			
			# Replace one param line with this parameter
			echo "$(echo "$temp" | sed "0,/name/s//$paramName/; 0,/<param>$/s//$param/")" > $sumTempPath
			continue
		fi

		if [[ $(echo $j | grep "<returns>") ]]
		then
			summaryFound="method"
			continue
		fi
	done

	echo ""
done

# Get list of temp files
tmpList=$(find . -iname "*.tmp" | sort -V)

# Remove duplicate files
md5List="./.md5list"
touch $md5List
echo -e "\n\e[1mRemoving duplicates\e[0m"

let duplicateCount=0

for i in $tmpList
do
	md5=$(md5sum $i)

	if [[ $(grep $(echo $md5 | awk '{print $1}' ) $md5List) ]]
	then
		let duplicateCount+=1
		echo -en "\rDuplicates removed: $duplicateCount"
	else
		echo $md5 >> $md5List
	fi
done

echo ""

tmpList=$(cat $md5List)
rm $md5List

docsPath="./Documentation.md"
rm $docsPath
touch $docsPath

echo "# Documentation" >> $docsPath

for j in $tmpList
do
	cat $(echo $j | awk '{print $2}') | sed "s/<file>/$(echo $j | sed 's/^.*(//; s/).*$//')/g" >> $docsPath
	echo "" >> $docsPath
	echo "---" >> $docsPath
	echo "" >> $docsPath
done

echo -e "\nRemoving temp files"
rm -rf $tempPath
