using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Data.Provides;
using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Features.AddMinCost;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Features.Main
{
    public class MainFormViewModel
    {
        private readonly IProductProvider _productProvider;
        private readonly IProductTypeProvider _productTypeProvider;
        private readonly IMaterialProvider _materialProvider;
        private readonly IProductMaterialProvider _productMaterialProvider;

        private readonly List<ProductLong> _products;
        private readonly Dictionary<string, SortesTypes> _sortesTypes;
        private readonly List<ProductType> _productsTypes;
        private readonly List<int> _selectedProducts;
        private long _currentPage;
        private int _sizePage;
        private SortesTypes _currentSortesType;
        private int _currentFilter;
        private string _currentSearch;
        private bool _currentSortesDirection;

        public List<ProductLong> Products 
        {
            get 
            {
                return new List<ProductLong>(_products);
            }
        }

        public Dictionary<string, SortesTypes> SortesTypes
        {
            get 
            {
                return new Dictionary<string, SortesTypes>(_sortesTypes); 
            }
        }

        public List<ProductType> ProductTypes
        {
            get
            {
                return new List<ProductType>(_productsTypes);
            }
        }

        public List<int> SelectedProducts
        {
            get
            {
                return new List<int>(_selectedProducts);
            }
        }

        public long CurrentPage 
        {
            get 
            {
                return _currentPage;
            }
            set
            {
                if (value < 0 || value >= MaxPage) return;
                ChangePage(CurrentSearch, value, SizePage, SortesDirection, CurrentSortesType, CurrentFilter);
                _currentPage = value;
            }
        }
        public long MaxPage { get; private set; }

        public SortesTypes CurrentSortesType
        {
            get
            {
                return _currentSortesType;
            }
            set
            {
                if(value == _currentSortesType) return;
                Search(CurrentSearch, SizePage, SortesDirection, value, CurrentFilter);
                _currentSortesType = value;
            }
        }

        public int CurrentFilter
        {
            get
            {
                return _currentFilter;
            }
            set
            {
                if(value == _currentFilter) return;
                Search(CurrentSearch, SizePage, SortesDirection, CurrentSortesType, value);
                _currentFilter = value;
            }
        }
        private int SizePage
        {
            get
            {
                return _sizePage;
            }
            set
            {
                if (value < 1 || value == _sizePage) return;
                Search(CurrentSearch, value, SortesDirection, CurrentSortesType, CurrentFilter);
                _sizePage = value;
            }
        }

        public string CurrentSearch
        {
            get
            {
                return _currentSearch;
            }
            set
            {
                string validValue = value.ToLower().Trim();
                if (validValue == _currentSearch) return;
                Search(validValue, SizePage, SortesDirection, CurrentSortesType, CurrentFilter);
                _currentSearch = validValue;
            }
        }

        public bool SortesDirection
        {
            get
            {
                return _currentSortesDirection;
            }
            set
            {
                if(value == _currentSortesDirection) return;
                Search(CurrentSearch, SizePage, value, CurrentSortesType, CurrentFilter);
                _currentSortesDirection = value;
            }
        }

        public MainFormViewModel(IProductTypeProvider productTypeProvider, IProductProvider productProvider, IMaterialProvider materialProvider, IProductMaterialProvider productMaterialProvider)
        {
            _productTypeProvider = productTypeProvider;
            _productProvider = productProvider;
            _materialProvider = materialProvider;
            _productMaterialProvider = productMaterialProvider;

            _sizePage = 20;
            _currentPage = 0;
            MaxPage = 0;
            _currentSearch = string.Empty;
            _currentSortesDirection = true;
            _currentSortesType = Common.Data.Entities.SortesTypes.Title;
            _currentFilter = -1;

            _products = new List<ProductLong>();
            _sortesTypes = new Dictionary<string, SortesTypes>()
            {
                { "Название", Common.Data.Entities.SortesTypes.Title },
                { "Минимальная стоимость для агента", Common.Data.Entities.SortesTypes.MinCostForAgent },
                { "Номер производственного цеха", Common.Data.Entities.SortesTypes.ProductionWorkshopNumber }
            };
            _productsTypes = new List<ProductType>();
            _selectedProducts = new List<int>();
        }

        public void Load()
        {
            try
            {
                List<ProductType> tempProductsTypes = _productTypeProvider.SelectAll();
                Search(CurrentSearch, SizePage, SortesDirection, CurrentSortesType, CurrentFilter);
                _productsTypes.Clear();
                _productsTypes.AddRange(tempProductsTypes);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось загрузить данные");
            }
        }

        private void ChangePage(string search, long page, int sizePage, bool sortesDirection, SortesTypes sortesType, int idProductType)
        {
            try
            {
                List<Product> products = _productProvider.SelectAll(search, page, sizePage, sortesDirection, sortesType, idProductType);
                ProductLong[] temp = new ProductLong[products.Count];
                for (int i = 0; i < temp.Length; i++)
                {
                    List<ProductMaterial> productMaterials = _productMaterialProvider.SelectAllByProduct(products[i].Id);
                    List<MaterialOfProductLong> materials = new List<MaterialOfProductLong>();
                    foreach (ProductMaterial productMaterial in productMaterials)
                    {
                        materials.Add(new MaterialOfProductLong(_materialProvider.Select(productMaterial.IdMaterial), productMaterial.Count));
                    }
                    temp[i] = new ProductLong
                        (
                            products[i].Id,
                            products[i].Title,
                            products[i].ArticleNumber,
                            products[i].Description,
                            products[i].Image,
                            products[i].ProductionPersonCount,
                            products[i].ProductionWorkshopNumber,
                            products[i].MinCostForAgent,
                            _productProvider.IsSoldInTheLastMonth(products[i].Id),
                            products[i].IdProductType != null ? _productTypeProvider.Select(products[i].IdProductType ?? 0) : null,
                            materials
                        );
                }
                _products.Clear();
                _products.AddRange(temp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось загрузить страницу");
            }
        }

        private void Search(string search, int sizePage, bool sortesDirection, SortesTypes sortesType, int idProductType)
        {
            try 
            {
                MaxPage = _productProvider.GetMaxPage(search, sizePage, idProductType);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось загрузить данные о страницах");
            }
            ChangePage(search, 0, sizePage, sortesDirection, sortesType, idProductType);
            _currentPage = 0;
        }

        public void SelectProduct(int idProduct)
        {
            if (!_selectedProducts.Contains(idProduct))
            {
                _selectedProducts.Add(idProduct);
            }
        }

        public void UnselectProduct(int idProduct)
        {
            _selectedProducts.Remove(idProduct);
        }

        public bool OpenProductEditor()
        {
            return OpenProductEditor(null);
        }

        public bool OpenProductEditor(ProductLong product)
        {
            if(Program.Navigator.MakeProductEditorForm(product).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Search(CurrentSearch, SizePage, SortesDirection, CurrentSortesType, CurrentFilter);
                return true;
            }
            return false;
        }

        public bool OpenAddMinCost()
        {
            Product[] products = GetSelectedProducts();

            AddMinCostForm addMinCostForm = new AddMinCostForm(GetMiddleCostSelectedProducts(products), (value) =>
            {
                AddMinCostForSelectedProducts(products, value);
            });
            if(addMinCostForm.ShowDialog() == DialogResult.OK)
            {
                ChangePage(CurrentSearch, CurrentPage, SizePage, SortesDirection, CurrentSortesType, CurrentFilter);
                return true;
            }
            return false;
        }

        private decimal GetMiddleCostSelectedProducts(Product[] products)
        {
            decimal sum = 0;
            foreach (Product product in products)
            {
                sum += product.MinCostForAgent;
            }
            return sum / products.Length;
        }

        private void AddMinCostForSelectedProducts(Product[] products, decimal cost)
        {
            try
            {
                foreach (Product product in products)
                {
                    product.MinCostForAgent += cost;
                    _productProvider.Update(product);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                Debug.WriteLine(ex.Message);
                throw new ApplicationException("Не удалось добавить стоимость");
            }
        }

        private Product[] GetSelectedProducts()
        {
            Product[] products = new Product[SelectedProducts.Count];
            for (int i = 0; i < products.Length; i++)
            {
                products[i] = _productProvider.Select(SelectedProducts[i]);
            }

            return products;
        }
    }
}
