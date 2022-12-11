namespace Day_01
{
    public class Day
    {
        List<String> input;
        List<int>    elves;
        public Day()
        {
            input = File.ReadAllLines("Day_01\\input.txt").ToList();
            elves = new();
            var count = 0;
            foreach(var line in input)
            {
                if(line.Equals("") ) {
                    elves.Add(count);
                    count = 0;
                } else
                    count += int.Parse(line);
            }
        }
        public int S1()
        {
            return elves.Max();
        }
        public int S2()
        {
            return elves.OrderBy(a => a).TakeLast(3).Sum();
        }
    }
}