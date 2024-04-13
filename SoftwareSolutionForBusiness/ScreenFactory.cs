using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Features.ProductEditor;

namespace SoftwareSolutionForBusiness
{
    internal interface IScreenFactory
    {
        MainForm MakeMainForm();

        ProductEditorForm MakeProductEditorForm(ProductLong product);
    }

    internal class ScreenFactory : IScreenFactory
    {
        private readonly IDI _di;

        internal ScreenFactory(IDI di) 
        {
            _di = di;
        }

        public MainForm MakeMainForm()
        {
            return new MainForm(_di.CreateMainFormViewModel());
        }

        public ProductEditorForm MakeProductEditorForm(ProductLong product)
        {
            return new ProductEditorForm(_di.CreateProductEditorFormViewModel(product));
        }
    }
}
