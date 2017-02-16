using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.HelperObjects
{
    public class Section
    {
        public int sectionId { get; set; }
        public string name { get; set; }
        public int lineId { get; set; }
        public int? startBlockId { get; set; }
        public int? endBlockId { get; set; }
        public bool isBidirectional { get; set; }
        public List<Block> blocks { get; set; }

        public Section(int sId, string n, int lId, int? sbId, int? ebId, bool isBi, List<Block> bl = null)
        {
            sectionId = sId;
            name = n;
            lineId = lId;
            startBlockId = sbId;
            endBlockId = ebId;
            isBidirectional = isBi;
            if (bl != null)
                blocks = bl;
            else
                blocks = new List<Block>();
        }
    }
}
