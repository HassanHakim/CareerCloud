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
    public class ApplicantResumeRepository : BaseADORepository<ApplicantResumePoco>, IDataRepository<ApplicantResumePoco>
    {
        enum ApplicantResumeFields { Id, Applicant, Resume, Last_Updated }
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
                                                   ([Id]
                                                   ,[Applicant]
                                                   ,[Resume]
                                                   ,[Last_Updated])
                                             VALUES
                                                   (@Id
                                                   ,@Applicant
                                                   ,@Resume
                                                   ,@Last_Updated)";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            List<ApplicantResumePoco> applicantResumeList = new List<ApplicantResumePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Applicant]
                                          ,[Resume]
                                          ,[Last_Updated]
                                      FROM [dbo].[Applicant_Resumes]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantResumePoco applicantResumePoco = new ApplicantResumePoco();
                    applicantResumePoco.Id = reader.GetGuid((int)ApplicantResumeFields.Id);
                    applicantResumePoco.Applicant = reader.GetGuid((int)ApplicantResumeFields.Applicant);
                    applicantResumePoco.Resume = reader.GetString((int)ApplicantResumeFields.Resume);
                    if (!reader.IsDBNull((int)ApplicantResumeFields.Last_Updated))
                         applicantResumePoco.LastUpdated = reader.GetDateTime((int)ApplicantResumeFields.Last_Updated);
                    applicantResumeList.Add(applicantResumePoco);
                }
                reader.Close();
            }
            return applicantResumeList;
        }


        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Resumes]
                                       SET [Applicant] = @Applicant
                                          ,[Resume] = @Resume
                                          ,[Last_Updated] = @Last_Updated
                                     WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantResumePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", item.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", item.LastUpdated);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
