# Gintama Web Scraper

## Goal:

This project was born with the idea of ​​creating a Tier list of the plot arcs of the anime "Gintama", (taking advantage of the fact that I am rewatching the series).

For this I need to do 4 things:
1) Obtain the info of all the plot arcs (quickly and easily).
2) Save them in a database or Json file.
3) Get that data from a Rest API.
4) And finally create a client web application that consumes said API, with which you can make the Tier list.

## How to run

1. Install [.NET 5 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) and [MySQL](https://www.mysql.com) Server to run.
2. Clone the repository.
3. Open a terminal and navigate to the root project folder.
4. Edit the file called ```user-db-config.json``` with your MySQL credentials.
5. Now run ```dotnet build``` to compile the project.
6. Finally run ```dotnet run --project GintamaArcsScrapper``` to run the app.

## Contact

Created by [@retaLazyCodes](https://github.com/retaLazyCodes) - feel free to contact me!
