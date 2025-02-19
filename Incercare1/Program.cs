using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Incercare1
{
    class Program
    {
        
        [STAThread]
        static void Main()
        {
            Board board = new Board(8);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        

       
    }

}
