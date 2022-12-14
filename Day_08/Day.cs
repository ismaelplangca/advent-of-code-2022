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
        var count = 0;
        var rowLen = forest.GetLength(0);
        var colLen = forest.GetLength(1);
        for(var row = 0; row < rowLen; row++)
            for(var col = 0; col < colLen; col++)
                if(SolveVisibility(forest[row,col], row, col) )
                    count++;
        return count;
    }
    public int S2()
    {
        var count = 0;
        var rowLen = forest.GetLength(0);
        var colLen = forest.GetLength(1);
        for(var row = 0; row < rowLen; row++)
            for(var col = 0; col < colLen; col++)
            {
                var total = SolveScenicScore(forest[row,col], row, col);
                if(total > count)
                    count = total;
            }
        return count ;
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

        var left = 0;
        for(int i = col - 1; i >= 0; i--) {
            if(forest[row, i] >= height) {
                left++;
                break;
            }
            left++;
        }

        var right = 0;
        for(int i = col + 1; i < forest.GetLength(0); i++) {
            if(forest[row, i] >= height) {
                right++;
                break;
            }
            right++;
        }

        var top = 0;
        for(int i = row - 1; i >= 0; i--) {
            if(forest[i, col] >= height) {
                top++;
                break;
            }
            top++;
        }

        var bottom = 0;
        for(int i = row + 1; i < forest.GetLength(1); i++) {
            if(forest[i, col] >= height) {
                bottom++;
                break;
            }
            bottom++;
        }
        return left * right * top * bottom;
    }
}