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
    public class SecurityRoleRepository : BaseADORepository<SecurityRolePoco>, IDataRepository<SecurityRolePoco>
    {
        enum SecurityRoleFields {Id, Role, Is_Inactive}
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Roles]
                                                       ([Id]
                                                       ,[Role]
                                                       ,[Is_Inactive])
                                                 VALUES
                                                       (@Id 
                                                       ,@Role 
                                                       ,@Is_Inactive )";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityRolePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            List<SecurityRolePoco> securityRoleList = new List<SecurityRolePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Role]
                                          ,[Is_Inactive]
                                      FROM [dbo].[Security_Roles]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityRolePoco securityRolePoco = new SecurityRolePoco();
                    securityRolePoco.Id = reader.GetGuid((int)SecurityRoleFields.Id);
                    securityRolePoco.Role = reader.GetString((int)SecurityRoleFields.Role);
                    securityRolePoco.IsInactive = reader.GetBoolean((int)SecurityRoleFields.Is_Inactive);
                    securityRoleList.Add(securityRolePoco);
                }
                reader.Close();
            }
            return securityRoleList;
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Security_Roles]
                                           SET [Role] = @Role
                                              ,[Is_Inactive] = @Is_Inactive
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityRolePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Role", item.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
