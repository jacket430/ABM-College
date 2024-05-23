using System;

class TicTacToe
{
    static int[,] board = new int[3, 3]
    {
        { 0, 1, 0 },
        { 1, 0, 1 },
        { 1, 0, 0 }
    };

    static void Main()
    {
        DisplayBoard();
        int winner = CheckWinner();
        if (winner != -1)
        {
            Console.WriteLine($"The winner is Player {winner + 1}!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }

    static void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static int CheckWinner()
    {
        if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2]) return board[0, 0];
        if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2]) return board[1, 0];
        if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2]) return board[2, 0];

        if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0]) return board[0, 0];
        if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1]) return board[0, 1];
        if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2]) return board[0, 2];

        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return board[0, 0];
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return board[0, 2];

        // No winner
        return -1;
    }
}
