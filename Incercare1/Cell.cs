using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incercare1
{
    class Cell
    {
        public int rowNumber;
        public int colNumber;
        public bool currOccupied;
        public bool validNextMove;
        public Panel cellPanel;
        public Figure figure;
        public bool visited;


        public Cell(int i, int j)
        {
            rowNumber = i;
            colNumber = j;
        }
    }
}
