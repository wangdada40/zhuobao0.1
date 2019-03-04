using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace 珠宝.SignalR
{
    public class MyConnection1 : PersistentConnection
    {
        public MyConnection1()
        {

            Debug.WriteLine("我被初始化了");

        }


        protected override Task OnConnected(IRequest request, string connectionId)
        {
            return Connection.Send(connectionId, "Welcome!");
        }

        //接收信息
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            //把传过来的data序列化，因为传过来的是json格式
            var model = JsonConvert.DeserializeObject<MyChat>(data);
            //如果传过来的是welcome，证明是刚进房的用户
            if (model.Action == "welcome")
            {
                //把用户ID，加进组中
                this.Groups.Add(connectionId, model.RoomName);
                //返回welcome new user 给除了进组用户以为的其他人
                //参数model.RoonName 是房间名，connectionId排查用户的ID
                var getData = new getdata {
                    name = model.RoomName,
                    ramark = "Welcome new user!"

                };
                return this.Groups.Send(model.RoomName, getData.ramark, connectionId);
                //如果不排除组，Id返回给所有人
                //return Connection.Send(connectionId,"Welcom")
            }
            //否则就是 用户发送信息，发给除了用户的其他人
            else
            {
                //model.Data 是发送的内容
                return this.Groups.Send(model.RoomName, model.Data, connectionId);
            }

        }
    }
}