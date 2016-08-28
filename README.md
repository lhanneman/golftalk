## GolfTalk

GolfTalk is a very basic, real-time score-keeping mobile site for golf tournaments/scrambles. It allows users to update their score, see other teams' scores, and also talk trash to the other teams.

## Motivation

GolfTalk exists because I wanted a way to make our employer-sponsored golf outing a little more fun. Rather than having all the teams finish their rounds, and see how everyone did at the end, I thought it would make things more interesting if we could see the scores in real-time, and also talk a little trash along the way. :)

## Installation

No installation necessary - just open the solution in Visual Studio. This project is written in C# using Entity Framework, but uses jQuery and SignalR for the score updates and trash talk messages, and a Boostrap layout so it is mobile friendly out on the course. It can be easily deployed to Azure or any other hosting service to get up and running in no time.

## Docs

The project itself is pretty self explanatory. `DataAccess\GolfInitializer.cs` contains the seed method used to populate the database with the golf course information (par for each 18 holes, yards) as well as the team member information. I wanted this to be as simple as possible so there is no real authentication - a GUID is generated for each team, and that GUID is used with the link provided to each team member who wishes to use the app. For example - `www.yoursite.com/golftalk?teamid={guid}`. This GUID is saved in a cookie so that when a user for that team enters a score, it is entered for the correct team.


## Contributors

Contributions are welcome!