using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testTableParser
{
    public class PdfXmlItem
    {
        public int PageNumber;
        public string Title;
        public BoundingBox BBox = new BoundingBox();

    }
}
