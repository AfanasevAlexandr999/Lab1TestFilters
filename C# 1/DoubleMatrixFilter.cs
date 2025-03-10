using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__1
{
    internal class DoubleMatrixFilter : Filters
    {
        protected float[,] kernel1 = null;
        protected float[,] kernel2 = null;
        protected DoubleMatrixFilter() { }
        public DoubleMatrixFilter(float[,] kernel1, float[,] kernel2)
        {
            this.kernel1 = kernel1;
            this.kernel2 = kernel2;
        }

        protected override Color calculateNewPixelColor(Bitmap sourseImage, int x, int y)
        {
            int radiusX = kernel1.GetLength(0) / 2;
            int radiusY = kernel1.GetLength(1) / 2;
            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            for (int l = -radiusX; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourseImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourseImage.Height - 1);
                    Color neighborColor = sourseImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + radiusX, l + radiusY];
                    resultG1 += neighborColor.G * kernel1[k + radiusX, l + radiusY];
                    resultB1 += neighborColor.B * kernel1[k + radiusX, l + radiusY];

                }
            radiusX = kernel2.GetLength(0) / 2;
            radiusY = kernel2.GetLength(1) / 2;
            float resultR2 = 0;
            float resultG2 = 0;
            float resultB2 = 0;
            for (int l = -radiusX; l <= radiusY; l++)
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourseImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourseImage.Height - 1);
                    Color neighborColor = sourseImage.GetPixel(idX, idY);
                    resultR2 += neighborColor.R * kernel2[k + radiusX, l + radiusY];
                    resultG2 += neighborColor.G * kernel2[k + radiusX, l + radiusY];
                    resultB2 += neighborColor.B * kernel2[k + radiusX, l + radiusY];

                }
            return Color.FromArgb(
                Clamp((int)(Math.Sqrt(resultR1 * resultR1 + resultR2 * resultR2)), 0, 255),
                Clamp((int)(Math.Sqrt(resultG1 * resultG1 + resultG2 * resultG2)), 0, 255),
                Clamp((int)(Math.Sqrt(resultB1 * resultB1 + resultB2 * resultB2)), 0, 255));
        }
    }
}
