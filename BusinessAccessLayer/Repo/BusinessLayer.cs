using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DataTransferObject.DTO;
using System.Configuration;
using Dapper;

namespace BusinessAccessLayer.Repo
{
    public class BusinessLayer : IBusinessLayer
    {

        private SqlConnection con;

        public void Connection()
        {
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con = new SqlConnection(conString);
        }


        public IEnumerable<HelperModel> GetEmployeeById(int id)
        {
            IEnumerable<HelperModel> data = new List<HelperModel>();

          //  var sqlQuery = @"SELECT E.EmployeeId, E.EmployeeName, E.EmployeeSalary, D.DetailId, D.FatherName, D.Address, D.Contact, D.EmployeeId
           //                  FROM Employee E INNER JOIN EmployeeDetail D ON E.EmployeeId = D.EmployeeId WHERE E.EmployeeId =" + id;      
            //Connection();
            //con.Open();
            //data = SqlMapper.Query<EmployeeModel>(con, sqlQuery);
            //con.Close();
            //return data.ToList();

            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                return db.Query<HelperModel>("GetEmployeeById", param, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<HelperModel> GetEmployees()
        {
            IEnumerable<HelperModel> data = new List<HelperModel>();
                      
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                return db.Query<HelperModel>("GetEmployees");
            };
        }

        public void Create(HelperModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@EmployeeName", model.EmployeeName);
            param.Add("@EmployeeSalary", model.EmployeeSalary);
            param.Add("@FatherName", model.FatherName);
            param.Add("@Contact", model.Contact);
            param.Add("@Address", model.Address);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                db.Execute("InsertEmployees", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void Update(int id, HelperModel model)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);
            param.Add("@EmployeeName", model.EmployeeName);
            param.Add("@EmployeeSalary", model.EmployeeSalary);
            param.Add("@FatherName", model.FatherName);
            param.Add("@Contact", model.Contact);
            param.Add("@Address", model.Address);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                db.Execute("UpdateEmployee", param, commandType: CommandType.StoredProcedure);
            }

        }

        public void Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString))
            {
                db.Execute("DeleteEmployee", param, commandType: CommandType.StoredProcedure);
            }           
        }
    }
}
