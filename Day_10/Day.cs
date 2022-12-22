namespace Day_10;
public class Day
{
    string[] ins;
    public Day()
    {
        ins = File.ReadAllLines("Day_10\\input.txt");
    }
    public int S1()
    {
        return Cycle(ins)
            .Select((reg, i) => (i + 1) * reg)
            .Where((_, i) => i == 19 || i == 59 || i == 99 || i == 139 || i == 179 || i == 219)
            .Sum();
    }
    public string S2()
    {
        return String.Join(
            Environment.NewLine,
            Cycle(ins).Select((reg, i) => {
                var pixel = i % 40;
                if(pixel == reg - 1 || pixel == reg || pixel == reg + 1)
                    return '#';
                else
                    return '.';
            })
            .Chunk(40)
            .Select(row => new String(row) )
        );
    }
    IEnumerable<int> Cycle(string[] program)
    {
        var X = 1;
        foreach(var ins in program)
        {
            if(ins.StartsWith("noop") )
                yield return X;
            else
            {
                yield return X;
                yield return X;
                X += int.Parse(ins.Split(" ").Last() );
            }
        }
    }
}