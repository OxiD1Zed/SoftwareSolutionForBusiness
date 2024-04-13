using SoftwareSolutionForBusiness.Common.Data.Entities;
using SoftwareSolutionForBusiness.Common.Presentation;
using SoftwareSolutionForBusiness.Common.Theme;
using SoftwareSolutionForBusiness.Features.Main;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SoftwareSolutionForBusiness
{
    public partial class MainForm : Form
    {
        private readonly MainFormViewModel _viewModel;

        public MainForm(MainFormViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            this.BackColor = AppTheme.Background;
            this.Font = AppTheme.MiddleFont;
            textBoxSearch.BackColor = AppTheme.ControlBackground;
            comboBoxFilter.BackColor = AppTheme.ControlBackground;
            comboBoxSorting.BackColor = AppTheme.ControlBackground;
            buttonAddProduct.BackColor = AppTheme.ControlBackground;
            buttonChangeDirection.BackColor = AppTheme.ControlBackground;
            buttonAddMinCost.BackColor = AppTheme.ControlBackground;
            comboBoxFilter.Items.Add("Все типы");
            

            foreach (Control control in tableLayoutPanelMain.Controls)
            {
                if (!(control is FlowLayoutPanel))
                {
                    control.GotFocus += (s, args) => control.BackColor = AppTheme.ActiveBackground;
                    control.LostFocus += (s, args) => control.BackColor = AppTheme.ControlBackground;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ActionHandler(() => _viewModel.Load());
            comboBoxSorting.Items.AddRange(_viewModel.SortesTypes.Keys.ToArray());
            comboBoxFilter.Items.AddRange(_viewModel.ProductTypes.ToArray());
            RefreshProducts();
            RefreshPages();
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if(_viewModel.OpenProductEditor())
                RefreshPage();
        }

        private void ButtonChangeDirection_Click(object sender, EventArgs e)
        {
            ActionHandler(() =>
            {
                bool newDirection = !_viewModel.SortesDirection;
                _viewModel.SortesDirection = newDirection;
                buttonChangeDirection.Text = newDirection ? "↑" : "↓";
                RefreshPage();
            });
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            timerSearch.Stop();
            timerSearch.Start();
        }

        private void ComboBoxSorting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionHandler(() =>
            {
                _viewModel.CurrentSortesType = _viewModel.SortesTypes[comboBoxSorting.SelectedItem as string];
                RefreshPage();
            });
        }

        private void ComboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActionHandler(() =>
            {
                _viewModel.CurrentFilter = comboBoxFilter.SelectedItem is ProductType ? (comboBoxFilter.SelectedItem as ProductType).Id : -1;
                RefreshPage();
            });
            
        }

        private void FlowLayoutPanelProducts_SizeChanged(object sender, EventArgs e)
        {
            foreach(Control control in flowLayoutPanelProducts.Controls)
            {
                if(control is ProductControl)
                {
                    control.Size = new Size(flowLayoutPanelProducts.Size.Width - flowLayoutPanelProducts.Padding.Horizontal - control.Margin.Horizontal, control.Size.Height);
                }
            }
        }

        private LinkLabel[] GeneratePages(long maxPage, long currentPage)
        {
            LinkLabel[] pages = new LinkLabel[maxPage + 2];
            pages[0] = new LinkLabel()
            {
                Text = ">",
                LinkColor = Color.Black,
                ActiveLinkColor = AppTheme.ActiveBackground,
                LinkBehavior = LinkBehavior.NeverUnderline,
                AutoSize = true
            };
            pages[0].LinkClicked += (sender, e) => 
            {
                _viewModel.CurrentPage += 1;
                RefreshPage();
            };
            pages[pages.Length - 1] = new LinkLabel()
            {
                Text = "<",
                LinkColor = Color.Black,
                ActiveLinkColor = AppTheme.ActiveBackground,
                LinkBehavior = LinkBehavior.NeverUnderline,
                AutoSize = true
            };
            pages[pages.Length - 1].LinkClicked += (sender, e) =>
            {
                _viewModel.CurrentPage -= 1;
                RefreshPage();
            };
            for (int i = pages.Length - 2; i > 0; i--)
            {
                int localIndex = i;
                pages[i] = new LinkLabel()
                {
                    Text = (maxPage - i + 1).ToString(),
                    LinkColor = Color.Black,
                    ActiveLinkColor = AppTheme.ActiveBackground,
                    LinkBehavior = maxPage - i == currentPage ? LinkBehavior.AlwaysUnderline : LinkBehavior.NeverUnderline,
                    AutoSize = true
                };
                pages[i].LinkClicked += (sender, e) =>
                {
                    _viewModel.CurrentPage = maxPage - localIndex;
                    RefreshPage();
                };
            }

            return pages;
        }

        private void TimerSearch_Tick(object sender, EventArgs e)
        {
            ActionHandler(() => 
            {
                _viewModel.CurrentSearch = textBoxSearch.Text;
                RefreshPage();
            });
            timerSearch.Stop();
        }

        private void RefreshProducts()
        {
            ProductControl[] productControls = new ProductControl[_viewModel.Products.Count];
            for(int i = 0; i < productControls.Length; i++)
            {
                int localIndex = i;
                productControls[i] = new ProductControl
                {
                    Product = _viewModel.Products[i],
                    IsSelected = _viewModel.SelectedProducts.Contains(_viewModel.Products[i].Id),
                    SelectEvent = () => 
                    {
                        _viewModel.SelectProduct(_viewModel.Products[localIndex].Id);
                        buttonAddMinCost.Enabled = _viewModel.SelectedProducts.Count > 0;
                        buttonAddMinCost.Visible = buttonAddMinCost.Enabled;
                    },
                    UnselectEvent = () => 
                    {
                        _viewModel.UnselectProduct(_viewModel.Products[localIndex].Id);
                        buttonAddMinCost.Enabled = _viewModel.SelectedProducts.Count > 0;
                        buttonAddMinCost.Visible = buttonAddMinCost.Enabled;
                    },
                    ChangeProductEvent = () => 
                    {
                        if(_viewModel.OpenProductEditor(_viewModel.Products[localIndex]))
                            RefreshPage();
                    }
                };
                productControls[i].Size = new Size(flowLayoutPanelProducts.Size.Width - flowLayoutPanelProducts.Padding.Horizontal - productControls[i].Margin.Horizontal, productControls[i].Size.Height);
            }
            flowLayoutPanelProducts.Controls.Clear();
            flowLayoutPanelProducts.Controls.AddRange(productControls);
        }

        private void RefreshPages()
        {
            flowLayoutPanelPages.Controls.Clear();
            flowLayoutPanelPages.Controls.AddRange(GeneratePages(_viewModel.MaxPage, _viewModel.CurrentPage));
        }

        private void RefreshPage()
        {
            RefreshPages();
            RefreshProducts();
        }

        private void ActionHandler(Action method)
        {
            try
            {
                method();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonAddMinCost_Click(object sender, EventArgs e)
        {
            if (_viewModel.OpenAddMinCost())
                RefreshProducts();
        }
    }
}
