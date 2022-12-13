using System.Text.RegularExpressions;
namespace Day_05
{
    public class Day
    {
        string[] input;
        Stack<char>[] stacks;
        Regex regex;
        public Day()
        {
            input = File.ReadAllText("Day_05\\input.txt").Split("\n\n");
            stacks = ParseStacks(input[0]);
            regex = new Regex(@"^move (\d+) from (\d+) to (\d+)$");
        }
        public string S1()
        {
            foreach(var line in input[1].Split("\n", StringSplitOptions.RemoveEmptyEntries) )
                ExecuteS1(ParseMove(line) );
            return String.Join("", stacks.Select(a => a.Peek().ToString() ) );
        }
        public string S2()
        {
            foreach(var line in input[1].Split("\n", StringSplitOptions.RemoveEmptyEntries) )
                ExecuteS2(ParseMove(line) );
            return String.Join("", stacks.Select(a => a.Peek().ToString() ) );
        }
        Stack<char>[] ParseStacks(string input)
        {
            var stacks = Enumerable.Repeat(0, 9)
                .Select(a => new Stack<char>() )
                .ToArray();
            foreach(var line in input.Split("\n").Reverse().Skip(1) )
            {
                var count = 0;
                for(int i = 1; i < line.Length; i += 4)
                {
                    if(line[i] != ' ')
                        stacks[count].Push(line[i]);
                    count++;
                }
            }
            return stacks;
        }
        int[] ParseMove(string line)
        {
            var groups = regex.Match(line).Groups;
            var count  = Int32.Parse(groups[1].Value);
            var source = Int32.Parse(groups[2].Value) - 1;
            var dest   = Int32.Parse(groups[3].Value) - 1;

            return new int[]{count, source, dest};
        }
        void ExecuteS1(int[] move)
        {
            for(int i = 0; i < move[0]; i++)
                stacks[move[1]].Push(stacks[move[2]].Pop() );
        }
        void ExecuteS2(int[] move)
        {
            var temp = new List<char>();
            for(int i = 0; i < move[0]; i++)
                temp.Add(stacks[move[1]].Pop() );
            temp.Reverse();
            for(int i = 0; i < move[0]; i++)
                stacks[move[2]].Push(temp[i]);
        }
    }
}