using Npgsql;
using SoftwareSolutionForBusiness.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SoftwareSolutionForBusiness.Common.Data.Provides
{
    public interface IProductTypeProvider
    {
        List<ProductType> SelectAll();
        List<ProductType> SelectAll(string search);

        ProductType Select(int id);
    }

    public class ProductTypeProvider : IProductTypeProvider
    {
        private readonly NpgsqlConnection _connection;

        public ProductTypeProvider(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public ProductType Select(int id)
        {
            _connection.Open();
            ProductType productType = null;
            Exception exception = null;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select id, title, defected_percent from product_type where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                productType = ProductTypeFromReader(reader);
                            }
                            else
                            {
                                exception = new NpgsqlException("Не удалось получить тип продутка \"{id}\"");
                            }
                        }
                        else
                        {
                            exception = new ArgumentException($"Тип продукта \"{id}\" не найден");
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            if(exception != null) throw exception;
            return productType;
        }

        public List<ProductType> SelectAll(string search)
        {
            _connection.Open();
            List<ProductType> productTypes = new List<ProductType>();
            try
            {
                using (NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = $"select id, title, defected_percent from product_type where lower(title) like '%{search}%'";
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productTypes.Add(ProductTypeFromReader(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return productTypes;
        }

        public List<ProductType> SelectAll()
        {
            return SelectAll("");
        }

        private ProductType ProductTypeFromReader(NpgsqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            double defectedPercent = reader.GetDouble(reader.GetOrdinal("defected_percent"));

            return new ProductType(id, title, defectedPercent);
        }
    }
}
