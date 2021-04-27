# Simple-DotNetCore-Project

## Introduction:

This project implements reading and aggregating stock market data from two different sources and expose the aggregated result as REST endpoints. The first endpoint returns a paged list of latest prices with pagination and custom sort order, the second returns the latest price and some additional field for a given tiker entry. Samples of the input data are provided as csv files. The csv files are in 'CSVFiles' folder in the root of project.


## Launching the server

To launch the application server please follow these instructions:

1- open a cmd in the root folder of the project (StockMarketDP folder)

2- enter these commands:

    dotnet restore
    dotnet run

then open a browser and go to http://localhost:5000/swagger/index.html

=> Also you can open the project solution file in Visual Studio and run the program using IIS Express.

### Requirements

'Needs .Net core 3.1 installed on your computer'
