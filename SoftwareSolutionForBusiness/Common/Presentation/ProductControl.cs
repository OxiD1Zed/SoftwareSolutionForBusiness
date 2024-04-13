using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Common.Theme;
using SoftwareSolutionForBusiness.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Common.Presentation
{
    public partial class ProductControl : UserControl
    {
        private ProductLong _product;
        private bool _isSelected;
        private Color _defaultBackground;
        
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (value)
                {
                    BackColor = AppTheme.ActiveBackground;
                    buttonSelect.Enabled = false;
                    buttonUnselect.Enabled = true;
                }
                else
                {
                    BackColor = _defaultBackground;
                    buttonSelect.Enabled = true;
                    buttonUnselect.Enabled = false;
                }
                _isSelected = value;
            }
        }

        public Action ChangeProductEvent { get; set; }

        public Action SelectEvent { get; set; }

        public Action UnselectEvent { get; set; }

        public ProductLong Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                labelArticleNumber.Text = _product.ArticleNumber;
                labelCost.Text = _product.MinCostForAgent.ToString();
                labelTypeAndName.Text = _product.ProductType != null ? _product.ProductType.Title + " | " + _product.Title : _product.Title;
                labelMaterials.Text = string.Join(", ", _product.Materials);
                if (!_product.IsSoldInTheLastMonth) _defaultBackground = AppTheme.NegativeBackground;
                else _defaultBackground = AppTheme.ControlBackground;
                if (_product.Image != null)
                {
                    try
                    {
                        pictureBoxImage.Image = Image.FromFile(Program.ProjectPath + "\\Resources" + _product.Image);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                        Debug.WriteLine(ex.Message);
                        pictureBoxImage.Image = Resources.Plug;
                    }
                }
            }
        }

        public ProductControl()
        {
            InitializeComponent();
            IsSelected = false;
            Font = AppTheme.MiddleFont;
            labelTypeAndName.Font = AppTheme.BigFont;
            labelCost.Font = AppTheme.MiddleFont;
            labelArticleNumber.Font = AppTheme.MiddleFont;
            labelMaterials.Font = AppTheme.MiddleFont;
            contextMenuStripActions.Font = AppTheme.MiddleFont;
            contextMenuStripActions.BackColor = AppTheme.ControlBackground;
        }

        private void ButtonChangeProduct_Click(object sender, EventArgs e)
        {
            ChangeProductEvent();
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            SelectEvent();
            IsSelected = true;
        }

        private void ButtonUnselect_Click(object sender, EventArgs e)
        {
            UnselectEvent();
            IsSelected = false;
        }
    }
}
