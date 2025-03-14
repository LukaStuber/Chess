﻿using System.Text;
using static Chess.Game;
using System.Numerics;

namespace Chess
{
    class Chess
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            
            Pieces[,] board = GenerateBoard();
            string input;
            VectorPair coords;
            
            bool isWhite = true;

            PrintBoard(board);
            input = GetInput(board, isWhite);
            isWhite = !isWhite;

            while (input != "q")
            {
                Console.Clear();

                coords = AlgebraicToCoords(input);
                board = MovePiece(board, coords);

                if (isWhite) PrintBoard(board);
                else PrintBoardReverse(board);

                input = GetInput(board, isWhite);
                isWhite = !isWhite;
            }
        }   
    }
}