using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 珠宝.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult ce()
        {
            return View();
        }
        //注册界面.
        public ActionResult Register()
        {
            return View();
        }

        //浮动小人
        public ActionResult fu()
        {
            return View();
        }
        //瀑布流
        public ActionResult pubu()
        {

            return View();
        }

        //瀑布流
        public ActionResult cepubu()
        {

            return View();
        }
        //主界面
        public ActionResult menu()
        {
            return View();
        }
        //展示
        public ActionResult show(int userid)
        {
            return View();
        }
        //设计师页面
        public ActionResult stylist()
        {
            return View();
        }
        //聊天界面
        public ActionResult chat()
        {
            return View();
        }
        //下单界面
        public ActionResult order() {
            return View();
        }
    }
}