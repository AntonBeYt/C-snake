namespace Snake;
public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    public Position GetDirection(ConsoleKey key)
    {
        var newDirection = new Position(0, -1);
        if (key == ConsoleKey.UpArrow)
        {  
            newDirection = new Position(0, -1);
            
        } else if (key == ConsoleKey.RightArrow)
        {
            newDirection = new Position(1, 0);
            
        } else if (key == ConsoleKey.DownArrow)
        {
            newDirection = new Position(0, 1);
            
        } else if (key == ConsoleKey.LeftArrow)
        {
            newDirection = new Position(-1, 0);
        }
        return newDirection;
    }
}
