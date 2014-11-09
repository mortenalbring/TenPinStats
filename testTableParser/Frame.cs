using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTableParser
{
    public class Frame
    {
        public string Player { get; set; }
        public Ball Ball1 = new Ball();
        public Ball Ball2 = new Ball();
    }
}
