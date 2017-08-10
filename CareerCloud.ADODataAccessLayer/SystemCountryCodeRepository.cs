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
    public class SystemCountryCodeRepository : BaseADORepository, IDataRepository<SystemCountryCodePoco>
    {
        enum SystemCountryCodeFields { Code, Name}

        public void Add(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[System_Country_Codes]
                                                       ([Code]
                                                       ,[Name])
                                                VALUES
                                                       (@Code 
                                                       ,@Name )";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemCountryCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            List<SystemCountryCodePoco> systemCountryCodeList = new List<SystemCountryCodePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Code]
                                          ,[Name]
                                      FROM [dbo].[System_Country_Codes]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SystemCountryCodePoco systemCountryCodePoco = new SystemCountryCodePoco();

                    systemCountryCodePoco.Code = reader.GetString((int)SystemCountryCodeFields.Code);
                    systemCountryCodePoco.Name = reader.GetString((int)SystemCountryCodeFields.Name);

                    systemCountryCodeList.Add(systemCountryCodePoco);
                }
                reader.Close();
            }
            return systemCountryCodeList;
        }

        public IList<SystemCountryCodePoco> GetList(Func<SystemCountryCodePoco, bool> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            IList<SystemCountryCodePoco> systemCountryCodeList = GetAll(navigationProperties);
            systemCountryCodeList.Where(where);
            return systemCountryCodeList;
        }

        public SystemCountryCodePoco GetSingle(Func<SystemCountryCodePoco, bool> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
        {
            return GetAll(navigationProperties).SingleOrDefault(where);
        }

        public void Remove(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM [dbo].[System_Country_Codes]
                                          WHERE [Code] = @Code";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemCountryCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void Update(params SystemCountryCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[System_Country_Codes]
                                       SET [Name] = @Name
                                     WHERE [Code] = @Code";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemCountryCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Code", item.Code);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
