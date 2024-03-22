namespace Snake;
public class Board
{
        private readonly string[,] _map =
        {
            { "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", ". ", "[]" },
            { "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]", "[]" }
        };
        
        public Snake Snake;
        private Position _food;
        private int _timer;
        public Board()
        {
            _timer = 500;
            Snake = new Snake(); 
            Snake.Add(new Position(7, 12)); 
            Snake.Add(new Position(7, 12)); 
            Snake.Add(new Position(7, 12)); 
            PlaceFood();
        }
    
    public void Draw()
    {
        Console.Clear();
        for (int y = 0; y < _map.GetLength(0); y++)
        {
            for (int x = 0; x < _map.GetLength(1); x++)
            {
                var currentPosition = new Position(x, y);
                if (Snake.Positions.Any(snek => snek.X == currentPosition.X && snek.Y == currentPosition.Y))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@ ");
                    Console.ResetColor();
                }
                else if (currentPosition.X == _food.X && currentPosition.Y == _food.Y)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u00a4 ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(_map[x, y]);
                }
            }
            Console.WriteLine();
            
        }
        Thread.Sleep(_timer);
        Snake.Move();
        CheckCollisionWithFood();
        CheckCollision();
    }
    private bool IsCollidingWithEdges(Position head)
    {
        int maxX = _map.GetLength(1) - 2; 
        int maxY = _map.GetLength(0) - 2;

        if (head.X < 1 || head.X > maxX || head.Y < 1 || head.Y > maxY)
        {
            return true;
        }
        return false;
    }
    private bool IsCollidingWithItself(Position head)
    {
        for (int i = 1; i < Snake.Positions.Count; i++) 
        {
            if (Snake.Positions[i].X == head.X && Snake.Positions[i].Y == head.Y)
            {
                return true;
            }
        }
        return false;
    }
    public void CheckCollision()
    {
        Position head = Snake.Positions[0];

        if (IsCollidingWithEdges(head) || IsCollidingWithItself(head))
        {
            Game.GameOver = true;
        }
    }
    private void PlaceFood()
    {
        var random = new Random();
        int x, y;
        do
        {
            x = random.Next(1, _map.GetLength(0) - 2);
            y = random.Next(1, _map.GetLength(1) - 2);
        } while (Snake.Positions.Any(s => s.X == x && s.Y == y));
        _food = new Position(x, y);
    }
    private void CheckCollisionWithFood()
    {
        if (Snake.Positions[0].X == _food.X && Snake.Positions[0].Y == _food.Y)
        {
            Snake.Add(Snake.Positions[Snake.Positions.Count - 1]);
            _timer -= 20;
            PlaceFood();
        }
    }
}