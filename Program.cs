using System;

namespace Connect_Four
{ 

	class Program
	{
		public class Player
		{
			public string playerName;
			public string playerSymbol;
		}

		public class Computer
		{
			public string computerName;
			public string computerSymbol;
		}

		static int playerDrop(string[,] board, Player currentPlayer)
		{
			int dropChoice;

			Console.WriteLine(currentPlayer.playerName + "'s Turn ");
			do
			{
				Console.WriteLine("Please enter a number between 1 and 7: ");
				dropChoice = Convert.ToInt32(Console.ReadLine());
			} while (dropChoice < 1 || dropChoice > 7);

			while (board[1, dropChoice] == "X " || board[1, dropChoice] == "O ")
			{
				Console.WriteLine("That row is full, please enter a new row: ");
				dropChoice = Convert.ToInt32(Console.ReadLine());
			}

			return dropChoice;

		}

		static int computerDrop(string[,] board, Computer currentPlayer)
        {
			int dropChoice;

			Console.WriteLine(currentPlayer.computerName + "'s Turn ");
			var r = new Random();
			do
			{
				Console.WriteLine("Please enter a number between 1 and 7: ");
				dropChoice = r.Next(1, 8);
			} while (dropChoice < 1 || dropChoice > 7);

			while (board[1, dropChoice] == "X " || board[1, dropChoice] == "O ")
			{
				Console.WriteLine("That row is full, please enter a new row: ");
				dropChoice = r.Next(1, 8);
			}

			return dropChoice;
			
		}

		static void checkBellow(string[,] board, Player currentPlayer, int dropChoice)
		{
			int length = 6;
			int turn = 0;


			do
			{
				if (board[length, dropChoice] != "X " && board[length, dropChoice] != "O ")
				{
					board[length, dropChoice] = currentPlayer.playerSymbol;
					turn = 1;
				}
				else
				{
					--length;
				}

			} while (turn != 1);


		}

		static void computerCheckBellow(string[,] board, Computer currentPlayer, int dropChoice)
		{
			int length = 6;
			int turn = 0;


			do
			{
				if (board[length, dropChoice] != "X " && board[length, dropChoice] != "O ")
				{
					board[length, dropChoice] = currentPlayer.computerSymbol;
					turn = 1;
				}
				else
				{
					--length;
				}

			} while (turn != 1);


		}


		static void displayBoard(string[,] board)
		{
			int rows = 6, columns = 7, i, j;

			for (i = 1; i <= rows; i++)
			{
				Console.Write("|");
				for (j = 1; j <= columns; j++)
				{
					if (board[i, j] != "X " && board[i, j] != "O ")
					{
						board[i, j] = "* ";
					}


					Console.Write(board[i, j]);

				}

				Console.Write("| \n");
			}

		}

		static int check(string[,] board, Player currentPlayer)
		{
			string XO;
			int win;

			XO = currentPlayer.playerSymbol;
			win = 0;

			for (int i = 8; i >= 1; --i)
			{

				for (int j = 9; j >= 1; --j)
				{

					if (board[i, j] == XO && board[i - 1, j - 1] == XO && board[i - 2, j - 2] == XO && board[i - 3, j - 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i, j - 1] == XO && board[i, j - 2] == XO && board[i, j - 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i - 1, j] == XO && board[i - 2, j] == XO && board[i - 3, j] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i - 1, j + 1] == XO && board[i - 2, j + 2] == XO && board[i - 3, j + 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i, j + 1] == XO && board[i, j + 2] == XO && board[i, j + 3] == XO)
					{
						win = 1;
					}
				}

			}

			return win;
		}

		static int computerCheck(string[,] board, Computer currentPlayer)
		{
			string XO;
			int win;

			XO = currentPlayer.computerSymbol;
			win = 0;

			for (int i = 8; i >= 1; --i)
			{

				for (int j = 9; j >= 1; --j)
				{

					if (board[i, j] == XO && board[i - 1, j - 1] == XO && board[i - 2, j - 2] == XO && board[i - 3, j - 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i, j - 1] == XO && board[i, j - 2] == XO && board[i, j - 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i - 1, j] == XO && board[i - 2, j] == XO && board[i - 3, j] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i - 1, j + 1] == XO && board[i - 2, j + 2] == XO && board[i - 3, j + 3] == XO)
					{
						win = 1;
					}

					else if (board[i, j] == XO && board[i, j + 1] == XO && board[i, j + 2] == XO && board[i, j + 3] == XO)
					{
						win = 1;
					}
				}

			}

