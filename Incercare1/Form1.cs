using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incercare1
{


     partial class Form1 : Form
    {
        Cell[] sol = new Cell[10000];
        ImageList FiguresImageList = new ImageList();
       

        public Form1()
        {
            InitializeComponent();
           
        }
        Board board = new Board(8);
        private void Form1_Load(object sender, EventArgs e)
        {
            
            GenerateFigures(board);
            CreateBoard(board);
        
            
            
      
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
        }

        

        public void CreateBoard(Board board)
        {
            int tileSize = 80;
            this.Width = 780;
            this.Height = 680;
            int x = 0;
            

            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    Cell c = board.Grid[i, j];
                    
                   


                    c.cellPanel = new Panel
                    {
                        Size = new Size(tileSize, tileSize),
                        Location = new Point(tileSize * j, tileSize * i),
                    };

                  

                    Controls.Add(c.cellPanel);
                    board.Grid[i, j] = c;

                    if (board.Grid[i, j].figure != null)
                        board.Grid[i, j].cellPanel.BackgroundImage = board.Grid[i, j].figure.FigureImage;



                    if ((i + j) % 2 == 0)
                    {
                        c.cellPanel.BackColor = Color.Brown;
                    }
                    else
                    {
                        c.cellPanel.BackColor = Color.Beige;
                    }                   
                
                    
                }
                
            }
            

        
            
        }
        
        public bool IsOutOfBounds(Cell cell)
        {
            if (cell.rowNumber < 0 || cell.rowNumber > 7 || cell.colNumber < 0 || cell.colNumber > 7)
                return true;
            else
                return false;
        }


     
        public void GenerateFigures(Board board)
        {
            Random rand = new Random();
            int rowNumber; int colNumber;
            Figure[] WhitePawn = new Figure[8];
            Figure[] BlackPawn = new Figure[8];
            string curPath = AppDomain.CurrentDomain.BaseDirectory;
            string solDir = Directory.GetParent(curPath).FullName;

            string imagesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Images");

            for (int i = 0; i < 8; i++)
            {
                WhitePawn[i] = new Figure(Figure.FigureName.Pawn, Figure.FigureColor.White, Path.Combine(imagesPath, "white-pawn.png"));
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = WhitePawn[i];

                BlackPawn[i] = new Figure(Figure.FigureName.Pawn, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-pawn.png"));
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = BlackPawn[i];
            }










            Figure[] WhiteRook = new Figure[2];
            Figure[] BlackRook = new Figure[2];
            for (int i = 0; i < 2; i++) {
                WhiteRook[i] = new Figure(Figure.FigureName.Rook, Figure.FigureColor.White, Path.Combine(imagesPath, "white-rook.png"));
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = WhiteRook[i];
                BlackRook[i] = new Figure(Figure.FigureName.Rook, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-rook.png"));
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = BlackRook[i];
            }
            


            Figure[] WhiteKnight = new Figure[2];
            Figure[] BlackKnight = new Figure[2];
            for (int i = 0; i < 2; i++) {
                WhiteKnight[i] = new Figure(Figure.FigureName.Knight, Figure.FigureColor.White, Path.Combine(imagesPath, "white-knight.png"));
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = WhiteKnight[i];
                BlackKnight[i] = new Figure(Figure.FigureName.Knight, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-knight.png"));
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = BlackKnight[i];
            }
            


            Figure[] WhiteBishop = new Figure[2];
            Figure[] BlackBishop = new Figure[2];
            for(int i = 0; i < 2; i++)
            {
                WhiteBishop[i] = new Figure(Figure.FigureName.Bishop, Figure.FigureColor.White, Path.Combine(imagesPath, "white-bishop.png"));
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = WhiteBishop[i];
                BlackBishop[i] = new Figure(Figure.FigureName.Bishop, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-bishop.png"));
                while (board.Grid[rowNumber, colNumber].currOccupied)
                {
                    rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
                }
                board.Grid[rowNumber, colNumber].currOccupied = true;
                board.Grid[rowNumber, colNumber].figure = BlackBishop[i];
            }
            


            Figure WhiteQueen = new Figure(Figure.FigureName.Queen, Figure.FigureColor.White, Path.Combine(imagesPath, "white-queen.png"));
            Figure BlackQueen = new Figure(Figure.FigureName.Queen, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-queen.png"));
            rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
            while (board.Grid[rowNumber, colNumber].currOccupied)
            {
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
            }
            board.Grid[rowNumber, colNumber].currOccupied = true;
            board.Grid[rowNumber, colNumber].figure = WhiteQueen;
            while (board.Grid[rowNumber, colNumber].currOccupied)
            {
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
            }
            board.Grid[rowNumber, colNumber].currOccupied = true;
            board.Grid[rowNumber, colNumber].figure = BlackQueen;



            Figure WhiteKing = new Figure(Figure.FigureName.King, Figure.FigureColor.White, Path.Combine(imagesPath, "white-king.png"));
            Figure BlackKing = new Figure(Figure.FigureName.King, Figure.FigureColor.Black, Path.Combine(imagesPath, "black-king.png"));
            while (board.Grid[rowNumber, colNumber].currOccupied)
            {
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
            }
            board.Grid[rowNumber, colNumber].currOccupied = true;
            board.Grid[rowNumber, colNumber].figure = WhiteKing;
            while (board.Grid[rowNumber, colNumber].currOccupied)
            {
                rowNumber = rand.Next(0, 8); colNumber = rand.Next(0, 8);
            }
            board.Grid[rowNumber, colNumber].currOccupied = true;
            board.Grid[rowNumber, colNumber].figure = BlackKing;

        }

        

        public void ChangeColor(Cell cell)
        {
            cell.cellPanel.BackColor = Color.Green;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public int FigureRowNumber; public int FigureColumnNumber;
        public int TargetRowNumber; public int TargetColumnNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            FigureRowNumber = Int32.Parse(textBox1.Text);
            FigureColumnNumber = Int32.Parse(textBox2.Text);
            ChangeColor(board.Grid[FigureRowNumber, FigureColumnNumber]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TargetRowNumber = Int32.Parse(textBox3.Text);
            TargetColumnNumber = Int32.Parse(textBox4.Text);
            ChangeColor(board.Grid[TargetRowNumber, TargetColumnNumber]);
        }

        public bool Valid(Cell c)
        {
            if (IsOutOfBounds(c) || c.currOccupied || c.visited)
                return false;
            else
                return true;
        }

        void MakeGreen(Board board)
        {
            for(int i = 0; sol[i]!=null; i++)
            {
                board.Grid[sol[i].rowNumber, sol[i].colNumber].cellPanel.BackColor = Color.Aquamarine;
            }
        }

        public void Test(Cell cell)
        {
            cell.cellPanel.BackColor = Color.Aquamarine;
        }


        bool ok = false;
        public void FindWay(int k,Cell startCell, Cell targetCell)
        {
            if (targetCell.currOccupied)
                return;
            board.GetNextMoves(startCell);
            startCell.visited = true;
            for (int i = 0; board.NextLegalMove[i]!=null; i++)
            {
                
                if (Valid(board.NextLegalMove[i]))
                {
                    sol[k] = board.NextLegalMove[i];
                    if (sol[k].rowNumber == targetCell.rowNumber && sol[k].colNumber == targetCell.colNumber)
                    {                      
                        MakeGreen(board);
                        ok = true;
                        return;
                    } 
                    else
                        FindWay(k + 1, sol[k], targetCell);
                    
                }
                

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FindWay(0, board.Grid[FigureRowNumber, FigureColumnNumber], board.Grid[TargetRowNumber, TargetColumnNumber]);
            if (!ok)
                MessageBox.Show("No path");
            else
                MessageBox.Show("Path/Paths found!", "Success", MessageBoxButtons.OK);
            board.Grid[TargetRowNumber, TargetColumnNumber].cellPanel.BackColor = Color.Purple;
            board.GetNextMoves(board.Grid[FigureRowNumber, FigureColumnNumber]);

            //Test(board.NextLegalMove[0]);
        }
    }
}
