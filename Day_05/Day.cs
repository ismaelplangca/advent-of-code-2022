namespace Day_05
{
    public class Day
    {
        string[] input;
        Stack<char>[] stacks;
        public Day()
        {
            input = File.ReadAllText("Day_05\\input.txt").Split("\n\n");
            stacks = ParseStacks(input[0]);
        }
        public void S1()
        {

        }
        Stack<char>[] ParseStacks(string input)
        {
            var stacks = new Stack<char>[9];
            foreach(var line in input.Split("\n") )
            {
                var count = 0;
                for(int i = 1; i < line.Length; i += 4)
                {
                    if(line[i] != '\0')
                        stacks[count].Push(line[i]);
                    count++;
                }
            }
            return stacks;
        }
    }
}