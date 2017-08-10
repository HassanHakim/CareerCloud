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
    public class CompanyJobDescriptionRepository : BaseADORepository<CompanyJobDescriptionPoco>, IDataRepository<CompanyJobDescriptionPoco>
    {
        enum CompanyJobDescriptionFields {Id ,Job ,Job_Name, Job_Descriptions, Time_Stamp}
        public void Add(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs_Descriptions]
                                                           ([Id]
                                                           ,[Job]
                                                           ,[Job_Name]
                                                           ,[Job_Descriptions])
                                                     VALUES
                                                           (@Id 
                                                           ,@Job 
                                                           ,@Job_Name 
                                                           ,@Job_Descriptions )";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobDescriptionPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
        {
            List<CompanyJobDescriptionPoco> companyJobDescriptionList = new List<CompanyJobDescriptionPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Job]
                                          ,[Job_Name]
                                          ,[Job_Descriptions]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Jobs_Descriptions]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobDescriptionPoco companyJobDescriptionPoco = new CompanyJobDescriptionPoco();
                    companyJobDescriptionPoco.Id = reader.GetGuid((int)CompanyJobDescriptionFields.Id);
                    companyJobDescriptionPoco.Job = reader.GetGuid((int)CompanyJobDescriptionFields.Job);
                    if (!reader.IsDBNull((int)CompanyJobDescriptionFields.Job_Name))
                        companyJobDescriptionPoco.JobName = reader.GetString((int)CompanyJobDescriptionFields.Job_Name);
                    if (!reader.IsDBNull((int)CompanyJobDescriptionFields.Job_Descriptions))
                        companyJobDescriptionPoco.JobDescriptions = reader.GetString((int)CompanyJobDescriptionFields.Job_Descriptions);                    
                    companyJobDescriptionPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyJobDescriptionFields.Time_Stamp);
                    companyJobDescriptionList.Add(companyJobDescriptionPoco);
                }
                reader.Close();
            }
            return companyJobDescriptionList;
        }

        public void Update(params CompanyJobDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Jobs_Descriptions]
                                           SET [Job] = @Job
                                              ,[Job_Name] = @Job_Name
                                              ,[Job_Descriptions] = @Job_Descriptions
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobDescriptionPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Job_Name", item.JobName);
                    cmd.Parameters.AddWithValue("@Job_Descriptions", item.JobDescriptions);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
