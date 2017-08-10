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
    public class SystemLanguageCodeRepository : BaseADORepository, IDataRepository<SystemLanguageCodePoco>
    {
        enum SystemLanguageCodeFields { LanguageID, Name, Native_Name }
        public void Add(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[System_Language_Codes]
                                                       ([LanguageID]
                                                       ,[Name]
                                                       ,[Native_Name])
                                                 VALUES
                                                       (@LanguageID 
                                                       ,@Name 
                                                       ,@Native_Name )";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemLanguageCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            List<SystemLanguageCodePoco> systemLanguageCodeList = new List<SystemLanguageCodePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [LanguageID]
                                          ,[Name]
                                          ,[Native_Name]
                                      FROM [dbo].[System_Language_Codes]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SystemLanguageCodePoco systemLanguageCodePoco = new SystemLanguageCodePoco();

                    systemLanguageCodePoco.LanguageID = reader.GetString((int)SystemLanguageCodeFields.LanguageID);
                    systemLanguageCodePoco.Name = reader.GetString((int)SystemLanguageCodeFields.Name);
                    systemLanguageCodePoco.NativeName = reader.GetString((int)SystemLanguageCodeFields.Native_Name);
                    systemLanguageCodeList.Add(systemLanguageCodePoco);
                }
                reader.Close();
            }
            return systemLanguageCodeList;
        }

        public IList<SystemLanguageCodePoco> GetList(Func<SystemLanguageCodePoco, bool> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IList<SystemLanguageCodePoco> systemLanguageCodeList = GetAll(navigationProperties);
            systemLanguageCodeList.Where(where);
            return systemLanguageCodeList;
        }

        public SystemLanguageCodePoco GetSingle(Func<SystemLanguageCodePoco, bool> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            return GetAll(navigationProperties).SingleOrDefault(where);
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"DELETE FROM [dbo].[System_Language_Codes]
                                         WHERE [LanguageID] = @LanguageID";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemLanguageCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[System_Language_Codes]
                                       SET [Name] = @Name
                                          ,[Native_Name] = @Native_Name
                                     WHERE [LanguageID] = @LanguageID";
                cmd.Connection = conn;
                conn.Open();
                foreach (SystemLanguageCodePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", item.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", item.NativeName);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
