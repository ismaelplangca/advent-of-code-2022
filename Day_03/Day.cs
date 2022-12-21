namespace Day_03;
public class Day
{
    List<string> input;

    public Day()
    {
        input = File.ReadAllLines("Day_03\\input.txt").ToList();
    }
    public int S1()
    {
        return input
            .Select(SplitInHalf)
            .Select(a => a[0].Intersect(a[1]).First() )
            .Sum(GetPriority);
    }
    public int S2()
    {
        return input
            .Chunk(3)
            .Select(a => a[0].Intersect(a[1]).Intersect(a[2]).First() )
            .Sum(GetPriority);
    }
    string[] SplitInHalf(string line)
    {
        var mid = line.Length / 2;
        return new string[]{line.Substring(0, mid), line.Substring(mid)};
    }
    int GetPriority(char c) => Char.IsUpper(c) switch
    {
        true => (int)c - 38,
        false => (int)c - 96
    };
}
