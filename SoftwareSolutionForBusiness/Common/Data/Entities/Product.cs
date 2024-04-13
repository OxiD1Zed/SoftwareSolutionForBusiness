using System.Collections.Generic;

namespace SoftwareSolutionForBusiness.Common.Data.Entities
{
    public class Product
    {
        public int Id;
        public string Title;
        public string ArticleNumber;
        public string Description;
        public string Image;
        public int? ProductionPersonCount;
        public int? ProductionWorkshopNumber;
        public decimal MinCostForAgent;
        public int? IdProductType;

        public Product(int id, string title, string articleNumber, string description, string image, int? productionPersonCount, int? productionWorkshopNumber, decimal minCostForAgent, int? idProductType)
        {
            Id = id;
            Title = title;
            ArticleNumber = articleNumber;
            Description = description;
            Image = image;
            ProductionPersonCount = productionPersonCount;
            ProductionWorkshopNumber = productionWorkshopNumber;
            MinCostForAgent = minCostForAgent;
            IdProductType = idProductType;
        }
    }
}
