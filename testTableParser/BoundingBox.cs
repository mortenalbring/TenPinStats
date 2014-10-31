using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTableParser
{
    public class BoundingBox
    {
        public double x0;
        public double x1;

        public double y0;
        public double y1;

        public string makeCSV()
        {
            return x0 + "," + y0 + "," + x1 + "," + y1;
        }
    }
}
