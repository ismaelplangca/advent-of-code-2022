namespace Day_08;

public class Day
{
    short[,] forest;
    public Day()
    {
        var lines = File.ReadAllLines("Day_08\\input.txt");
        
        forest = new short[lines.Count(),lines[0].Length];
        for(int row = 0; row < forest.GetLength(0); row++)
            for(int col = 0; col < forest.GetLength(1); col++)
                forest[row,col] = (short)char.GetNumericValue(lines[row][col]);

    }
    public int S1()
    {
        return Enumerable.Range(0, forest.GetLength(0) )
                .SelectMany(row =>
                    Enumerable.Range(0, forest.GetLength(1) )
                    .Select(col => new { row, col, val = forest[row, col] } )
                ).Count(x => SolveVisibility(x.val, x.row, x.col) );
    }
    public int S2()
    {
        return Enumerable.Range(0, forest.GetLength(0) )
                .SelectMany(row =>
                    Enumerable.Range(0, forest.GetLength(1) )
                    .Select(col => new { row, col, val = forest[row, col] } )
                ).Max(x => SolveScenicScore(x.val, x.row, x.col) );
    }
    bool SolveVisibility(short height, int row, int col)
    {
        var left = !Enumerable
            .Range(0, col)
            .Any(i => forest[row, i] >= height);

        var right = !Enumerable
            .Range(col + 1, forest.GetLength(0) - col - 1)
            .Any(i => forest[row, i] >= height);
        
        var top = !Enumerable
            .Range(0, row)
            .Any(i => forest[i, col] >= height);

        var bottom = !Enumerable
            .Range(row + 1, forest.GetLength(1) - row - 1)
            .Any(i => forest[i, col] >= height);

        return left || right || top || bottom;
    }
    bool AtEdge(int row, int col) => (row == 0 || row == forest.GetLength(1) - 1 || col == 0 || col == forest.GetLength(0) - 1);
    int SolveScenicScore(short height, int row, int col)
    {
        if(AtEdge(row, col) )
            return 0;

        var left = Enumerable
            .Range(0, col).Reverse()
            .TakeWhile(i => forest[row, i] < height)
            .Count();

        var right = Enumerable
            .Range(col + 1, forest.GetLength(0) ).Reverse()
            .TakeWhile(i => forest[row, i] < height)
            .Count();

        var top = Enumerable
            .Range(0, row).Reverse()
            .TakeWhile(i => forest[i, col] < height)
            .Count();

        var bottom = Enumerable
            .Range(row + 1, forest.GetLength(1) )
            .TakeWhile(i => forest[i, col] < height)
            .Count();

        return left * right * top * bottom;
    }
}