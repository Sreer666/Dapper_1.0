using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;
using System.Collections;

namespace Dapper_1._0
{
   public class Dapper_Sample
    {
        static void Main(string[] args)
        {
           IDbConnection db = new SqlConnection(CommonVariables.ConnectionString);

           string query = "Select distinct member_id FROM stat_his..member_status with(nolock) WHERE member_id IN('11937') and status_cd='PENDNG'";
           var results =  db.Query<int>(query).Single();
            Console.WriteLine(results);

        }
    }
    public class CommonVariables
    {
        public static String ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["Medisys_Dev"].ConnectionString; }
        }
    }

    //public class DbConnect
    //{
    //    static IDbConnection db = new SqlConnection(CommonVariables.ConnectionString);

    //   public void DbconnectMethod()
    //    {
    //        string query = "Select distinct member_id FROM stat_his..member_status with(nolock) WHERE member_id IN('11937') and status_cd='PENDNG'";
    //        db.Query<int>(query).Single();
    //    }
    //}


}
