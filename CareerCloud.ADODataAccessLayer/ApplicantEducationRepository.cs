using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseADORepository<ApplicantEducationPoco> , IDataRepository<ApplicantEducationPoco>
    {       
        enum AppEduFields { Id, Applicant, Major , Certificate_Diploma, Start_Date, Completion_Date, Completion_Percent, Time_Stamp }

        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
                                                        ([Id],[Applicant],[Major],[Certificate_Diploma],
                                                        [Start_Date],[Completion_Date],[Completion_Percent])
                                                VALUES  (@Id,@Applicant,@Major,@Certificate_Diploma
                                                        ,@Start_Date,@Completion_Date,@Completion_Percent)";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);                    
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApplicantEducationPoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            List<ApplicantEducationPoco> appEduList = new List<ApplicantEducationPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Applicant]
                                          ,[Major]
                                          ,[Certificate_Diploma]
                                          ,[Start_Date]
                                          ,[Completion_Date]
                                          ,[Completion_Percent]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Educations]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantEducationPoco appEduPoco = new ApplicantEducationPoco();
                    appEduPoco.Id = reader.GetGuid((int)AppEduFields.Id);
                    appEduPoco.Applicant = reader.GetGuid((int)AppEduFields.Applicant);
                    appEduPoco.Major = reader.GetString((int)AppEduFields.Major);
                    if (!reader.IsDBNull((int)AppEduFields.Certificate_Diploma))
                        appEduPoco.CertificateDiploma = reader.GetString((int)AppEduFields.Certificate_Diploma);
                    if (!reader.IsDBNull((int)AppEduFields.Start_Date))
                        appEduPoco.StartDate = reader.GetDateTime((int)AppEduFields.Start_Date);
                    if (!reader.IsDBNull((int)AppEduFields.Completion_Date))
                        appEduPoco.CompletionDate = reader.GetDateTime((int)AppEduFields.Completion_Date);
                    if (!reader.IsDBNull((int)AppEduFields.Completion_Percent))
                        appEduPoco.CompletionPercent = reader.GetByte((int)AppEduFields.Completion_Percent);
                    appEduPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)AppEduFields.Time_Stamp);
                    appEduList.Add(appEduPoco);
                }
                reader.Close();
            }
            return appEduList;
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                           SET [Applicant] = @Applicant
                                              ,[Major] = @Major
                                              ,[Certificate_Diploma] = @Certificate_Diploma
                                              ,[Start_Date] = @Start_Date
                                              ,[Completion_Date] = @Completion_Date
                                              ,[Completion_Percent] = @Completion_Percent
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantEducationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Major", item.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", item.CompletionPercent);                    
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
