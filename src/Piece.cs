using static Chess.Game;

namespace Chess
{
    class Pawn
    {
        public static bool ValidMove(Pieces[,] board, VectorPair coords)
        {
            bool isWhite = board[coords.Pair1.x, coords.Pair1.y] == Pieces.P ? true : false;

            if (isWhite)
            {
                if (coords.Pair1.x + 1 == coords.Pair2.x && (int)board[coords.Pair2.x, coords.Pair2.y] < 7) return false;
                if (coords.Pair1.x - 1 == coords.Pair2.x && (int)board[coords.Pair2.x, coords.Pair2.y] < 7) return false;
                if (coords.Pair1.y != 1 && coords.Pair1.y + 2 == coords.Pair2.y) return false;
                if (coords.Pair1.x == coords.Pair2.x && board[coords.Pair2.x, coords.Pair2.y] != Pieces.e) return false;
            }
            else
            {
                if (coords.Pair1.x + 1 == coords.Pair2.x && ((int)board[coords.Pair2.x, coords.Pair2.y] > 6 || (int)board[coords.Pair2.x, coords.Pair2.y] == 0)) return false;
                if (coords.Pair1.x - 1 == coords.Pair2.x && ((int)board[coords.Pair2.x, coords.Pair2.y] > 6 || (int)board[coords.Pair2.x, coords.Pair2.y] == 0)) return false;
                if (coords.Pair1.y != 6 && coords.Pair1.y - 2 == coords.Pair2.y) return false;

            }

            return true;
        }
    }
    
}
