namespace Day_06
{
    public class Day
    {
        string input;
        public Day()
        {
            input = File.ReadAllLines("Day_06\\input.txt").First();
        }
        public void S1()
        {
            Console.WriteLine(FindMarker(input, 4) );
        }
        public void S2()
        {
            Console.WriteLine(FindMarker(input, 14) );
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