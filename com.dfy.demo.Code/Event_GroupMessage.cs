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
        
        /// <summary>
        /// 收到群消息
        /// </summary>
        /// <param name="sender">消息来源</param>
        /// <param name="e">事件参数</param>
        public void GroupMessage(object sender, CQGroupMessageEventArgs e)
        {

            CQCode cqat = e.FromQQ.CQCode_At();
            e.FromGroup.SendGroupMessage(cqat, "您发送了一条信息 ", e.Message);

            //throw new NotImplementedException();
        }
    }
}