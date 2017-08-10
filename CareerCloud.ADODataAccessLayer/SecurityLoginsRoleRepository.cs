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
    public class SecurityLoginsRoleRepository : BaseADORepository<SecurityLoginsRolePoco>, IDataRepository<SecurityLoginsRolePoco>
    {
        enum SecurityLoginRoleFields { Id, Login, Role, Time_Stamp }
        public void Add(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins_Roles]
                                                       ([Id]
                                                       ,[Login]
                                                       ,[Role])
                                                 VALUES
                                                       (@Id
                                                       ,@Login
                                                       ,@Role)";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsRolePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
        {
            List<SecurityLoginsRolePoco> SecurityLoginsRoleList = new List<SecurityLoginsRolePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Role]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Security_Logins_Roles]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginsRolePoco securityLoginsRolePoco = new SecurityLoginsRolePoco();
                    securityLoginsRolePoco.Id = reader.GetGuid((int)SecurityLoginRoleFields.Id);
                    securityLoginsRolePoco.Login = reader.GetGuid((int)SecurityLoginRoleFields.Login);
                    securityLoginsRolePoco.Role = reader.GetGuid((int)SecurityLoginRoleFields.Role);
                    securityLoginsRolePoco.TimeStamp = reader.GetFieldValue<byte[]>((int)SecurityLoginRoleFields.Time_Stamp);
                    SecurityLoginsRoleList.Add(securityLoginsRolePoco);
                }
                reader.Close();
            }
            return SecurityLoginsRoleList;
        }

        public void Update(params SecurityLoginsRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins_Roles]
                                       SET [Login] = @Login
                                              ,[Role] = @Role
                                     WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginsRolePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
