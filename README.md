[![Nuget version][nuget-image]][nuget-url]

# Royale Wrapper

<img align="right" width="100" height"100" src="./icon.png">

A handy C# wrapper for the [Official Clash Royale API](https://developer.clashroyale.com) using .NET Standard 2.0

## Installation

```
Install-Package RoyaleWrapper
```

## Get Started

```csharp
// Get the United States Location
var locations = await client.GetLocationsAsync();
var us = locations.First(x => x.Name == "United States");

// Get Top 10 Players in the US
var players = await client.GetLocationRankingsPlayersAsync(us.Id, limit: 10);

// Get the battle log for the top player
var topPlayer = players.First();
var battles = await client.GetBattleLogAsync(topPlayer.Tag);

// Look at their PvP victories
var victories = battles.Where(x => x.Type == "PvP" && x.Team.First().TrophyChange > 0);

// Who did they beat?
var losers = victories.SelectMany(x => x.Opponent);

// What was the most recent losers highest trophy count?
var recentLoser = await client.GetPlayerAsync(losers.First().Tag);
var highestTrophies = recentLoser.BestTrophies;
```

## Features

- [X] **Full API coverage as of `2018-08-15`** - review the [API Docs](https://developer.clashroyale.com/#/documentation)
- [X] **Paging support** - using `limit` and `NextAsync()`/`PreviousAsync()` - [checkout the paging test](./RoyaleWrapper.Test/Paging.cs)
- [X] **Fully Async** - keeping your requests efficient

**Still To Come**
- [ ] **Helpful Properties on Classes** - Because having to look at `TrophyChange` to see who won is terrible.
- [ ] **Optional Request Caching** - To make repetitive queries snappy

------------------------

### Contributing

Want to help out? Great! Here are a few notes:

- Be sure to setup tests for any additional methods you add to the `Client`
- Be sure that tests pass :)
- Setup your API Key in the unit tests by adding a `appsettings.json` with `{"config":{"key":"YOUR_API_KEY"}}` to `/RoyaleWrapper.Test`


[nuget-image]: https://img.shields.io/nuget/v/RoyaleWrapper.svg?style=flat-square
[nuget-url]: https://www.nuget.org/packages/RoyaleWrapper/