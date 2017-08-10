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
    public class CompanyLocationRepository : BaseADORepository<CompanyLocationPoco>, IDataRepository<CompanyLocationPoco>
    {
        enum CompanyLocationFields  { Id, Company, Country_Code, State_Province_Code, Street_Address, City_Town, Zip_Postal_Code, Time_Stamp }

        public void Add(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Company_Locations]
                                                       ([Id]
                                                       ,[Company]
                                                       ,[Country_Code]
                                                       ,[State_Province_Code]
                                                       ,[Street_Address]
                                                       ,[City_Town]
                                                       ,[Zip_Postal_Code])
                                                 VALUES
                                                       (@Id 
                                                       ,@Company 
                                                       ,@Country_Code 
                                                       ,@State_Province_Code 
                                                       ,@Street_Address 
                                                       ,@City_Town 
                                                       ,@Zip_Postal_Code )";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyLocationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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

        public override IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
        {
            List<CompanyLocationPoco> companyLocationList = new List<CompanyLocationPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Company]
                                          ,[Country_Code]
                                          ,[State_Province_Code]
                                          ,[Street_Address]
                                          ,[City_Town]
                                          ,[Zip_Postal_Code]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Company_Locations]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CompanyLocationPoco companyLocationPoco = new CompanyLocationPoco();
                    companyLocationPoco.Id = reader.GetGuid((int)CompanyLocationFields.Id);
                    companyLocationPoco.Company = reader.GetGuid((int)CompanyLocationFields.Company);
                    companyLocationPoco.CountryCode = reader.GetString((int)CompanyLocationFields.Country_Code);
                    if (!reader.IsDBNull((int)CompanyLocationFields.State_Province_Code))
                        companyLocationPoco.Province = reader.GetString((int)CompanyLocationFields.State_Province_Code);
                    if (!reader.IsDBNull((int)CompanyLocationFields.Street_Address))
                        companyLocationPoco.Street = reader.GetString((int)CompanyLocationFields.Street_Address);
                    if (!reader.IsDBNull((int)CompanyLocationFields.City_Town))
                        companyLocationPoco.City = reader.GetString((int)CompanyLocationFields.City_Town);
                    if (!reader.IsDBNull((int)CompanyLocationFields.Zip_Postal_Code))
                        companyLocationPoco.PostalCode = reader.GetString((int)CompanyLocationFields.Zip_Postal_Code);
                    companyLocationPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)CompanyLocationFields.Time_Stamp);
                    companyLocationList.Add(companyLocationPoco);
                }
                reader.Close();
            }
            return companyLocationList;

        }
 

        public void Update(params CompanyLocationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Company_Locations]
                                           SET [Company] = @Company
                                              ,[Country_Code] = @Country_Code
                                              ,[State_Province_Code] = @State_Province_Code
                                              ,[Street_Address] = @Street_Address
                                              ,[City_Town] = @City_Town
                                              ,[Zip_Postal_Code] = @Zip_Postal_Code
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (CompanyLocationPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Company", item.Company);
                    cmd.Parameters.AddWithValue("@Country_Code", item.CountryCode);
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
