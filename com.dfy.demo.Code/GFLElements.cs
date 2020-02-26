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
        string Name { get; set; }
        
        double Possibility { get; set; }

        int Index { get; set; }

        int Starnum { get; set; }
        #endregion

        public GFLElements(int _index, double _possibility, int _starnum, string _name)
        {
            Name = _name;
            Possibility = _possibility;
            Index = _index;
            Starnum = _starnum;
        }

        public GFLElements(double _possibility, int _starnum)
        {
            //Name = _name;
            Name = "Equip";
            Possibility = _possibility;
            Starnum = _starnum;
            Index = -1;
        }
    }
}
