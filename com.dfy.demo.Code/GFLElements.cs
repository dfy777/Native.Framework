using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dfy.demo.Code
{
    /// <summary>
    /// 四种建造模型的基类
    /// </summary>
    public class GFLElements
    {
        //属性
        #region
        public string Name { get; set; }

        public double Possibility { get; set; }

        public int Index { get; set; }

        public int Starnum { get; set; }

        public string PType { get; set; }
        #endregion

        public GFLElements()
        {

        }

        public GFLElements(int _index, double _possibility, int _starnum, string _name, string _type)
        {
            Name = _name;
            Possibility = _possibility;
            Index = _index;
            Starnum = _starnum;
            PType = _type;
        }

        public GFLElements(double _possibility, int _starnum)
        {
            //Name = _name;
            Name = "Equip";
            Possibility = _possibility;
            Starnum = _starnum;
            Index = -1;
        }

        public override string ToString()
        {
            string str1 = "Name: " + Name;
            string str2 = "Star: " + Starnum;
            string str3 = "type: " + PType; 
            return $"{str1, -50}{str2, -50}{str3}";
        }
    }
}
