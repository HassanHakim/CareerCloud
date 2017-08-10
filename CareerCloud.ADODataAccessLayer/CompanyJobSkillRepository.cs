using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyJobSkillRepository : BaseADORepository<CompanyJobSkillPoco>, IDataRepository<CompanyJobSkillPoco>
    {
        enum CompanyJobSkillFields { Id, Job, Skill, Skill_Level, Importance, Time_Stamp }

        public void Add(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
                                                           ([Id]
                                                           ,[Job]
                                                           ,[Skill]
                                                           ,[Skill_Level]
                                                           ,[Importance])
                                                     VALUES
                                                           (@Id 
                                                           ,@Job 
                                                           ,@Skill 
                                                           ,@Skill_Level 
                                                           ,@Importance )";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobSkillPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
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

        public override IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
        {
            List<CompanyJobSkillPoco> companyJobSkillList = new List<CompanyJobSkillPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Job]
                                          ,[Skill]
                                          ,[Skill_Level]
                                          ,[Importance]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Job_Skills]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobSkillPoco companyJobSkillPoco = new CompanyJobSkillPoco();
                    companyJobSkillPoco.Id = reader.GetGuid((int)CompanyJobSkillFields.Id);
                    companyJobSkillPoco.Job = reader.GetGuid((int)CompanyJobSkillFields.Job);
                    companyJobSkillPoco.Skill = reader.GetString((int)CompanyJobSkillFields.Skill);
                    companyJobSkillPoco.SkillLevel = reader.GetString((int)CompanyJobSkillFields.Skill_Level);
                    companyJobSkillPoco.Importance = reader.GetInt32((int)CompanyJobSkillFields.Importance);                 
                    companyJobSkillPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyJobSkillFields.Time_Stamp);
                    companyJobSkillList.Add(companyJobSkillPoco);
                }
                reader.Close();
            }
            return companyJobSkillList;
        }
        
        public void Update(params CompanyJobSkillPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Job_Skills]
                                           SET [Job] = @Job
                                              ,[Skill] = @Skill
                                              ,[Skill_Level] = @Skill_Level
                                              ,[Importance] = @Importance
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobSkillPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Job", item.Job);
                    cmd.Parameters.AddWithValue("@Skill", item.Skill);
                    cmd.Parameters.AddWithValue("@Skill_Level", item.SkillLevel);
                    cmd.Parameters.AddWithValue("@Importance", item.Importance);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
