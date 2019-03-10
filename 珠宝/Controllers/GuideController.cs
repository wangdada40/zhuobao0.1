using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 珠宝.App_Start;

namespace 珠宝.Controllers
{
    public class GuideController : Controller
    {
        // GET: Guide
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Animation() {

            return View();
        }
        //上传喜好数据

        public string UpdateAnimation(int id,string style,string color,string describer,int money) {
            if (IsUser(id))
            {
                DataConnect sqlData = new DataConnect();
                String sql = "INSERT INTO UserLove(userID,style,color,describer,money) VALUES('" + id + "','" + "大众风" + "','" + color + "','" + describer + "','" + money + "')";
                sqlData.Update(sql);
                return "上传成功";
            }
            else {
                DataConnect sqlData = new DataConnect();
                String sql = "UPDATE UserLove SET style = '"+style+ "', color = '" + color + "',describer ='"+describer+"',money="+money+"' WHERE userID = 'Wilson'";
                sqlData.Check(sql);
                return "上传成功";
            }
          
            
        }

        //查找喜好数据
        public ActionResult GetAnimation(int id)
        {
            DataConnect sqlData = new DataConnect();
            String sql = "select * from UserLove where userID='" + id + "'";
            //接收数据
            DataSet data = sqlData.Check(sql);
            var checkjson = data.Tables[0];
            return Content(JsonConvert.SerializeObject(checkjson));

        }

        //查找是否存在用户
        public bool IsUser(int id)
        {
            DataConnect sqlData = new DataConnect();
            String sql = "select * from UserLove where userID='" + id + "'";
            //接收数据
            DataSet data = sqlData.Check(sql);
            if (data.Tables[0].Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}