			return win;
		}

		static int fullBoard(string[,] board)
		{
			int full = 0;
			for (int i = 1; i <= 7; ++i)
			{
				if (board[1, i] != "* ")
				{
					++full;
				}
			}

			return full;
		}

		static void playerWin(Player currentPlayer)
		{
			Console.WriteLine(currentPlayer.playerName + " Connected Four and WON!");
		}

		static void computerWin(Computer currentPlayer)
		{
			Console.WriteLine(currentPlayer.computerName + " Connected Four and WON!");
		}

		static int restart(string[,] board)
		{
			int restart;

			Console.WriteLine("Would you like to restart? Yes(1) No(2): ");
			restart = Convert.ToInt32(Console.ReadLine());
			if (restart == 1)
			{
				for (int i = 1; i <= 6; i++)
				{
					for (int j = 1; j <= 7; j++)
					{
						board[i, j] = "* ";
					}
				}
			}
			else
				Console.WriteLine("Goodbye!");
			return restart;
		}

		static void Main(string[] args)
		{
			int playerCount;
			Console.WriteLine("Let's Play Connect 4");
			Console.WriteLine("How many players?\n1) 1 Player\n2) 2 Player");
			playerCount = Convert.ToInt32(Console.ReadLine());


			if (playerCount == 1)
			{
				Player playerOne = new Player();
				Computer playerTwo = new Computer();
				string[,] board = new string[9, 10];
				int dropChoice, win, full, again;

				Console.WriteLine("Player One please enter your name: ");
				playerOne.playerName = Console.ReadLine();
				playerOne.playerSymbol = "X ";
				playerTwo.computerName = "Computer";
				playerTwo.computerSymbol = "O ";

				full = 0;
				win = 0;
				again = 0;
				displayBoard(board);

				do
				{
					dropChoice = playerDrop(board, playerOne);
					checkBellow(board, playerOne, dropChoice);
					displayBoard(board);
					win = check(board, playerOne);
					if (win == 1)
					{
						playerWin(playerOne);
						again = restart(board);
						if (again == 2)
						{
							break;
						}
					}

					dropChoice = computerDrop(board, playerTwo);
					computerCheckBellow(board, playerTwo, dropChoice);
					displayBoard(board);
					win = computerCheck(board, playerTwo);
					if (win == 1)
					{
						computerWin(playerTwo);
						again = restart(board);
						if (again == 2)
						{
							break;
						}
					}
					full = fullBoard(board);
					if (full == 7)
					{
						Console.WriteLine("The board is full, it is a draw!");
						again = restart(board);
					}

				} while (again != 2);
			}


			else if (playerCount == 2)
			{
				Player playerOne = new Player();
				Player playerTwo = new Player();
				string[,] board = new string[9, 10];
				int dropChoice, win, full, again;

				Console.WriteLine("Let's Play Connect 4");
				Console.WriteLine("Player One please enter your name: ");
				playerOne.playerName = Console.ReadLine();
				playerOne.playerSymbol = "X ";
				Console.WriteLine("Player Two please enter your name: ");
				playerTwo.playerName = Console.ReadLine();
				playerTwo.playerSymbol = "O ";

				full = 0;
				win = 0;
				again = 0;
				displayBoard(board);

				do
				{
					dropChoice = playerDrop(board, playerOne);
					checkBellow(board, playerOne, dropChoice);
					displayBoard(board);
					win = check(board, playerOne);
					if (win == 1)
					{
						playerWin(playerOne);
						again = restart(board);
						if (again == 2)
						{
							break;
						}
					}

					dropChoice = playerDrop(board, playerTwo);
					checkBellow(board, playerTwo, dropChoice);
					displayBoard(board);
					win = check(board, playerTwo);
					if (win == 1)
					{
						playerWin(playerTwo);
						again = restart(board);
						if (again == 2)
						{
							break;
						}
					}
					full = fullBoard(board);
					if (full == 7)
					{
						Console.WriteLine("The board is full, it is a draw!");
						again = restart(board);
					}

				} while (again != 2);


			}
		}
	}
}
