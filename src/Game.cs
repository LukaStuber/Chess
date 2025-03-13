namespace Chess
{
    class Game
    {
        public struct Piece
        {
            public Pieces piece;
            public bool isWhite;
        }

        public enum Pieces
        { // white = 1-6, black = 7-12
            e,
            P,
            N,
            B,
            R,
            Q,
            K,
            p,
            n,
            b,
            r,
            q,
            k,
            INVALID
        }

        public struct Vector2
        {
            public int x;
            public int y;
        }

        public struct VectorPair
        {
            public Vector2 Pair1;
            public Vector2 Pair2;
        }

        const string ascii = " ♙♘♗♖♕♔♙♘♗♖♕♔";

        public static void PrintBoard(Pieces[,] board)
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write($"{y + 1} | ");
                for (int x = 0; x < 8; x++)
                {
                    if (x % 2 == 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (y % 2 == 0 && x % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if ((int)board[x, y] >= 1 && (int)board[x, y] <= 6)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{ascii[(int)board[x, y]]} ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  +----------------");
            Console.WriteLine("    a b c d e f g h");
        }

        public static void PrintBoardReverse(Pieces[,] board)
        {
            for (int y = 0; y < 8; y++)
            {
                Console.Write($"{y + 1} | ");
                for (int x = 0; x < 8; x++)
                {
                    if (x % 2 == 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else if (y % 2 == 0 && x % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                    }

                    if ((int)board[x, y] >= 1 && (int)board[x, y] <= 6)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.Write($"{ascii[(int)board[x, y]]} ");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  +----------------");
            Console.WriteLine("    a b c d e f g h");
        }

        public static Pieces[,] GenerateBoard()
        {
            return new Pieces[,]
            {
                {Pieces.R, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.r},
                {Pieces.N, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.n},
                {Pieces.B, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.b},
                {Pieces.K, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.k},
                {Pieces.Q, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.q},
                {Pieces.B, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.b},
                {Pieces.N, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.n},
                {Pieces.R, Pieces.P, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.p, Pieces.r}
            };
        }

        public static VectorPair AlgebraicToCoords(string input)
        {
            VectorPair output;

            output.Pair1.x = char.ToUpper(input[0]) - 64 - 1;
            output.Pair1.y = int.Parse(input[1].ToString()) - 1;
            output.Pair2.x = char.ToUpper(input[2]) - 64 - 1;
            output.Pair2.y = int.Parse(input[3].ToString()) - 1;

            return output;
        }

        public static string GetInput(Pieces[,] board, bool isWhite)
        {
            string _input;

            Console.Write((isWhite) ? "White: " : "Black: ");
            _input = Console.ReadLine();

            while (!ValidInput(_input, board, isWhite))
            {
                Console.WriteLine("invalid input");
                Console.Write((isWhite) ? "White: " : "Black: ");
                _input = Console.ReadLine();
            }

            return _input;
        }

        public static Pieces[,] MovePiece(Pieces[,] board, VectorPair coords)
        {
            Pieces piece = board[coords.Pair1.x, coords.Pair1.y] == Pieces.e ? Pieces.INVALID : board[coords.Pair1.x, coords.Pair1.y];

            if (piece != Pieces.INVALID)
            {
                board[coords.Pair1.x, coords.Pair1.y] = Pieces.e;
                board[coords.Pair2.x, coords.Pair2.y] = piece;
            }

            return board;
        }

        public static bool ValidInput(string input, Pieces[,] board, bool isWhite)
        {
            // false = invalid, true = valid

            if (input == "q") return true; // exception for quit

            string letters = "abcdefgh";
            string numbers = "12345678";

            if (input is null) return false;
            if (input.Length != 4) return false;
            if (!char.IsLetter(input[0]) || !char.IsLetter(input[2])) return false;
            if (!char.IsNumber(input[1]) || !char.IsNumber(input[3])) return false;
            if (!letters.Contains(input[0]) || !letters.Contains(input[2])) return false;
            if (!numbers.Contains(input[1]) || !numbers.Contains(input[3])) return false;

            VectorPair coords = AlgebraicToCoords(input);
            if (isWhite)
            {
                if ((int)board[coords.Pair1.x, coords.Pair1.y] < 1 || (int)board[coords.Pair1.x, coords.Pair1.y] > 6) return false;
            }
            else
            {
                if ((int)board[coords.Pair1.x, coords.Pair1.y] < 7) return false;
            }

            if (!GetValidMove(input, board, coords)) return false; 

            return true;
        }

        private static bool GetValidMove(string input, Pieces[,] board, VectorPair coords)
        {
            return (int)board[coords.Pair1.x, coords.Pair1.y] switch
            {
                0 => false,
                1 => Pawn.ValidMove(input, board, coords),
                //2 => Knight.ValidMove(input, board, coords),
                //3 => Bishop.ValidMove(input, board, coords),
                //4 => Rook.ValidMove(input, board, coords),
                //5 => Queen.ValidMove(input, board, coords),
                //6 => King.ValidMove(input, board, coords),
                7 => Pawn.ValidMove(input, board, coords),
                //8 => Knight.ValidMove(input, board, coords),
                //9 => Bishop.ValidMove(input, board, coords),
                //10 => Rook.ValidMove(input, board, coords),
                //11 => Queen.ValidMove(input, board, coords),
                //12 => King.ValidMove(input, board, coords),
            };
        }
    }
}
