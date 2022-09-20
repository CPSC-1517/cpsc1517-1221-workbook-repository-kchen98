// See https://aka.ms/new-console-template for more information
using OOPReview1;

// Test creating a new Roster with valid values
// NhlRoster validPlayer1 = new NhlRoster(97, "Connor McDavid", NhlPosition.C); or
var validPlayer1 = new NhlRoster(97, "Connor McDavid", NhlPosition.C);
// Print the validPlayer1 object to the screen 
// The output should be "97, Connor MCDavid, C"
Console.WriteLine(validPlayer1);

try
{
    // Test creating a new Roster with an invalid No
    NhlRoster invalidPlayer1 = new NhlRoster(100, "Leon Draisatil", NhlPosition.C);
    // An ArgumentOutOfRangeException should be thrown with a messag indentifying what the error is
}
catch (ArgumentOutOfRangeException ex)
{
    // The ParamName of the exception should be
    // "Player number must be between 0 and 98"
    // Do Not Use Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ParamName);
}

try
{
    // Test creating a new Roster with an invalid Player Name
    NhlRoster invalidPlayer1 = new NhlRoster(77, "", NhlPosition.C);
    // An ArgumentException should be thrown with a message indentifying what the error is 
}
catch (ArgumentException ex)
{
    // The ParamName of the exception should be
    // "Name must contain text"
    // Do Not Use Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ParamName);
}

try
{
    // Test creating a new Roster with an invalid Player Name
    NhlRoster invalidPlayer1 = new NhlRoster(77, null!, NhlPosition.C);
    // An ArgumentException should be thrown with a message indentifying what the error is 
}
catch (ArgumentException ex)
{
    // The ParamName of the exception should be
    // "Name must contain text"
    // Do Not Use Console.WriteLine(ex.Message);
    Console.WriteLine(ex.ParamName);
}
var senators = new NhlTeam(NhlConference.Eastern, NhlDivision.Atlantic, "Senators", "Ottawa");

senators.GamesPlayed = 82;
senators.Wins = 33;
senators.Losses = 42;
senators.OvertimeLosses = 7;
// Print Points - should be 73

Console.WriteLine(senators);
Console.WriteLine($"Points = {senators.Points}");

