using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using 珠宝.App_Start;

namespace 珠宝.Controllers
{
    public class HomeInterfaceController : Controller
    {
        // GET: HomeInterface
        public ActionResult Index()
        {
            return View();
        }
        //注册
        public string Register(string name, int sex, string tel, string pass, string email)
        {
            // try {
            if (IsUser(name) == "用户名不存在")
            {
                DataConnect sqlData = new DataConnect();
                String sql = "INSERT INTO users([Name],Sex,Tel,Pass,Email,Dentity) VALUES('" + name + "','" + sex + "','" + tel + "','" + pass + "','" + email + "','" + 1 + "')";
                sqlData.Update(sql);
                return "注册成功";
            }
            else
            {
                return "用户名存在";
            }
            //}
            //catch {
            //    return "注册失败";
            //}
        }
        //查询用户是否存在
        public string IsUser(string name)
        {
            DataConnect sqlData = new DataConnect();
            String sql = "select * from users where [Name]='" + name + "'";
            //接收数据
            DataSet data = sqlData.Check(sql);
            if (data.Tables[0].Rows.Count == 0)
            {
                return "用户名不存在";
            }
            else
            {
                return "用户存在";
            }
        }
        //得到全部用户 0是普通用户
        public ActionResult getAllUser()
        {
            DataConnect sqlData = new DataConnect();
            String sql = "select * from users  " ;
            //接收数据
            DataSet data = sqlData.Check(sql);
            var checkjson = data.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));
        }




        //检测用户名与密码是否一致 0：密码错误 1：正确可以登录  -1：用户名不存在
        public int IsLogin(string name, string pass)
        {
            if (IsUser(name) == "用户存在")
            {
                DataConnect sqlData = new DataConnect();
                //SELECT * FROM users WHERE Name='admin' and Pass='12'
                String sql = "SELECT * FROM users WHERE Name='" + name + "' and Pass='" + pass + "'";
                //接收返回数据
                DataSet data = sqlData.Check(sql);
                if (data.Tables[0].Rows.Count == 0)
                {//密码不一致
                    return 0;
                }
                else
                {

                    //可以登录
                    return Convert.ToInt32(data.Tables[0].Rows[0][0].ToString());
                }

            }
            else
            {
                //用户名不存在
                return -1;
            }
        }
        public ActionResult uploadgoods()
        {

            return View();
        }
        [HttpPost]
        public ActionResult uploadgoods(string name, string money, string remark, HttpPostedFileBase img)
        {
            var filePath = Server.MapPath(string.Format("~/{0}", "img2"));
            //编写地位
            string guid = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
            String guid2 = name + guid;
            //路径地址
            var url = Path.Combine(filePath, guid2);
            //保存图片
            img.SaveAs(url);
            //存到数据库
            DataConnect conn = new DataConnect();
            string sql = "insert into Diamond(Name, Money, Remark,img) values('" + name + "'," + money + ", '" + remark + "','" + url + "')";
            conn.Update(sql);
            return Content("<script>alert('上传成功');history.go(-1);</script>");
        }


        public ActionResult uploadperson()
        {

            return View();
        }
        [HttpPost]
        public ActionResult uploadperson(string name, string pass, string tel, string email, string sex, HttpPostedFileBase img)
        {
            var filePath = Server.MapPath(string.Format("~/{0}", "imghear"));
            //编写地位
            string guid = Guid.NewGuid().ToString().Replace("-", "") + ".jpg";
            String guid2 = name + guid;
            //路径地址
            var url = Path.Combine(filePath, guid2);
            //保存图片
            img.SaveAs(url);
            //存到数据库
            DataConnect conn = new DataConnect();
            string sql = " INSERT INTO users (NAME, Pass, Sex, Tel,Dentity,Email,img)VALUES ('" + name + "','" + pass + "', '" + sex + "','" + tel + "','" + 1 + "','" + email + "','" + url + "')";
            conn.Update(sql);
            return Content("<script>alert('上传成功');history.go(-1);</script>");
        }

        public ActionResult getperson(int Dentity)
        {
            DataConnect conn = new DataConnect();
            string sql = "select* from users where Dentity="+  Dentity;
            var check = conn.Check(sql);
            var checkjson = check.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));
        }

        public ActionResult getgoods()
        {
            DataConnect conn = new DataConnect();
            string sql = "select* from Diamond";
            var check = conn.Check(sql);
            var checkjson = check.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));
        }
        //买珠宝材料
        public ActionResult buygoods(int TheOrderId, int DiamondId)
        {
            DataConnect conn = new DataConnect();
            string sql = " INSERT INTO Material(TheOrderId,DiamondId)VALUES ('" + TheOrderId + "','" + DiamondId + "')";
            conn.Update(sql);
            return Content("<script>alert('上传成功');history.go(-1);</script>");
        }
        //下单
        public string Getorder(string JewelryName, string JewelryDescribe,
            int UserID, int DesignerID, int Money, int State, int Gold, string Remark)
        {
            DataConnect conn = new DataConnect();
            string sql = " INSERT INTO TheOrder(JewelryName,JewelryDescribe,UserID,DesignerID,Money,State,Gold,Remark)" +
                "VALUES ('" + JewelryName + "','" + JewelryDescribe + "','" + UserID + "','" + DesignerID + "','" + Money + "','" + State + "','" + Gold + "','" + Remark + "')";
            conn.Update(sql);
            return "下单成功";
        }
        //查设计师自己的单
        public ActionResult Getmyorder(int DesignerID)
        {
            DataConnect conn = new DataConnect();
            string sql = "select* from  TheOrder where DesignerID = '"+DesignerID+"'";
            var check = conn.Check(sql);
            var checkjson = check.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));
        }
        //得到自己的订单ID
        public ActionResult Getmyorderid(int userid)
        {
            DataConnect conn = new DataConnect();
            string sql = "select* from  TheOrder where UserID = '" + userid + "'";
            var check = conn.Check(sql);
            var checkjson = check.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));
        }
        //检查是否是自己的id
        public bool Ismyorderid(int userid,int TheOrderId)
        {
            DataConnect conn = new DataConnect();
            string sql = "select* from  TheOrder where UserID = '" + userid + "' and Id ='"+TheOrderId+"'";
            var check = conn.Check(sql);
            
            if (check.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else {
                return true;
            }
        }
        //创建订单所需的材料
        public string GetMaterial(int userid,int TheOrderId,int DiamondId) {

            //检查是否该用户的订单号
            if (Ismyorderid(userid, TheOrderId))
            {
                DataConnect conn = new DataConnect();
                string sql = " INSERT INTO Material(TheOrderId,DiamondId)" +
                    "VALUES ('" + TheOrderId + "','" + DiamondId + "')";
                conn.Update(sql);
                return "购买成功";
            }
            else {
                return "这不是你的订单号请再检查";

            }

        }



    }
}