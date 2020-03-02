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
        #region --字段--
        int FORMAT_INT = -30;
        #endregion

        #region --属性--
        public string Name { get; set; }

        public double Possibility { get; set; }

        public int Index { get; set; }

        public int Starnum { get; set; }

        public string PType { get; set; }
        #endregion


        #region --构造函数
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
        #endregion


        #region --公有方法--
        public override string ToString()
        {
            string str1 = "Name: " + Name;
            string str2 = "Star: " + Starnum;
            string str3 = "type: " + PType; 
            return $"{str1, -35}{str2, -30}{str3}";
        }
        #endregion

    }
}
