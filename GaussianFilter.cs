using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class GaussianFilter: MatrixFilter
    {
        public void createGaussianCernel (int radius, float sigma)
        {
            // определяем размер ядра
            int size = 2 * radius + 1;

            // создаём ядро фильтра
            kernel = new float[size, size];

            // коэфф. нормировки ядра
            float norm = 0;

            // рассчитываем ядро линейного фильтра
            for (int i = -radius; i <= radius; i++)
                for (int j = -radius; j < radius; j++)
                {
                    kernel[i + radius, j + radius] = (float)(Math.Exp( -(i * i + j * j) / (sigma * sigma) ));
                    norm += kernel[i + radius, j + radius];
                }

            //нормируем ядро
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
              
        }

        public GaussianFilter()
        {
            createGaussianCernel(3, 2);
        }
    }
}
