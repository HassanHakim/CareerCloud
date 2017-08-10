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
    public class ApplicantJobApplicationRepository : BaseADORepository<ApplicantJobApplicationPoco> , IDataRepository<ApplicantJobApplicationPoco>
    {
        enum AppJobApplicationFields { Id, Applicant, Job,  Application_Date, Time_Stamp }

        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Job_Applications]
                                                ([Id],[Applicant],[Job],[Application_Date])
                                         VALUES (@Id,@Applicant,@Job,@Application_Date)";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            List<ApplicantJobApplicationPoco> appJobApplicationList = new List<ApplicantJobApplicationPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Applicant]
                                          ,[Job]
                                          ,[Application_Date]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Job_Applications]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco appJobApplicationPoco = new ApplicantJobApplicationPoco();
                    appJobApplicationPoco.Id = reader.GetGuid((int)AppJobApplicationFields.Id);
                    appJobApplicationPoco.Applicant = reader.GetGuid((int)AppJobApplicationFields.Applicant);
                    appJobApplicationPoco.Job = reader.GetGuid((int)AppJobApplicationFields.Job);
                    appJobApplicationPoco.ApplicationDate= reader.GetDateTime((int)AppJobApplicationFields.Application_Date);
                    appJobApplicationPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)AppJobApplicationFields.Time_Stamp);
                    appJobApplicationList.Add(appJobApplicationPoco);
                }
                reader.Close();
            }
            return appJobApplicationList;
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Job_Applications]
                                       SET [Applicant] = @Applicant
                                          ,[Job] = @Job
                                          ,[Application_Date] = @Application_Date
                                     WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
