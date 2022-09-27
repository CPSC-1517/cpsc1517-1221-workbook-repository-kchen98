using LinqDemo; // For VideoGame
using static System.Console; // all you use access all static methods in Console class without Console prefix 

// Create a new List of VideoGame with sample data
var games = new List<VideoGame>
{
    new VideoGame("Diablo III", "Nintendo", 34.99, 1),
    new VideoGame("NBA 2K20 (PS4)", "Playstation", 49.99, 2),
    new VideoGame("NBA 2K20 (Switch)", "Nintendo", 49.99, 3),
    new VideoGame("NBA 2K20 (Xbox One)", "Xbox", 49.99, 4),
    new VideoGame("Forza Horizon 4", "Xbox", 39.99, 5),
    new VideoGame("Final Fantasy X", "Nintendo", 34.99, 6),
    new VideoGame("The Outer Worlds", "Playstation", 49.99, 7),
    new VideoGame("Kingdom Hearts 3", "Playstation", 19.99, 8),
    new VideoGame("Overwatch Legendary Edition", "Nintendo", 34.99, 9),
    new VideoGame("WWE 2K20", "Playstation", 39.99, 10),
    new VideoGame("Kingdom Hearts 3", "Xbox", 19.99, 11),
    new VideoGame("Dragon Quest Builders 2", "Playstation", 29.99, 12)
};

// Print all games to the screen using foreach statement
foreach (VideoGame currentGame in games)
{
    //Console.WriteLine(currentGame);
    WriteLine(currentGame);
}
WriteLine();

// Print all games to the screen using for statement
for (int index = 0; index < games.Count; index++)
{
    //Console.WriteLine(games[index]);
    WriteLine(games[index]);
}
WriteLine();

// Print all games to the screen using the LinQ ForEach extension function
games.ForEach(currentGame => WriteLine(currentGame)); // Single Statement
WriteLine();

// Block of Code
//games.ForEach(currentGame => {
//    WriteLine(currentGame);
//});

// Print all Nintendo games using the LinQ Where extension function to filter elements
games.Where(currentGame => currentGame.platform == "Nintendo")
    .ToList()
    .ForEach(currentGame => WriteLine(currentGame));
WriteLine();

// Print all Nintendo games using LinQ Query syntax
var nintendoGameQuery = from currentGame in games
                        where currentGame.platform == "Nintendo"
                        select currentGame;
foreach (var currentGame in nintendoGameQuery)
{
    WriteLine(currentGame);
}
WriteLine();

// Print just the Title of each VideoGame
games.Select(currentGame => currentGame.title)
    .ToList()
    .ForEach(title => WriteLine(title));
WriteLine();

// Print only distinct platform
games.Select(currentGame => currentGame.platform)
    .Distinct()
    .ToList()
    .ForEach((currentPlatform) => WriteLine(currentPlatform));
WriteLine();

// Sum all the Nintendo games
double sumOfAllNintendoGames = games
    .Where(item => item.platform == "Nintendo")
    .Sum(item => item.price);
WriteLine(sumOfAllNintendoGames);
WriteLine();

// Any games less than $20?
bool isAnyGameLessThan20 = games
    .Any(item => item.price < 20);
WriteLine(isAnyGameLessThan20);
WriteLine();

// All games less than $50
bool isAllGameLessThan50 = games
    .All(item => item.price < 50);
WriteLine(isAllGameLessThan50);
WriteLine();

// NO PC Games on sale?
bool isNoPcGameOnSale = !games
    .Any(item => item.platform == "PC Games");
WriteLine(isNoPcGameOnSale);
WriteLine();
