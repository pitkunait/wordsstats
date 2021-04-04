build:
	dotnet build WordsStats --configuration Release
test:
	dotnet test Tests
run:
	dotnet ./WordsStats/bin/Release/net5.0/WordsStats.dll ./WordsStats/Resources/words1.txt
plot:
	make run -s > data.txt && python ./Plotter/barplot.py data.txt