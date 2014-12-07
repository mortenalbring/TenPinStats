using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTableParser
{
    public class Player
    {
        string Name { get; set; }
        BoundingBox FrameBBox = new BoundingBox();
        BoundingBox ScoreBBox = new BoundingBox();
    }
}
