using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainProject
{
    class SmallBlock
    {
        int index;
        int size;
        int next1;
        int next2;
        int prev1;
        int prev2;
        bool underground = false;
        String station = "null";
        int speedLimit;

        public SmallBlock(string i, string s, string sL, string st, string n1, string n2, string p1, string p2)
        {
            index = Convert.ToInt32(i);
            size = Convert.ToInt32(s);
            next1 = Convert.ToInt32(n1);
            next2 = Convert.ToInt32(n2);
            prev1 = Convert.ToInt32(p1);
            prev2 = Convert.ToInt32(p2);
            if (st.Equals("UNDERGROUND")) underground = true;
            else if (!st.Equals("null")) station = st;
            speedLimit = Convert.ToInt32(sL);
        }
        public int getSpeedLimit()
        {
            return speedLimit;
        }
        public int getSize()
        {
            return size;
        }
        public int getNext1()
        {
            return next1;
        }
        public int getNext2()
        {
            return next2;
        }
        public int getPrev1()
        {
            return prev1;
        }
        public int getPrev2()
        {
            return prev2;
        }
    }
}
