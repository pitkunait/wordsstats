buildrun:
	dotnet build WordsStats --configuration Release && dotnet ./WordsStats/bin/Release/net5.0/WordsStats.dll ./WordsStats/Resources/words1.txt
test:
	dotnet test Tests