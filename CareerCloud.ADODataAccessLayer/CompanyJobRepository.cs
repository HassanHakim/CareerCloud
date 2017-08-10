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
    public class CompanyJobRepository : BaseADORepository<CompanyJobPoco>, IDataRepository<CompanyJobPoco>
    {
        enum CompanyJobFields { Id, Company, Profile_Created, Is_Inactive, Is_Company_Hidden, Time_Stamp }
    
        public void Add(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
                                                       ([Id]
                                                       ,[Company]
                                                       ,[Profile_Created]
                                                       ,[Is_Inactive]
                                                       ,[Is_Company_Hidden])
                                                 VALUES
                                                       (@Id 
                                                       ,@Company 
                                                       ,@Profile_Created 
                                                       ,@Is_Inactive 
                                                       ,@Is_Company_Hidden ) ";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
        {
            List<CompanyJobPoco> companyJobList = new List<CompanyJobPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Company]
                                          ,[Profile_Created]
                                          ,[Is_Inactive]
                                          ,[Is_Company_Hidden]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Jobs]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyJobPoco companyJobPoco = new CompanyJobPoco();
                    companyJobPoco.Id = reader.GetGuid((int)CompanyJobFields.Id);
                    companyJobPoco.Company = reader.GetGuid((int)CompanyJobFields.Company);
                    companyJobPoco.ProfileCreated = reader.GetDateTime((int)CompanyJobFields.Profile_Created);
                    companyJobPoco.IsInactive = reader.GetBoolean((int)CompanyJobFields.Is_Inactive);
                    companyJobPoco.IsCompanyHidden = reader.GetBoolean((int)CompanyJobFields.Is_Company_Hidden);
                    companyJobPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyJobFields.Time_Stamp);
                    companyJobList.Add(companyJobPoco);
                }
                reader.Close();
            }
            return companyJobList;
        }
        
        public void Update(params CompanyJobPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Jobs]
                                           SET [Company] = @Company
                                              ,[Profile_Created] = @Profile_Created
                                              ,[Is_Inactive] = @Is_Inactive
                                              ,[Is_Company_Hidden] = @Is_Company_Hidden
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyJobPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Profile_Created", item.ProfileCreated);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Is_Company_Hidden", item.IsCompanyHidden);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
