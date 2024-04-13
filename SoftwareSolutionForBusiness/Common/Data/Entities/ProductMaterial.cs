namespace SoftwareSolutionForBusiness.Common.Data.Entities
{
    public class ProductMaterial
    {
        public int IdProduct;
        public int IdMaterial;
        public double? Count;

        public ProductMaterial(int idProduct, int idMaterial, double? count)
        {
            IdProduct = idProduct;
            IdMaterial = idMaterial;
            Count = count;
        }
    }
}
