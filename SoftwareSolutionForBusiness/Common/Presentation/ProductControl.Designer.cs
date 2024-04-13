namespace SoftwareSolutionForBusiness.Common.Presentation
{
    partial class ProductControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.labelTypeAndName = new System.Windows.Forms.Label();
            this.labelCost = new System.Windows.Forms.Label();
            this.labelArticleNumber = new System.Windows.Forms.Label();
            this.labelMaterials = new System.Windows.Forms.Label();
            this.contextMenuStripActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonChangeProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.contextMenuStripActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 8;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49918F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.49917F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50167F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.50328F));
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxImage, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelTypeAndName, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelCost, 6, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelArticleNumber, 2, 1);
            this.tableLayoutPanelMain.Controls.Add(this.labelMaterials, 2, 2);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(8, 8);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(669, 73);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.pictureBoxImage, 2);
            this.pictureBoxImage.Image = global::SoftwareSolutionForBusiness.Properties.Resources.Plug;
            this.pictureBoxImage.InitialImage = global::SoftwareSolutionForBusiness.Properties.Resources.Plug;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.tableLayoutPanelMain.SetRowSpan(this.pictureBoxImage, 3);
            this.pictureBoxImage.Size = new System.Drawing.Size(160, 67);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // labelTypeAndName
            // 
            this.labelTypeAndName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTypeAndName.AutoEllipsis = true;
            this.labelTypeAndName.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelTypeAndName, 4);
            this.labelTypeAndName.Location = new System.Drawing.Point(169, 0);
            this.labelTypeAndName.Name = "labelTypeAndName";
            this.labelTypeAndName.Size = new System.Drawing.Size(326, 24);
            this.labelTypeAndName.TabIndex = 2;
            this.labelTypeAndName.Text = "Тип продукта | Наименование продукта";
            this.labelTypeAndName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCost
            // 
            this.labelCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCost.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelCost, 2);
            this.labelCost.Location = new System.Drawing.Point(501, 0);
            this.labelCost.Name = "labelCost";
            this.tableLayoutPanelMain.SetRowSpan(this.labelCost, 3);
            this.labelCost.Size = new System.Drawing.Size(165, 73);
            this.labelCost.TabIndex = 1;
            this.labelCost.Text = "Стоимость";
            this.labelCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelArticleNumber
            // 
            this.labelArticleNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArticleNumber.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelArticleNumber, 4);
            this.labelArticleNumber.Location = new System.Drawing.Point(169, 24);
            this.labelArticleNumber.Name = "labelArticleNumber";
            this.labelArticleNumber.Size = new System.Drawing.Size(326, 24);
            this.labelArticleNumber.TabIndex = 3;
            this.labelArticleNumber.Text = "Артикул";
            // 
            // labelMaterials
            // 
            this.labelMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaterials.AutoEllipsis = true;
            this.labelMaterials.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelMaterials, 4);
            this.labelMaterials.Location = new System.Drawing.Point(169, 48);
            this.labelMaterials.Name = "labelMaterials";
            this.labelMaterials.Size = new System.Drawing.Size(326, 25);
            this.labelMaterials.TabIndex = 4;
            this.labelMaterials.Text = "Материал 1, материал 2...";
            // 
            // contextMenuStripActions
            // 
            this.contextMenuStripActions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonChangeProduct,
            this.buttonSelect,
            this.buttonUnselect});
            this.contextMenuStripActions.Name = "contextMenuStripActions";
            this.contextMenuStripActions.Size = new System.Drawing.Size(209, 76);
            // 
            // buttonChangeProduct
            // 
            this.buttonChangeProduct.Name = "buttonChangeProduct";
            this.buttonChangeProduct.Size = new System.Drawing.Size(208, 24);
            this.buttonChangeProduct.Text = "Редактировать";
            this.buttonChangeProduct.Click += new System.EventHandler(this.ButtonChangeProduct_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(208, 24);
            this.buttonSelect.Text = "Выделить";
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonUnselect
            // 
            this.buttonUnselect.Name = "buttonUnselect";
            this.buttonUnselect.Size = new System.Drawing.Size(208, 24);
            this.buttonUnselect.Text = "Убрать выделение";
            this.buttonUnselect.Click += new System.EventHandler(this.ButtonUnselect_Click);
            // 
            // ProductControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ContextMenuStrip = this.contextMenuStripActions;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ProductControl";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Size = new System.Drawing.Size(685, 89);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.contextMenuStripActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelTypeAndName;
        private System.Windows.Forms.Label labelCost;
        private System.Windows.Forms.Label labelArticleNumber;
        private System.Windows.Forms.Label labelMaterials;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripActions;
        private System.Windows.Forms.ToolStripMenuItem buttonChangeProduct;
        private System.Windows.Forms.ToolStripMenuItem buttonSelect;
        private System.Windows.Forms.ToolStripMenuItem buttonUnselect;
    }
}
