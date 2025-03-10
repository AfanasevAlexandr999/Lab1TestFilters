using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace C__1
{
    internal class GrayScaleFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
             Color sourceColor = sourceImage.GetPixel(x, y);
             int intensive = (int)(sourceColor.R * 0.299 + sourceColor.G * 0.587 + sourceColor.B * 0.114);
             Color resultColor = Color.FromArgb(intensive, intensive, intensive);
             return resultColor;
        }

    }
}
