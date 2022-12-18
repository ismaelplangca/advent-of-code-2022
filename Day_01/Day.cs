namespace Day_01
{
    public class Day
    {
        List<String> input;
        List<int>    elves;
        public Day()
        {
            input = File.ReadAllLines("Day_01\\input.txt").ToList();
            elves = input
                .Aggregate(new List<int>() { 0 }, (list, line) => {
                        if(String.IsNullOrWhiteSpace(line) ) {
                            list.Add(0);
                            return list;
                        }
                        list[list.Count() - 1] += int.Parse(line);
                        return list;
                    });
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