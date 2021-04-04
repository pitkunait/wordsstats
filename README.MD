# Substring occurence counter

If `make` is available:

- Build counter: `make build`
- Run tests: `make tests`
- Run words counter `make run`
- Plot word frequencies bar plot `make plot` (must install python requirements first `pip install -r ./Plotter/requirements.txt`)

If `make` is unavailable:
- `dotnet build WordsStats --configuration Release` to build application
- `dotnet test Tests` to run tests
- `dotnet ./WordsStats/bin/Release/net5.0/WordsStats.dll ./WordsStats/Resources/words1.txt` to count words from given file
- `dotnet ./WordsStats/bin/Release/net5.0/WordsStats.dll ./WordsStats/Resources/words1.txt > data.txt && python ./Plotter/barplot.py data.txt` to count words from given file and plot results  (must install python requirements first `pip install -r ./Plotter/requirements.txt`)