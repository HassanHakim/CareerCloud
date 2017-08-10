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
    public class CompanyProfileRepository : BaseADORepository<CompanyProfilePoco>, IDataRepository<CompanyProfilePoco>
    {
        enum CompanyProfileFields { Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo, Time_Stamp }
        
        public void Add(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
                                                       ([Id]
                                                       ,[Registration_Date]
                                                       ,[Company_Website]
                                                       ,[Contact_Phone]
                                                       ,[Contact_Name]
                                                       ,[Company_Logo])
                                                 VALUES
                                                       (@Id 
                                                       ,@Registration_Date 
                                                       ,@Company_Website 
                                                       ,@Contact_Phone 
                                                       ,@Contact_Name 
                                                       ,@Company_Logo )";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
        {
            List<CompanyProfilePoco> companyProfileList = new List<CompanyProfilePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Registration_Date]
                                          ,[Company_Website]
                                          ,[Contact_Phone]
                                          ,[Contact_Name]
                                          ,[Company_Logo]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Profiles]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyProfilePoco companyProfilePoco = new CompanyProfilePoco();

                    companyProfilePoco.Id = reader.GetGuid((int)CompanyProfileFields.Id);
                    companyProfilePoco.RegistrationDate = reader.GetDateTime((int)CompanyProfileFields.Registration_Date);
                    if (!reader.IsDBNull((int)CompanyProfileFields.Company_Website))
                        companyProfilePoco.CompanyWebsite = reader.GetString((int)CompanyProfileFields.Company_Website);
                    companyProfilePoco.ContactPhone = reader.GetString((int)CompanyProfileFields.Contact_Phone);
                    if (!reader.IsDBNull((int)CompanyProfileFields.Contact_Name))
                        companyProfilePoco.ContactName = reader.GetString((int)CompanyProfileFields.Contact_Name);
                    if (!reader.IsDBNull((int)CompanyProfileFields.Company_Logo))
                        companyProfilePoco.CompanyLogo = reader.GetFieldValue<byte[]>((int)CompanyProfileFields.Company_Logo);
                    companyProfilePoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyProfileFields.Time_Stamp);

                    companyProfileList.Add(companyProfilePoco);
                }
                reader.Close();
            }
            return companyProfileList;
        }

        public void Update(params CompanyProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Profiles]
                                           SET [Registration_Date] = @Registration_Date
                                              ,[Company_Website] = @Company_Website
                                              ,[Contact_Phone] = @Contact_Phone
                                              ,[Contact_Name] = @Contact_Name
                                              ,[Company_Logo] = @Company_Logo
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyProfilePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Registration_Date", item.RegistrationDate);
                    cmd.Parameters.AddWithValue("@Company_Website", item.CompanyWebsite);
                    cmd.Parameters.AddWithValue("@Contact_Phone", item.ContactPhone);
                    cmd.Parameters.AddWithValue("@Contact_Name", item.ContactName);
                    cmd.Parameters.AddWithValue("@Company_Logo", item.CompanyLogo);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
