# Sport List web api
_by Siyin Yang_

This is project written in C# with .net core 3.1.
It's run-able and deploy-able web api. 

### Steps to build
Download this repo, and run terminal inside the folder.
```
dotnet resotre
dotnet publish -c Release
```
### Steps to run
```
For local play around, please just run as debug or release mode locally in you IDE.
```

### Design and assumption
For one basketball game, there're three things need to be taken:
1. Player data
2. Team data
3. Game data
And all of above could be store as `Event`. So there's only one `Event` table.

Due to One team could have multiple games, and one games must contain two parties,
So the `Game` table will use `gameId` + `teamId` as combined key.

One player could only play within one team, so `player -> team` is `many-to-one` relationship.

For fast running and prove of concept, it's using `Entity Framework Core in-memory db` as current data access framework.
There's two reasons for choosing this:
1. It could be easily replaced by changing provider to use real database
2. Unit test could mock actual data for complicate cases, or for running e2e tests.
