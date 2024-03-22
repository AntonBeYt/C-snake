namespace Snake;
public class Snake
{
    public List<Position> Positions { get; set; }
    public Position Direction = new Position(0, -1);
    public Snake()
    {
        Positions = new List<Position>();
    }
    public void Add(Position position)
    {
        Positions.Add(position);
    }
    public void Move()
    {
        Position head = Positions[0];
        Position newHead = new Position(head.X + Direction.X, head.Y + Direction.Y);
        Positions.Insert(0, newHead);
        Positions.RemoveAt(Positions.Count - 1);
    }
    public void UpdateDirection(ConsoleKey key)
    {
        var newDirection = Direction.GetDirection(key);
        if (newDirection.X != Direction.X || newDirection.Y != Direction.Y)
        {
            Direction = newDirection;
        }
    }
}