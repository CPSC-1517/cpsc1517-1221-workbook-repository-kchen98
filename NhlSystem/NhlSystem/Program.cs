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
    var nullPerson = new Person(null);
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