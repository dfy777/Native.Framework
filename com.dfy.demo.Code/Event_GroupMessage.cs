using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using Native.Sdk.Cqp.Model;

namespace com.dfy.demo.Code.Event_me
{
    public class Event_GroupMessage : IGroupMessage
    {
        #region --字段--
        #endregion


        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender">消息来源</param>
        /// <param name="e">事件参数</param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {

            CQCode cqat = e.FromQQ.CQCode_At();
            //QQMessage msg = new QQMessage(e.Message.CQApi, e.Message.Id, "人精建造");

            if ( e.Message.Text.IndexOf("人形建造") >= 0)
            {
                e.FromGroup.SendGroupMessage(cqat, Action_MakeTdoll(e.Message));
            }
            else
            {
                e.FromGroup.SendGroupMessage(cqat, "您发送了一条信息 ", e.Message);
            }

            e.Handler = true;  
        }

        public QQMessage Action_MakeTdoll(QQMessage receive_msg)
        {
            Simulator simulator = new Simulator();

            string[] order = receive_msg.Text.Split(' ');
            List<string> result_str = simulator.BuildElement(int.Parse(order[1]), int.Parse(order[2]),
                                                             int.Parse(order[3]), int.Parse(order[4]), 10);

            string final = "\n";
            foreach (string item in result_str)
            {
                final += item + '\n';
            }

            return new QQMessage(receive_msg.CQApi, receive_msg.Id, final); 
        }
    }
}