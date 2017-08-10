using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace CareerCloud.ADODataAccessLayer
{
    public abstract class BaseADORepository
    {
        protected readonly string _connStr;

        protected BaseADORepository()
        {
            _connStr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        }
    }
    public abstract class BaseADORepository<T> : BaseADORepository where T : IPoco
    {
        public abstract IList<T> GetAll(
            params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties);


        public IList<T> GetList(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            IList<T> pocos = GetAll(navigationProperties);
            pocos.Where(where);
            return pocos;
        }

        public T GetSingle(Func<T, bool> where, params System.Linq.Expressions.Expression<Func<T, object>>[] navigationProperties)
        {
            return GetAll(navigationProperties).SingleOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                TableAttribute attribute = (TableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(TableAttribute));
                //GetCustomAttribute(memberInfo, typeof(TableAttribute))//                                       
                string tableName = attribute.Name;
                cmd.CommandText = $"DELETE {tableName} WHERE Id = @Id";

                conn.Open();
                foreach (T item in items)
                {
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }
        }
    }
}