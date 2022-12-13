namespace Day_08;

public class Day
{
    short[,] input;
    Tree [,] trees;
    public Day()
    {
        var inp = File.ReadAllText("Day_08\\input.txt").Split("\n");
        input = new short[inp[0].Length,inp.Count()];
        for(int i = 0; i < input.GetLength(0); i++)
            for(int j = 0; j < input.GetLength(1); j++)
                input[i,j] = short.Parse(inp[i][j]+"");
        trees = ParseInput(input);
    }
    public int S1()
    {
        return trees
    }
    Tree[,] ParseInput(short[,] input)
    {
        var lenX = input.GetLength(0);
        var lenY = input.GetLength(1);
        var trees = new Tree[lenX,lenY];
        for(short i = 0; i < lenX; i++)
        {
            if(i == 0 || i == lenX - 1) {
                for(short j = 0; j < lenY; j++) {
                    var t = new Tree(input[i,j]);
                    t.AtEdge = true;
                    trees[i,j] = t;
                }
            } else {
                for(short j = 0; j < lenY; j++)
                    trees[i,j] = new Tree(input[i,j]);
                trees[i, 0].AtEdge = true;
                trees[i, lenY - 1].AtEdge =  true;
            }
        }
        return trees;
    }
    bool IsVisible(Tree tree, int x, int y)
    {
        if(tree.AtEdge)
            return true;

        while(!trees[x++,y].AtEdge)
            if(trees[x,y].Height > tree.Height)
                return true;
        
        while(!trees[x--,y].AtEdge)
            if(trees[x,y].Height > tree.Height)
                return true;
        
        while(!trees[x,y++].AtEdge)
            if(trees[x,y].Height > tree.Height)
                return true;

        while(!trees[x,y--].AtEdge)
            if(trees[x,y].Height > tree.Height)
                return true;

        return false;
    }
    record Pos(short X, short Y);
    class Tree
    {
        public short Height { get; set; }
        public bool IsVisible { get; set;}
        public bool AtEdge { get; set; }

        public Tree(short height) =>
        (Height) = (height);
    }
}