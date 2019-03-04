using Microsoft.Owin;
using Owin;
using 珠宝.SignalR;

[assembly: OwinStartupAttribute(typeof(珠宝.Startup))]
namespace 珠宝
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<MyConnection1>("/myconnection");

           // ConfigureAuth(app);
        }
    }
}
