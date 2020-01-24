using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.Sdk.Extension
{
    public static class ApiExtension
    {
        public static bool SendMessage(this CQGroupMessageEventArgs e, object[] message)
        {
            return e.CQApi.SendGroupMessage(e.FromGroup.Id, message) == 0;
        }

        public static bool SendMessage(this CQGroupMessageEventArgs e, string message)
        {
            return e.CQApi.SendGroupMessage(e.FromGroup.Id, message) == 0;
        }

        public static bool SendMessageWithAt(this CQGroupMessageEventArgs e, string message)
        {
            return e.CQApi.SendGroupMessage(e.FromGroup.Id,
                new object[]{
                CQApi.CQCode_At(e.FromQQ.Id),
                message,
            }) == 0;
        }
    }
}
