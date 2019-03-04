using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 珠宝.SignalR
{
    public class MyChat
    {
        //房间名
        public string RoomName { get; set; }
        //内容
        public string Data { get; set; }
        //进入房间消息
        public string Action { get; set; }

    }
}