using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    class Block
    {
        //these properties keep track of block info
        private int blockId { get; set; }
        private int blockNum { get; set; }
        private String section { get; set; }
        private String line { get; set; }
        private int length { get; set; }
        private int speedLimit { get; set; }
        private double grade { get; set; }
        private double elevation { get; set; }
        private double cumElevation { get; set; }

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
    }
}
