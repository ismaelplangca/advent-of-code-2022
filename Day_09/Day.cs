namespace Day_09;
public class Day
{
    HashSet<Point> positions;
    List<Move> input;
    enum Direction { Up, Down, Left, Right }
    public Day()
    {
           positions = new();
           input = File.ReadAllLines("Day_09\\input.txt")
            .Select(line => {
                var dir = line[0] switch
                {
                    'U' => Direction.Up,
                    'D' => Direction.Down,
                    'L' => Direction.Left,
                    'R' => Direction.Right,
                     _  => throw new ArgumentException("Invalid input for enum", line)
                };
                return new Move(dir, int.Parse(line.Substring(2) ) );
            }).ToList();
    }
    public int S1()
    {
        var head = new Point();
        var tail = new Point();
        HashSet<Point> visited = new() { tail };
        foreach(var move in input)
        {
            for(int i = 0; i < move.Steps; i++)
            {
                head = head.Move(move.Dir);
                tail = tail.Follow(head);
                visited.Add(tail);
            }
        }
        return visited.Count();
    }
    public int S2()
    {
        var rope = Enumerable.Repeat(new Point(), 10).ToArray();
        HashSet<Point> visited = new() { rope.Last() };
        foreach(var move in input)
        {
            for(int i = 0; i < move.Steps; i++)
            {

                rope[0] = rope[0].Move(move.Dir);
                for(int j = 1; j < rope.Length; j++)
                    rope[j] = rope[j].Follow(rope[j - 1]);
                visited.Add(rope.Last() );
            }
        }
        return visited.Count();
    }
    record Move(Direction Dir, int Steps);
    record Point(int X = 0, int Y = 0)
    {
        public Point Move(Direction dir)
            => dir switch
        {
            Direction.Up    => this with { Y = Y - 1 },
            Direction.Down  => this with { Y = Y + 1 },
            Direction.Left  => this with { X = X - 1 },
            Direction.Right => this with { X = X + 1 },
            _ => this
        };
        public Point Follow(Point head)
        {
            var xdist = X - head.X;
            var xabs = Math.Abs(xdist);

            var ydist = Y - head.Y;
            var yabs = Math.Abs(ydist);

            if(xabs <= 1 && yabs <= 1)
                return this;
            else if(xdist == 0 && Math.Abs(ydist) > 1)
                return this with { Y = Y - Math.Sign(ydist) };
            else if(ydist == 0 && Math.Abs(xdist) > 1)
                return this with { X = X - Math.Sign(xdist) };
            else
                return new Point(X - Math.Sign(xdist), Y - Math.Sign(ydist) );
        }
    }
}