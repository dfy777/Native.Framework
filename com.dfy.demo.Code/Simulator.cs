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
        #region --字段--
        private Produce produce;
        #endregion


        #region --构造函数--
        public Simulator()
        {
            produce = new Produce();
        }
        #endregion


        #region --公有方法--

        /// <summary>
        /// 人形普建方法
        /// </summary>
        /// <param name="manpower">人力</param>
        /// <param name="ammo">弹药</param>
        /// <param name="ration">口粮</param>
        /// <param name="parts">零件</param>
        /// <param name="produce_num">建造次数</param>
        /// <returns>建造得到的人形的数据列表</returns>
        public List<string> BuildElement(int manpower, int ammo, int ration, 
                                 int parts, int produce_num)
        {
            try
            {
                produce.SetResources(manpower, ammo, ration, parts);
                return produce.BeginToProduce(1, produce_num);
            }
            catch(ArgumentException e)
            {
                throw new ArgumentException("非法资源数目", e);
            }
        }

        /// <summary>
        /// 人形普建方法
        /// </summary>
        /// <param name="resources">建造资源列表</param>
        /// <param name="produce_num">建造次数</param>
        /// <returns>建造得到的人形的数据列表</returns>
        public List<string> BuildElement(List<int> resources, int produce_num)
        {
            try
            {
                produce.SetResources(resources[0], resources[1], resources[2], resources[3]);
                return produce.BeginToProduce(1, produce_num);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("非法资源数目", e);
            }
        }

        #endregion

    }
}
