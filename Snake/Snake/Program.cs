using Snake;
var game = new Game();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("-- Welcome to the Spaghetti snake --");
Console.ResetColor();
while (true)
{
Thread.Sleep(500);
game.PlaySound("../../../sounds/hello_there.wav");
Thread.Sleep(500);
game.Run();
game.PlaySound("../../../sounds/bruh.wav");
Console.WriteLine("Would you like to play again? y/n");
var response = Console.ReadLine();
if (response != "y")
{
    Console.Clear();
    Console.WriteLine("Coward");
    break;
}
}
