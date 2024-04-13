using SoftwareSolutionForBusiness.Common.Data.Entities;

namespace SoftwareSolutionForBusiness.Common.Domain.Entities
{
    public class MaterialOfProductLong
    {
        public Material Material;
        public double? Count;
        
        public MaterialOfProductLong(Material material, double? count)
        {
            Material = material;
            Count = count;
        }

        public override string ToString()
        {
            return Material.ToString();
        }

        public MaterialOfProductLong CopyWith(Material material = null, double? count = null)
        {
            return new MaterialOfProductLong(material ?? Material, count ?? Count);
        }
    }
}
