using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class GlassFilter: Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int k, int l)
        {
            int x = (int)(k + (r.NextDouble() - 0.5) * 10);
            int y = (int)(l + (r.NextDouble() - 0.5) * 10);

            int X = Clamp(x, 0, sourceImage.Width - 1);
            int Y = Clamp(y, 0, sourceImage.Height - 1);

            return (sourceImage.GetPixel(X, Y));
        }
    }
}
