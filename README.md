[![Build status](https://ci.appveyor.com/api/projects/status/a4yu46cpnw9iowix?svg=true)](https://ci.appveyor.com/project/dlerps/lokomotiv) [![NuGet](https://img.shields.io/nuget/dt/DDev.Lokomotiv.svg)](https://www.nuget.org/packages/DDev.Lokomotiv/)


# DDev Lokomotiv (C# Deutsche Bahn API clients)
A dotnet core library for the open APIs of **Deutsche Bahn**. At this moment it only has a client for the Freeplan API (Fahrplan-Free). There are plans to add more clients for the DB API suite.

## How to use

### Requirements
This is a **.Net Standard** library (versions 1.3 & 2.0).

External dependencies:
 - `Newtonsoft.Json =<10.0.3`

### Use the Clients

This section includes exmaples of how to use the API clients. First you need to add a reference to this library. There are versions available via the public *NuGet.org* feed.

```
dotnet add package DDev.Lokomotiv
```

```
Install-Package DDev.Lokomotiv
```

#### DBFreeplanClient

```CSharp
using DDev.Lokomotiv;
using DDev.Lokomotiv.Freeplan;

DBFreeplanClient client = new DBFreeplanClient();

IList<TrainStation> locations = await client.FindLocation("Hamburg");
IList<TrainStationEvent> arrivals = await client.GetArrivals("Berlin", new DateTime(2017, 11, 20));
```

## Development

This library is developed & maintained by *Daniel Lerps*.

This is an open-source library under the MIT license. Feel free to fork this repository and add pull request if you want to contribute.

Check [Deutsche Bahn APIs](https://developer.deutschebahn.com/store/apis/list) to see which other APIs are available and still need clients.