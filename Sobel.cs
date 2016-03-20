using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class Sobel: MatrixFilter
    {
        public void createSobelCernel(int dim)
        {
            int size = dim;
            kernel = new float[size, size];

            kernel[0, 0] = -1;
            kernel[0, 1] = -2;
            kernel[0, 2] = -1;

            kernel[1, 0] =  0;
            kernel[1, 1] =  0;
            kernel[1, 2] =  0;
            
            kernel[2, 0] =  1;
            kernel[2, 1] =  2;
            kernel[2, 2] =  1;
        }

        public Sobel()
        {
            createSobelCernel(3);
        }
    }
}
