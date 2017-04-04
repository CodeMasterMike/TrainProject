using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Crossing
    {
        public int crossingId { get; set; }
        public int blockId { get; set; }
        public bool activated { get; set; }

        public Crossing(int id, int bId)
        {
            crossingId = id;
            blockId = bId;
            activated = false;
        }
    }
}