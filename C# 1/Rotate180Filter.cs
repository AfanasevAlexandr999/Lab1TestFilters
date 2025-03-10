using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__1
{
    internal class Rotate180Filter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int x0 = sourceImage.Width / 2;
            int y0 = sourceImage.Height / 2; // центры поворота

            double phi = Math.PI; // угол поворота

            int new_x = (int)((x - x0) * Math.Cos(phi)) - (int)((y - y0) * Math.Sin(phi)) + x0;
            int new_y = (int)((x - x0) * Math.Sin(phi)) + (int)((y - y0) * Math.Cos(phi)) + y0;

            if (new_x >= 0 && new_x < sourceImage.Width && new_y >= 0 && new_y < sourceImage.Height)
            {
                return sourceImage.GetPixel(new_x, new_y);
            }
            else
            {
                return Color.FromArgb(0, 0, 0);

            }
        }
    }
}
