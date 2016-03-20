using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class Harsh : MatrixFilter
    {
        public void createHarshCernel(int dim)
        {
            int size = dim;
            kernel = new float[size, size];

            kernel[0, 0] = 0;
            kernel[0, 1] = -1;
            kernel[0, 2] = 0;

            kernel[1, 0] =  -1;
            kernel[1, 1] =  5;
            kernel[1, 2] =  -1;
            
            kernel[2, 0] =  0;
            kernel[2, 1] =  -1;
            kernel[2, 2] =  0;
        }

        public Harsh()
        {
            createHarshCernel(3);
        }
    }
}
