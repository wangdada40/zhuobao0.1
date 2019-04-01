using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 珠宝.App_Start
{
  
    // 链接数据库
    //数据库连接
    public class DataConnect
    {

        //  static string mystr = "server='39.108.145.219';database='jewelry';uid='sa';password='as19961122'";
        static string mystr = "Data Source ='localhost'; Initial Catalog ='jewelry'; Integrated Security = True";
        
        static   SqlConnection myconn = new SqlConnection(mystr);


        //增
        public void Update(String sql)
        {
            myconn.Open();
            String sqlstr = sql;

            SqlCommand myda2 = new SqlCommand(sqlstr, myconn);

            myda2.ExecuteNonQuery();//执行插入语句

            myconn.Close();
        }
      
        //删
        public void Delete(String sql)
        {

            myconn.Open();
            //   String sqlstr = "select * from T_USER where u_name ='" + user + "'";
            String sqlstr = sql;
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, myconn);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            myda.Dispose();
            myds.Dispose();
            myconn.Close();


        }

        //查
        public DataSet Check(String sql)
        {
            myconn.Open();
            String sqlstr = sql;
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, myconn);
            DataSet myds = new DataSet();
            myda.Fill(myds);
            myda.Dispose();
            myds.Dispose();
            myconn.Close();
            return myds;

        }

        //改
        public void Change(String sql)
        {
            myconn.Open();
            //   String sqlstr = "select * from T_USER where u_name ='" + user + "'";
            String sqlstr = sql;
            SqlCommand myda2 = new SqlCommand(sqlstr, myconn);
            myda2.ExecuteNonQuery();//执行插入语句
            myconn.Close();
        }
    }
}