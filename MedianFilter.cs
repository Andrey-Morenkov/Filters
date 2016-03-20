using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class MedianFilter : Filters
    {
        protected float[,] kernel = null;
        protected float[] brightline = null;

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor;

            int rad = kernel.GetLength(0) / 2;
            int z = 0;

            for (int l = -rad; l <= rad; l++)
            {
                for (int k = -rad; k <= rad; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    sourceColor = sourceImage.GetPixel(idX,idY);

                    brightline[z] = (0.36f * sourceColor.R + 0.53f * sourceColor.G + 0.11f * sourceColor.B);
                    z++;
                }
            }

            Array.Sort(brightline);

            float resultBr = brightline[rad*rad/ 2];

          /*  return Color.FromArgb(Clamp((int)resultBr, 0, 255),
                                  Clamp((int)resultBr, 0, 255),
                                  Clamp((int)resultBr, 0, 255));*/
            sourceColor = sourceImage.GetPixel(x, y);
            Color resultColor = Color.FromArgb(Clamp(sourceColor.R + (int)resultBr, 0, 255),
                                              Clamp(sourceColor.G + (int)resultBr, 0, 255),
                                              Clamp(sourceColor.B + (int)resultBr, 0, 255));
            return resultColor;
        }

        public MedianFilter(int rad)
        {
            kernel = new float[rad, rad];
            brightline = new float[rad*rad];
        }
    }
}
