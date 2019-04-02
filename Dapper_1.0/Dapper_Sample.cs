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
        //The Execute() method of the Dapper framework can be used to insert, update, or delete data into a database.
        //The Query() extension method in Dapper enables you to retrieve data from the database and populate data in your object model
        //The QueryMultiple() It can execute multiple queries within the same command and map results.

        static void Main(string[] args)
        {
           IDbConnection EmployeeModeldb = new SqlConnection(CommonVariables.ConnectionStringsEmployeeModel);

            if (EmployeeModeldb.Database == "CodeFirstNewDatabaseSample.BloggingContext")
            {

                #region Retrieve ALL Departments
                Console.WriteLine("Retrieve ALL Departments");
                string DepartmentsSelectQuery = "Select * from Departments";
                //By using QueryMultiple()
                var DepartmentsResults = EmployeeModeldb.QueryMultiple(DepartmentsSelectQuery);
                var qury = DepartmentsResults.Read<Departments>();
                foreach (var item in qury)
                {
                    Console.WriteLine("ID: \t" + item.ID + "\t" + "NAME: \t" + item.Name + "\t" + "Location: \t" + item.Location);
                    //Console.WriteLine(qury.ID + "\t" + qury.Name + "\t" + qury.Location);
                }

                Console.WriteLine("END Retrieve ALL Departments");
                #endregion

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                #region Trying to retrive list of ID
                //By using Query()
                //var DepartmentsResults = EmployeeModeldb.Query<Departments>(DepartmentsSelectQuery);

                //string DepartmentsIDres = "select ID from Departments";
                Console.WriteLine("Trying to retrive list of ID");
                var DepartmentsIDResults = EmployeeModeldb.QueryMultiple("select ID from Departments");
                var quryIDResults = DepartmentsIDResults.Read<Departments>();
                foreach (var item in quryIDResults)
                {
                    Console.WriteLine("ID: \t" + item.ID);
                    //Console.WriteLine(qury.ID + "\t" + qury.Name + "\t" + qury.Location);
                }
                Console.WriteLine("END to retrive list of ID");

                #endregion
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                #region Retrieve only one ID
                Console.WriteLine("Retrieve only one ID");
                var x = quryIDResults.First();
                Console.WriteLine("SINGLE ID: \t" + x.ID);

                Console.WriteLine("End OF Retrieve only ID");

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                #endregion

                //select Name from Departments

                #region Trying to retrive list of NAME
                Console.WriteLine("Trying to retrive list of NAME");
                var DepartmentsNameResults = EmployeeModeldb.QueryMultiple("select Name from Departments");
                var quryNameResults = DepartmentsNameResults.Read<Departments>();
                foreach (var item in quryNameResults)
                {
                    Console.WriteLine("Name: \t" + item.Name);
                    //Console.WriteLine(qury.ID + "\t" + qury.Name + "\t" + qury.Location);
                }
                Console.WriteLine("END to retrive list of Name"); 
                #endregion


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                #region Retrieve only Name

                Console.WriteLine("Retrieve only Name");
                var name = quryNameResults.First();
                Console.WriteLine("Name: \t" + name.Name);

                Console.WriteLine("End OF Retrieve only Name"); 
                #endregion

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                //select* from Departments where ID = 1
                //select* from Departments where Name = 'IT'
                //select* from Departments where Location = 'Norfolk'

                #region Departments WITH ID
                Console.WriteLine("Retrieve Departments WITH ID");

                var DepartmentsIDResultsS = EmployeeModeldb.QueryMultiple("select* from Departments where ID = 1");
                var quryIDResultsS = DepartmentsIDResultsS.Read<Departments>().First();


                Console.WriteLine("ID: \t" + quryIDResultsS.ID + "\t" + "Name: \t" + quryIDResultsS.Name + "\t" + "Location: \t" + quryIDResultsS.Location);

                Console.WriteLine("End Of Retrieve Departments WITH ID"); 
                #endregion


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();

                #region Retrieve Departments WITH Name
                Console.WriteLine("Retrieve Departments WITH Name");

                var DepartmentsNameResultsS = EmployeeModeldb.QueryMultiple("select* from Departments where Name = 'IT'");
                var quryNameResultsS = DepartmentsNameResultsS.Read<Departments>().First();


                Console.WriteLine("ID: \t" + quryNameResultsS.ID + "\t" + "Name: \t" + quryNameResultsS.Name + "\t" + "Location: \t" + quryNameResultsS.Location);

                Console.WriteLine("End Of Retrieve Departments WITH Name"); 
                #endregion


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                #region Retrieve Departments WITH Location
                Console.WriteLine("Retrieve Departments WITH Location");

                var DepartmentsLocationResultsS = EmployeeModeldb.QueryMultiple("select* from Departments where Location = 'Norfolk'");
                var quryLocationResultsS = DepartmentsLocationResultsS.Read<Departments>().First();


                Console.WriteLine("ID: \t" + quryIDResultsS.ID + "\t" + "Name: \t" + quryIDResultsS.Name + "\t" + "Location: \t" + quryIDResultsS.Location);

                Console.WriteLine("End Of Retrieve Departments WITH Location"); 
                #endregion

                //select ID from Departments where ID =1
                //select Name from Departments where Name = 'IT'
                //select Location from Departments where Location = 'Norfolk'
                //select ID,Name from Departments where ID =1

                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();


                #region Retrieve Departments WITH ID and NAME
                Console.WriteLine("Retrieve Departments WITH ID and NAME");

                var DepartmentslocatidResultsS = EmployeeModeldb.QueryMultiple("select ID,Name from Departments where ID =1");
                var quryLocationidResultsS = DepartmentslocatidResultsS.Read<Departments>().First();


                Console.WriteLine("ID: \t" + quryLocationidResultsS.ID + "\t" + "Name: \t" + quryLocationidResultsS.Name);

                Console.WriteLine("End Of Retrieve Departments WITH ID and NAME");


                Console.WriteLine(); Console.WriteLine(); Console.WriteLine();
                #endregion

                //Select * from Departments where ID in (1, 3)
                //select top 2 * from Departments
                //select count(ID) from Departments
                //select *from Departments order by ID ASC, Name DESC
                //select ID from Departments order by ID DESC

                #region Retrieve Selected Departments
                Console.WriteLine("Retrieve Selected Departments ");

                var DepartmentslocatidselResultsS = EmployeeModeldb.QueryMultiple("Select * from Departments where ID in (1, 3)");
                var quryLocationidselResultsS = DepartmentslocatidselResultsS.Read<Departments>();

                foreach (var item in quryLocationidselResultsS)
                {
                    Console.WriteLine("ID: \t" + item.ID + "\t" + "NAME: \t" + item.Name + "\t" + "Location: \t" + item.Location);
                }
                Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); 
                #endregion

            }
        }
    }
    public class CommonVariables
    {
        public static String ConnectionStringsEmployeeModel
        {
            get { return ConfigurationManager.ConnectionStrings["EmployeeModel"].ConnectionString; }
        }    public static String ConnectionStringsMedisys_Dev
        {
            get { return ConfigurationManager.ConnectionStrings["Medisys_Dev"].ConnectionString; }
        }
    }
}
