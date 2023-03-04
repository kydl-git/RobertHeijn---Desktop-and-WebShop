namespace RobertHeijn_Management_App.Controls.ShopUserControls;

partial class OrderManagementUc
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

	#region Component Designer generated code

	/// <summary> 
	/// Required method for Designer support - do not modify 
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBottomButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnEditOrderStatus = new System.Windows.Forms.Button();
            this.dgvOrdersList = new System.Windows.Forms.DataGridView();
            this.tlpBackground.SuspendLayout();
            this.tlpBottomButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpBackground
            // 
            this.tlpBackground.BackColor = System.Drawing.Color.Transparent;
            this.tlpBackground.ColumnCount = 2;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpBackground.Controls.Add(this.tlpBottomButtons, 1, 0);
            this.tlpBackground.Controls.Add(this.dgvOrdersList, 0, 0);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(0, 0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 1;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBackground.Size = new System.Drawing.Size(1234, 572);
            this.tlpBackground.TabIndex = 0;
            // 
            // tlpBottomButtons
            // 
            this.tlpBottomButtons.ColumnCount = 1;
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottomButtons.Controls.Add(this.btnEditOrderStatus, 0, 1);
            this.tlpBottomButtons.Location = new System.Drawing.Point(962, 3);
            this.tlpBottomButtons.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpBottomButtons.Name = "tlpBottomButtons";
            this.tlpBottomButtons.RowCount = 3;
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tlpBottomButtons.Size = new System.Drawing.Size(272, 262);
            this.tlpBottomButtons.TabIndex = 0;
            // 
            // btnEditOrderStatus
            // 
            this.btnEditOrderStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnEditOrderStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditOrderStatus.FlatAppearance.BorderSize = 0;
            this.btnEditOrderStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnEditOrderStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnEditOrderStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditOrderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEditOrderStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.btnEditOrderStatus.Location = new System.Drawing.Point(0, 5);
            this.btnEditOrderStatus.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditOrderStatus.Name = "btnEditOrderStatus";
            this.btnEditOrderStatus.Size = new System.Drawing.Size(272, 52);
            this.btnEditOrderStatus.TabIndex = 8;
            this.btnEditOrderStatus.Text = "Edit Order Status";
            this.btnEditOrderStatus.UseVisualStyleBackColor = false;
            this.btnEditOrderStatus.Click += new System.EventHandler(this.BtnEditOrderStatus_Click);
            // 
            // dgvProductsList
            // 
            this.dgvOrdersList.AllowUserToAddRows = false;
            this.dgvOrdersList.AllowUserToDeleteRows = false;
            this.dgvOrdersList.AllowUserToResizeRows = false;
            this.dgvOrdersList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrdersList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOrdersList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.dgvOrdersList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOrdersList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(222)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdersList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvOrdersList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdersList.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvOrdersList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvOrdersList.EnableHeadersVisualStyles = false;
            this.dgvOrdersList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.dgvOrdersList.Location = new System.Drawing.Point(3, 3);
            this.dgvOrdersList.Name = "dgvOrdersList";
            this.dgvOrdersList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvOrdersList.RowHeadersVisible = false;
            this.dgvOrdersList.RowHeadersWidth = 62;
            this.dgvOrdersList.RowTemplate.Height = 25;
            this.dgvOrdersList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrdersList.Size = new System.Drawing.Size(956, 508);
            this.dgvOrdersList.TabIndex = 4;
            this.dgvOrdersList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvOrdersList_CellClick);
            this.dgvOrdersList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvOrdersList_DataBindingComplete);
            // 
            // OrderManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.CausesValidation = false;
            this.Controls.Add(this.tlpBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.MinimumSize = new System.Drawing.Size(1234, 572);
            this.Name = "OrderManagementUc";
            this.Size = new System.Drawing.Size(1234, 572);
            this.tlpBackground.ResumeLayout(false);
            this.tlpBottomButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdersList)).EndInit();
            this.ResumeLayout(false);

	}

	#endregion

	private TableLayoutPanel tlpBackground;
	private TableLayoutPanel tlpBottomButtons;
	private Button btnEditOrderStatus;
	private DataGridView dgvOrdersList;
}
