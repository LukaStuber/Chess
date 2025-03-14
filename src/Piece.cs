using static Chess.Game;

namespace Chess
{
    class Piece
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
        public static bool ValidMove(string input, Pieces[,] board, VectorPair coords)
        {
            return true;
        }
    }
}
