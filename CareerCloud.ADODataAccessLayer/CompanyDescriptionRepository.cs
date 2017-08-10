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
    public class CompanyDescriptionRepository : BaseADORepository<CompanyDescriptionPoco>, IDataRepository<CompanyDescriptionPoco>
    {
        enum CompanyDescriptionFields {Id, Company, LanguageID, Company_Name, Company_Description, Time_Stamp} 
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                                                           ([Id]
                                                           ,[Company]
                                                           ,[LanguageID]
                                                           ,[Company_Name]
                                                           ,[Company_Description])
                                                     VALUES
                                                           (@Id 
                                                           ,@Company 
                                                           ,@LanguageID 
                                                           ,@Company_Name 
                                                           ,@Company_Description)";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyDescriptionPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            List<CompanyDescriptionPoco> CompanyDescriptionList = new List<CompanyDescriptionPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Company]
                                          ,[LanguageID]
                                          ,[Company_Name]
                                          ,[Company_Description]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Descriptions]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyDescriptionPoco companyDescriptionPoco = new CompanyDescriptionPoco();
                    companyDescriptionPoco.Id = reader.GetGuid((int)CompanyDescriptionFields.Id);
                    companyDescriptionPoco.Company = reader.GetGuid((int)CompanyDescriptionFields.Company);
                    companyDescriptionPoco.LanguageId = reader.GetString((int)CompanyDescriptionFields.LanguageID);
                    companyDescriptionPoco.CompanyName = reader.GetString((int)CompanyDescriptionFields.Company_Name);
                    companyDescriptionPoco.CompanyDescription = reader.GetString((int)CompanyDescriptionFields.Company_Description);
                    companyDescriptionPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyDescriptionFields.Time_Stamp);
                    CompanyDescriptionList.Add(companyDescriptionPoco);
                }
                reader.Close();
            }
            return CompanyDescriptionList;
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                                           SET [Company] = @Company
                                              ,[LanguageID] = @LanguageID
                                              ,[Company_Name] = @Company_Name
                                              ,[Company_Description] = @Company_Description
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyDescriptionPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", item.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", item.CompanyDescription);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
