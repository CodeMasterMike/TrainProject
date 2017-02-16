using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.HelperObjects
{
    public class Line
    {
        public int lineId { get; set; }
        public string name { get; set; }
        public List<Section> sections { get; set; }

        public Line(int lId, string n, List<Section> sl = null)
        {
            lineId = lId;
            name = n;
            if (sl != null)
                sections = sl;
            else
                sections = new List<Section>();
        }
    }
}
