using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Event_Friend : IFriendAdd, IFriendAddRequest
    {
        public void FriendAdd(object sender, CQFriendAddEventArgs e)
        {
            Common.NewFriends += 1;
        }

        public void FriendAddRequest(object sender, CQFriendAddRequestEventArgs e)
        {
            if (Common.IsRunning == false) { return; }
            e.CQApi.SetFriendAddRequest(e.ResponseFlag, Native.Csharp.Sdk.Cqp.Enum.CQResponseType.PASS);
        }
    }
}
