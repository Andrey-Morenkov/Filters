using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Filters
{
    abstract class Filters
    {
        public Random r = new System.Random();
        public Bitmap processImage (Bitmap sourceImage, BackgroundWorker worker)
        {
            Bitmap ImageForCancel = sourceImage;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int i = 0; i < sourceImage.Width; i++)
            {
                if (worker.CancellationPending == false)
                {
                    worker.ReportProgress((int)((float)i / resultImage.Width * 100));
                    for (int j = 0; j < sourceImage.Height; j++)
                    {
                        resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                    }
                }
                else
                    return ImageForCancel;
            }
            return resultImage;
        }

        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }


    }
}
