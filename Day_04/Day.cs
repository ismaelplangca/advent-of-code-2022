namespace Day_04
{
    public class Day
    {
        List<string> input;
        List<duo>    elves;
        record pair(int start, int end);
        record duo(pair first, pair second);
        public Day()
        {
            input = File.ReadAllLines("Day_04\\input.txt").ToList();
            elves = input
                .Select(a => a.Split(",") )
                .Select(a => {
                    var p1 = a[0].Split("-");
                    var p2 = a[1].Split("-");
                    return new duo(
                            new pair(Int32.Parse(p1[0]), Int32.Parse(p1[1]) ),
                            new pair(Int32.Parse(p2[0]), Int32.Parse(p2[1]) )
                        );
                }).ToList();
        }
        public void S1()
        {
            var output = elves.Select(Enclosed).Count(a => a);
            Console.WriteLine(output);
        }
        public void S2()
        {
            var output = elves.Select(Overlaps).Count(a => a);
            Console.WriteLine(output);
        }
        bool Enclosed(duo elves)
        {
            if(elves.first.start <= elves.second.start && 
                elves.first.end >= elves.second.end)
                return true;
            if(elves.second.start <= elves.first.start && 
                elves.second.end >= elves.first.end)
                return true;
            return false;
        }
        bool Overlaps(duo elves)
        {
            if(elves.first.start <= elves.second.end &&
                elves.first.end >= elves.second.start)
                return true;
            if(elves.second.start <= elves.first.end &&
                elves.second.end >= elves.first.start)
                return true;
            return false;
        }
    }
}