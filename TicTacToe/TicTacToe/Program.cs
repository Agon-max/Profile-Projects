using System;

class Program
{
	static char[,] board = {
		{ '1', '2', '3' },
		{ '4', '5', '6' },
		{ '7', '8', '9' }
	};

	static int turns = 0;

	static void Main()
	{
		char currentPlayer = 'X';
		bool gameRunning = true;

		while (gameRunning)
		{
			Console.Clear();
			DisplayBoard();

			Console.WriteLine($"Player {currentPlayer}, choose your position (1-9): ");
			string input = Console.ReadLine();

			if (PlaceMark(input, currentPlayer))
			{
				turns++;
				if (CheckWin(currentPlayer))
				{
					Console.Clear();
					DisplayBoard();
					Console.WriteLine($"🎉 Player {currentPlayer} wins!");
					gameRunning = false;
				}
				else if (turns == 9)
				{
					Console.Clear();
					DisplayBoard();
					Console.WriteLine("It's a draw!");
					gameRunning = false;
				}
				else
				{
					currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
				}
			}
			else
			{
				Console.WriteLine("Invalid move! Press any key to try again.");
				Console.ReadKey();
			}
		}

		Console.WriteLine("Game over. Press any key to exit.");
		Console.ReadKey();
	}

	static void DisplayBoard()
	{
		Console.WriteLine();
		Console.WriteLine($" {board[0, 0]} | {board[0, 1]} | {board[0, 2]} ");
		Console.WriteLine("---+---+---");
		Console.WriteLine($" {board[1, 0]} | {board[1, 1]} | {board[1, 2]} ");
		Console.WriteLine("---+---+---");
		Console.WriteLine($" {board[2, 0]} | {board[2, 1]} | {board[2, 2]} ");
		Console.WriteLine();
	}

	static bool PlaceMark(string input, char player)
	{
		for (int row = 0; row < 3; row++)
		{
			for (int col = 0; col < 3; col++)
			{
				if (board[row, col].ToString() == input)
				{
					if (board[row, col] == 'X' || board[row, col] == 'O')
						return false;

					board[row, col] = player;
					return true;
				}
			}
		}
		return false;
	}

	static bool CheckWin(char player)
	{
		// Rows and columns
		for (int i = 0; i < 3; i++)
		{
			if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
				(board[0, i] == player && board[1, i] == player && board[2, i] == player))
				return true;
		}

		// Diagonals
		if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
			(board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
			return true;

		return false;
	}
}
