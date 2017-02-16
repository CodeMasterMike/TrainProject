using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    public class Block
    {
        //these properties keep track of block info
        public int blockId { get; set; }
        public int blockNum { get; set; }
        public String section { get; set; }
        public String line { get; set; }
        public int length { get; set; }
        public int speedLimit { get; set; }
        public double grade { get; set; }
        public double elevation { get; set; }
        public double cumElevation { get; set; }
        public int sectionId { get; set; }
        public int direction { get; set; }
        public bool isUnderground { get; set; }

        //need to discuss how to do this further
        private int prevBlock { get; set; }
        private int nextBlock { get; set; }
        private Boolean bidirectional { get; set; }
        
        //these boolean properties keep track of state of block 
        private Boolean broken { get; set; }
        private Boolean occupied { get; set; }
        private Boolean hasCrossing { get; set; }
        private Boolean hasSwitch { get; set; } //maybe make this int to say which crossing?

        public Block()
        {
            
        }

        public Block(int bId, int bn, int sId, decimal l, decimal g, decimal e, decimal ce, int sl, bool ug)
        {
            blockId = bId;
            blockNum = bn;
            sectionId = sId;
            length = (int)l;
            grade = (double)g; //needs to be decimal
            elevation = (double)e;
            cumElevation = (double)ce;
            speedLimit = sl;
            isUnderground = ug;
        }
    }
}
