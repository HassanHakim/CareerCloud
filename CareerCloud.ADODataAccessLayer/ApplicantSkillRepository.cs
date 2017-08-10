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
    public class ApplicantSkillRepository : BaseADORepository<ApplicantSkillPoco>, IDataRepository<ApplicantSkillPoco>
    {
        enum ApplicantSkillFields 
        { Id, Applicant, Skill, Skill_Level, Start_Month, Start_Year, End_Month, End_Year, Time_Stamp }
        public void Add(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Skills]
                                                       ([Id]
                                                       ,[Applicant]
                                                       ,[Skill]
                                                       ,[Skill_Level]
                                                       ,[Start_Month]
                                                       ,[Start_Year]
                                                       ,[End_Month]
                                                       ,[End_Year])
                                                 VALUES
                                                       (@Id 
                                                       ,@Applicant 
                                                       ,@Skill 
                                                       ,@Skill_Level 
                                                       ,@Start_Month 
                                                       ,@Start_Year 
                                                       ,@End_Month 
                                                       ,@End_Year )";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public override IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
        {
            List<ApplicantSkillPoco> applicantSkillList = new List<ApplicantSkillPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Applicant]
                                          ,[Skill]
                                          ,[Skill_Level]
                                          ,[Start_Month]
                                          ,[Start_Year]
                                          ,[End_Month]
                                          ,[End_Year]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Skills]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantSkillPoco applicantSkillPoco = new ApplicantSkillPoco();
                    applicantSkillPoco.Id = reader.GetGuid((int)ApplicantSkillFields.Id);
                    applicantSkillPoco.Applicant = reader.GetGuid((int)ApplicantSkillFields.Applicant);
                    applicantSkillPoco.Skill = reader.GetString((int)ApplicantSkillFields.Skill);
                    applicantSkillPoco.SkillLevel = reader.GetString((int)ApplicantSkillFields.Skill_Level);
                    applicantSkillPoco.StartMonth = reader.GetByte((int)ApplicantSkillFields.Start_Month);
                    applicantSkillPoco.StartYear = reader.GetInt32((int)ApplicantSkillFields.Start_Year);
                    applicantSkillPoco.EndMonth = reader.GetByte((int)ApplicantSkillFields.End_Month);
                    applicantSkillPoco.EndYear = reader.GetInt32((int)ApplicantSkillFields.End_Year);
                    applicantSkillPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)ApplicantSkillFields.Time_Stamp);
                    applicantSkillList.Add(applicantSkillPoco);
                }
                reader.Close();
            }
            return applicantSkillList;
        }

        public void Update(params ApplicantSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Skills]
                                           SET [Applicant] = @Applicant
                                              ,[Skill] = @Skill
                                              ,[Skill_Level] = @Skill_Level
                                              ,[Start_Month] = @Start_Month
                                              ,[Start_Year] = @Start_Year
                                              ,[End_Month] = @End_Month
                                              ,[End_Year] = @End_Year
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantSkillPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Applicant", item.Applicant);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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
