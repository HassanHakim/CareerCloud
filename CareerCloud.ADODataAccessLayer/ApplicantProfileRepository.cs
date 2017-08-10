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
    public class ApplicantProfileRepository : BaseADORepository<ApplicantProfilePoco>, IDataRepository<ApplicantProfilePoco>
    {
        enum ApplicantProfilesFields 
        { Id, Login, Current_Salary, Current_Rate, Currency, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code, Time_Stamp }

        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                                   ([Id]
                                                   ,[Login]
                                                   ,[Current_Salary]
                                                   ,[Current_Rate]
                                                   ,[Currency]
                                                   ,[Country_Code]
                                                   ,[State_Province_Code]
                                                   ,[Street_Address]
                                                   ,[City_Town]
                                                   ,[Zip_Postal_Code])
                                             VALUES
                                                   (@Id
                                                   ,@Login
                                                   ,@Current_Salary
                                                   ,@Current_Rate
                                                   ,@Currency
                                                   ,@Country_Code
                                                   ,@State_Province_Code
                                                   ,@Street_Address
                                                   ,@City_Town
                                                   ,@Zip_Postal_Code)";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            List<ApplicantProfilePoco> applicantProfilesList = new List<ApplicantProfilePoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Current_Salary]
                                          ,[Current_Rate]
                                          ,[Currency]
                                          ,[Country_Code]
                                          ,[State_Province_Code]
                                          ,[Street_Address]
                                          ,[City_Town]
                                          ,[Zip_Postal_Code]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Applicant_Profiles]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ApplicantProfilePoco applicantProfilePoco = new ApplicantProfilePoco();
                    applicantProfilePoco.Id = reader.GetGuid((int)ApplicantProfilesFields.Id);
                    applicantProfilePoco.Login = reader.GetGuid((int)ApplicantProfilesFields.Login);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Current_Salary))
                        applicantProfilePoco.CurrentSalary = reader.GetDecimal((int)ApplicantProfilesFields.Current_Salary);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Current_Rate))
                        applicantProfilePoco.CurrentRate = reader.GetDecimal((int)ApplicantProfilesFields.Current_Rate);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Currency))
                        applicantProfilePoco.Currency = reader.GetString((int)ApplicantProfilesFields.Currency);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Country_Code))
                        applicantProfilePoco.Country = reader.GetString((int)ApplicantProfilesFields.Country_Code);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.State_Province_Code))
                        applicantProfilePoco.Province = reader.GetString((int)ApplicantProfilesFields.State_Province_Code);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Street_Address))
                        applicantProfilePoco.Street = reader.GetString((int)ApplicantProfilesFields.Street_Address);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.City_Town))
                        applicantProfilePoco.City = reader.GetString((int)ApplicantProfilesFields.City_Town);
                    if (!reader.IsDBNull((int)ApplicantProfilesFields.Zip_Postal_Code))
                        applicantProfilePoco.PostalCode = reader.GetString((int)ApplicantProfilesFields.Zip_Postal_Code);
                    applicantProfilePoco.TimeStamp = reader.GetFieldValue<byte[]>((int)ApplicantProfilesFields.Time_Stamp);
                    applicantProfilesList.Add(applicantProfilePoco);
                }
                reader.Close();
            }
            return applicantProfilesList;
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                           SET   [Login] = @Login
                                                ,[Current_Salary] = @Current_Salary
                                                ,[Current_Rate] = @Current_Rate
                                                ,[Currency] = @Currency
                                                ,[Country_Code] = @Country_Code
                                                ,[State_Province_Code] = @State_Province_Code
                                                ,[Street_Address] = @Street_Address
                                                ,[City_Town] = @City_Town
                                                ,[Zip_Postal_Code] = @Zip_Postal_Code
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (ApplicantProfilePoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    cmd.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    cmd.Parameters.AddWithValue("@Currency", item.Currency);
                    cmd.Parameters.AddWithValue("@Country_Code", item.Country);
                    cmd.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    cmd.Parameters.AddWithValue("@Street_Address", item.Street);
                    cmd.Parameters.AddWithValue("@City_Town", item.City);
                    cmd.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
