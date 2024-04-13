using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Domain.Entities;
using SoftwareSolutionForBusiness.Common.Presentation;
using SoftwareSolutionForBusiness.Common.Theme;
using SoftwareSolutionForBusiness.Properties;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness.Features.ProductEditor
{
    public partial class ProductEditorForm : Form
    {
        private readonly ProductEditorFormViewModel _viewModel;
        private string _pathImage;
        public ProductEditorForm(ProductEditorFormViewModel viewModel)
        {
            InitializeComponent();
            this.Font = AppTheme.MiddleFont;
            this.BackColor = AppTheme.Background;
            textBoxName.BackColor = AppTheme.ControlBackground;
            textBoxArticleNumber.BackColor = AppTheme.ControlBackground;
            textBoxDescription.BackColor = AppTheme.ControlBackground;
            comboBoxTypeOfProduct.BackColor = AppTheme.ControlBackground;
            numericWorkshop.BackColor = AppTheme.ControlBackground;
            numericPersonCount.BackColor = AppTheme.ControlBackground;
            numericMinCost.BackColor = AppTheme.ControlBackground;
            buttonSave.BackColor = AppTheme.ControlBackground;
            buttonDelete.BackColor = AppTheme.ControlBackground;
            buttonChangeImage.BackColor = AppTheme.ControlBackground;
            buttonAddMaterial.BackColor = AppTheme.ControlBackground;
            foreach (Control control in tableLayoutPanelMain.Controls)
            {
                control.GotFocus += (s, args) => control.BackColor = AppTheme.ActiveBackground;
                control.LostFocus += (s, args) => control.BackColor = AppTheme.ControlBackground;
            }
            _pathImage = null;
            _viewModel = viewModel;
            buttonDelete.Enabled = !_viewModel.IsNew;
            buttonDelete.Visible = !_viewModel.IsNew;
        }

        private void ProductEditorForm_Load(object sender, EventArgs e)
        {
            ActionHandler(() =>
            {
                _viewModel.Load();
                comboBoxTypeOfProduct.Items.AddRange(_viewModel.ProductTypes.ToArray());
                comboBoxMaterial.Items.AddRange(_viewModel.Materials.ToArray());
            });
            textBoxName.Text = _viewModel.ProductLong.Title;
            textBoxArticleNumber.Text = _viewModel.ProductLong.ArticleNumber;
            textBoxDescription.Text = _viewModel.ProductLong.Description;
            numericMinCost.Value = _viewModel.ProductLong.MinCostForAgent;
            numericPersonCount.Value = _viewModel.ProductLong.ProductionPersonCount ?? 0;
            numericWorkshop.Value = _viewModel.ProductLong.ProductionWorkshopNumber ?? 0;
            comboBoxTypeOfProduct.SelectedItem = _viewModel.ProductLong.ProductType != null ? _viewModel.ProductTypes.Where((type) => type.Id == _viewModel.ProductLong.ProductType.Id).FirstOrDefault() : null;
            if (_viewModel.ProductLong.Image != null)
            {
                try
                {
                    pictureBoxImage.Image = Image.FromFile(Program.ProjectPath + "\\Resources" + _viewModel.ProductLong.Image);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                    Debug.WriteLine(ex.Message);
                    pictureBoxImage.Image = Resources.Plug;
                }
            }
            RefreshMaterials();
        }

        private void RefreshMaterials()
        {
            ActionHandler(() =>
            {
                MaterialControl[] controls = new MaterialControl[_viewModel.ProductLong.Materials.Count];
                for(int i = 0; i < controls.Length; i++)
                {
                    int localIndex = i;
                    MaterialControl control = new MaterialControl()
                    {
                        MaterialOfProduct = _viewModel.ProductLong.Materials[i],
                        DeleteEvent = () => 
                        {
                            _viewModel.RemoveMaterialOfProductLong(_viewModel.ProductLong.Materials[localIndex]);
                            RefreshMaterials();
                        },
                        ChangeCountEvent = (count) =>
                        {
                            _viewModel.ChangeMaterialOfProductLong(_viewModel.ProductLong.Materials[localIndex], count);
                        }
                    };
                    control.Size = new Size(flowLayoutPanelMaterials.Size.Width - flowLayoutPanelMaterials.Padding.Horizontal - control.Margin.Horizontal, control.Size.Height);
                    controls[i] = control;
                }
                flowLayoutPanelMaterials.Controls.Clear();
                flowLayoutPanelMaterials.Controls.AddRange(controls);
            });
        }

        private void ButtonChangeImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = "images (.png, .jpeg, .jpg)|*.png;*.jpeg;*.jpg"
            };
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBoxImage.Image = Image.FromFile(dialog.FileName);
                    _pathImage = dialog.FileName;
                }
                catch
                {
                    pictureBoxImage.Image = Resources.Plug;
                }
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show
            (
                "Вы действительно хотите удалить данный продукт?\nДанное дествие необратимо!", 
                "Удаление продукта", 
                MessageBoxButtons.OKCancel
            ) == DialogResult.OK)
            {
                ActionHandler(() => {
                    _viewModel.Delete();
                    DialogResult = DialogResult.OK;
                    this.Close();
                    });
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (String.IsNullOrWhiteSpace(textBoxName.Text))
            {
                errorProviderTitle.SetError(textBoxName, "Название должно быть указано");
                isValid = false;
            }
            if (String.IsNullOrWhiteSpace(textBoxArticleNumber.Text))
            {
                errorProviderArticleNumber.SetError(textBoxArticleNumber, "Артикл должен быть указан");
                isValid = false;
            }
            if(numericMinCost.Value <= 0)
            {
                errorProviderMinCostForAgent.SetError(numericMinCost, "Минимальная стоимость должна быть указана");
                isValid = false;
            }

            if (isValid)
            {
                ActionHandler(() =>
                {
                    _viewModel.Save
                        (
                            textBoxName.Text,
                            textBoxArticleNumber.Text,
                            textBoxDescription.Text,
                            decimal.ToInt32(numericWorkshop.Value),
                            decimal.ToInt32(numericPersonCount.Value),
                            comboBoxTypeOfProduct.SelectedItem as ProductType,
                            numericMinCost.Value,
                            _pathImage
                        );
                    MessageBox.Show("Продукт сохранен");
                    DialogResult = DialogResult.OK;
                    this.Close();
                });
            }
        }

        private void FlowLayoutPanelMaterials_SizeChanged(object sender, EventArgs e)
        {
            foreach(Control control in flowLayoutPanelMaterials.Controls)
            {
                if(control is MaterialControl)
                {
                    control.Size = new Size(flowLayoutPanelMaterials.Size.Width - flowLayoutPanelMaterials.Padding.Horizontal - control.Margin.Horizontal, control.Size.Height);
                }
            }
        }

        private void ActionHandler(Action action)
        {
            try
            {
                action();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddMaterial_Click(object sender, EventArgs e)
        {
            _viewModel.AddMaterial(comboBoxMaterial.SelectedItem as Material);
            RefreshMaterials();
        }
    }
}
