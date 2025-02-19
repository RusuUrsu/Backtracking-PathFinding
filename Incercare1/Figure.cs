using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Incercare1
{
    class Figure
    {
        public Image FigureImage;

        public enum FigureName
        {
            Pawn,
            Knight,
            Bishop,
            Rook,
            Queen,
            King
        }

        public enum FigureColor
        {
            White,
            Black
        }

        public FigureName name;
        public FigureColor color;
        public Figure(FigureName n, FigureColor c, string img)
        {
            name = n;
            color = c;
            this.FigureImage = Image.FromFile(img);
        }

        
    }
}
