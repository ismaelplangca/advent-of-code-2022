namespace Day_11;
public class Day
{
    string[] monkeys;
    public Day()
    {
        monkeys = File
            .ReadAllText("Day_11\\input.txt")
            .Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
    }
    public int S1()
    {
        return 0;
    }
    
}
class Monkey
{
    Queue<int> Items;
    Func<long, long> Operation;
    int DivisibleBy;
    int IfTrue;
    int IfFalse;
    public Monkey(Queue<int> items, Func<long, long> operation, int divisibleBy, int ifTrue, int ifFalse) 
        => (Items, Operation, DivisibleBy, IfTrue, IfFalse)
        =  (items, operation, divisibleBy, ifTrue, ifFalse);
    public Monkey ParseMonkey(string input)
    {
        var lines = input.Split("\n");
        var items = lines[1]
            .Substring(lines[1].IndexOf(":") + 1)
            .Split(", ")
            .Select(Int32.Parse)
            .ToArray();
        var op = lines[2].IndexOf("old") + 4;
        Func<long, long> operation = (long old) => {
            
        }; 
        var divisibleBy = Int32.Parse(lines[3].Substring(lines[3].IndexOf(" ") + 1) );
        var ifTrue = Int32.Parse(lines[4].Substring(lines[4].LastIndexOf(" ") + 1) );
        var ifFalse = Int32.Parse(lines[5].Substring(lines[5].LastIndexOf(" ") + 1) );
        return new Monkey(new Queue<int>(items), operation, divisibleBy, ifTrue, ifFalse);
    }
}