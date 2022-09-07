// See https://aka.ms/new-console-template for more information
using OOPReview1;

var senators = new NhlTeam(NhlConference.Eastern, NhlDivision.Atlantic, "Senators", "Ottawa");

senators.GamesPlayed = 82;
senators.Wins = 33;
senators.Losses = 42;
senators.OvertimeLosses = 7;
// Print Points - should be 73

Console.WriteLine(senators);
Console.WriteLine($"Points = {senators.Points}");

