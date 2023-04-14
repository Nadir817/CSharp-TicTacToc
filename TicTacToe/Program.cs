using System;
using System.Globalization;

internal class Program
{
    static char[,] boards =
    {
        {'1', '2', '3'},
        {'4', '5', '6'},
        {'7', '8', '9'},
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

    public static void PlacePiece(int player, int row, int col)
    {
        char piece = player == 1 ? 'x' : 'o';
        boards[row, col] = piece;
    }

    public static bool CanPlace(int r, int c)
    {
        if (boards[r, c] != 'x' && boards[r,c] !='o')
        {
            return true;
        } else { return false; }
    }

    public static bool WinCheck()
    {
        if (boards[0,0] == boards[0,1] && boards[0, 1] == boards[0, 2])
        {
            return true;
        } else if (boards[1, 0] == boards[1, 1] && boards[1, 1] == boards[1, 2])
        {
            return true;
        } else if (boards[2, 0] == boards[2, 1] && boards[2, 1] == boards[2, 2])
        {
            return true;
        } else if (boards[0, 0] == boards[1, 0] && boards[1, 0] == boards[2, 0])
        {
            return true;
        } else if (boards[0, 1] == boards[1, 1] && boards[1, 1] == boards[2, 1])
        {
            return true;
        } else if (boards[0, 2] == boards[1, 2] && boards[1, 2] == boards[2, 2])
        {
            return true;
        } else if (boards[0, 0] == boards[1, 1] && boards[1, 1] == boards[2, 2])
        {
            return true;
        } else if (boards[0, 2] == boards[1, 1] && boards[1, 1] == boards[2, 0])
        {
            return true;
        } else { return false; }
    }

    private static void Main(string[] args)
    {
        int player = 1;
        int count = 0;
        
        do
        {
            SetField();
            Console.WriteLine("Player {0} please pick a field to place your piece: ", player);
            int input;
            bool success = Int32.TryParse(Console.ReadLine(), out input);
            while (!success)
            {
                Console.WriteLine("Please pick a valid field");
                success = Int32.TryParse(Console.ReadLine(), out input);
            }
            int row = (input - 1) / boards.GetLength(0);
            int col = (input - 1) % boards.GetLength(0);
            if (!CanPlace(row, col))
            {
                Console.Clear();
                Console.WriteLine("Please pick non occupied field");
                continue;
            }
            PlacePiece(player, row, col);
            count++;
            if (count > 4)
            {
                if (WinCheck())
                {
                    Console.Clear();
                    SetField();
                    Console.WriteLine("Winner is player {0}", player);
                    break;
                }
                if (count == 9)
                {
                    Console.Clear();
                    SetField();
                    Console.WriteLine("It is a tie.");
                    break;
                }
            }
            player = player == 1 ? 2 : 1;
            Console.Clear();


        } while (true);
    }
}