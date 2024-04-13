using Npgsql;
using SoftwareSolutionForBusiness.Common.Data.Provides;
using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Features.Main;
using SoftwareSolutionForBusiness.Features.ProductEditor;

namespace SoftwareSolutionForBusiness
{
    internal interface IDI
    {
        IMaterialProvider CreateMaterialProvider();

        IProductProvider CreateProductProvider();

        IProductTypeProvider CreateProductTypeProvider();

        IProductMaterialProvider CreateProductMaterialProvider();

        ProductEditorFormViewModel CreateProductEditorFormViewModel(ProductLong product);

        MainFormViewModel CreateMainFormViewModel();
    }

    internal class DI: IDI
    {
        private readonly NpgsqlConnection _connection;
        private IMaterialProvider _materialProvider;
        private IProductProvider _productProvider;
        private IProductTypeProvider _productTypeProvider;
        private IProductMaterialProvider _providerMaterialProvider;

        internal DI(NpgsqlConnection connection) 
        {
            _connection = connection;
        }

        public MainFormViewModel CreateMainFormViewModel()
        {
            return new MainFormViewModel(CreateProductTypeProvider(), CreateProductProvider(), CreateMaterialProvider(), CreateProductMaterialProvider());
        }

        public IProductMaterialProvider CreateProductMaterialProvider()
        {
            if(_providerMaterialProvider == null)
            {
                _providerMaterialProvider = new ProductMaterialProvider(_connection);
            }
            return _providerMaterialProvider;
        }

        public IMaterialProvider CreateMaterialProvider()
        {
            if( _materialProvider == null )
            {
                _materialProvider = new MaterialProvider( _connection );
            }
            return _materialProvider;
        }

        public IProductProvider CreateProductProvider()
        {
            if(_productProvider == null)
            {
                _productProvider = new ProductProvider( _connection );
            }
            return _productProvider;
        }

        public IProductTypeProvider CreateProductTypeProvider()
        {
            if(_productTypeProvider == null)
            {
                _productTypeProvider = new ProductTypeProvider( _connection );
            }
            return _productTypeProvider;
        }

        public ProductEditorFormViewModel CreateProductEditorFormViewModel(ProductLong product)
        {
            return new ProductEditorFormViewModel(product, CreateProductProvider(), CreateProductTypeProvider(), CreateMaterialProvider(), CreateProductMaterialProvider());
        }
    }
}
