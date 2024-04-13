using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Data.Provides;
using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Features.ProductEditor
{
    public class ProductEditorFormViewModel
    {
        // убрать productlong только в mainform , а здесь использовать product или написать новый класс
        private readonly IProductProvider _productProvider;
        private readonly IProductTypeProvider _productTypeProvider;
        private readonly IMaterialProvider _materialProvider;
        private readonly IProductMaterialProvider _productMaterialProvider;

        private readonly List<MaterialOfProductLong> _saveMaterials;
        private readonly List<MaterialOfProductLong> _updateMaterials;
        private readonly List<MaterialOfProductLong> _deleteMaterials;
        private readonly List<Material> _materials;
        private readonly List<ProductType> _productTypes;
        private readonly ProductLong _product;
        private readonly ProductLong _copyProduct;
        
        public bool IsNew { get { return _product == null; } }

        public ProductLong ProductLong
        {
            get
            {
                return _copyProduct;
            }
        }

        public List<Material> Materials
        {
            get
            {
                return new List<Material>(_materials);
            }
        }

        public List<ProductType> ProductTypes
        {
            get
            {
                return new List<ProductType>(_productTypes);
            }
        }

        public ProductEditorFormViewModel(ProductLong product, IProductProvider productProvider, IProductTypeProvider productTypeProvider, IMaterialProvider materialProvider, IProductMaterialProvider productMaterialProvider)
        {
            _productProvider = productProvider;
            _productTypeProvider = productTypeProvider;
            _materialProvider = materialProvider;
            _productMaterialProvider = productMaterialProvider;
            _saveMaterials = new List<MaterialOfProductLong>();
            _updateMaterials = new List<MaterialOfProductLong>();
            _deleteMaterials = new List<MaterialOfProductLong>();
            _materials = new List<Material>();
            _productTypes = new List<ProductType>();
            _product = product;
            if (product != null)
            {
                _copyProduct = _product.CopyWith
                    (
                        title: string.Copy(_product.Title),
                        description: _product.Description != null ? string.Copy(_product.Description) : null,
                        articleNumber: string.Copy(_product.ArticleNumber),
                        image: _product.Image != null ? string.Copy(_product.Image) : null,
                        productType: _product.ProductType?.CopyWith(title: string.Copy(_product.ProductType.Title)),
                        materials: new List<MaterialOfProductLong>()
                    );
                foreach (MaterialOfProductLong materialOfProductLong in _product.Materials)
                {
                    _copyProduct.Materials.Add(materialOfProductLong.CopyWith(material: materialOfProductLong.Material.CopyWith()));
                }
            }
            else
            {
                _copyProduct = new ProductLong();
            }
        }

        public void Load()
        {
            try
            {
                List<Material> tempMaterials = _materialProvider.SelectAll();
                List<ProductType> tempProductTypes = _productTypeProvider.SelectAll();
                _materials.Clear();
                _materials.AddRange(tempMaterials);
                _productTypes.Clear();
                _productTypes.AddRange(tempProductTypes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось загрузить данные");
            }
        }

        public void Delete()
        {
            try
            {
                _productProvider.Delete(_copyProduct.Id);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось удалить товар");
            }
        }

        public void Save(string title, string articleNumber, string description, int productionWorkshopNumber, int productionPersonCount, ProductType productType, decimal minCostForAgent, string image)
        {
            _copyProduct.Title = title;
            _copyProduct.ArticleNumber = articleNumber;
            _copyProduct.ProductionWorkshopNumber = productionWorkshopNumber <= 0m ? null : (int?)productionWorkshopNumber;
            _copyProduct.ProductionPersonCount = productionPersonCount <= 0m ? null : (int?)productionPersonCount;
            _copyProduct.ProductType = productType;
            _copyProduct.Description = String.IsNullOrWhiteSpace(description) ? null : description;
            _copyProduct.MinCostForAgent = minCostForAgent;
            try
            {
                if (_product == null)
                {
                    int id = _productProvider.Insert(
                        new Product
                        (
                            _copyProduct.Id,
                            _copyProduct.Title,
                            _copyProduct.ArticleNumber,
                            _copyProduct.Description,
                            SaveImage(image),
                            _copyProduct.ProductionPersonCount,
                            _copyProduct.ProductionWorkshopNumber,
                            _copyProduct.MinCostForAgent,
                            _copyProduct.ProductType?.Id
                        )
                    );
                    foreach (MaterialOfProductLong materialOfProductLong in _saveMaterials)
                    {
                        _productMaterialProvider.Insert(new ProductMaterial(id, materialOfProductLong.Material.Id, materialOfProductLong.Count));
                    }
                }
                else
                {
                    _product.Title = _copyProduct.Title;
                    _product.ProductionWorkshopNumber = _copyProduct.ProductionWorkshopNumber;
                    _product.ProductionPersonCount = _copyProduct.ProductionPersonCount;
                    _product.Description = _copyProduct.Description;
                    _product.Image = SaveImage(image) ?? _product.Image;
                    _product.MinCostForAgent = _copyProduct.MinCostForAgent;
                    _product.ProductType = _copyProduct.ProductType;
                    _productProvider.Update(
                        new Product
                        (
                            _product.Id,
                            _product.Title,
                            _product.ArticleNumber,
                            _product.Description,
                            _product.Image,
                            _product.ProductionPersonCount,
                            _product.ProductionWorkshopNumber,
                            _product.MinCostForAgent,
                            _product.ProductType.Id
                        )
                    );
                    foreach (MaterialOfProductLong materialOfProductLong in _saveMaterials)
                    {
                        _productMaterialProvider.Insert(new ProductMaterial(_product.Id, materialOfProductLong.Material.Id, materialOfProductLong.Count));
                    }
                    foreach(MaterialOfProductLong materialOfProductLong in _updateMaterials)
                    {
                        _productMaterialProvider.Update(new ProductMaterial(_product.Id, materialOfProductLong.Material.Id, materialOfProductLong.Count));
                    }
                    foreach(MaterialOfProductLong materialOfProductLong in _deleteMaterials)
                    {
                        _productMaterialProvider.Delete(_product.Id, materialOfProductLong.Material.Id);
                    }
                }
            }
            catch(ArgumentException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось сохранить продукт");
            }
        }

        public void AddMaterial(Material material)
        {
            if (material == null) return;
            MaterialOfProductLong searchMaterial = _copyProduct.Materials.Where((m) => m.Material.Id == material.Id).FirstOrDefault();
            if(searchMaterial != null)
            {
                searchMaterial.Count++;
                if (!_saveMaterials.Contains(searchMaterial) && !_updateMaterials.Contains(searchMaterial))
                {
                    _updateMaterials.Add(searchMaterial);
                }
            }
            else
            {
                MaterialOfProductLong newMaterial = new MaterialOfProductLong(material, 1);
                _copyProduct.Materials.Add(newMaterial);
                _saveMaterials.Add(newMaterial);
            }
        }

        public void RemoveMaterialOfProductLong(MaterialOfProductLong material)
        {
            if(material == null) return;
            _copyProduct.Materials.Remove(material);
            _saveMaterials.Remove(material);
            bool isUpdateRemove = _updateMaterials.Remove(material);
            if (isUpdateRemove)
            {
                _deleteMaterials.Add(material);
            }
        }

        public void ChangeMaterialOfProductLong(MaterialOfProductLong material, double count)
        {
            if (material == null) return;
            if(!_updateMaterials.Contains(material))
            {
                _updateMaterials.Add(material);
            }
            else
            {
                MaterialOfProductLong startMaterial = _product?.Materials.Where((m) => m.Material.Id == material.Material.Id).FirstOrDefault();
                if(startMaterial != null && startMaterial.Count == count)
                {
                    _updateMaterials.Remove(material);
                }
            }
            material.Count = count;
        }

        private string SaveImage(string pathImage)
        {
            if (String.IsNullOrWhiteSpace(pathImage)) return null;
            try
            {
                string fileName = Path.GetFileName(pathImage);
                string resourcesPath = Program.ProjectPath + "\\Resources";
                string imagePath = "\\products\\" + fileName;
                string filePath = resourcesPath + imagePath;
                if (!File.Exists(filePath))
                {
                    File.Copy(pathImage, filePath);
                }

                return imagePath;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
