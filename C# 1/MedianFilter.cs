using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__1
{
    internal class MedianFilter : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int[] listR = new int[9];
            int[] listG = new int[9];
            int[] listB = new int[9];
            int cnt = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    listR[cnt] = sourseImage.GetPixel(Clamp(x + j, 0, sourseImage.Width - 1), Clamp(y + i, 0, sourseImage.Height - 1)).R;
                    listG[cnt] = sourseImage.GetPixel(Clamp(x + j, 0, sourseImage.Width - 1), Clamp(y + i, 0, sourseImage.Height - 1)).G;
                    listB[cnt] = sourseImage.GetPixel(Clamp(x + j, 0, sourseImage.Width - 1), Clamp(y + i, 0, sourseImage.Height - 1)).B;
                    cnt++;
                }
            }
            Array.Sort(listR);
            Array.Sort(listG);
            Array.Sort(listB);
            return Color.FromArgb(listR[4], listG[4], listB[4]);
        }
    }
}
