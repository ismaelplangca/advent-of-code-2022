namespace Day_02
{
    enum move
    {
        Rock,
        Paper,
        Scissors
    }

    public class Day
    {
        List<string> input;
        Dictionary<move, List<move> > losesTo = new() 
        {
            {move.Rock, new List<move>(){ move.Paper } },
            {move.Paper, new List<move>(){ move.Scissors } },
            {move.Scissors, new List<move>(){ move.Rock } }
        };
        // selected shape points : 
        // Rock = 1, Paper = 2, Scissors = 3
        // outcome points :
        // Loss = 0, Draw = 3, Win = 6
        public Day()
        {
            input = File.ReadAllLines("Day_02\\input.txt").ToList();
        }
        public int S1()
        {
            // TotalScore
            return input.Select(a => CalcRound(ReadMove(a[0]), ReadMove(a[2]) ) ).Sum();
        }
        // X = lose, Y = draw, Z = win
        public int S2()
        {
            // TotalScore
            return input.Select(a => CalcRound(ReadMove(a[0]), FollowStrategy(ReadMove(a[0]), a[2]) ) ).Sum();
        }
        move ReadMove(char input)
        {
            if(input == 'A' || input == 'X')
                return move.Rock;
            if(input == 'B' || input == 'Y')
                return move.Paper;
            if(input == 'C' || input == 'Z')
                return move.Scissors;
            throw new Exception("How?");
        }
        int CalcRound(move opp, move player)
        {
            var score = (int)player + 1;
            if(player == opp)
                return score + 3;
            else if(losesTo[player].Contains(opp) )
                return score;
            else
                return score + 6;
        }
        move FollowStrategy(move opp, char strat)
        {
            // lose
            if(strat == 'X')
                return losesTo[losesTo[opp][0]][0];
            // draw
            if(strat == 'Y')
                return opp;
            // win
            if(strat == 'Z')
                return losesTo[opp][0];
            throw new Exception("Fuck");
        }
    }
}