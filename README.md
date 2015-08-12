## GolfTalk

GolfTalk is a very basic, real-time score-keeping mobile site for golf tournaments/scrambles. It allows users to update their score, see other teams' scores, and also talk trash to the other teams.

## Motivation

GolfTalk exists because I wanted a way to make our employer-sponsored golf outing a little more fun. Rather than having all the teams finish their rounds, and see how everyone did at the end, I thought it would make things more interesting if we could see the scores in real-time, and also talk a little trash along the way. :)

## Docs

This project is written in C# using Entity Framework, but uses jQuery and SignalR for the score updates and trash talk messages, and a Bootstrap layout so it is mobile friendly out on the course.

The project itself is pretty self explanatory. `DataAccess\GolfInitializer.cs` contains the seed method used to populate the database with the golf course information (par for each 18 holes, yards) as well as the team member information. I wanted this to be as simple as possible so there is no real authentication - a GUID is generated for each team, and that GUID is used with the link provided to each team member who wishes to use the app. For example - `www.yoursite.com/golftalk?teamid={guid}`. This GUID is saved in a cookie so that when a user for that team enters a score, it is entered for the correct team.


## Contributors

Contributions are welcome! Some ideas I've got, but may or may not get around too as soon as I'd like, include an actual authentication system with real user accounts/logins, support for more golf courses or importing golf course information. Trash talk and chat improvments would be nice as well, such as GIF support, etc.
