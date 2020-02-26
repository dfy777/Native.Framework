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
    public abstract class GFLElements
    {
        /// <summary>
        /// 确定建造得到的道具的星级数
        /// </summary>
        /// <param name="produce_type">建造类型</param>
        /// <returns>返回星级数</returns>
        abstract public int make_star(int produce_type);
        
    }
}
