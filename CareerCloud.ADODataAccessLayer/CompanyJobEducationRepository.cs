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
    public class CompanyJobEducationRepository : BaseADORepository<CompanyJobEducationPoco>, IDataRepository<CompanyJobEducationPoco>
    {
        enum CompanyJobEducationFields {Id, Job, Major, Importance, Time_Stamp}
        public void Add(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Educations]
                                                           ([Id]
                                                           ,[Job]
                                                           ,[Major]
                                                           ,[Importance])
                                                     VALUES
                                                           (@Id 
                                                           ,@Job 
                                                           ,@Major 
                                                           ,@Importance) ";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Importance", item.Importance);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
        {
            List<CompanyJobEducationPoco> companyJobEducationList = new List<CompanyJobEducationPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Job]
                                          ,[Major]
                                          ,[Importance]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Job_Educations]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobEducationPoco companyJobEducationPoco = new CompanyJobEducationPoco();
                    companyJobEducationPoco.Id = reader.GetGuid((int)CompanyJobEducationFields.Id);
                    companyJobEducationPoco.Job = reader.GetGuid((int)CompanyJobEducationFields.Job);
                    companyJobEducationPoco.Major = reader.GetString((int)CompanyJobEducationFields.Major);
                    companyJobEducationPoco.Importance = reader.GetInt16((int)CompanyJobEducationFields.Importance);
                    companyJobEducationPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyJobEducationFields.Time_Stamp);
                    companyJobEducationList.Add(companyJobEducationPoco);
                }
                reader.Close();
            }
            return companyJobEducationList;
        }

        public void Update(params CompanyJobEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Job_Educations]
                                           SET [Job] = @Job
                                              ,[Major] = @Major
                                              ,[Importance] = @Importance
                                         WHERE [Id] = @Id ";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobEducationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Importance", item.Importance);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
