using SoftwareSolutionForBusiness.Common.Data.Entities;
using System.Collections.Generic;

namespace SoftwareSolutionForBusiness.Common.Domain.Entities
{
    public class ProductLong
    {
        public int Id;
        public string Title;
        public string ArticleNumber;
        public string Description;
        public string Image;
        public int? ProductionPersonCount;
        public int? ProductionWorkshopNumber;
        public decimal MinCostForAgent;
        public bool IsSoldInTheLastMonth;
        public ProductType ProductType;
        public List<MaterialOfProductLong> Materials;
        
        public ProductLong
            (
                int id, 
                string title, 
                string articleNumber, 
                string description, 
                string image, 
                int? productionPersonCount, 
                int? productionWorkshopNumber, 
                decimal minCostForAgent, 
                bool isSoldInTheLastMonth,
                ProductType productType,
                List<MaterialOfProductLong> materials
            )
        {
            Id = id;
            Title = title;
            ArticleNumber = articleNumber;
            Description = description;
            Image = image;
            ProductionPersonCount = productionPersonCount;
            ProductionWorkshopNumber = productionWorkshopNumber;
            MinCostForAgent = minCostForAgent;
            ProductType = productType;
            Materials = materials;
            IsSoldInTheLastMonth = isSoldInTheLastMonth;
        }

        public ProductLong()
        {
            Id = -1;
            Title = null;
            ArticleNumber = null;
            Description = null;
            Image = null;
            ProductionPersonCount = null;
            ProductionWorkshopNumber = null;
            MinCostForAgent = 0;
            IsSoldInTheLastMonth = false;
            ProductType = null;
            Materials = new List<MaterialOfProductLong>();
        }

        public ProductLong CopyWith
            (
                int? id = null, 
                string title = null,
                string articleNumber = null,
                string description = null,
                string image = null,
                int? productionPersonCount = null,
                int? productionWorkshopNumber = null,
                decimal? minCostForAgent = null,
                bool? isSoldInTheLastMonth = null,
                ProductType productType = null,
                List<MaterialOfProductLong> materials = null
            )
        {
            return new ProductLong
                (
                    id ?? Id,
                    title ?? Title,
                    articleNumber ?? ArticleNumber,
                    description ?? Description,
                    image ?? Image,
                    productionPersonCount ?? ProductionPersonCount,
                    productionWorkshopNumber ?? ProductionWorkshopNumber,
                    minCostForAgent ?? MinCostForAgent,
                    isSoldInTheLastMonth ?? IsSoldInTheLastMonth,
                    productType ?? ProductType,
                    materials ?? Materials
                );
        }
    }
}
