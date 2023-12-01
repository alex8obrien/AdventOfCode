using System.Text;

namespace Day01
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
            // lines = new string[] { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" };

            int total = 0, first = 0, last = 0, value;

            foreach (string line in lines)
            {   
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        first = int.Parse(c.ToString());
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        last = int.Parse(line[i].ToString());
                        break;
                    }
                }

                value = int.Parse($"{first}{last}");
                total += value;
            }

            Console.WriteLine($"Part 1: {total}");
        }

        private static void Part2(string[] lines)
        {
            // lines = new string[] {"two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen" };

            int total = 0, value;

            foreach (string line in lines)
            {
                int first = 0, last = 0;
                StringBuilder builder = new StringBuilder();

                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        first = int.Parse(c.ToString());
                        break;
                    }
                    else
                    {
                        builder.Append(c);

                        foreach (KeyValuePair<string, int> pair in values)
                        {
                            if (builder.ToString().Contains(pair.Key))
                            {
                                first = pair.Value;
                                break;
                            }
                        }

                        if (first != 0)
                        {
                            break;
                        }
                    }
                }

                builder.Clear();

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    if (char.IsDigit(line[i]))
                    {
                        last = int.Parse(line[i].ToString());
                        break;
                    }
                    else
                    {
                        builder.Insert(0, line[i]);

                        foreach (KeyValuePair<string, int> pair in values)
                        {
                            if (builder.ToString().Contains(pair.Key))
                            {
                                last = pair.Value;
                                break;
                            }
                        }

                        if (last != 0)
                        {
                            break;
                        }
                    }
                }

                value = int.Parse($"{first}{last}");
                total += value;
            }

            Console.WriteLine($"Part 2: {total}");
        }

        private static Dictionary<string, int> values = new Dictionary<string, int>()
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };
    }
}
