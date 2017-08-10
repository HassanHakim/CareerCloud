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
    public class ApplicantWorkHistoryRepository : BaseADORepository<ApplicantWorkHistoryPoco>, IDataRepository<ApplicantWorkHistoryPoco>
    {
        enum ApplicantWorkHistoryFields { Id, Applicant, Company_Name, Country_Code, Location, Job_Title, Job_Description, Start_Month, Start_Year, End_Month, End_Year, Time_Stamp } 
        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Work_History]
                                                       ([Id]
                                                       ,[Applicant]
                                                       ,[Company_Name]
                                                       ,[Country_Code]
                                                       ,[Location]
                                                       ,[Job_Title]
                                                       ,[Job_Description]
                                                       ,[Start_Month]
                                                       ,[Start_Year]
                                                       ,[End_Month]
                                                       ,[End_Year])
                                                 VALUES
                                                       (@Id 
                                                       ,@Applicant 
                                                       ,@Company_Name 
                                                       ,@Country_Code 
                                                       ,@Location 
                                                       ,@Job_Title 
                                                       ,@Job_Description 
                                                       ,@Start_Month 
                                                       ,@Start_Year 
                                                       ,@End_Month 
                                                       ,@End_Year )";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            List<ApplicantWorkHistoryPoco> applicantWorkHistoryList = new List<ApplicantWorkHistoryPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Applicant]
                                          ,[Company_Name]
                                          ,[Country_Code]
                                          ,[Location]
                                          ,[Job_Title]
                                          ,[Job_Description]
                                          ,[Start_Month]
                                          ,[Start_Year]
                                          ,[End_Month]
                                          ,[End_Year]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Work_History]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco applicantWorkHistoryPoco = new ApplicantWorkHistoryPoco();

                    applicantWorkHistoryPoco.Id = reader.GetGuid((int)ApplicantWorkHistoryFields.Id);
                    applicantWorkHistoryPoco.Applicant = reader.GetGuid((int)ApplicantWorkHistoryFields.Applicant);
                    applicantWorkHistoryPoco.CompanyName = reader.GetString((int)ApplicantWorkHistoryFields.Company_Name);
                    applicantWorkHistoryPoco.CountryCode = reader.GetString((int)ApplicantWorkHistoryFields.Country_Code);
                    applicantWorkHistoryPoco.Location = reader.GetString((int)ApplicantWorkHistoryFields.Location);
                    applicantWorkHistoryPoco.JobTitle = reader.GetString((int)ApplicantWorkHistoryFields.Job_Title);
                    applicantWorkHistoryPoco.JobDescription = reader.GetString((int)ApplicantWorkHistoryFields.Job_Description);
                    applicantWorkHistoryPoco.StartMonth = reader.GetInt16((int)ApplicantWorkHistoryFields.Start_Month);
                    applicantWorkHistoryPoco.StartYear = reader.GetInt32((int)ApplicantWorkHistoryFields.Start_Year);
                    applicantWorkHistoryPoco.EndMonth = reader.GetInt16((int)ApplicantWorkHistoryFields.End_Month);
                    applicantWorkHistoryPoco.EndYear = reader.GetInt32((int)ApplicantWorkHistoryFields.End_Year);

                    applicantWorkHistoryPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)ApplicantWorkHistoryFields.Time_Stamp);

                    applicantWorkHistoryList.Add(applicantWorkHistoryPoco);
                }
                reader.Close();
            }
            return applicantWorkHistoryList;
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Work_History]
                                           SET [Applicant] = @Applicant
                                              ,[Company_Name] = @Company_Name
                                              ,[Country_Code] = @Country_Code
                                              ,[Location] = @Location
                                              ,[Job_Title] = @Job_Title
                                              ,[Job_Description] = @Job_Description
                                              ,[Start_Month] = @Start_Month
                                              ,[Start_Year] = @Start_Year
                                              ,[End_Month] = @End_Month
                                              ,[End_Year] = @End_Year
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantWorkHistoryPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", item.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", item.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", item.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", item.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", item.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", item.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", item.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", item.EndYear);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
