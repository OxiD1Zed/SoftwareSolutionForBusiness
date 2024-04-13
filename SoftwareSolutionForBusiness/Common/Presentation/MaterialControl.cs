using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Common.Theme;
using SoftwareSolutionForBusiness.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Common.Presentation
{
    public partial class MaterialControl : UserControl
    {
        private MaterialOfProductLong _materialOfProduct;
        public Action SelectEvent { get; set; }

        public Action DeleteEvent { get; set; }

        public Action<double> ChangeCountEvent { get; set; }

        public MaterialOfProductLong MaterialOfProduct
        {
            get
            {
                return _materialOfProduct;
            }
            set
            {
                if (value == null) return;
                _materialOfProduct = value;
                labelName.Text = _materialOfProduct.Material.Title;
                labelCost.Text = _materialOfProduct.Material.Cost.ToString();
                labelCountInPack.Text = _materialOfProduct.Material.CountInPack.ToString() + " " + _materialOfProduct.Material.Unit;
                numericCount.Value = (decimal)(_materialOfProduct.Count ?? 0);
                if (_materialOfProduct.Material.Image != null)
                {
                    try
                    {
                        pictureBoxImage.Image = Image.FromFile(Program.ProjectPath + "\\Resources" + _materialOfProduct.Material.Image);
                    }
                    catch(Exception ex)
                    {
                        Debug.WriteLine(ex.StackTrace);
                        Debug.WriteLine(ex.Message);
                        pictureBoxImage.Image = Resources.Plug;
                    }
                }
            }
        }

        public MaterialControl()
        {
            InitializeComponent();
        }

        private void MaterialControl_Load(object sender, EventArgs e)
        {
            this.Font = AppTheme.MiddleFont;
            this.BackColor = AppTheme.ControlBackground;
            contextMenuStripActions.BackColor = AppTheme.ControlBackground;
            contextMenuStripActions.Font = this.Font;
            numericCount.BackColor = AppTheme.ControlBackground;
            numericCount.GotFocus += (s, args) => numericCount.BackColor = AppTheme.ActiveBackground;
            numericCount.LostFocus += (s, args) => numericCount.BackColor = AppTheme.ControlBackground;
        }

        private void ButtonSelect_Click(object sender, EventArgs e)
        {
            if (ChangeCountEvent == null) return;
            SelectEvent();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ChangeCountEvent == null) return;
            DeleteEvent();
        }

        private void NumericCount_ValueChanged(object sender, EventArgs e)
        {
            if (ChangeCountEvent == null) return;
            ChangeCountEvent(decimal.ToDouble(numericCount.Value));
        }
    }
}
