namespace Day_10;
public class Day
{
    List<int> input;
    public Day()
    {
        input = File
            .ReadAllLines("Day_10\\small.txt")
            .Aggregate(new List<int>(), (list, line) => {
                if(Char.IsDigit(line.Last() ) ) {
                    list.Add(0);
                    list.Add(int.Parse(line.Substring(4) ) );
                    return list;
                } else {
                    list.Add(0);
                    return list;
                }
            });
    }
    record Ins(int ExeTime, int Value) {
        Ins Tick() => this with { ExeTime = ExeTime - 1 };
    }
    class PU
    {
        Ins curr;
        Ins[] intructions;
        int value = 1;
        public PU(string filename)
        {
            intructions = File
                .ReadAllLines(filename)
                .Select(line => {
                    if(Char.IsDigit(line.Last() ) ) {
                        return new Ins(2, int.Parse(line.Substring(4) ) );
                    } else
                        return new Ins(1,0);
                }).ToArray();
            curr = intructions[0];
        }
    }
    public int S1()
    {
        return 0;
    }
}