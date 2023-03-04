namespace RobertHeijn_Management_App.Forms.Popups;

partial class AddProductPopUp
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
		this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
		this.tlpButtonsBackground = new System.Windows.Forms.TableLayoutPanel();
		this.btnCancel = new System.Windows.Forms.Button();
		this.btnOk = new System.Windows.Forms.Button();
		this.tlpProductInfo = new System.Windows.Forms.TableLayoutPanel();
		this.tlpQuantityAmount = new System.Windows.Forms.TableLayoutPanel();
		this.pnlProductQuantity = new System.Windows.Forms.Panel();
		this.tlpProductQuantity = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductQuantityError = new System.Windows.Forms.Label();
		this.tlpProductQuantityInput = new System.Windows.Forms.TableLayoutPanel();
		this.nudProductQuantity = new System.Windows.Forms.NumericUpDown();
		this.cmbUnit = new System.Windows.Forms.ComboBox();
		this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductQuantity = new System.Windows.Forms.Label();
		this.cbxEditQuantity = new System.Windows.Forms.CheckBox();
		this.pnlProductAmount = new System.Windows.Forms.Panel();
		this.tlpProductAmount = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductAmount = new System.Windows.Forms.Label();
		this.lblProductAmountError = new System.Windows.Forms.Label();
		this.nudAvailableAmount = new System.Windows.Forms.NumericUpDown();
		this.tlpNameCategory = new System.Windows.Forms.TableLayoutPanel();
		this.pnlProductName = new System.Windows.Forms.Panel();
		this.tlpProductName = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductName = new System.Windows.Forms.Label();
		this.tbProductName = new System.Windows.Forms.TextBox();
		this.lblProductNameError = new System.Windows.Forms.Label();
		this.pnlProductCategory = new System.Windows.Forms.Panel();
		this.tlpProductCategory = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductCategory = new System.Windows.Forms.Label();
		this.lblProductCategoryError = new System.Windows.Forms.Label();
		this.cmbProductCategory = new System.Windows.Forms.ComboBox();
		this.pnlProductSubCategory = new System.Windows.Forms.Panel();
		this.tlpProductSubCategory = new System.Windows.Forms.TableLayoutPanel();
		this.cmbProductSubCategory = new System.Windows.Forms.ComboBox();
		this.lblProductSubCategory = new System.Windows.Forms.Label();
		this.lblProductSubCategoryError = new System.Windows.Forms.Label();
		this.lblProductInfo = new System.Windows.Forms.Label();
		this.pnlProductPrice = new System.Windows.Forms.Panel();
		this.tlpProductPrice = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductPriceError = new System.Windows.Forms.Label();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.lblProductPrice = new System.Windows.Forms.Label();
		this.cbxEditPrice = new System.Windows.Forms.CheckBox();
		this.nudProductPrice = new System.Windows.Forms.NumericUpDown();
		this.tlpBackground.SuspendLayout();
		this.tlpButtonsBackground.SuspendLayout();
		this.tlpProductInfo.SuspendLayout();
		this.tlpQuantityAmount.SuspendLayout();
		this.pnlProductQuantity.SuspendLayout();
		this.tlpProductQuantity.SuspendLayout();
		this.tlpProductQuantityInput.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.nudProductQuantity)).BeginInit();
		this.tableLayoutPanel2.SuspendLayout();
		this.pnlProductAmount.SuspendLayout();
		this.tlpProductAmount.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.nudAvailableAmount)).BeginInit();
		this.tlpNameCategory.SuspendLayout();
		this.pnlProductName.SuspendLayout();
		this.tlpProductName.SuspendLayout();
		this.pnlProductCategory.SuspendLayout();
		this.tlpProductCategory.SuspendLayout();
		this.pnlProductSubCategory.SuspendLayout();
		this.tlpProductSubCategory.SuspendLayout();
		this.pnlProductPrice.SuspendLayout();
		this.tlpProductPrice.SuspendLayout();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.nudProductPrice)).BeginInit();
		this.SuspendLayout();
		// 
		// tlpBackground
		// 
		this.tlpBackground.AutoSize = true;
		this.tlpBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
		this.tlpBackground.CausesValidation = false;
		this.tlpBackground.ColumnCount = 1;
		this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpBackground.Controls.Add(this.tlpButtonsBackground, 0, 1);
		this.tlpBackground.Controls.Add(this.tlpProductInfo, 0, 0);
		this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpBackground.Location = new System.Drawing.Point(3, 3);
		this.tlpBackground.Margin = new System.Windows.Forms.Padding(0);
		this.tlpBackground.Name = "tlpBackground";
		this.tlpBackground.RowCount = 2;
		this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
		this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
		this.tlpBackground.Size = new System.Drawing.Size(880, 444);
		this.tlpBackground.TabIndex = 0;
		// 
		// tlpButtonsBackground
		// 
		this.tlpButtonsBackground.ColumnCount = 5;
		this.tlpButtonsBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
		this.tlpButtonsBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
		this.tlpButtonsBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
		this.tlpButtonsBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
		this.tlpButtonsBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
		this.tlpButtonsBackground.Controls.Add(this.btnCancel, 3, 0);
		this.tlpButtonsBackground.Controls.Add(this.btnOk, 1, 0);
		this.tlpButtonsBackground.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpButtonsBackground.Location = new System.Drawing.Point(0, 377);
		this.tlpButtonsBackground.Margin = new System.Windows.Forms.Padding(0);
		this.tlpButtonsBackground.Name = "tlpButtonsBackground";
		this.tlpButtonsBackground.RowCount = 1;
		this.tlpButtonsBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpButtonsBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpButtonsBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpButtonsBackground.Size = new System.Drawing.Size(880, 67);
		this.tlpButtonsBackground.TabIndex = 0;
		// 
		// btnCancel
		// 
		this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
		this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnCancel.FlatAppearance.BorderSize = 0;
		this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
		this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
		this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
		this.btnCancel.Location = new System.Drawing.Point(448, 0);
		this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.Size = new System.Drawing.Size(220, 67);
		this.btnCancel.TabIndex = 0;
		this.btnCancel.Text = "Cancel";
		this.btnCancel.UseVisualStyleBackColor = false;
		// 
		// btnOk
		// 
		this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
		this.btnOk.Dock = System.Windows.Forms.DockStyle.Fill;
		this.btnOk.FlatAppearance.BorderSize = 0;
		this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
		this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
		this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
		this.btnOk.Location = new System.Drawing.Point(211, 0);
		this.btnOk.Margin = new System.Windows.Forms.Padding(0);
		this.btnOk.Name = "btnOk";
		this.btnOk.Size = new System.Drawing.Size(220, 67);
		this.btnOk.TabIndex = 1;
		this.btnOk.Text = "btnOk";
		this.btnOk.UseVisualStyleBackColor = false;
		this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
		// 
		// tlpProductInfo
		// 
		this.tlpProductInfo.AutoSize = true;
		this.tlpProductInfo.ColumnCount = 5;
		this.tlpProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.010101F));
		this.tlpProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.64646F));
		this.tlpProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.010101F));
		this.tlpProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.32323F));
		this.tlpProductInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.010101F));
		this.tlpProductInfo.Controls.Add(this.tlpQuantityAmount, 1, 4);
		this.tlpProductInfo.Controls.Add(this.tlpNameCategory, 1, 2);
		this.tlpProductInfo.Controls.Add(this.pnlProductSubCategory, 3, 2);
		this.tlpProductInfo.Controls.Add(this.lblProductInfo, 1, 1);
		this.tlpProductInfo.Controls.Add(this.pnlProductPrice, 3, 4);
		this.tlpProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductInfo.Location = new System.Drawing.Point(0, 0);
		this.tlpProductInfo.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductInfo.Name = "tlpProductInfo";
		this.tlpProductInfo.RowCount = 6;
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpProductInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpProductInfo.Size = new System.Drawing.Size(880, 377);
		this.tlpProductInfo.TabIndex = 2;
		// 
		// tlpQuantityAmount
		// 
		this.tlpQuantityAmount.ColumnCount = 3;
		this.tlpQuantityAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
		this.tlpQuantityAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
		this.tlpQuantityAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
		this.tlpQuantityAmount.Controls.Add(this.pnlProductQuantity, 0, 0);
		this.tlpQuantityAmount.Controls.Add(this.pnlProductAmount, 2, 0);
		this.tlpQuantityAmount.Location = new System.Drawing.Point(8, 201);
		this.tlpQuantityAmount.Margin = new System.Windows.Forms.Padding(0);
		this.tlpQuantityAmount.Name = "tlpQuantityAmount";
		this.tlpQuantityAmount.RowCount = 1;
		this.tlpQuantityAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpQuantityAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpQuantityAmount.Size = new System.Drawing.Size(568, 134);
		this.tlpQuantityAmount.TabIndex = 1;
		// 
		// pnlProductQuantity
		// 
		this.pnlProductQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductQuantity.Controls.Add(this.tlpProductQuantity);
		this.pnlProductQuantity.Location = new System.Drawing.Point(0, 0);
		this.pnlProductQuantity.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductQuantity.Name = "pnlProductQuantity";
		this.pnlProductQuantity.Size = new System.Drawing.Size(278, 133);
		this.pnlProductQuantity.TabIndex = 3;
		// 
		// tlpProductQuantity
		// 
		this.tlpProductQuantity.ColumnCount = 1;
		this.tlpProductQuantity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductQuantity.Controls.Add(this.lblProductQuantityError, 0, 2);
		this.tlpProductQuantity.Controls.Add(this.tlpProductQuantityInput, 0, 1);
		this.tlpProductQuantity.Controls.Add(this.tableLayoutPanel2, 0, 0);
		this.tlpProductQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductQuantity.Location = new System.Drawing.Point(0, 0);
		this.tlpProductQuantity.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductQuantity.Name = "tlpProductQuantity";
		this.tlpProductQuantity.RowCount = 3;
		this.tlpProductQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductQuantity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductQuantity.Size = new System.Drawing.Size(278, 133);
		this.tlpProductQuantity.TabIndex = 0;
		// 
		// lblProductQuantityError
		// 
		this.lblProductQuantityError.AutoSize = true;
		this.lblProductQuantityError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductQuantityError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductQuantityError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductQuantityError.Location = new System.Drawing.Point(3, 90);
		this.lblProductQuantityError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductQuantityError.Name = "lblProductQuantityError";
		this.lblProductQuantityError.Size = new System.Drawing.Size(272, 41);
		this.lblProductQuantityError.TabIndex = 2;
		this.lblProductQuantityError.Text = "lblProductQuantityError";
		this.lblProductQuantityError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductQuantityError.Visible = false;
		// 
		// tlpProductQuantityInput
		// 
		this.tlpProductQuantityInput.ColumnCount = 2;
		this.tlpProductQuantityInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
		this.tlpProductQuantityInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
		this.tlpProductQuantityInput.Controls.Add(this.nudProductQuantity, 0, 0);
		this.tlpProductQuantityInput.Controls.Add(this.cmbUnit, 1, 0);
		this.tlpProductQuantityInput.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductQuantityInput.Location = new System.Drawing.Point(0, 41);
		this.tlpProductQuantityInput.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductQuantityInput.Name = "tlpProductQuantityInput";
		this.tlpProductQuantityInput.RowCount = 1;
		this.tlpProductQuantityInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductQuantityInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpProductQuantityInput.Size = new System.Drawing.Size(278, 47);
		this.tlpProductQuantityInput.TabIndex = 3;
		// 
		// nudProductQuantity
		// 
		this.nudProductQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
		this.nudProductQuantity.Location = new System.Drawing.Point(3, 3);
		this.nudProductQuantity.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
		this.nudProductQuantity.Name = "nudProductQuantity";
		this.nudProductQuantity.Size = new System.Drawing.Size(188, 33);
		this.nudProductQuantity.TabIndex = 4;
		// 
		// cmbUnit
		// 
		this.cmbUnit.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cmbUnit.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.cmbUnit.FormattingEnabled = true;
		this.cmbUnit.Location = new System.Drawing.Point(197, 5);
		this.cmbUnit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
		this.cmbUnit.Name = "cmbUnit";
		this.cmbUnit.Size = new System.Drawing.Size(78, 36);
		this.cmbUnit.TabIndex = 2;
		// 
		// tableLayoutPanel2
		// 
		this.tableLayoutPanel2.ColumnCount = 2;
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
		this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
		this.tableLayoutPanel2.Controls.Add(this.lblProductQuantity, 0, 0);
		this.tableLayoutPanel2.Controls.Add(this.cbxEditQuantity, 1, 0);
		this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel2.Name = "tableLayoutPanel2";
		this.tableLayoutPanel2.RowCount = 1;
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tableLayoutPanel2.Size = new System.Drawing.Size(272, 35);
		this.tableLayoutPanel2.TabIndex = 2;
		// 
		// lblProductQuantity
		// 
		this.lblProductQuantity.AutoSize = true;
		this.lblProductQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductQuantity.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductQuantity.Location = new System.Drawing.Point(3, 0);
		this.lblProductQuantity.Name = "lblProductQuantity";
		this.lblProductQuantity.Size = new System.Drawing.Size(89, 35);
		this.lblProductQuantity.TabIndex = 0;
		this.lblProductQuantity.Text = "Quantity";
		this.lblProductQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// cbxEditQuantity
		// 
		this.cbxEditQuantity.AutoSize = true;
		this.cbxEditQuantity.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cbxEditQuantity.Location = new System.Drawing.Point(98, 3);
		this.cbxEditQuantity.Name = "cbxEditQuantity";
		this.cbxEditQuantity.Size = new System.Drawing.Size(171, 29);
		this.cbxEditQuantity.TabIndex = 1;
		this.cbxEditQuantity.Text = "Edit Quantity";
		this.cbxEditQuantity.UseVisualStyleBackColor = true;
		this.cbxEditQuantity.CheckedChanged += new System.EventHandler(this.cbxEditQuantity_CheckedChanged);
		// 
		// pnlProductAmount
		// 
		this.pnlProductAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductAmount.Controls.Add(this.tlpProductAmount);
		this.pnlProductAmount.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlProductAmount.Location = new System.Drawing.Point(289, 0);
		this.pnlProductAmount.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductAmount.Name = "pnlProductAmount";
		this.pnlProductAmount.Size = new System.Drawing.Size(279, 134);
		this.pnlProductAmount.TabIndex = 2;
		// 
		// tlpProductAmount
		// 
		this.tlpProductAmount.ColumnCount = 1;
		this.tlpProductAmount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductAmount.Controls.Add(this.lblProductAmount, 0, 0);
		this.tlpProductAmount.Controls.Add(this.lblProductAmountError, 0, 2);
		this.tlpProductAmount.Controls.Add(this.nudAvailableAmount, 0, 1);
		this.tlpProductAmount.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductAmount.Location = new System.Drawing.Point(0, 0);
		this.tlpProductAmount.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductAmount.Name = "tlpProductAmount";
		this.tlpProductAmount.RowCount = 3;
		this.tlpProductAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductAmount.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductAmount.Size = new System.Drawing.Size(279, 134);
		this.tlpProductAmount.TabIndex = 0;
		// 
		// lblProductAmount
		// 
		this.lblProductAmount.AutoSize = true;
		this.lblProductAmount.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductAmount.Location = new System.Drawing.Point(3, 0);
		this.lblProductAmount.Name = "lblProductAmount";
		this.lblProductAmount.Size = new System.Drawing.Size(273, 41);
		this.lblProductAmount.TabIndex = 0;
		this.lblProductAmount.Text = "Amount";
		this.lblProductAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// lblProductAmountError
		// 
		this.lblProductAmountError.AutoSize = true;
		this.lblProductAmountError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductAmountError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductAmountError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductAmountError.Location = new System.Drawing.Point(3, 91);
		this.lblProductAmountError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductAmountError.Name = "lblProductAmountError";
		this.lblProductAmountError.Size = new System.Drawing.Size(273, 41);
		this.lblProductAmountError.TabIndex = 2;
		this.lblProductAmountError.Text = "lblProductAmountError";
		this.lblProductAmountError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductAmountError.Visible = false;
		// 
		// nudAvailableAmount
		// 
		this.nudAvailableAmount.Dock = System.Windows.Forms.DockStyle.Fill;
		this.nudAvailableAmount.Location = new System.Drawing.Point(3, 44);
		this.nudAvailableAmount.Maximum = new decimal(new int[] {
			10000,
			0,
			0,
			0});
		this.nudAvailableAmount.Name = "nudAvailableAmount";
		this.nudAvailableAmount.Size = new System.Drawing.Size(273, 33);
		this.nudAvailableAmount.TabIndex = 3;
		// 
		// tlpNameCategory
		// 
		this.tlpNameCategory.ColumnCount = 3;
		this.tlpNameCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
		this.tlpNameCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2F));
		this.tlpNameCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49F));
		this.tlpNameCategory.Controls.Add(this.pnlProductName, 0, 0);
		this.tlpNameCategory.Controls.Add(this.pnlProductCategory, 2, 0);
		this.tlpNameCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpNameCategory.Location = new System.Drawing.Point(8, 33);
		this.tlpNameCategory.Margin = new System.Windows.Forms.Padding(0);
		this.tlpNameCategory.Name = "tlpNameCategory";
		this.tlpNameCategory.RowCount = 1;
		this.tlpNameCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpNameCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpNameCategory.Size = new System.Drawing.Size(568, 165);
		this.tlpNameCategory.TabIndex = 0;
		// 
		// pnlProductName
		// 
		this.pnlProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductName.Controls.Add(this.tlpProductName);
		this.pnlProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlProductName.Location = new System.Drawing.Point(0, 0);
		this.pnlProductName.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductName.Name = "pnlProductName";
		this.pnlProductName.Size = new System.Drawing.Size(278, 165);
		this.pnlProductName.TabIndex = 1;
		// 
		// tlpProductName
		// 
		this.tlpProductName.ColumnCount = 1;
		this.tlpProductName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductName.Controls.Add(this.lblProductName, 0, 0);
		this.tlpProductName.Controls.Add(this.tbProductName, 0, 1);
		this.tlpProductName.Controls.Add(this.lblProductNameError, 0, 2);
		this.tlpProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductName.Location = new System.Drawing.Point(0, 0);
		this.tlpProductName.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductName.Name = "tlpProductName";
		this.tlpProductName.RowCount = 3;
		this.tlpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductName.Size = new System.Drawing.Size(278, 165);
		this.tlpProductName.TabIndex = 0;
		// 
		// lblProductName
		// 
		this.lblProductName.AutoSize = true;
		this.lblProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductName.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductName.Location = new System.Drawing.Point(3, 0);
		this.lblProductName.Name = "lblProductName";
		this.lblProductName.Size = new System.Drawing.Size(272, 51);
		this.lblProductName.TabIndex = 0;
		this.lblProductName.Text = "Name:";
		this.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// tbProductName
		// 
		this.tbProductName.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tbProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
		this.tbProductName.Location = new System.Drawing.Point(3, 56);
		this.tbProductName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
		this.tbProductName.Name = "tbProductName";
		this.tbProductName.PlaceholderText = "Product Name";
		this.tbProductName.Size = new System.Drawing.Size(272, 33);
		this.tbProductName.TabIndex = 1;
		// 
		// lblProductNameError
		// 
		this.lblProductNameError.AutoSize = true;
		this.lblProductNameError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductNameError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductNameError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductNameError.Location = new System.Drawing.Point(3, 112);
		this.lblProductNameError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductNameError.Name = "lblProductNameError";
		this.lblProductNameError.Size = new System.Drawing.Size(272, 51);
		this.lblProductNameError.TabIndex = 2;
		this.lblProductNameError.Text = "lblProductNameError";
		this.lblProductNameError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductNameError.Visible = false;
		// 
		// pnlProductCategory
		// 
		this.pnlProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductCategory.Controls.Add(this.tlpProductCategory);
		this.pnlProductCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlProductCategory.Location = new System.Drawing.Point(289, 0);
		this.pnlProductCategory.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductCategory.Name = "pnlProductCategory";
		this.pnlProductCategory.Size = new System.Drawing.Size(279, 165);
		this.pnlProductCategory.TabIndex = 2;
		// 
		// tlpProductCategory
		// 
		this.tlpProductCategory.ColumnCount = 1;
		this.tlpProductCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductCategory.Controls.Add(this.lblProductCategory, 0, 0);
		this.tlpProductCategory.Controls.Add(this.lblProductCategoryError, 0, 2);
		this.tlpProductCategory.Controls.Add(this.cmbProductCategory, 0, 1);
		this.tlpProductCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductCategory.Location = new System.Drawing.Point(0, 0);
		this.tlpProductCategory.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductCategory.Name = "tlpProductCategory";
		this.tlpProductCategory.RowCount = 3;
		this.tlpProductCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductCategory.Size = new System.Drawing.Size(279, 165);
		this.tlpProductCategory.TabIndex = 0;
		// 
		// lblProductCategory
		// 
		this.lblProductCategory.AutoSize = true;
		this.lblProductCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductCategory.Location = new System.Drawing.Point(3, 0);
		this.lblProductCategory.Name = "lblProductCategory";
		this.lblProductCategory.Size = new System.Drawing.Size(273, 51);
		this.lblProductCategory.TabIndex = 0;
		this.lblProductCategory.Text = "Category:";
		this.lblProductCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// lblProductCategoryError
		// 
		this.lblProductCategoryError.AutoSize = true;
		this.lblProductCategoryError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductCategoryError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductCategoryError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductCategoryError.Location = new System.Drawing.Point(3, 112);
		this.lblProductCategoryError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductCategoryError.Name = "lblProductCategoryError";
		this.lblProductCategoryError.Size = new System.Drawing.Size(273, 51);
		this.lblProductCategoryError.TabIndex = 2;
		this.lblProductCategoryError.Text = "lblProductCategoryError";
		this.lblProductCategoryError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductCategoryError.Visible = false;
		// 
		// cmbProductCategory
		// 
		this.cmbProductCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cmbProductCategory.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.cmbProductCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
		this.cmbProductCategory.FormattingEnabled = true;
		this.cmbProductCategory.Location = new System.Drawing.Point(3, 56);
		this.cmbProductCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
		this.cmbProductCategory.Name = "cmbProductCategory";
		this.cmbProductCategory.Size = new System.Drawing.Size(273, 36);
		this.cmbProductCategory.TabIndex = 3;
		this.cmbProductCategory.SelectedIndexChanged += new System.EventHandler(this.cmbProductCategory_SelectedIndexChanged);
		// 
		// pnlProductSubCategory
		// 
		this.pnlProductSubCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductSubCategory.Controls.Add(this.tlpProductSubCategory);
		this.pnlProductSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.pnlProductSubCategory.Location = new System.Drawing.Point(584, 33);
		this.pnlProductSubCategory.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductSubCategory.Name = "pnlProductSubCategory";
		this.pnlProductSubCategory.Size = new System.Drawing.Size(284, 165);
		this.pnlProductSubCategory.TabIndex = 2;
		// 
		// tlpProductSubCategory
		// 
		this.tlpProductSubCategory.ColumnCount = 1;
		this.tlpProductSubCategory.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductSubCategory.Controls.Add(this.cmbProductSubCategory, 0, 1);
		this.tlpProductSubCategory.Controls.Add(this.lblProductSubCategory, 0, 0);
		this.tlpProductSubCategory.Controls.Add(this.lblProductSubCategoryError, 0, 2);
		this.tlpProductSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductSubCategory.Location = new System.Drawing.Point(0, 0);
		this.tlpProductSubCategory.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductSubCategory.Name = "tlpProductSubCategory";
		this.tlpProductSubCategory.RowCount = 3;
		this.tlpProductSubCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductSubCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductSubCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductSubCategory.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tlpProductSubCategory.Size = new System.Drawing.Size(284, 165);
		this.tlpProductSubCategory.TabIndex = 0;
		// 
		// cmbProductSubCategory
		// 
		this.cmbProductSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cmbProductSubCategory.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.cmbProductSubCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
		this.cmbProductSubCategory.FormattingEnabled = true;
		this.cmbProductSubCategory.Location = new System.Drawing.Point(3, 56);
		this.cmbProductSubCategory.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
		this.cmbProductSubCategory.Name = "cmbProductSubCategory";
		this.cmbProductSubCategory.Size = new System.Drawing.Size(278, 36);
		this.cmbProductSubCategory.TabIndex = 4;
		// 
		// lblProductSubCategory
		// 
		this.lblProductSubCategory.AutoSize = true;
		this.lblProductSubCategory.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductSubCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductSubCategory.Location = new System.Drawing.Point(3, 0);
		this.lblProductSubCategory.Name = "lblProductSubCategory";
		this.lblProductSubCategory.Size = new System.Drawing.Size(278, 51);
		this.lblProductSubCategory.TabIndex = 0;
		this.lblProductSubCategory.Text = "SubCategory";
		this.lblProductSubCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// lblProductSubCategoryError
		// 
		this.lblProductSubCategoryError.AutoSize = true;
		this.lblProductSubCategoryError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductSubCategoryError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductSubCategoryError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductSubCategoryError.Location = new System.Drawing.Point(3, 112);
		this.lblProductSubCategoryError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductSubCategoryError.Name = "lblProductSubCategoryError";
		this.lblProductSubCategoryError.Size = new System.Drawing.Size(278, 51);
		this.lblProductSubCategoryError.TabIndex = 2;
		this.lblProductSubCategoryError.Text = "lblProductSubCategoryError";
		this.lblProductSubCategoryError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductSubCategoryError.Visible = false;
		// 
		// lblProductInfo
		// 
		this.lblProductInfo.AutoSize = true;
		this.lblProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductInfo.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductInfo.Location = new System.Drawing.Point(11, 3);
		this.lblProductInfo.Name = "lblProductInfo";
		this.lblProductInfo.Size = new System.Drawing.Size(562, 30);
		this.lblProductInfo.TabIndex = 0;
		this.lblProductInfo.Text = "Product Info:";
		this.lblProductInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// pnlProductPrice
		// 
		this.pnlProductPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
		this.pnlProductPrice.Controls.Add(this.tlpProductPrice);
		this.pnlProductPrice.Location = new System.Drawing.Point(584, 201);
		this.pnlProductPrice.Margin = new System.Windows.Forms.Padding(0);
		this.pnlProductPrice.Name = "pnlProductPrice";
		this.pnlProductPrice.Size = new System.Drawing.Size(284, 133);
		this.pnlProductPrice.TabIndex = 2;
		// 
		// tlpProductPrice
		// 
		this.tlpProductPrice.ColumnCount = 1;
		this.tlpProductPrice.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tlpProductPrice.Controls.Add(this.lblProductPriceError, 0, 2);
		this.tlpProductPrice.Controls.Add(this.tableLayoutPanel1, 0, 0);
		this.tlpProductPrice.Controls.Add(this.nudProductPrice, 0, 1);
		this.tlpProductPrice.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tlpProductPrice.Location = new System.Drawing.Point(0, 0);
		this.tlpProductPrice.Margin = new System.Windows.Forms.Padding(0);
		this.tlpProductPrice.Name = "tlpProductPrice";
		this.tlpProductPrice.RowCount = 3;
		this.tlpProductPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 31F));
		this.tlpProductPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36F));
		this.tlpProductPrice.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
		this.tlpProductPrice.Size = new System.Drawing.Size(284, 133);
		this.tlpProductPrice.TabIndex = 0;
		// 
		// lblProductPriceError
		// 
		this.lblProductPriceError.AutoSize = true;
		this.lblProductPriceError.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductPriceError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.lblProductPriceError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
		this.lblProductPriceError.Location = new System.Drawing.Point(3, 90);
		this.lblProductPriceError.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
		this.lblProductPriceError.Name = "lblProductPriceError";
		this.lblProductPriceError.Size = new System.Drawing.Size(278, 41);
		this.lblProductPriceError.TabIndex = 2;
		this.lblProductPriceError.Text = "lblProductPriceError";
		this.lblProductPriceError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		this.lblProductPriceError.Visible = false;
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 2;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
		this.tableLayoutPanel1.Controls.Add(this.lblProductPrice, 0, 0);
		this.tableLayoutPanel1.Controls.Add(this.cbxEditPrice, 1, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 1;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(278, 35);
		this.tableLayoutPanel1.TabIndex = 2;
		// 
		// lblProductPrice
		// 
		this.lblProductPrice.AutoSize = true;
		this.lblProductPrice.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lblProductPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
		this.lblProductPrice.Location = new System.Drawing.Point(3, 0);
		this.lblProductPrice.Name = "lblProductPrice";
		this.lblProductPrice.Size = new System.Drawing.Size(77, 35);
		this.lblProductPrice.TabIndex = 0;
		this.lblProductPrice.Text = "Price(€)";
		this.lblProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
		// 
		// cbxEditPrice
		// 
		this.cbxEditPrice.AutoSize = true;
		this.cbxEditPrice.Dock = System.Windows.Forms.DockStyle.Fill;
		this.cbxEditPrice.Location = new System.Drawing.Point(86, 3);
		this.cbxEditPrice.Name = "cbxEditPrice";
		this.cbxEditPrice.Size = new System.Drawing.Size(189, 29);
		this.cbxEditPrice.TabIndex = 1;
		this.cbxEditPrice.Text = "Edit Price";
		this.cbxEditPrice.UseVisualStyleBackColor = true;
		this.cbxEditPrice.CheckedChanged += new System.EventHandler(this.cbxEditPrice_CheckedChanged);
		// 
		// nudProductPrice
		// 
		this.nudProductPrice.DecimalPlaces = 2;
		this.nudProductPrice.Dock = System.Windows.Forms.DockStyle.Fill;
		this.nudProductPrice.Increment = new decimal(new int[] {
			25,
			0,
			0,
			131072});
		this.nudProductPrice.Location = new System.Drawing.Point(3, 44);
		this.nudProductPrice.Maximum = new decimal(new int[] {
			1000,
			0,
			0,
			0});
		this.nudProductPrice.Name = "nudProductPrice";
		this.nudProductPrice.Size = new System.Drawing.Size(278, 33);
		this.nudProductPrice.TabIndex = 3;
		// 
		// AddProductPopUp
		// 
		this.AcceptButton = this.btnOk;
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		this.AutoScroll = true;
		this.AutoSize = true;
		this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
		this.CancelButton = this.btnCancel;
		this.ClientSize = new System.Drawing.Size(886, 450);
		this.Controls.Add(this.tlpBackground);
		this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
		this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		this.Margin = new System.Windows.Forms.Padding(5);
		this.MinimumSize = new System.Drawing.Size(886, 450);
		this.Name = "AddProductPopUp";
		this.Padding = new System.Windows.Forms.Padding(3);
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "AddProductPopUp";
		this.Load += new System.EventHandler(this.AddProductPopUp_Load);
		this.tlpBackground.ResumeLayout(false);
		this.tlpBackground.PerformLayout();
		this.tlpButtonsBackground.ResumeLayout(false);
		this.tlpProductInfo.ResumeLayout(false);
		this.tlpProductInfo.PerformLayout();
		this.tlpQuantityAmount.ResumeLayout(false);
		this.pnlProductQuantity.ResumeLayout(false);
		this.tlpProductQuantity.ResumeLayout(false);
		this.tlpProductQuantity.PerformLayout();
		this.tlpProductQuantityInput.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.nudProductQuantity)).EndInit();
		this.tableLayoutPanel2.ResumeLayout(false);
		this.tableLayoutPanel2.PerformLayout();
		this.pnlProductAmount.ResumeLayout(false);
		this.tlpProductAmount.ResumeLayout(false);
		this.tlpProductAmount.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.nudAvailableAmount)).EndInit();
		this.tlpNameCategory.ResumeLayout(false);
		this.pnlProductName.ResumeLayout(false);
		this.tlpProductName.ResumeLayout(false);
		this.tlpProductName.PerformLayout();
		this.pnlProductCategory.ResumeLayout(false);
		this.tlpProductCategory.ResumeLayout(false);
		this.tlpProductCategory.PerformLayout();
		this.pnlProductSubCategory.ResumeLayout(false);
		this.tlpProductSubCategory.ResumeLayout(false);
		this.tlpProductSubCategory.PerformLayout();
		this.pnlProductPrice.ResumeLayout(false);
		this.tlpProductPrice.ResumeLayout(false);
		this.tlpProductPrice.PerformLayout();
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		((System.ComponentModel.ISupportInitialize)(this.nudProductPrice)).EndInit();
		this.ResumeLayout(false);
		this.PerformLayout();

	}

	#endregion

	private TableLayoutPanel tlpBackground;
	private TableLayoutPanel tlpButtonsBackground;
	private Button btnCancel;
	private Button btnOk;
	private Label lblProductInfo;
	private Panel pnlProductName;
	private TableLayoutPanel tlpProductName;
	private Label lblProductName;
	private TextBox tbProductName;
	private Label lblProductNameError;
	private Panel pnlProductPrice;
	private TableLayoutPanel tlpProductPrice;
	private Label lblProductPrice;
	private Label lblProductPriceError;
	private Panel pnlProductCategory;
	private TableLayoutPanel tlpProductCategory;
	private Label lblProductCategory;
	private Label lblProductCategoryError;
	private TableLayoutPanel tlpProductInfo;
	private TableLayoutPanel tlpNameCategory;
	private ComboBox cmbProductCategory;
	private TableLayoutPanel tlpQuantityAmount;
	private Panel pnlProductAmount;
	private TableLayoutPanel tlpProductAmount;
	private Label lblProductAmount;
	private Label lblProductAmountError;
	private Panel pnlProductSubCategory;
	private TableLayoutPanel tlpProductSubCategory;
	private ComboBox cmbProductSubCategory;
	private Label lblProductSubCategory;
	private Label lblProductSubCategoryError;
	private Panel pnlProductQuantity;
	private TableLayoutPanel tlpProductQuantity;
	private Label lblProductQuantityError;
	private Label lblProductQuantity;
	private TableLayoutPanel tlpProductQuantityInput;
	private ComboBox cmbUnit;
	private TableLayoutPanel tableLayoutPanel1;
	private CheckBox cbxEditPrice;
	private TableLayoutPanel tableLayoutPanel2;
	private CheckBox cbxEditQuantity;
	private NumericUpDown nudProductPrice;
	private NumericUpDown nudProductQuantity;
	private NumericUpDown nudAvailableAmount;
}