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
        public int sectionId { get; set; }
        public int direction { get; set; }
        public String section { get; set; }
        public String line { get; set; }
        public int length { get; set; }
        public int speedLimit { get; set; }
        public double grade { get; set; } //need to change these to decimal
        public double elevation { get; set; }
        public double cumElevation { get; set; }
        public bool isUnderground { get; set; }
        public bool isFromYard { get; set; }
        public bool isToYard { get; set; }

        //need to discuss how to do this further
        public int? prevBlockId { get; set; }
        public int? nextBlockId { get; set; }
        public Boolean bidirectional { get; set; }
        
        //these boolean properties keep track of state of block 
        private Boolean broken { get; set; }
        private Boolean occupied { get; set; }
        private Boolean hasCrossing { get; set; }
        private Boolean hasSwitch { get; set; } //maybe make this int to say which crossing?


        //now infrastructure related things
        public Station station { get; set; }
        public Crossing crossing { get; set; }
        public Switch parentSwitch { get; set; }
        public Beacon beacon { get; set; }

        public Block(int bN, int d)
        {
            blockNum = bN;
            direction = d;
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
