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
using NhlSystem;

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