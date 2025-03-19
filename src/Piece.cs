using static Chess.Game;
using static Chess.Chess;
using Microsoft.Win32.SafeHandles;

namespace Chess
{
    class Chess
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

    abstract class Piece
    {
        public Pieces piece { get; set; }
    }

    class Pawn : Piece
    {
        public bool home { get; set; }

        public static bool ValidMove(string input, Pieces[,] board, VectorPair coords)
        {
            return true;
        }
    }
}
