namespace Chess
{
    class Chess
    {
 
        struct Vector2
        {
            public int x;
            public int y;
        }

        struct VectorPair
        {
            public Vector2 Pair1;
            public Vector2 Pair2;           
        }

        enum Pieces
        {
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
        
        const string ascii = ".PNBRQKpnbrqk";

        static void Main()
        {
            Pieces[,] board = GenerateBoard();
            string? input;
            VectorPair coords;

            PrintBoard(board);
            input = Console.ReadLine();
            while (!CheckInput(input, board))
            {
                Console.WriteLine("invalid input");
                input = Console.ReadLine();
            }      

            while (input != "q")
            {
                coords = AlgebraicToCoords(input);
                board = MovePiece(board, coords);
                PrintBoard(board);

                input = Console.ReadLine();
                while (!CheckInput(input, board))
                {
                    Console.WriteLine("invalid input");
                    input = Console.ReadLine();
                }
            }
        }

        static void PrintBoard(Pieces[,] board)
        {
            for (int y = 7; y >= 0; y--)
            {
                Console.Write($"{y + 1} | ");
                for (int x = 0; x < 8; x++)
                {
                    Console.Write($"{ascii[(int)board[x,y]]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  +----------------");
            Console.WriteLine("    a b c d e f g h");
        }

        static void PrintBoardReverse(Pieces[,] board)
        {
            for (int y = 0; y < 8; y++)
            {
                Console.Write($"{y + 1} | ");
                for (int x = 0; x < 8; x++)
                {
                    Console.Write($"{ascii[(int)board[x, y]]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("  +----------------");
            Console.WriteLine("    a b c d e f g h");
        }

        static Pieces[,] GenerateBoard()
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

        static VectorPair AlgebraicToCoords(string input)
        {
            VectorPair output;

            output.Pair1.x = char.ToUpper(input[0]) - 64 - 1;
            output.Pair1.y = int.Parse(input[1].ToString()) - 1;
            output.Pair2.x = char.ToUpper(input[2]) - 64 - 1;
            output.Pair2.y = int.Parse(input[3].ToString()) - 1;

            return output;
        }

        static Pieces[,] MovePiece(Pieces[,] board, VectorPair coords)
        {
            Pieces piece = board[coords.Pair1.x, coords.Pair1.y] == Pieces.e ? Pieces.INVALID : board[coords.Pair1.x, coords.Pair1.y];

            if (piece != Pieces.INVALID)
            {
                board[coords.Pair1.x, coords.Pair1.y] = Pieces.e;
                board[coords.Pair2.x, coords.Pair2.y] = piece;
            }

            return board;
        }

        static bool CheckInput(string? input, Pieces[,] board)
        {
            // false = invalid, true = valid

            string letters = "abcdefgh"; 
            string numbers = "12345678";

            if (input is null) return false;
            if (input.Length != 4) return false;
            if (!char.IsLetter(input[0]) || !char.IsLetter(input[2])) return false;
            if (!char.IsNumber(input[1]) || !char.IsNumber(input[3])) return false;
            if (!letters.Contains(input[0]) && !letters.Contains(input[2])) return false;
            if (!numbers.Contains(input[1]) && !numbers.Contains(input[3])) return false;
            if (!CheckMoveType(input, board)) return false;

            return true;
        }

        static bool CheckMoveType(string? input, Pieces[,] board)
        {
            return true;
        }
    }
}