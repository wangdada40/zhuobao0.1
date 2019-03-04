using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 珠宝.Controllers
{
    public class BackgroundController : Controller
    {
        //登录界面
        public ActionResult login()
        {
            return View();
        }

        // GET: background
        public ActionResult Index()
        {
            return View();
        }

        //初始界面
        public ActionResult Index_V1()
        {
            return View();
        }
        //收件箱
        public ActionResult mailbox()
        {
            return View();
        }
        //查看邮箱
        public ActionResult mail_detail()
        {
            return View();
        }
        //写信
        public ActionResult mail_compose()
        {
            return View();
        }
        //联系人
        public ActionResult contacts()
        {
            return View();
        }
        //个人资料
        public ActionResult profile()
        {
            return View();
        }
        //项目

        public ActionResult projects()
        {
            return View();
        }
        //项目详情
        public ActionResult project_detail()
        {
            return View();
        }
        //团队管理

        public ActionResult teams_board()
        {
            return View();
        }
        //客户管理

        public ActionResult clients()
        {
            return View();
        }
        //日历
        public ActionResult calendar()
        {
            return View();
        }
        //标签
        
             public ActionResult pin_board()
        {
            return View();
        }
        //单据
        public ActionResult invoice()
        {
            return View();
        }
        //单据打印invoice_print
        public ActionResult invoice_print()
        {
            return View();
        }
        //聊天窗口chat_view
        public ActionResult chat_view()
        {
            return View();
        }
        public ActionResult loginh()
        {
            return View();
        }
        public ActionResult form_wizard1()
        {
            return View();
        }
        public ActionResult person_wizard1()
        {
            return View();
        }
    }
}