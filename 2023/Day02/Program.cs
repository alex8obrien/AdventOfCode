namespace Day02
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            // lines = new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" };

            int total = 0, red = 12, green = 13, blue = 14;

            foreach (string line in lines)
            {
                bool valid = true;
                int id = int.Parse(line.Split(':')[0].Split(' ')[1]);
                
                string[] cubes = line.Split(new char[] { ':', ';', ',' }, StringSplitOptions.TrimEntries);

                foreach (string cube in cubes)
                {
                    int value = GetInt(cube);

                    if (value == 0)
                        continue;
                    
                    // if at any point that value is too big, break out of the loop
                    
                    if (cube.Contains("red") && value > red)
                    {
                        valid = false;
                        break;
                    }
                    else if (cube.Contains("green") && value > green)
                    {
                        valid = false;
                        break;
                    }
                    else if (cube.Contains("blue") && value > blue)
                    {
                        valid = false;
                        break;
                    }

                    if (!valid)
                        break;
                                        
                }

                if (valid)
                    total += id;
            }

            Console.WriteLine(total);
        }

        private static int GetInt(string str)
        {
            bool valid = int.TryParse(str.Split(' ')[0], out int value);

            if (valid)
                return value;
            else
                return 0;
        }

        private static void Part2(string[] lines)
        {
            // calc minimum needed for each game
            // multiply and add to total

            // lines = new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" };


            int total = 0, red = 0, green = 0, blue = 0;

            foreach (string line in lines)
            {
                string[] cubes = line.Split(new char[] { ':', ';', ',' }, StringSplitOptions.TrimEntries);

                foreach (string cube in cubes)
                {
                    int value = GetInt(cube);

                    if (value == 0)
                        continue;
                    
                    // if at any point that value is too big, break out of the loop
                    
                    if (cube.Contains("red"))
                    {
                        if (value > red)
                            red = value;
                    }
                    else if (cube.Contains("green"))
                    {
                        if (value > green)
                            green = value;
                    }
                    else if (cube.Contains("blue"))
                    {
                        if (value > blue)
                            blue = value;
                    }                                        
                }

                total += red * green * blue;
                red = 0;
                green = 0;
                blue = 0;
            }

            Console.WriteLine(total);
        }
    }
}