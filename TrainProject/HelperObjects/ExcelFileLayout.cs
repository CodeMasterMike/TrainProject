using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject.HelperObjects
{
    class ExcelFileLayout
    {
        public String Line { get; set; } //0
        public String Section { get; set; } //1
        public int BlockNumber { get; set; } //2
        public double BlockLength { get; set; } //3
        public double BlockGrade { get; set; } //4
        public int SpeedLimit { get; set; } //5
        public String Infrastructure { get; set; } //6
        //empty column here //7
        public double Elevation { get; set; } //8
        public double CumulativeElevation { get; set; } //9
        public String SwitchBlock { get; set; } //10
        public String ArrowDirection { get; set; } //11

        public ExcelFileLayout(String line, String section, int blockNumber, double blockLength, double blockGrade, int speedLimit, String infrastructure, double elevation, double cumulativeElevation, String switchBlock, String arrowDirection)
        {
            Line = line;
            Section = section;
            BlockNumber = blockNumber;
            BlockLength = blockLength;
            BlockGrade = blockGrade;
            SpeedLimit = speedLimit;
            Infrastructure = infrastructure;
            Elevation = elevation;
            CumulativeElevation = cumulativeElevation;
            SwitchBlock = switchBlock;
            ArrowDirection = arrowDirection;
        }

        //add ToString function if not working properly somewhere
    }
}
