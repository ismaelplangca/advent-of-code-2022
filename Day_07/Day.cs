namespace Day_07
{
    // Find all of the directories with a total size of at most 100000
    // Calculate the sum of their total sizes
    public class Day
    {
        string[] input;
        List<Dir> directories;

        public Day()
        {
            input = File.ReadLines("Day_07\\input.txt").ToArray();
            directories = ParseCommands();
        }
        public void S1()
        {
            var output = directories
                .Select(CalcTotalDirSize)
                .Where(size => size <= 100000)
                .Sum();
            Console.WriteLine(output);
        }
        public void S2()
        {
            var totalSize = CalcTotalDirSize(directories[0]);
            var availableSpace = 70000000 - totalSize;
            var output = directories
                .Select(CalcTotalDirSize)
                .Where(size => availableSpace + size >= 30000000)
                .OrderBy(a => a)
                .FirstOrDefault();
            Console.WriteLine(output);
        }
        long CalcTotalDirSize(Dir dir)
        {
            if(!dir.SubDirs.Any() )
                return dir.Size;
            return dir.Size + dir.SubDirs.Sum(CalcTotalDirSize);
        }
        List<Dir> ParseCommands()
        {
            var root = new Dir("root", null);
            var curr = root;
            var dirs = new List<Dir>(){ root };

            for(int i = 0; i < input.Length; i++)
            {
                var commands = input[i].Split(' ');
                switch(commands[1]) {
                    case "cd" :
                        curr = commands[2] switch {
                            "/"  => root,
                            ".." => curr.Parent ?? curr,
                            _    => curr.SubDirs.First(a => a.Name == commands[2])
                        };
                    break;
                    case "ls" :
                        var ls = input.Skip(i + 1).TakeWhile(a => a[0] != '$' );
                        foreach(var line in ls)
                        {
                            var spl = line.Split(' ');
                            if(spl[0].Equals("dir") )
                            {
                                var dir = new Dir(spl[1], curr);
                                curr.SubDirs.Add(dir);
                                dirs.Add(dir);
                            } else {
                                var fileSize = long.Parse(spl[0]);
                                curr.Files.Add(new CommsFile(spl[1], fileSize) );
                                curr.Size += fileSize;
                            }
                        }
                        i += ls.Count();
                    break;
                }
            }

            return dirs;
        }
    }
    record CommsFile(string Name, long Size);
    class Dir
    {
        public string Name { get; set; }
        public Dir Parent { get; set; }
        public long Size { get; set; }
        public ICollection<Dir> SubDirs { get; set; } = new List<Dir>();
        public ICollection<CommsFile> Files { get; set; } = new List<CommsFile>();

        public Dir(string name, Dir? parent) =>
        (Name, Parent) = (name, parent!);

        public override string ToString()
        {
            return
                "Dir(Name=" + Name +
                ",Parent=" + (Parent is null ? "null" : Parent.Name)   +
                ",Size=" + Size +
                ",SubDirs=" + String.Join(",", SubDirs.Select(a => a.Name) ) +
                ",Files=" + String.Join(",", Files.Select(a => a.Name) ) + ")";
        }
    }
}