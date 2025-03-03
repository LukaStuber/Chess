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
        }
        
        const string ascii = ".PNBRQKpnbrqk";
        
        static void Main()
        {
            Pieces[,] board = GenerateBoard();
            string input;
            VectorPair coords = new();

            while (true)
            {
                PrintBoard(board);
                input = Console.ReadLine();
                Console.WriteLine(input);

                coords = AlgebraicToCoords(input);
                Console.WriteLine(coords.Pair1.x);
                Console.WriteLine(coords.Pair1.y);
                Console.WriteLine(coords.Pair2.x);
                Console.WriteLine(coords.Pair2.y);

                board = MovePiece(board, coords);

                PrintBoard(board);
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
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 7; x >= 0; x--)
                {
                    Console.Write($"{ascii[(int)board[x,y]]} ");
                }
                Console.WriteLine();
            }
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
            Pieces piece = board[coords.Pair1.x, coords.Pair1.y];
            board[coords.Pair1.x, coords.Pair1.y] = Pieces.e;

            board[coords.Pair2.x, coords.Pair2.y] = piece;

            return board;
        }
    }
}