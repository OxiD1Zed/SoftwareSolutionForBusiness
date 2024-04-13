using Npgsql;
using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Data.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SoftwareSolutionForBusiness.Common.Data.Provides
{
    public interface IProductMaterialProvider
    {
        List<ProductMaterial> SelectAllByProduct(int idProduct);

        ProductMaterial Select(int idProduct, int idMaterial);

        void Insert(ProductMaterial productMaterial);

        bool Update(ProductMaterial productMaterial);

        bool Delete(int idProduct, int idMaterial);
    }

    public class ProductMaterialProvider : IProductMaterialProvider
    {
        private readonly NpgsqlConnection _connection;

        public ProductMaterialProvider(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(int idProduct, int idMaterial)
        {
            bool isDelete = false;
            RequastHandler((command) =>
            {
                command.CommandText = "delete from product_material where id_material = @IdMaterial and id_product = @IdProduct";
                command.Parameters.AddWithValue("@IdMaterial", idMaterial);
                command.Parameters.AddWithValue("@IdProduct", idProduct);
                isDelete = command.ExecuteNonQuery() > 0;
            });
            return isDelete;
        }

        public void Insert(ProductMaterial productMaterial)
        {
            RequastHandler((command) =>
            {
                command.CommandText = "insert into product_material (id_product, id_material, count) values (@IdProduct, @IdMaterial, @Count)";
                command.Parameters.AddWithValue("@IdMaterial", productMaterial.IdMaterial);
                command.Parameters.AddWithValue("@IdProduct", productMaterial.IdProduct);
                command.Parameters.AddWithValue("@Count", DBExtension.GetValidValue(productMaterial.Count));
                command.ExecuteNonQuery();
            });
        }

        public ProductMaterial Select(int idProduct, int idMaterial)
        {
            ProductMaterial productMaterial = null;
            Exception exception = null;
            RequastHandler((command) =>
            {
                command.CommandText = "select id_product, id_material, count from product_material where id_material = @IdMaterial and id_product = @IdProduct";
                command.Parameters.AddWithValue("@IdMaterial", idMaterial);
                command.Parameters.AddWithValue("@IdProduct", idProduct);
                using(NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            productMaterial = ProductMaterialFromReader(reader);
                        }
                        else
                        {
                            exception = new NpgsqlException("Не удалось получить материал продукта");
                        }
                    }
                    else
                    {
                        exception = new ArgumentException("Не удалось найти материал продукта");
                    }
                }
            });
            if(exception != null) throw exception;
            return productMaterial;
        }

        public List<ProductMaterial> SelectAllByProduct(int idProduct)
        {
            List<ProductMaterial> productMaterials = new List<ProductMaterial>();
            RequastHandler((command) =>
            {
                command.CommandText = "select id_product, id_material, count from product_material where id_product = @IdProduct";
                command.Parameters.AddWithValue("@IdProduct", idProduct);
                using(NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        productMaterials.Add(ProductMaterialFromReader(reader));
                    }
                }
            });
            return productMaterials;
        }

        public bool Update(ProductMaterial productMaterial)
        {
            bool isUpdate = false;
            RequastHandler((command) =>
            {
                command.CommandText = "update product_material set count = @Count where id_product = @IdProduct and id_material = @IdMaterial";
                command.Parameters.AddWithValue("@IdMaterial", productMaterial.IdMaterial);
                command.Parameters.AddWithValue("@IdProduct", productMaterial.IdProduct);
                command.Parameters.AddWithValue("@Count", DBExtension.GetValidValue(productMaterial.Count));
                isUpdate = command.ExecuteNonQuery() > 0;
            });
            return isUpdate;
        }

        private ProductMaterial ProductMaterialFromReader(NpgsqlDataReader reader)
        {
            int idProduct = reader.GetInt32(reader.GetOrdinal("id_product"));
            int idMaterial = reader.GetInt32(reader.GetOrdinal("id_material"));
            double? count = reader.GetValue(reader.GetOrdinal("count")) as double?;

            return new ProductMaterial(idProduct, idMaterial, count);
        }

        private void RequastHandler(Action<NpgsqlCommand> action)
        {
            _connection.Open();
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    action(command);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
        }
    }
}
