using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginsLogRepository : BaseADORepository<SecurityLoginsLogPoco>, IDataRepository<SecurityLoginsLogPoco>
    {
        enum SecurityLoginLogFields { Id, Login, Source_IP, Logon_Date, Is_Succesful}

        public void Add(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
                                                       ([Id]
                                                       ,[Login]
                                                       ,[Source_IP]
                                                       ,[Logon_Date]
                                                       ,[Is_Succesful])
                                                 VALUES
                                                       (@Id 
                                                       ,@Login 
                                                       ,@Source_IP 
                                                       ,@Logon_Date 
                                                       ,@Is_Succesful )";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
        {
            List<SecurityLoginsLogPoco> securityLoginsLogList = new List<SecurityLoginsLogPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Source_IP]
                                          ,[Logon_Date]
                                          ,[Is_Succesful]
                                      FROM [dbo].[Security_Logins_Log]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsLogPoco securityLoginsLogPoco = new SecurityLoginsLogPoco();
                    securityLoginsLogPoco.Id = reader.GetGuid((int)SecurityLoginLogFields.Id);
                    securityLoginsLogPoco.Login = reader.GetGuid((int)SecurityLoginLogFields.Login);
                    securityLoginsLogPoco.SourceIP = reader.GetString((int)SecurityLoginLogFields.Source_IP);
                    securityLoginsLogPoco.LogonDate = reader.GetDateTime((int)SecurityLoginLogFields.Logon_Date);
                    securityLoginsLogPoco.IsSuccesful = reader.GetBoolean((int)SecurityLoginLogFields.Is_Succesful);
                    securityLoginsLogList.Add(securityLoginsLogPoco);
                }
                reader.Close();
            }
            return securityLoginsLogList;
        }

        public void Update(params SecurityLoginsLogPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Log]
                                       SET [Login] = @Login
                                          ,[Source_IP] = @Source_IP
                                          ,[Logon_Date] = @Logon_Date
                                          ,[Is_Succesful] = @Is_Succesful
                                     WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsLogPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Source_IP", item.SourceIP);
                    cmd.Parameters.AddWithValue("@Logon_Date", item.LogonDate);
                    cmd.Parameters.AddWithValue("@Is_Succesful", item.IsSuccesful);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
