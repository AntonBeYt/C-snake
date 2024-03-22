using System.Diagnostics;
namespace Snake;
public class Game
{
    public static bool GameOver { get; set; }
    private Board _board;
    public void Run()
    {
        _board = new Board();
        GameOver = false;
        while (!GameOver)
        {
            HandleInput();
            _board.Draw();
            _board.CheckCollision();
        }
        Console.WriteLine("Too bad...");
    }

    private void HandleInput()
    {
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            _board.Snake.UpdateDirection(key);
        }
    }
    public void PlaySound(string soundFilePath)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "/usr/bin/afplay",
            Arguments = $"\"{soundFilePath}\"",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true
        };
        using Process? process = Process.Start(startInfo);
        process?.WaitForExit();
    }
}