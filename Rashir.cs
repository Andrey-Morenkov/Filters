using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Filters
{
    class Rashir : Filters
    {
        public bool [,] mask;
        public Bitmap dst;
        public int MH;
        public int MW;



        public Color ResultColor( int _MaxIntensity)
        {
            return Color.FromArgb(Clamp(_MaxIntensity, 0, 255), Clamp(_MaxIntensity, 0, 255), Clamp(_MaxIntensity, 0, 255));
        }

  /*      public int CalculateIntensity(int _x, int _y, Bitmap _src)
        {
            return (int)(0.36 * _src.GetPixel(_x, _y).R + 0.53 * _src.GetPixel(_x, _y).G + 0.11 * _src.GetPixel(_x, _y).B);
        }*/

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            
            Color tmp=Color.Black;
            int MaxIntensity = 0;
            if ((x == 0) || (y == 0) || (x == sourceImage.Width - 1) || (y == sourceImage.Height - 1)) return (sourceImage.GetPixel(x, y));
            for (int j = -MH / 2; j <= MH / 2; j++)
                {
                    for (int i = -MW / 2; i <= MW / 2; i++)
                       {
                           Color sourceColor = sourceImage.GetPixel(x+i, y+j);
                            int Intensity =Clamp((int)(0.36*sourceColor.R+0.53*sourceColor.G+0.11*sourceColor.B),0,255);
                                //CalculateIntensity(x + i, y + j, src);
                            if (mask[i+1, j+1] && (Intensity > MaxIntensity))
                            {
                                MaxIntensity = Intensity;
                                tmp = sourceColor;
                            }
                        }
                 }
            //Color resultColor = Color.FromArgb(Clamp(sourceColor.R + (int)resultBr, 0, 255),
            //                                  Clamp(sourceColor.G + (int)resultBr, 0, 255),
            //                                  Clamp(sourceColor.B + (int)resultBr, 0, 255));
            return tmp;
        }

        public Rashir(int rad)
        {
            MH = MW = rad;

            mask = new bool[rad, rad];
            mask[0,0] = false;
            mask[0,1] = true;
            mask[0,2] = false;

            mask[1,0] = true;
            mask[1,1] = true;
            mask[1,2] = true;

            mask[2,0] = false;
            mask[2,1] = true;
            mask[2,2] = false;
                
        }





    }
}
