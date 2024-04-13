namespace SoftwareSolutionForBusiness.Common.Data.Entities
{
    public class ProductType
    {
        public int Id;
        public string Title;
        public double DefectedPercent;

        public ProductType(int id, string title, double defectedPercent)
        {
            Id = id;
            Title = title;
            DefectedPercent = defectedPercent;
        }

        public override string ToString()
        {
            return Title;
        }

        public ProductType CopyWith(int? id = null, string title = null, double? defectedPercent = null)
        {
            return new ProductType(id ?? Id, title ?? Title, defectedPercent ?? DefectedPercent);
        }
    }
}
