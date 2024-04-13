namespace SoftwareSolutionForBusiness.Common.Data.Entities
{
    public class Material
    {
        public int Id;
        public string Title;
        public int CountInPack;
        public string Unit;
        public double? CountInStock;
        public double MinCount;
        public string Description;
        public decimal Cost;
        public string Image;
        public int IdMaterialType;

        public Material(int id, string title, int countInPack, string unit, double? countInStock, double minCount, string description, decimal cost, string image, int idMaterialType)
        {
            Id = id;
            Title = title;
            CountInPack = countInPack;
            Unit = unit;
            CountInStock = countInStock;
            MinCount = minCount;
            Description = description;
            Cost = cost;
            Image = image;
            IdMaterialType = idMaterialType;
        }

        public override string ToString()
        {
            return Title;
        }

        public Material CopyWith(int? id = null, string title = null, int? countInPack = null, string unit = null, double? countInStock = null, double? minCount = null, string description = null, decimal? cost = null, string image = null, int? idMaterialType = null)
        {
            return new Material
                (
                    id ?? Id, 
                    title ?? Title, 
                    countInPack ?? CountInPack,
                    unit ?? Unit,
                    countInStock ?? CountInStock,
                    minCount ?? MinCount,
                    description ?? Description,
                    cost ?? Cost,
                    Image ?? Image,
                    idMaterialType ?? IdMaterialType
                );
        }
    }
}
