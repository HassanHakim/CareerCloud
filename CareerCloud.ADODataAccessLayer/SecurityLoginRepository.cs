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
    public class SecurityLoginRepository : BaseADORepository<SecurityLoginPoco>, IDataRepository<SecurityLoginPoco>
    {
        enum SecurityLoginFields { Id, Login, Password, Created_Date, Password_Update_Date,  Agreement_Accepted_Date,Is_Locked, Is_Inactive,
                                    Email_Address,  Phone_Number, Full_Name, Force_Change_Password,Prefferred_Language, Time_Stamp }
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                                       ([Id]
                                                       ,[Login]
                                                       ,[Password]
                                                       ,[Created_Date]
                                                       ,[Password_Update_Date]
                                                       ,[Agreement_Accepted_Date]
                                                       ,[Is_Locked]
                                                       ,[Is_Inactive]
                                                       ,[Email_Address]
                                                       ,[Phone_Number]
                                                       ,[Full_Name]
                                                       ,[Force_Change_Password]
                                                       ,[Prefferred_Language])
                                                 VALUES
                                                       (@Id 
                                                       ,@Login 
                                                       ,@Password 
                                                       ,@Created_Date 
                                                       ,@Password_Update_Date 
                                                       ,@Agreement_Accepted_Date 
                                                       ,@Is_Locked 
                                                       ,@Is_Inactive 
                                                       ,@Email_Address 
                                                       ,@Phone_Number 
                                                       ,@Full_Name 
                                                       ,@Force_Change_Password 
                                                       ,@Prefferred_Language )";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public override IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            List<SecurityLoginPoco> securityLoginList = new List<SecurityLoginPoco>();
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Password]
                                          ,[Created_Date]
                                          ,[Password_Update_Date]
                                          ,[Agreement_Accepted_Date]
                                          ,[Is_Locked]
                                          ,[Is_Inactive]
                                          ,[Email_Address]
                                          ,[Phone_Number]
                                          ,[Full_Name]
                                          ,[Force_Change_Password]
                                          ,[Prefferred_Language]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Security_Logins]";
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SecurityLoginPoco securityLoginPoco = new SecurityLoginPoco();
                    securityLoginPoco.Id = reader.GetGuid((int)SecurityLoginFields.Id);
                    securityLoginPoco.Login = reader.GetString((int)SecurityLoginFields.Login);
                    securityLoginPoco.Password = reader.GetString((int)SecurityLoginFields.Password);
                    securityLoginPoco.Created = reader.GetDateTime((int)SecurityLoginFields.Created_Date);
                    if (!reader.IsDBNull((int)SecurityLoginFields.Password_Update_Date))
                        securityLoginPoco.PasswordUpdate = reader.GetDateTime((int)SecurityLoginFields.Password_Update_Date);
                    if (!reader.IsDBNull((int)SecurityLoginFields.Agreement_Accepted_Date))
                        securityLoginPoco.AgreementAccepted = reader.GetDateTime((int)SecurityLoginFields.Agreement_Accepted_Date);
                    securityLoginPoco.IsLocked = reader.GetBoolean((int)SecurityLoginFields.Is_Locked);
                    securityLoginPoco.IsInactive = reader.GetBoolean((int)SecurityLoginFields.Is_Inactive);
                    securityLoginPoco.EmailAddress = reader.GetString((int)SecurityLoginFields.Email_Address);
                    if (!reader.IsDBNull((int)SecurityLoginFields.Phone_Number))
                        securityLoginPoco.PhoneNumber = reader.GetString((int)SecurityLoginFields.Phone_Number);
                    if (!reader.IsDBNull((int)SecurityLoginFields.Full_Name))
                        securityLoginPoco.FullName = reader.GetString((int)SecurityLoginFields.Full_Name);
                    securityLoginPoco.ForceChangePassword = reader.GetBoolean((int)SecurityLoginFields.Force_Change_Password);
                    if (!reader.IsDBNull((int)SecurityLoginFields.Prefferred_Language))
                        securityLoginPoco.PrefferredLanguage = reader.GetString((int)SecurityLoginFields.Prefferred_Language);
                    securityLoginPoco.TimeStamp = reader.GetFieldValue<byte[]>((int)SecurityLoginFields.Time_Stamp);
                    securityLoginList.Add(securityLoginPoco);
                }
                reader.Close();
            }
            return securityLoginList;
        }

        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                           SET [Login] = @Login
                                              ,[Password] = @Password
                                              ,[Created_Date] = @Created_Date
                                              ,[Password_Update_Date] = @Password_Update_Date
                                              ,[Agreement_Accepted_Date] = @Agreement_Accepted_Date
                                              ,[Is_Locked] = @Is_Locked
                                              ,[Is_Inactive] = @Is_Inactive
                                              ,[Email_Address] = @Email_Address
                                              ,[Phone_Number] = @Phone_Number
                                              ,[Full_Name] = @Full_Name
                                              ,[Force_Change_Password] = @Force_Change_Password
                                              ,[Prefferred_Language] = @Prefferred_Language
                                         WHERE [Id] = @Id";
                cmd.Connection = conn;
                conn.Open();
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}
