using static Chess.Game;

namespace Chess
{
    class Chess
    {
        static void Main()
        {
            Pieces[,] board = GenerateBoard();
            string input;
            VectorPair coords;
            
            // true = white, false = black
            bool turn = true;

            PrintBoard(board);
            Console.Write((turn) ? "White: " : "Black: ");
            input = Console.ReadLine();
            while (!ValidInput(input, board, turn))
            {
                Console.WriteLine("invalid input");
                Console.Write((turn) ? "White: " : "Black: ");
                input = Console.ReadLine();
            }
            turn = !turn;

            while (input != "q")
            {
                Console.Clear();

                coords = AlgebraicToCoords(input);
                board = MovePiece(board, coords);

                if (turn) PrintBoard(board);
                else PrintBoardReverse(board);
                Console.Write((turn) ? "White: " : "Black: ");

                input = Console.ReadLine();
                while (!ValidInput(input, board, turn))
                {
                    Console.WriteLine("invalid input");
                    Console.Write((turn) ? "White: " : "Black: ");
                    input = Console.ReadLine();
                }
                turn = !turn;
            }
        }   
    }
}