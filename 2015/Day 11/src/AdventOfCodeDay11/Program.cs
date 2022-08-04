using AdventOfCodeDay11;

IPasswordGenerator generator = new PasswordGenerator(); 

Console.WriteLine("Part 1");
var currentPassword = "hxbxwxba";
var nextPassword = generator.GetNextPassword(currentPassword);
Console.WriteLine($"The next password is: {nextPassword}");
Console.WriteLine();

Console.WriteLine("Part 2");
nextPassword = generator.GetNextPassword(nextPassword);
Console.WriteLine($"The next password is: {nextPassword}");