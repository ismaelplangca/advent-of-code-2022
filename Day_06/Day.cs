namespace Day_06
{
    public class Day
    {
        string input;
        public Day()
        {
            input = File.ReadAllLines("Day_06\\input.txt").First();
        }
        public int S1()
        {
            return FindMarker(input, 4);
        }
        public int S2()
        {
            return FindMarker(input, 14);
        }
        int FindMarker(string input, int windowLen)
        {
            for(int i = 0; i <= input.Length - windowLen; i++)
                if(input.Substring(i, windowLen).ToCharArray().Distinct().Count() == windowLen)
                    return i + windowLen;
            return -1;
        }
    }
}