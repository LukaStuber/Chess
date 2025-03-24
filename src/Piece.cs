using static Chess.Game;
using static Chess.Core;

namespace Chess
{
    class Core
    {
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
    }

    class Pawn
    {
        public static bool ValidMove(Pieces[,] board, VectorPair coords)
        {
            bool isWhite = board[coords.Pair1.x, coords.Pair1.y] == Pieces.P ? true : false;

            

            return true;
        }
    }
    
}
