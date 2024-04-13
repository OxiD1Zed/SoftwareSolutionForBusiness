using Npgsql;
using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Data.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SoftwareSolutionForBusiness.Common.Data.Provides
{
    public interface IProductProvider
    {
        Product Select(int id);

        List<Product> SelectAll(long currentPage, int sizePage);

        List<Product> SelectAll(string search, long currentPage, int sizePage, bool isUp, SortesTypes sortType, int idProductType);

        bool IsSoldInTheLastMonth(int idProduct);

        long GetMaxPage(string search, int sizePage, int idProductType);

        bool Update(Product product);

        bool Delete(int id);

        int Insert(Product product);
    }

    public class ProductProvider : IProductProvider
    {
        private readonly NpgsqlConnection _connection;

        public ProductProvider(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public bool Delete(int id)
        {
            _connection.Open();
            bool isDelete = false;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "delete from product where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    isDelete = command.ExecuteNonQuery() > 0;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return isDelete;
        }

        public int Insert(Product product)
        {
            if (IsRegistration(product.ArticleNumber)) throw new ArgumentException($"Товар с артиклом \"{product.ArticleNumber}\" уже существует");
            _connection.Open();
            int id = product.Id;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "insert into product (id_product_type, title, article_number, description, image, production_person_count, production_workshop_number, min_cost_for_agent)" +
                        "values (@IdProductType, @Title, @ArticleNumber, @Description, @Image, @ProductionPersonCount, @ProductionWorkshopNumber, @MinCostForAgent) returning id";
                    command.Parameters.AddWithValue("@IdProductType", DBExtension.GetValidValue(product.IdProductType));
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@ArticleNumber", product.ArticleNumber);
                    command.Parameters.AddWithValue("@Description", DBExtension.GetValidValue(product.Description));
                    command.Parameters.AddWithValue("@Image", DBExtension.GetValidValue(product.Image));
                    command.Parameters.AddWithValue("@ProductionPersonCount", DBExtension.GetValidValue(product.ProductionPersonCount));
                    command.Parameters.AddWithValue("@ProductionWorkshopNumber", DBExtension.GetValidValue(product.ProductionWorkshopNumber));
                    command.Parameters.AddWithValue("@MinCostForAgent", product.MinCostForAgent);
                    id = (int)command.ExecuteScalar();
                }
            }
            catch(Exception ex )
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return id;
        }

        public List<Product> SelectAll(long currentPage, int sizePage)
        {
            return SelectAll("", currentPage, sizePage, true, SortesTypes.None, -1);
        }

        public List<Product> SelectAll(string search, long currentPage, int sizePage, bool isUp, SortesTypes sortType, int idProductType)
        {
            _connection.Open();
            List<Product> products = new List<Product>();
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    string sort = isUp ? "asc" : "desc";
                    command.CommandText = "select id, id_product_type, title, article_number, description, image, production_person_count, production_workshop_number, min_cost_for_agent " +
                        $"from product where (lower(title) like '%{search}%' or lower(description) like '%{search}%') " +
                        (idProductType != -1 ? $"and {idProductType} = id_product_type " : "") +
                        $"order by {NameFromSortesTypes(sortType)} {sort} " +
                        $"limit @SizePage offset @Offset";
                    command.Parameters.AddWithValue("@SizePage", sizePage);
                    command.Parameters.AddWithValue("@Offset", sizePage * currentPage);
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            products.Add(ProductFromReader(reader));
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
            return products;
        }

        public bool Update(Product product)
        {
            _connection.Open();
            bool isUpdate = false;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "update product set id_product_type = @IdProductType, " +
                        "title = @Title, " +
                        "description = @Description, " +
                        "image = @Image, " +
                        "production_person_count = @ProductionPersonCount, " +
                        "production_workshop_number = @ProductionWorkshopNumber, " +
                        "min_cost_for_agent = @MinCostForAgent " +
                        "where id = @Id";
                    command.Parameters.AddWithValue("@Title", product.Title);
                    command.Parameters.AddWithValue("@IdProductType", DBExtension.GetValidValue(product.IdProductType));
                    command.Parameters.AddWithValue("@Description", DBExtension.GetValidValue(product.Description));
                    command.Parameters.AddWithValue("@Image", DBExtension.GetValidValue(product.Image));
                    command.Parameters.AddWithValue("@ProductionPersonCount", DBExtension.GetValidValue(product.ProductionPersonCount));
                    command.Parameters.AddWithValue("@ProductionWorkshopNumber", DBExtension.GetValidValue(product.ProductionWorkshopNumber));
                    command.Parameters.AddWithValue("@MinCostForAgent", product.MinCostForAgent);
                    command.Parameters.AddWithValue("@Id", product.Id);
                    isUpdate = command.ExecuteNonQuery() > 0;
                }
            }
            catch( Exception ex ) 
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return isUpdate;
        }

        private bool IsRegistration(string articleNumber)
        {
            _connection.Open();
            bool isRegistration = true;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select count(id) as c from product where lower(article_number) = @ArticleNumber";
                    command.Parameters.AddWithValue("@ArticleNumber", articleNumber.ToLower());
                    isRegistration = (long)command.ExecuteScalar() > 0;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return isRegistration;
        }

        private Product ProductFromReader(NpgsqlDataReader reader)
        {
            int id = reader.GetInt32(reader.GetOrdinal("id"));
            int? idProductType = reader.GetValue(reader.GetOrdinal("id_product_type")) as int?;
            string title = reader.GetString(reader.GetOrdinal("title"));
            string articleNumber = reader.GetString(reader.GetOrdinal("article_number"));
            string description = reader.GetValue(reader.GetOrdinal("description")) as string;
            string image = reader.GetValue(reader.GetOrdinal("image")) as string;
            int? productionPersonCount = reader.GetValue(reader.GetOrdinal("production_person_count")) as int?;
            int? productionWorkshopNumber = reader.GetValue(reader.GetOrdinal("production_workshop_number")) as int?;
            decimal minCostForAgent = reader.GetDecimal(reader.GetOrdinal("min_cost_for_agent"));

            return new Product(id, title, articleNumber, description, image, productionPersonCount, productionWorkshopNumber, minCostForAgent, idProductType);
        }

        private string NameFromSortesTypes(SortesTypes type)
        {
            switch(type)
            {
                case SortesTypes.ProductionWorkshopNumber:
                    return "production_workshop_number";
                case SortesTypes.MinCostForAgent:
                    return "min_cost_for_agent";
                default:
                    return "title";
            }
        }

        public long GetMaxPage(string search, int sizePage, int idProductType)
        {
            _connection.Open();
            long maxPage = 0;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select count(id) as c " +
                        $"from product where (lower(title) like '%{search}%' or lower(description) like '%{search}%') " +
                        (idProductType != -1 ? $"and {idProductType} = id_product_type " : "");
                    maxPage = (long)Math.Ceiling((long)command.ExecuteScalar() / (double)sizePage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return maxPage;
        }

        public bool IsSoldInTheLastMonth(int idProduct)
        {
            _connection.Open();
            bool isSoldInTheLastMonth = false;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select sale_date from product_sale where id_product = @Id order by sale_date desc limit 1";
                    object result = command.ExecuteScalar();
                    if(result != null)
                    {
                        isSoldInTheLastMonth = (DateTime)result > DateTime.Now.Subtract(TimeSpan.FromDays(30));
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
            }
            _connection.Close();
            return isSoldInTheLastMonth;
        }

        public Product Select(int id)
        {
            _connection.Open();
            Product product = null;
            Exception exception = null;
            try
            {
                using(NpgsqlCommand command = _connection.CreateCommand())
                {
                    command.CommandText = "select id, id_product_type, title, article_number, description, image, production_person_count, production_workshop_number, min_cost_for_agent " +
                        "from product where id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    using(NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                product = ProductFromReader(reader);
                            }
                            else
                            {
                                exception = new NpgsqlException($"Не удалось получить продукт {id}");
                            }
                        }
                        else
                        {
                            exception = new ArgumentException($"Не удалось найти продукт {id}");
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
            return product;
        }
    }
}
