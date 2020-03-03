using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;
using Native.Sdk.Cqp;

namespace com.dfy.demo.Code.Event_me
{
    enum MakeTodll_FastFormula
    {

    }

    public class Event_GroupMessage : IGroupMessage
    {
        #region --字段--

        private Simulator simulator;
        private int BUILD_NUM = 10;
        private List<GFLElements> gflelements_list;

        #endregion


        #region --构造方法--

        public Event_GroupMessage()
        {
            this.simulator = new Simulator();
        }

        #endregion


        #region --公有方法--
        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender">消息来源</param>
        /// <param name="e">事件参数</param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {

            CQCode cqat = e.FromQQ.CQCode_At();
            //QQMessage msg = new QQMessage(e.Message.CQApi, e.Message.Id, "人精建造");

            if ( e.Message.Text.Length > 6 && e.Message.Text.IndexOf("人形建造", 0, 5) == 0)
            {
                try
                {
                    gflelements_list = Action_MakeTdoll(e.Message);

                    int[] index_list = new int[BUILD_NUM];
                    for(int i = 0; i < BUILD_NUM; i++)
                    {
                        index_list[i] = gflelements_list[i].Index;
                    }

                    CombineGraph cg = new CombineGraph(index_list);
                    cg.CombineAvator();


                    CQCode cqimg = CQApi.CQCode_Image("new.png");

                    e.FromGroup.SendGroupMessage(cqat, cqimg);
                }
                catch (Exception)
                {
                    return;
                }
            }
            else
            {
                //e.FromGroup.SendGroupMessage(cqat, e.Message.Text, e.Message);
                return;
            }

            e.Handler = true;  
        }

        #endregion


        #region --私有方法--

        /// <summary>
        /// 识别人形建造字符串
        /// </summary>
        /// <param name="receive_msg">输入的指令</param>
        /// <returns>表示建造结果的字符串</returns>
        private List<GFLElements> Action_MakeTdoll(QQMessage receive_msg)
        {
            //Simulator simulator = new Simulator();

            string[] order = receive_msg.Text.Split();
            List<GFLElements> tdoll_info;

            if (order.Length == 2)  // 输入的指令为建造公式
            {
                try
                {
                    string formula = order[1];
                    List<int> resources = Tdoll_FormulaDistinguish(formula);

                    if (resources.Count == 4)
                    {
                        tdoll_info = simulator.BuildElement(resources, BUILD_NUM);
                    }
                    else
                    {
                        throw new ArgumentException("建造公式错误");
                    }
                }
                catch(FormatException e1)
                {
                    throw e1;
                }
                catch(ArgumentException e2)
                {
                    throw new ArgumentException("建造公式错误", e2);
                }
            }
            else if (order.Length == 5)     //输入的指令为建造资源
            {
                try
                {
                    tdoll_info = this.simulator.BuildElement(int.Parse(order[1]),int.Parse(order[2]), 
                                                                            int.Parse(order[3]), int.Parse(order[4]), BUILD_NUM);
                }
                catch(FormatException e1)
                {
                    throw e1;
                }
                catch(ArgumentException e2)
                {
                    throw new ArgumentException("非法资源数目", e2);
                }
            }
            else
            {
                throw new ArrayTypeMismatchException("建造指令形式错误");
            }

            return tdoll_info; 
        }

        /// <summary>
        /// 判断人形建造指令的公式
        /// </summary>
        /// <param name="formula">公式字符串</param>
        /// <returns>四项建造资源数目</returns>
        private List<int> Tdoll_FormulaDistinguish(string formula)
        {
            //根据长度判断公式形式
            List<int> resources = new List<int>();
            try
            {
                if (formula.Length > 3 && formula.ToLower().IndexOf("x4") > 0)    //以缩写方式 --130x4
                {
                    formula = formula.Replace("x4", string.Empty);
                    int formula_int = int.Parse(formula);

                    resources.Add(formula_int);
                    resources.Add(formula_int);
                    resources.Add(formula_int);
                    resources.Add(formula_int);
                }
                else if (formula.Length == 4)    //以数字形式 --2021/4441
                {
                    int formula_int = int.Parse(formula);

                    switch(formula_int)
                    {
                        case 7614:      // mg 730 630 130 430
                            resources.Add(730);
                            resources.Add(630);
                            resources.Add(130);
                            resources.Add(430);
                            break;
                        case 0442:      // ar 97 404 404 233
                            resources.Add(97);
                            resources.Add(404);
                            resources.Add(404);
                            resources.Add(233);
                            break;
                        case 1442:      // ar 112 404 404 233
                            resources.Add(112);
                            resources.Add(404);
                            resources.Add(404);
                            resources.Add(233);
                            break;
                        case 4042:      // rf 404 91 404 233
                            resources.Add(404);
                            resources.Add(91);
                            resources.Add(404);
                            resources.Add(233);
                            break;
                        case 4040:      // rf 404 99 404 98
                            resources.Add(404);
                            resources.Add(99);
                            resources.Add(404);
                            resources.Add(98);
                            break;
                        case 4442:      // smg 430 430 430 230
                            resources.Add(430);
                            resources.Add(430);
                            resources.Add(430);
                            resources.Add(430);
                            break;
                        default:
                            break;
                    }

                    if (resources.Count != 4)
                    {
                        throw new ArgumentException("公式形式错误");
                    }
                }
                else if ((formula.Length == 3) || (formula.Length == 2)) //以枪类型形式 --smg/ar/rf
                {
                    string formula_lower = formula.ToLower();
                    if (formula_lower.Equals("smg"))
                    {
                        resources.Add(400);
                        resources.Add(400);
                        resources.Add(100);
                        resources.Add(200);
                    }
                    else if (formula_lower.Equals("ar"))
                    {
                        resources.Add(100);
                        resources.Add(400);
                        resources.Add(400);
                        resources.Add(200);
                    }
                    else if (formula_lower.Equals("rf"))
                    {
                        resources.Add(400);
                        resources.Add(100);
                        resources.Add(400);
                        resources.Add(200);
                    }
                    else if (formula_lower.Equals("mg"))
                    {
                        resources.Add(800);
                        resources.Add(800);
                        resources.Add(100);
                        resources.Add(400);
                    }
                    else if (formula_lower.Equals("hg"))
                    {
                        resources.Add(130);
                        resources.Add(130);
                        resources.Add(130);
                        resources.Add(30);
                    }
                    else
                    {
                        // do nothing
                    }

                    if (resources.Count != 4)
                    {
                        throw new ArgumentException("人形类型错误");
                    }
                }
                else
                {
                    throw new ArgumentException("建造公式错误");
                }
            }
            catch (ArgumentException e1)
            {
                throw new ArgumentException("建造公式错误", e1);
            }
            catch (FormatException e2)
            {
                throw new FormatException("建造公式错误", e2);
            }

            return resources;
        }

        #endregion
    }
}