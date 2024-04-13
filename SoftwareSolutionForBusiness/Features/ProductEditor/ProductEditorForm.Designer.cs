namespace SoftwareSolutionForBusiness.Features.ProductEditor
{
    partial class ProductEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditorForm));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxMaterial = new System.Windows.Forms.ComboBox();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelArticleNumber = new System.Windows.Forms.Label();
            this.labelTypeOfProduct = new System.Windows.Forms.Label();
            this.labelPersonCount = new System.Windows.Forms.Label();
            this.labelWorkshopNumber = new System.Windows.Forms.Label();
            this.labelMinCost = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxArticleNumber = new System.Windows.Forms.TextBox();
            this.comboBoxTypeOfProduct = new System.Windows.Forms.ComboBox();
            this.numericPersonCount = new System.Windows.Forms.NumericUpDown();
            this.numericWorkshop = new System.Windows.Forms.NumericUpDown();
            this.numericMinCost = new System.Windows.Forms.NumericUpDown();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonChangeImage = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAddMaterial = new System.Windows.Forms.Button();
            this.panelMaterials = new System.Windows.Forms.Panel();
            this.flowLayoutPanelMaterialsPages = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelMaterials = new System.Windows.Forms.FlowLayoutPanel();
            this.errorProviderTitle = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderArticleNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProviderMinCostForAgent = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPersonCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWorkshop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinCost)).BeginInit();
            this.panelMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderArticleNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMinCostForAgent)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 12;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxMaterial, 9, 5);
            this.tableLayoutPanelMain.Controls.Add(this.labelMaterial, 6, 5);
            this.tableLayoutPanelMain.Controls.Add(this.labelDescription, 0, 11);
            this.tableLayoutPanelMain.Controls.Add(this.labelName, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxImage, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxLogo, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelArticleNumber, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelTypeOfProduct, 0, 7);
            this.tableLayoutPanelMain.Controls.Add(this.labelPersonCount, 0, 8);
            this.tableLayoutPanelMain.Controls.Add(this.labelWorkshopNumber, 0, 9);
            this.tableLayoutPanelMain.Controls.Add(this.labelMinCost, 0, 10);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxName, 3, 5);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxArticleNumber, 3, 6);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxTypeOfProduct, 3, 7);
            this.tableLayoutPanelMain.Controls.Add(this.numericPersonCount, 3, 8);
            this.tableLayoutPanelMain.Controls.Add(this.numericWorkshop, 3, 9);
            this.tableLayoutPanelMain.Controls.Add(this.numericMinCost, 3, 10);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxDescription, 3, 11);
            this.tableLayoutPanelMain.Controls.Add(this.buttonChangeImage, 5, 4);
            this.tableLayoutPanelMain.Controls.Add(this.buttonSave, 10, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonDelete, 9, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonAddMaterial, 11, 4);
            this.tableLayoutPanelMain.Controls.Add(this.panelMaterials, 6, 6);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.Padding = new System.Windows.Forms.Padding(16);
            this.tableLayoutPanelMain.RowCount = 13;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.689466F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1235, 529);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // comboBoxMaterial
            // 
            this.comboBoxMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.comboBoxMaterial, 3);
            this.comboBoxMaterial.FormattingEnabled = true;
            this.comboBoxMaterial.IntegralHeight = false;
            this.comboBoxMaterial.Location = new System.Drawing.Point(919, 213);
            this.comboBoxMaterial.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.comboBoxMaterial.MaxDropDownItems = 5;
            this.comboBoxMaterial.Name = "comboBoxMaterial";
            this.comboBoxMaterial.Size = new System.Drawing.Size(284, 24);
            this.comboBoxMaterial.TabIndex = 1;
            // 
            // labelMaterial
            // 
            this.labelMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMaterial.AutoEllipsis = true;
            this.labelMaterial.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelMaterial, 3);
            this.labelMaterial.Location = new System.Drawing.Point(619, 206);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(294, 38);
            this.labelMaterial.TabIndex = 1;
            this.labelMaterial.Text = "Материалы:";
            this.labelMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.AutoEllipsis = true;
            this.labelDescription.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelDescription, 3);
            this.labelDescription.Location = new System.Drawing.Point(19, 434);
            this.labelDescription.Name = "labelDescription";
            this.tableLayoutPanelMain.SetRowSpan(this.labelDescription, 2);
            this.labelDescription.Size = new System.Drawing.Size(294, 79);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Описание:";
            this.labelDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoEllipsis = true;
            this.labelName.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelName, 3);
            this.labelName.Location = new System.Drawing.Point(19, 206);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(294, 38);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Название:";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.pictureBoxImage, 12);
            this.pictureBoxImage.Image = global::SoftwareSolutionForBusiness.Properties.Resources.Plug;
            this.pictureBoxImage.Location = new System.Drawing.Point(19, 57);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.tableLayoutPanelMain.SetRowSpan(this.pictureBoxImage, 3);
            this.pictureBoxImage.Size = new System.Drawing.Size(1197, 108);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImage.TabIndex = 1;
            this.pictureBoxImage.TabStop = false;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = global::SoftwareSolutionForBusiness.Properties.Resources.Logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(19, 19);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(94, 32);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelArticleNumber
            // 
            this.labelArticleNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelArticleNumber.AutoEllipsis = true;
            this.labelArticleNumber.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelArticleNumber, 3);
            this.labelArticleNumber.Location = new System.Drawing.Point(19, 244);
            this.labelArticleNumber.Name = "labelArticleNumber";
            this.labelArticleNumber.Size = new System.Drawing.Size(294, 38);
            this.labelArticleNumber.TabIndex = 2;
            this.labelArticleNumber.Text = "Артикул:";
            this.labelArticleNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTypeOfProduct
            // 
            this.labelTypeOfProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTypeOfProduct.AutoEllipsis = true;
            this.labelTypeOfProduct.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelTypeOfProduct, 3);
            this.labelTypeOfProduct.Location = new System.Drawing.Point(19, 282);
            this.labelTypeOfProduct.Name = "labelTypeOfProduct";
            this.labelTypeOfProduct.Size = new System.Drawing.Size(294, 38);
            this.labelTypeOfProduct.TabIndex = 3;
            this.labelTypeOfProduct.Text = "Тип продукта:";
            this.labelTypeOfProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelPersonCount
            // 
            this.labelPersonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPersonCount.AutoEllipsis = true;
            this.labelPersonCount.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelPersonCount, 3);
            this.labelPersonCount.Location = new System.Drawing.Point(19, 320);
            this.labelPersonCount.Name = "labelPersonCount";
            this.labelPersonCount.Size = new System.Drawing.Size(294, 38);
            this.labelPersonCount.TabIndex = 4;
            this.labelPersonCount.Text = "Количетсво человек для производства:";
            this.labelPersonCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelWorkshopNumber
            // 
            this.labelWorkshopNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWorkshopNumber.AutoEllipsis = true;
            this.labelWorkshopNumber.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelWorkshopNumber, 3);
            this.labelWorkshopNumber.Location = new System.Drawing.Point(19, 358);
            this.labelWorkshopNumber.Name = "labelWorkshopNumber";
            this.labelWorkshopNumber.Size = new System.Drawing.Size(294, 38);
            this.labelWorkshopNumber.TabIndex = 5;
            this.labelWorkshopNumber.Text = "№ производственного цеха:";
            this.labelWorkshopNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelMinCost
            // 
            this.labelMinCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMinCost.AutoEllipsis = true;
            this.labelMinCost.AutoSize = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.labelMinCost, 3);
            this.labelMinCost.Location = new System.Drawing.Point(19, 396);
            this.labelMinCost.Name = "labelMinCost";
            this.labelMinCost.Size = new System.Drawing.Size(294, 38);
            this.labelMinCost.TabIndex = 6;
            this.labelMinCost.Text = "Минимальная стоимость:";
            this.labelMinCost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxName, 3);
            this.textBoxName.Location = new System.Drawing.Point(319, 214);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(281, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxArticleNumber
            // 
            this.textBoxArticleNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxArticleNumber, 3);
            this.textBoxArticleNumber.Location = new System.Drawing.Point(319, 252);
            this.textBoxArticleNumber.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.textBoxArticleNumber.Name = "textBoxArticleNumber";
            this.textBoxArticleNumber.Size = new System.Drawing.Size(281, 22);
            this.textBoxArticleNumber.TabIndex = 2;
            // 
            // comboBoxTypeOfProduct
            // 
            this.comboBoxTypeOfProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.comboBoxTypeOfProduct, 3);
            this.comboBoxTypeOfProduct.FormattingEnabled = true;
            this.comboBoxTypeOfProduct.IntegralHeight = false;
            this.comboBoxTypeOfProduct.Location = new System.Drawing.Point(319, 289);
            this.comboBoxTypeOfProduct.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.comboBoxTypeOfProduct.MaxDropDownItems = 5;
            this.comboBoxTypeOfProduct.Name = "comboBoxTypeOfProduct";
            this.comboBoxTypeOfProduct.Size = new System.Drawing.Size(281, 24);
            this.comboBoxTypeOfProduct.TabIndex = 3;
            // 
            // numericPersonCount
            // 
            this.numericPersonCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.numericPersonCount, 3);
            this.numericPersonCount.Location = new System.Drawing.Point(319, 328);
            this.numericPersonCount.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.numericPersonCount.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericPersonCount.Name = "numericPersonCount";
            this.numericPersonCount.Size = new System.Drawing.Size(281, 22);
            this.numericPersonCount.TabIndex = 4;
            this.numericPersonCount.ThousandsSeparator = true;
            // 
            // numericWorkshop
            // 
            this.numericWorkshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.numericWorkshop, 3);
            this.numericWorkshop.Location = new System.Drawing.Point(319, 366);
            this.numericWorkshop.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.numericWorkshop.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numericWorkshop.Name = "numericWorkshop";
            this.numericWorkshop.Size = new System.Drawing.Size(281, 22);
            this.numericWorkshop.TabIndex = 5;
            this.numericWorkshop.ThousandsSeparator = true;
            // 
            // numericMinCost
            // 
            this.numericMinCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.numericMinCost, 3);
            this.numericMinCost.DecimalPlaces = 2;
            this.numericMinCost.Location = new System.Drawing.Point(319, 404);
            this.numericMinCost.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.numericMinCost.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericMinCost.Name = "numericMinCost";
            this.numericMinCost.Size = new System.Drawing.Size(281, 22);
            this.numericMinCost.TabIndex = 6;
            this.numericMinCost.ThousandsSeparator = true;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxDescription, 3);
            this.textBoxDescription.Location = new System.Drawing.Point(319, 437);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(3, 3, 16, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.tableLayoutPanelMain.SetRowSpan(this.textBoxDescription, 2);
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDescription.Size = new System.Drawing.Size(281, 73);
            this.textBoxDescription.TabIndex = 7;
            // 
            // buttonChangeImage
            // 
            this.buttonChangeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChangeImage.AutoEllipsis = true;
            this.buttonChangeImage.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonChangeImage, 2);
            this.buttonChangeImage.Location = new System.Drawing.Point(519, 171);
            this.buttonChangeImage.Name = "buttonChangeImage";
            this.buttonChangeImage.Size = new System.Drawing.Size(194, 32);
            this.buttonChangeImage.TabIndex = 8;
            this.buttonChangeImage.Text = "Изменить";
            this.buttonChangeImage.UseVisualStyleBackColor = false;
            this.buttonChangeImage.Click += new System.EventHandler(this.ButtonChangeImage_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.AutoEllipsis = true;
            this.tableLayoutPanelMain.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.Location = new System.Drawing.Point(1019, 19);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(197, 32);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.AutoEllipsis = true;
            this.buttonDelete.ForeColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(919, 19);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(94, 32);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "×";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonAddMaterial
            // 
            this.buttonAddMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddMaterial.AutoEllipsis = true;
            this.buttonAddMaterial.Location = new System.Drawing.Point(1119, 171);
            this.buttonAddMaterial.Name = "buttonAddMaterial";
            this.buttonAddMaterial.Size = new System.Drawing.Size(97, 32);
            this.buttonAddMaterial.TabIndex = 11;
            this.buttonAddMaterial.Text = "+";
            this.buttonAddMaterial.UseVisualStyleBackColor = true;
            this.buttonAddMaterial.Click += new System.EventHandler(this.ButtonAddMaterial_Click);
            // 
            // panelMaterials
            // 
            this.panelMaterials.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMaterials.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanelMain.SetColumnSpan(this.panelMaterials, 6);
            this.panelMaterials.Controls.Add(this.flowLayoutPanelMaterialsPages);
            this.panelMaterials.Controls.Add(this.flowLayoutPanelMaterials);
            this.panelMaterials.Location = new System.Drawing.Point(624, 252);
            this.panelMaterials.Margin = new System.Windows.Forms.Padding(8);
            this.panelMaterials.Name = "panelMaterials";
            this.tableLayoutPanelMain.SetRowSpan(this.panelMaterials, 7);
            this.panelMaterials.Size = new System.Drawing.Size(587, 253);
            this.panelMaterials.TabIndex = 14;
            // 
            // flowLayoutPanelMaterialsPages
            // 
            this.flowLayoutPanelMaterialsPages.AutoScroll = true;
            this.flowLayoutPanelMaterialsPages.AutoSize = true;
            this.flowLayoutPanelMaterialsPages.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelMaterialsPages.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelMaterialsPages.Location = new System.Drawing.Point(0, 251);
            this.flowLayoutPanelMaterialsPages.Name = "flowLayoutPanelMaterialsPages";
            this.flowLayoutPanelMaterialsPages.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
            this.flowLayoutPanelMaterialsPages.Size = new System.Drawing.Size(585, 0);
            this.flowLayoutPanelMaterialsPages.TabIndex = 0;
            this.flowLayoutPanelMaterialsPages.WrapContents = false;
            // 
            // flowLayoutPanelMaterials
            // 
            this.flowLayoutPanelMaterials.AutoScroll = true;
            this.flowLayoutPanelMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelMaterials.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelMaterials.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelMaterials.Name = "flowLayoutPanelMaterials";
            this.flowLayoutPanelMaterials.Padding = new System.Windows.Forms.Padding(16);
            this.flowLayoutPanelMaterials.Size = new System.Drawing.Size(585, 251);
            this.flowLayoutPanelMaterials.TabIndex = 0;
            this.flowLayoutPanelMaterials.WrapContents = false;
            this.flowLayoutPanelMaterials.SizeChanged += new System.EventHandler(this.FlowLayoutPanelMaterials_SizeChanged);
            // 
            // errorProviderTitle
            // 
            this.errorProviderTitle.ContainerControl = this;
            // 
            // errorProviderArticleNumber
            // 
            this.errorProviderArticleNumber.ContainerControl = this;
            // 
            // errorProviderMinCostForAgent
            // 
            this.errorProviderMinCostForAgent.ContainerControl = this;
            // 
            // ProductEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1235, 529);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактор продукта";
            this.Load += new System.EventHandler(this.ProductEditorForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPersonCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWorkshop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinCost)).EndInit();
            this.panelMaterials.ResumeLayout(false);
            this.panelMaterials.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderArticleNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderMinCostForAgent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonChangeImage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPersonCount;
        private System.Windows.Forms.Label labelArticleNumber;
        private System.Windows.Forms.Label labelTypeOfProduct;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelWorkshopNumber;
        private System.Windows.Forms.Label labelMinCost;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxArticleNumber;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxTypeOfProduct;
        private System.Windows.Forms.NumericUpDown numericPersonCount;
        private System.Windows.Forms.NumericUpDown numericWorkshop;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.NumericUpDown numericMinCost;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.ComboBox comboBoxMaterial;
        private System.Windows.Forms.Button buttonAddMaterial;
        private System.Windows.Forms.Panel panelMaterials;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMaterialsPages;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMaterials;
        private System.Windows.Forms.ErrorProvider errorProviderTitle;
        private System.Windows.Forms.ErrorProvider errorProviderArticleNumber;
        private System.Windows.Forms.ErrorProvider errorProviderMinCostForAgent;
    }
}