using NhlSystem;
using System.IO;
using System.Text.Json;
// See https://aka.ms/new-console-template for more information
/*  Test Plan for Perosn
 *  
 *  Test Case                               Test Data                   Expected Result/Behaviour
 *  ---------                               ---------                   -------------------------
 *  Valid FullName                          FullName: Connor McDavid    FullName = Connor McDavid
 *  
 *  Null FullName                           FullName = null             ArgumentNullException
 *  
 *  Empty FullName                          FullName = ""               ArgumentNullException
 *  
 *  Whitespace FullName                     FullName = "   "            ArgumentNullException
 *      
 *  FullName less than 3 characters         FullName = "AB"             ArgumentException
 * */

// Test Case 1: Valid FullName
var validPerson = new Person("Connor McDavid");
Console.WriteLine(validPerson.FullName);    // The value should be Connor McDavid

// Test Case 2: Null FullName
try
{
    var nullPerson = new Person(null!);
    Console.WriteLine("Null Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName is required"
}

// Test Case 3: Empty FullName
try
{
    var emptyPerson = new Person("");
    Console.WriteLine("Empty FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName is required"
}

// Test Case 4: Whitespace FullName
try
{
    var whiteSpacePerson = new Person("    ");
    Console.WriteLine("Empty FullName Test Case failed.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.ParamName); // The output should be "FullName is required"
}

// Test Case 5: Minimum Length FullName
try
{
    var invalidFullNameLengthPerson = new Person("ab");
    Console.WriteLine("Empty FullName Test Case failed.");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message); // The output should be "FullName is required"
}

// Test creating a new Team
// Create a new Coach for the team
DateTime startDate = DateTime.Parse("2021-09-02");
Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
// Create a new Team
Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
// Add 3 players to the Team 
Player player1 = new Player("Connor McDavid", Position.C, 97);
Player player2 = new Player("Evander Kane", Position.LW, 91);
Player player3 = new Player("Leeon Draisaitl", Position.C, 29);
oilersTeam.AddPlayer(player1);
oilersTeam.AddPlayer(player2);
oilersTeam.AddPlayer(player3);
// Assign Goals and Assists to each player
player1.Goals = 44;
player1.Assists = 79;
player2.Goals = 22;
player2.Assists = 17;
player3.Goals = 55;
player3.Assists = 55;

// Check that the team has 3 players
Console.WriteLine($"Players in team is {oilersTeam.Players.Count}");
// Print each player in the team
foreach (Player currentPlayer in oilersTeam.Players)
{
    Console.WriteLine(currentPlayer);
}
// Check the TotalPlayerPoints should be (44+79+22+17+55+55) = 272
Console.WriteLine($"Total player points is {oilersTeam.TotalPlayerPoints}");
Console.WriteLine();

//CreatePlayersCsvFile();
//CreateTeamJsonFile();

//var team = ReadPlayerCsvFile();
var team = ReadTeamInfoFromJsonFile();
DisplayTeamInfo(team);

static void CreatePlayersCsvFile()
{
    // Test creating a new Team
    // Create a new Coach for the team
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    // Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    // Add 3 players to the Team 
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leeon Draisaitl", Position.C, 29);
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string PlayerCsvFile = "../../../Players.csv";
    File.WriteAllLines(PlayerCsvFile, oilersTeam.Players.Select(currentPlayer => currentPlayer.ToString()).ToList());
}

static Team ReadPlayerCsvFile()
{
    const string PlayerCsvFile = "../../../Players.csv";
    Coach teamCoach = new Coach("Jay Woodcroft", DateTime.Parse("2022-02-10"));
    Team oilersTeam = new Team("Edmonton Oilers", teamCoach);
    try
    {
        string[] allLines = File.ReadAllLines(PlayerCsvFile);
        foreach (string currentLine in allLines)
        {
            try
            {
                Player currentPlayer = null!;
                bool success = Player.TryParse(currentLine , out currentPlayer);
                if (success)
                {
                    oilersTeam.AddPlayer(currentPlayer);
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine($"Format exception {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error parsing data from line with exception {ex.Message}");
            }
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error reading from file with exception {ex.Message}");
    }
    return oilersTeam;
}

static void DisplayTeamInfo(Team currentTeam)
{
    if (currentTeam == null)
    {
        Console.WriteLine("There is no team supplied");
    }
    else
    {
        // Display the team name
        Console.WriteLine($"Team: {currentTeam.TeamName}");
        // Display the coach name and hire date
        Console.WriteLine($"Coach: {currentTeam.Coach.FullName} hired on {currentTeam.Coach.StartDate.ToString("MMM dd, yyyy")}");
        // Display the name, number, position, goals, assists, and points for each player
        foreach(Player currentPlayer in currentTeam.Players)
        {
            Console.WriteLine(currentPlayer.ToString());
        }
    }
}

static Team ReadTeamInfoFromJsonFile()
{
    Team currentTeam = null!;
    try
    {
        const string TeamJsonFile = "../../../Team.json";
        string jsonString = File.ReadAllText(TeamJsonFile);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true,
        };
        currentTeam = JsonSerializer.Deserialize<Team>(jsonString, options);
    }
    catch(Exception ex)
    {
        Console.WriteLine($"Error reading from json file with exception {ex.Message}");
    }
    return currentTeam;

}
static void CreateTeamJsonFile()
{
    // Test creating a new Team
    // Create a new Coach for the team
    DateTime startDate = DateTime.Parse("2021-09-02");
    Coach oilersCoach = new Coach("Jay Woodcroft", startDate);
    // Create a new Team
    Team oilersTeam = new Team("Edmonton Oilers", oilersCoach);
    // Add 3 players to the Team 
    Player player1 = new Player("Connor McDavid", Position.C, 97);
    Player player2 = new Player("Evander Kane", Position.LW, 91);
    Player player3 = new Player("Leeon Draisaitl", Position.C, 29);
    oilersTeam.AddPlayer(player1);
    oilersTeam.AddPlayer(player2);
    oilersTeam.AddPlayer(player3);

    const string TeamJsonFile = "../../../Team.json";
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true,
    };
    string jsonString = JsonSerializer.Serialize(oilersTeam, options);
    File.WriteAllText(TeamJsonFile, jsonString);
}