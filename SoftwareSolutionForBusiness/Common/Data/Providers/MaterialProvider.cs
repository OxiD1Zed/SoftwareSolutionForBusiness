using Npgsql;
using SoftwareSolutionForBusiness.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SoftwareSolutionForBusiness.Common.Data.Provides
{
    public interface IMaterialProvider
    {
        List<Material> SelectAll();

        List<Material> SelectByProduct(int idProduct, long currentPage, int sizePage);

        Material Select(int id);
    }

    public class MaterialProvider : IMaterialProvider
    {
        private readonly NpgsqlConnection _connection;

        public MaterialProvider(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public Material Select(int id)
        {
            _connection.Open();
            Material material = null;
            Exception exception = null;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select id, id_material_type, title, count_in_pack, unit, count_in_stock, min_count, description, cost, image " +
                        "from material where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                material = MaterialFromReader(reader);
                            }
                            else
                            {
                                exception = new NpgsqlException($"Не удалось прочитать материал \"{id}\"");
                            }
                        }
                        else
                        {
                            exception = new ArgumentException($"Не удалось найти материал \"{id}\"");
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
            if (exception != null) throw exception;
            return material;
        }

        public List<Material> SelectAll()
        {
            _connection.Open();
            List<Material> materials = new List<Material>();
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select id, id_material_type, title, count_in_pack, unit, count_in_stock, min_count, description, cost, image " +
                        $"from material order by title";
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            materials.Add(MaterialFromReader(reader));
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
            return materials;
        }

        public List<Material> SelectByProduct(int idProduct, long currentPage, int sizePage)
        {
            _connection.Open();
            List<Material> materials = new List<Material>();
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select m.id, m.id_material_type, m.title, m.count_in_pack, m.unit, m.count_in_stock, m.min_count, m.description, m.cost, m.image " +
                        "from material as m left join product_material as pm on m.id = pm.id_material where pm.id_product = @IdProduct order by id limit @SizePage offset @Offset";
                    command.Parameters.AddWithValue("@IdProduct", idProduct);
                    command.Parameters.AddWithValue("@SizePage", sizePage);
                    command.Parameters.AddWithValue("@Offset", currentPage * sizePage);
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            materials.Add(MaterialFromReader(reader));
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
            return materials;
        }

        private Material MaterialFromReader(NpgsqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            string title = reader.GetString(reader.GetOrdinal("title"));
            int countInPack = reader.GetInt32(reader.GetOrdinal("count_in_pack"));
            string unit = reader.GetString(reader.GetOrdinal("unit"));
            double? countInStock = reader.GetValue(reader.GetOrdinal("count_in_stock")) as double?;
            double minCount = reader.GetDouble(reader.GetOrdinal("min_count"));
            decimal cost = reader.GetDecimal(reader.GetOrdinal("cost"));
            string description = reader.GetValue(reader.GetOrdinal("description")) as string;
            string image = reader.GetValue(reader.GetOrdinal("image")) as string;
            int idMaterialType = reader.GetInt32(reader.GetOrdinal("id_material_type"));

            return new Material(id, title, countInPack, unit, countInStock, minCount, description, cost, image, idMaterialType);
        }
    }
}
