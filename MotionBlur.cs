using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Filters
{
    class MotionBlur : MatrixFilter
    {
        public void createMotionBlurCernel(int n)
        {
            int size = n; 
            kernel = new float[size, size];

            for(int i = 0; i < size; i++)
                for(int j = 0; j < size; j++)
                {
                    if (i == j)
                        kernel[i, j] = ((float)1/n);
                    else
                        kernel[i, j] = 0;
                }            
        }

        public MotionBlur()
        {
            createMotionBlurCernel(9);   // магия, выше 9 не ставить
        }
    }
}
