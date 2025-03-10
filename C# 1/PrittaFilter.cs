using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__1
{
    internal class PrittaFilter : DoubleMatrixFilter
    {
        public PrittaFilter() 
        {
            kernel1 = new float[,]
         {
             { -1,-1,-1},
             { 0,0,0},
             { 1,1,1}
         };
            kernel2 = new float[,]
            {
             { -1,0,1},
             { -1,0,1},
             { -1,0,1}
            };

        }
    }
}
