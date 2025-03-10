using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace C__1
{
    abstract class Filters
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y); // вычисление значения пикселя отфильтрованного изображения
        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker) //  создает пустое изображение такого же размера как и исходное
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++) // обходит все пиксели начиная с 0 0 
            {
                worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j)); // с помощью сетпиксель устанавливаем значение пикселю с текущими координатами значение функциии калькулейт нью пиксель коллор
                }
            }
            return resultImage;
        }
        public int Clamp(int value, int min, int max) // приведение значения пикселя к допустимому диапазону 0 255
        {
            return Math.Min(Math.Max(value, min), max);
        }
    }
}