using System.Text;

namespace Day03;

class Program
{
    static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        Part1(lines);
        Part2(lines);
    }

    private static void Part1(string[] lines)
    {
        lines = new string[] { "467..114..", "...*......", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.","...$.*....", ".664.598.." };

        int total = 0;
        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (char.IsDigit(lines[i][j]))
                {
                    stringBuilder.Append(lines[i][j]);
                }
                else if (stringBuilder.Length != 0)
                {
                    bool hasSymbol = false;

                    // Check adjacent and diagonal positions for symbols
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        for (int y = j - 1; y <= j + 1; y++)
                        {
                            if (x >= 0 && x < lines.Length && y >= 0 && y < lines[i].Length && lines[x][y] != '.' && char.IsSymbol(lines[x][y]))
                            {
                                hasSymbol = true;
                                break;
                            }
                        }
                        if (hasSymbol)
                        {
                            break;
                        }
                    }

                    if (hasSymbol)
                    {
                        total += int.Parse(stringBuilder.ToString());
                    }

                    stringBuilder.Clear();
                }
            }
        }

        Console.WriteLine($"Part 1: {total}");
    }

    private static void Part2(string[] lines)
    {

        Console.WriteLine($"Part 2: ");
    }
}
