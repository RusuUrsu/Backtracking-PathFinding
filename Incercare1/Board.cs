using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Incercare1
{
    class Board
    {
        public int Size; //8x8
        public Cell[,] Grid;
        public Cell[] NextLegalMove = new Cell[100];

        public Board(int s)
        {
            Size = s;
            Grid = new Cell[Size, Size];

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Cell(i, j);
                }
            }
        }

        public void GetNextMoves(Cell currCell)
        {
            int m = 0;
            switch (currCell.figure.name)
            {
                case Figure.FigureName.King:
                    TryAddValidMove(currCell, m, 1, 0); // Down
                    TryAddValidMove(currCell, m, -1, 0); // Up
                    TryAddValidMove(currCell, m, 0, 1); // Right
                    TryAddValidMove(currCell, m, 0, -1); // Left
                    TryAddValidMove(currCell, m, 1, 1); // Down-right
                    TryAddValidMove(currCell, m, -1, -1); // Up-left
                    TryAddValidMove(currCell, m, -1, 1); // Up-right
                    TryAddValidMove(currCell, m, 1, -1); // Down-left
                    break;

                case Figure.FigureName.Bishop:
                    TryAddValidMove(currCell, m, 1, 1); // Down-right
                    TryAddValidMove(currCell, m, -1, -1); // Up-left
                    TryAddValidMove(currCell, m, 1, -1); // Down-left
                    TryAddValidMove(currCell, m, -1, 1); // Up-right
                    break;

                case Figure.FigureName.Queen:
                    TryAddValidMove(currCell, m, 1, 0); // Down
                    TryAddValidMove(currCell, m, -1, 0); // Up
                    TryAddValidMove(currCell, m, 0, 1); // Right
                    TryAddValidMove(currCell, m, 0, -1); // Left
                    TryAddValidMove(currCell, m, 1, 1); // Down-right
                    TryAddValidMove(currCell, m, -1, -1); // Up-left
                    TryAddValidMove(currCell, m, -1, 1); // Up-right
                    TryAddValidMove(currCell, m, 1, -1); // Down-left
                    break;

                case Figure.FigureName.Rook:
                    TryAddValidMove(currCell, m, 1, 0); // Down
                    TryAddValidMove(currCell, m, -1, 0); // Up
                    TryAddValidMove(currCell, m, 0, 1); // Right
                    TryAddValidMove(currCell, m, 0, -1); // Left
                    break;

                case Figure.FigureName.Pawn:
                    if (currCell.figure.color == Figure.FigureColor.White)
                    {
                        TryAddValidMove(currCell, m, 1, 0); // Down
                    }
                    else
                    {
                        TryAddValidMove(currCell, m, -1, 0); // Up
                    }
                    break;

                case Figure.FigureName.Knight:
                    TryAddValidMove(currCell, m, 2, 1); // 2 down, 1 right
                    TryAddValidMove(currCell, m, -2, 1); // 2 up, 1 right
                    TryAddValidMove(currCell, m, -1, 2); // 1 up, 2 right
                    TryAddValidMove(currCell, m, -1, -2); // 1 up, 2 left
                    TryAddValidMove(currCell, m, 2, -1); // 2 down, 1 left
                    TryAddValidMove(currCell, m, 1, -2); // 1 down, 2 left
                    TryAddValidMove(currCell, m, -2, -1); // 2 up, 1 left
                    TryAddValidMove(currCell, m, 1, 2); // 1 down, 2 right
                    break;

                default:
                    break;
            }
        }

        private void TryAddValidMove(Cell currCell, int m, int rowOffset, int colOffset)
        {
            try
            {
                Cell nextCell = Grid[currCell.rowNumber + rowOffset, currCell.colNumber + colOffset];

                // Check if the destination cell is occupied by a figure of the same color
                if (nextCell.figure != null && nextCell.figure.color == currCell.figure.color)
                {
                    return; // Don't add the move if the cell is occupied by a friendly figure
                }

                nextCell.validNextMove = true;
                NextLegalMove[m] = nextCell;
                NextLegalMove[m++].figure = currCell.figure;
            }
            catch { }
        }
        public void ShowNextLegalMoves(Cell currCell, Figure.FigureName chessPiece)
        {
            //clear Board of previous action legal next moves 
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j].validNextMove = false;
                }
            }
            int dif = currCell.rowNumber - currCell.colNumber;
            int NewColNumber = 0;
            int NewRowNumber = 0;
            int m = 0;
            //mark all legal next moves based on chessPiece used
            switch (chessPiece)
            {
                    
                    case Figure.FigureName.Knight:
                        try
                {
                    Grid[currCell.rowNumber + 2, currCell.colNumber + 1].validNextMove = true;
                    NextLegalMove[m++] = Grid[currCell.rowNumber + 2, currCell.colNumber + 1];
                }
                catch { }

                try
                {
                    Grid[currCell.rowNumber + 1, currCell.colNumber + 2].validNextMove = true;
                    NextLegalMove[m++] = Grid[currCell.rowNumber + 1, currCell.colNumber + 2];
                }
                catch { }

                try
                {
                    Grid[currCell.rowNumber - 2, currCell.colNumber - 1].validNextMove = true;
                    NextLegalMove[m++] = Grid[currCell.rowNumber - 2, currCell.colNumber - 1];
                }
                catch { }

                try
                {
                    Grid[currCell.rowNumber - 1, currCell.colNumber - 2].validNextMove = true;
                    NextLegalMove[m++] = Grid[currCell.rowNumber - 1, currCell.colNumber - 2];
                }
                catch { }

                try
                {
                    Grid[currCell.rowNumber + 2, currCell.colNumber - 1].validNextMove = true;
                    NextLegalMove[m++] = Grid[currCell.rowNumber + 2, currCell.colNumber - 1];
                }
                catch { }

                try { Grid[currCell.rowNumber - 2, currCell.colNumber + 1].validNextMove = true; }
                catch { }

                try { Grid[currCell.rowNumber - 1, currCell.colNumber + 2].validNextMove = true; }
                catch { }

                break;
        
                        
                    case Figure.FigureName.King:
                        Grid[currCell.rowNumber + 1, currCell.colNumber].validNextMove = true;
                Grid[currCell.rowNumber + 1, currCell.colNumber + 1].validNextMove = true;
                Grid[currCell.rowNumber - 1, currCell.colNumber - 1].validNextMove = true;
                Grid[currCell.rowNumber - 1, currCell.colNumber].validNextMove = true;
                Grid[currCell.rowNumber, currCell.colNumber - 1].validNextMove = true;
                Grid[currCell.rowNumber, currCell.colNumber + 1].validNextMove = true;

                break;

                    case Figure.FigureName.Queen:

                        for (int i = 0; i < Size; i++)
                {
                    if (i != currCell.colNumber)
                        Grid[currCell.rowNumber, i].validNextMove = true;

                    if (i != currCell.rowNumber)
                        Grid[i, currCell.colNumber].validNextMove = true;

                    if (i != currCell.rowNumber && i != currCell.colNumber)
                        Grid[i, i].validNextMove = true;

                    if (i != currCell.rowNumber || i != currCell.colNumber)
                        Grid[i, i + dif].validNextMove = true;

                }

                break;

                    case Figure.FigureName.Rook:
                        for (int i = 0; i < Size; i++)
                {
                    if (i != currCell.colNumber)
                        Grid[currCell.rowNumber, i].validNextMove = true;

                    if (i != currCell.rowNumber)
                        Grid[i, currCell.colNumber].validNextMove = true;

                }
                break;


                    case Figure.FigureName.Bishop:
                        for (int i = 0; i < Size; i++)
                {
                    if (i != currCell.rowNumber && i != currCell.colNumber)
                        Grid[i, i].validNextMove = true;

                    if (i != currCell.rowNumber || i != currCell.colNumber)
                        Grid[i, i + dif].validNextMove = true;
                }

                break;

                default:
                        break;
        }
        }
           

        public bool IsOutOfBounds(Cell cell)
        {
            if (cell.rowNumber < 0 || cell.rowNumber > 7 || cell.colNumber < 0 || cell.colNumber > 7)
                return true;
            else
                return false;
        }

        public void UpdateBoard(Cell cell)
        {
            ShowNextLegalMoves(cell, cell.figure.name);
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    if (Grid[i, j].validNextMove && !IsOutOfBounds(Grid[i, j]) && !Grid[i, j].currOccupied)
                    {
                        Grid[i, j].cellPanel.BackColor = Color.Green;
                        
                    }
                }
            }
        }

    }
}
        
        

       

