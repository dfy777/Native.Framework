using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace com.dfy.demo.Code
{

    public class Simulator
    {
        private Produce produce;

        public Simulator()
        {
            produce = new Produce();
        }

        public void BuildElement(int manpower, int ammo, int ration, 
                                 int parts, int produce_num)
        {
            produce.SetResources(manpower, ammo, ration, parts);
            produce.BeginToProduce(1, produce_num);
        }
    }
}
