namespace Chess
{
    class Chess
    {
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
            string coord;

            while (true)
            {
                PrintBoard(board);
                input = Console.ReadLine();
                Console.WriteLine(input);

                coord = AlgebraicToCoords(input);
                Console.WriteLine(coord);

                Console.WriteLine(ascii[(int)board[int.Parse(coord[0].ToString()), int.Parse(coord[1].ToString())]]);
                Console.WriteLine(ascii[(int)board[int.Parse(coord[2].ToString()), int.Parse(coord[3].ToString())]]);
            }
        }

        static void PrintBoard(Pieces[,] board)
        {
            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    Console.Write($"{ascii[(int)board[x,y]]} ");
                }
                Console.WriteLine();
            }
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
                {Pieces.r, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.R},
                {Pieces.n, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.N},
                {Pieces.b, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.B},
                {Pieces.k, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.K},
                {Pieces.q, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.Q},
                {Pieces.b, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.B},
                {Pieces.n, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.N},
                {Pieces.r, Pieces.p, Pieces.e, Pieces.e, Pieces.e ,Pieces.e, Pieces.P, Pieces.R}
            };
        }

        static string AlgebraicToCoords(string input)
        {
            string output = "";
            int temp;

            output += char.ToUpper(input[0]) - 64;
            output += input[1];

            output += char.ToUpper(input[2]) - 64;
            output += input[3];

            temp = int.Parse(output);
            temp -= 1111;

            output = temp.ToString();

            return output;
        }
    }
}