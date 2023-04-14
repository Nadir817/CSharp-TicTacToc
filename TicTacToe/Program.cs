using System;

internal class Program
{
    static int[,] boards =
    {
        {1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 },
    };
    public static void SetField()
    {
        for (int i = 0; i < boards.GetLength(0); i++)
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", boards[i, 0], boards[i, 1], boards[i, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
        }
    }
    private static void Main(string[] args)
    {
        SetField();
    }
}