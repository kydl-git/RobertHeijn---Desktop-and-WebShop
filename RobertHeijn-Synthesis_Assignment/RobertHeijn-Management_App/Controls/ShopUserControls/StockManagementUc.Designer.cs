using System.ComponentModel;

namespace RobertHeijn_Management_App.Controls.ShopUserControls;

partial class StockManagementUc
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBottomButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditProduct = new System.Windows.Forms.Button();
            this.btnRemoveAvailableAmount = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRightMenu = new System.Windows.Forms.TableLayoutPanel();
            this.cbxHighestPrice = new System.Windows.Forms.CheckBox();
            this.cbxSubCategoryName = new System.Windows.Forms.CheckBox();
            this.nudMaxPrice = new System.Windows.Forms.NumericUpDown();
            this.cmbSubCategoryName = new System.Windows.Forms.ComboBox();
            this.cmbCategoryName = new System.Windows.Forms.ComboBox();
            this.cbxMaxPrice = new System.Windows.Forms.CheckBox();
            this.nudMinPrice = new System.Windows.Forms.NumericUpDown();
            this.cbxMinPrice = new System.Windows.Forms.CheckBox();
            this.cbxCategoryName = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvProductsList = new System.Windows.Forms.DataGridView();
            this.tlpBackground.SuspendLayout();
            this.tlpBottomButtons.SuspendLayout();
            this.tlpRightMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpBackground
            // 
            this.tlpBackground.BackColor = System.Drawing.Color.Transparent;
            this.tlpBackground.ColumnCount = 2;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpBackground.Controls.Add(this.tlpBottomButtons, 0, 1);
            this.tlpBackground.Controls.Add(this.tlpRightMenu, 1, 0);
            this.tlpBackground.Controls.Add(this.dgvProductsList, 0, 0);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(0, 0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 2;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBackground.Size = new System.Drawing.Size(1234, 572);
            this.tlpBackground.TabIndex = 0;
            // 
            // tlpBottomButtons
            // 
            this.tlpBottomButtons.ColumnCount = 7;
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottomButtons.Controls.Add(this.btnEditProduct, 0, 0);
            this.tlpBottomButtons.Controls.Add(this.btnRemoveAvailableAmount, 2, 0);
            this.tlpBottomButtons.Controls.Add(this.tableLayoutPanel1, 6, 0);
            this.tlpBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottomButtons.Location = new System.Drawing.Point(0, 517);
            this.tlpBottomButtons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpBottomButtons.Name = "tlpBottomButtons";
            this.tlpBottomButtons.RowCount = 1;
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottomButtons.Size = new System.Drawing.Size(962, 52);
            this.tlpBottomButtons.TabIndex = 0;
            // 
            // btnEditProduct
            // 
            this.btnEditProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnEditProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditProduct.FlatAppearance.BorderSize = 0;
            this.btnEditProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnEditProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnEditProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.btnEditProduct.Location = new System.Drawing.Point(0, 0);
            this.btnEditProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditProduct.Name = "btnEditProduct";
            this.btnEditProduct.Size = new System.Drawing.Size(182, 52);
            this.btnEditProduct.TabIndex = 8;
            this.btnEditProduct.Text = "Edit Product";
            this.btnEditProduct.UseVisualStyleBackColor = false;
            this.btnEditProduct.Click += new System.EventHandler(this.BtnEditProduct_Click);
            // 
            // btnRemoveProduct
            // 
            this.btnRemoveAvailableAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnRemoveAvailableAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRemoveAvailableAmount.FlatAppearance.BorderSize = 0;
            this.btnRemoveAvailableAmount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnRemoveAvailableAmount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnRemoveAvailableAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAvailableAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRemoveAvailableAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.btnRemoveAvailableAmount.Location = new System.Drawing.Point(249, 0);
            this.btnRemoveAvailableAmount.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveAvailableAmount.Name = "btnRemoveAvailableAmount";
            this.btnRemoveAvailableAmount.Size = new System.Drawing.Size(182, 52);
            this.btnRemoveAvailableAmount.TabIndex = 7;
            this.btnRemoveAvailableAmount.Text = "Remove Product Quantity";
            this.btnRemoveAvailableAmount.UseVisualStyleBackColor = false;
            this.btnRemoveAvailableAmount.Click += new System.EventHandler(this.BtnRemoveProduct_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(721, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 46);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // tlpRightMenu
            // 
            this.tlpRightMenu.ColumnCount = 1;
            this.tlpRightMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRightMenu.Controls.Add(this.cbxHighestPrice, 0, 17);
            this.tlpRightMenu.Controls.Add(this.cbxSubCategoryName, 0, 5);
            this.tlpRightMenu.Controls.Add(this.nudMaxPrice, 0, 15);
            this.tlpRightMenu.Controls.Add(this.cmbSubCategoryName, 0, 7);
            this.tlpRightMenu.Controls.Add(this.cmbCategoryName, 0, 3);
            this.tlpRightMenu.Controls.Add(this.cbxMaxPrice, 0, 13);
            this.tlpRightMenu.Controls.Add(this.nudMinPrice, 0, 11);
            this.tlpRightMenu.Controls.Add(this.cbxMinPrice, 0, 9);
            this.tlpRightMenu.Controls.Add(this.cbxCategoryName, 0, 1);
            this.tlpRightMenu.Controls.Add(this.btnSearch, 0, 19);
            this.tlpRightMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRightMenu.Location = new System.Drawing.Point(962, 0);
            this.tlpRightMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tlpRightMenu.Name = "tlpRightMenu";
            this.tlpRightMenu.RowCount = 21;
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRightMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpRightMenu.Size = new System.Drawing.Size(272, 514);
            this.tlpRightMenu.TabIndex = 3;
            // 
            // cbxHighestPrice
            // 
            this.cbxHighestPrice.AutoSize = true;
            this.cbxHighestPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxHighestPrice.Location = new System.Drawing.Point(3, 397);
            this.cbxHighestPrice.Name = "cbxHighestPrice";
            this.cbxHighestPrice.Size = new System.Drawing.Size(266, 35);
            this.cbxHighestPrice.TabIndex = 14;
            this.cbxHighestPrice.Text = "Most expensive";
            this.cbxHighestPrice.UseVisualStyleBackColor = true;
            // 
            // cbxSubCategoryName
            // 
            this.cbxSubCategoryName.AutoSize = true;
            this.cbxSubCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSubCategoryName.Location = new System.Drawing.Point(3, 109);
            this.cbxSubCategoryName.Name = "cbxSubCategoryName";
            this.cbxSubCategoryName.Size = new System.Drawing.Size(266, 35);
            this.cbxSubCategoryName.TabIndex = 17;
            this.cbxSubCategoryName.Text = "Sub-category name:";
            this.cbxSubCategoryName.UseVisualStyleBackColor = true;
            this.cbxSubCategoryName.CheckedChanged += new System.EventHandler(this.CbxSubCategoryName_CheckedChanged);
            // 
            // nudMaxPrice
            // 
            this.nudMaxPrice.DecimalPlaces = 2;
            this.nudMaxPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMaxPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudMaxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.nudMaxPrice.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudMaxPrice.Location = new System.Drawing.Point(3, 352);
            this.nudMaxPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMaxPrice.Name = "nudMaxPrice";
            this.nudMaxPrice.Size = new System.Drawing.Size(266, 29);
            this.nudMaxPrice.TabIndex = 15;
            // 
            // cmbSubCategoryName
            // 
            this.cmbSubCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbSubCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbSubCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.cmbSubCategoryName.FormattingEnabled = true;
            this.cmbSubCategoryName.Location = new System.Drawing.Point(3, 160);
            this.cmbSubCategoryName.Name = "cmbSubCategoryName";
            this.cmbSubCategoryName.Size = new System.Drawing.Size(266, 29);
            this.cmbSubCategoryName.TabIndex = 14;
            // 
            // cmbCategoryName
            // 
            this.cmbCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbCategoryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.cmbCategoryName.FormattingEnabled = true;
            this.cmbCategoryName.Location = new System.Drawing.Point(3, 64);
            this.cmbCategoryName.Name = "cmbCategoryName";
            this.cmbCategoryName.Size = new System.Drawing.Size(266, 29);
            this.cmbCategoryName.TabIndex = 9;
            // 
            // cbxMaxPrice
            // 
            this.cbxMaxPrice.AutoSize = true;
            this.cbxMaxPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxMaxPrice.Location = new System.Drawing.Point(3, 301);
            this.cbxMaxPrice.Name = "cbxMaxPrice";
            this.cbxMaxPrice.Size = new System.Drawing.Size(266, 35);
            this.cbxMaxPrice.TabIndex = 15;
            this.cbxMaxPrice.Text = "Max price:";
            this.cbxMaxPrice.UseVisualStyleBackColor = true;
            this.cbxMaxPrice.CheckedChanged += new System.EventHandler(this.CbxMaxPrice_CheckedChanged);
            // 
            // nudMinPrice
            // 
            this.nudMinPrice.DecimalPlaces = 2;
            this.nudMinPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudMinPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nudMinPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.nudMinPrice.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.nudMinPrice.Location = new System.Drawing.Point(3, 256);
            this.nudMinPrice.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMinPrice.Name = "nudMinPrice";
            this.nudMinPrice.Size = new System.Drawing.Size(266, 29);
            this.nudMinPrice.TabIndex = 12;
            // 
            // cbxMinPrice
            // 
            this.cbxMinPrice.AutoSize = true;
            this.cbxMinPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxMinPrice.Location = new System.Drawing.Point(3, 205);
            this.cbxMinPrice.Name = "cbxMinPrice";
            this.cbxMinPrice.Size = new System.Drawing.Size(266, 35);
            this.cbxMinPrice.TabIndex = 16;
            this.cbxMinPrice.Text = "Min price:";
            this.cbxMinPrice.UseVisualStyleBackColor = true;
            this.cbxMinPrice.CheckedChanged += new System.EventHandler(this.CbxMinPrice_CheckedChanged);
            // 
            // cbxCategoryName
            // 
            this.cbxCategoryName.AutoSize = true;
            this.cbxCategoryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxCategoryName.Location = new System.Drawing.Point(3, 13);
            this.cbxCategoryName.Name = "cbxCategoryName";
            this.cbxCategoryName.Size = new System.Drawing.Size(266, 35);
            this.cbxCategoryName.TabIndex = 13;
            this.cbxCategoryName.Text = "Category name:";
            this.cbxCategoryName.UseVisualStyleBackColor = true;
            this.cbxCategoryName.CheckedChanged += new System.EventHandler(this.CbxCategoryName_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.btnSearch.Location = new System.Drawing.Point(0, 445);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(272, 41);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // dgvProductsList
            // 
            this.dgvProductsList.AllowUserToAddRows = false;
            this.dgvProductsList.AllowUserToDeleteRows = false;
            this.dgvProductsList.AllowUserToResizeRows = false;
            this.dgvProductsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductsList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProductsList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.dgvProductsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductsList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(222)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductsList.EnableHeadersVisualStyles = false;
            this.dgvProductsList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.dgvProductsList.Location = new System.Drawing.Point(3, 3);
            this.dgvProductsList.Name = "dgvProductsList";
            this.dgvProductsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvProductsList.RowHeadersVisible = false;
            this.dgvProductsList.RowHeadersWidth = 62;
            this.dgvProductsList.RowTemplate.Height = 25;
            this.dgvProductsList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductsList.Size = new System.Drawing.Size(956, 508);
            this.dgvProductsList.TabIndex = 4;
            this.dgvProductsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvProductsList_CellClick);
            this.dgvProductsList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProductsList_DataBindingComplete);
            // 
            // StockManagementUc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.CausesValidation = false;
            this.Controls.Add(this.tlpBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(1234, 572);
            this.Name = "StockManagementUc";
            this.Size = new System.Drawing.Size(1234, 572);
            this.tlpBackground.ResumeLayout(false);
            this.tlpBottomButtons.ResumeLayout(false);
            this.tlpRightMenu.ResumeLayout(false);
            this.tlpRightMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductsList)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private TableLayoutPanel tlpBackground;
    private TableLayoutPanel tlpBottomButtons;
    private NumericUpDown nudMinPrice;
    private NumericUpDown nudMaxPrice;
    private Button btnRemoveAvailableAmount;
    private Button btnEditProduct;
    private TableLayoutPanel tlpRightMenu;
    private Button btnSearch;
    private ComboBox cmbCategoryName;
    private DataGridView dgvProductsList;
    private CheckBox cbxCategoryName;
    private ComboBox cmbSubCategoryName;
    private TableLayoutPanel tableLayoutPanel1;
    private CheckBox cbxHighestPrice;
    private CheckBox cbxSubCategoryName;
    private CheckBox cbxMaxPrice;
    private CheckBox cbxMinPrice;
}
