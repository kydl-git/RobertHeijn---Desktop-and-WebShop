namespace RobertHeijn_Management_App.Forms.Popups;

partial class ChangeOrderStatus
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
            this.tlpButtonBackground = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.tlpStatus = new System.Windows.Forms.TableLayoutPanel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.tlpOrderDetails = new System.Windows.Forms.TableLayoutPanel();
            this.lblOrderId = new System.Windows.Forms.Label();
            this.lbChangeOrderStatusForm = new System.Windows.Forms.Label();
            this.lblOrderIdValue = new System.Windows.Forms.Label();
            this.lblCustomerNameValue = new System.Windows.Forms.Label();
            this.tlpBackground.SuspendLayout();
            this.tlpButtonBackground.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            this.tlpStatus.SuspendLayout();
            this.tlpOrderDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBackground
            // 
            this.tlpBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            this.tlpBackground.ColumnCount = 1;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBackground.Controls.Add(this.tlpButtonBackground, 0, 2);
            this.tlpBackground.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpBackground.Controls.Add(this.lbChangeOrderStatusForm, 0, 0);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(1, 1);
            this.tlpBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 3;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpBackground.Size = new System.Drawing.Size(281, 367);
            this.tlpBackground.TabIndex = 0;
            // 
            // tlpButtonBackground
            // 
            this.tlpButtonBackground.ColumnCount = 5;
            this.tlpButtonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpButtonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tlpButtonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpButtonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41F));
            this.tlpButtonBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tlpButtonBackground.Controls.Add(this.btnConfirm, 1, 0);
            this.tlpButtonBackground.Controls.Add(this.btnCancel, 3, 0);
            this.tlpButtonBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtonBackground.Location = new System.Drawing.Point(0, 329);
            this.tlpButtonBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtonBackground.Name = "tlpButtonBackground";
            this.tlpButtonBackground.RowCount = 1;
            this.tlpButtonBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpButtonBackground.Size = new System.Drawing.Size(281, 38);
            this.tlpButtonBackground.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.Location = new System.Drawing.Point(16, 0);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(115, 38);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(147, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 38);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 1;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Controls.Add(this.tlpStatus, 0, 1);
            this.tlpCenter.Controls.Add(this.tlpOrderDetails, 0, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(0, 36);
            this.tlpCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 3;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpCenter.Size = new System.Drawing.Size(281, 293);
            this.tlpCenter.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerName.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerName.Location = new System.Drawing.Point(3, 0);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(275, 40);
            this.lblCustomerName.TabIndex = 0;
            this.lblCustomerName.Text = "Customer Name:";
            this.lblCustomerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCustomerNameValue
            // 
            this.lblCustomerNameValue.AutoSize = true;
            this.lblCustomerNameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCustomerNameValue.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCustomerNameValue.Location = new System.Drawing.Point(3, 0);
            this.lblCustomerNameValue.Name = "lblCustomerNameValue";
            this.lblCustomerNameValue.Size = new System.Drawing.Size(275, 40);
            this.lblCustomerNameValue.TabIndex = 0;
            this.lblCustomerNameValue.Text = "";
            this.lblCustomerNameValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpStatus
            // 
            this.tlpStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.tlpStatus.ColumnCount = 1;
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStatus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpStatus.Controls.Add(this.lblStatus, 0, 0);
            this.tlpStatus.Controls.Add(this.cmbStatus, 0, 1);
            this.tlpStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpStatus.Location = new System.Drawing.Point(0, 204);
            this.tlpStatus.Margin = new System.Windows.Forms.Padding(0);
            this.tlpStatus.Name = "tlpStatus";
            this.tlpStatus.RowCount = 2;
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpStatus.Size = new System.Drawing.Size(281, 89);
            this.tlpStatus.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(3, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(275, 44);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Order Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(70)))));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(3, 47);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(275, 33);
            this.cmbStatus.TabIndex = 1;
            // 
            // tlpOrderDetails
            // 
            this.tlpOrderDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.tlpOrderDetails.ColumnCount = 1;
            this.tlpOrderDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOrderDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpOrderDetails.Controls.Add(this.lblOrderId, 0, 0);
            this.tlpOrderDetails.Controls.Add(this.lblOrderIdValue, 0, 1);
            this.tlpOrderDetails.Controls.Add(this.lblCustomerName, 0, 2);
            this.tlpOrderDetails.Controls.Add(this.lblCustomerNameValue, 0, 3);
            this.tlpOrderDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOrderDetails.Location = new System.Drawing.Point(0, 0);
            this.tlpOrderDetails.Margin = new System.Windows.Forms.Padding(0);
            this.tlpOrderDetails.Name = "tlpOrderDetails";
            this.tlpOrderDetails.RowCount = 2;
            this.tlpOrderDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOrderDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOrderDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOrderDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpOrderDetails.Size = new System.Drawing.Size(281, 87);
            this.tlpOrderDetails.TabIndex = 0;
            // 
            // lblOrderId
            // 
            this.lblOrderId.AutoSize = true;
            this.lblOrderId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderId.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderId.Location = new System.Drawing.Point(3, 0);
            this.lblOrderId.Name = "lblOrderId";
            this.lblOrderId.Size = new System.Drawing.Size(275, 43);
            this.lblOrderId.TabIndex = 0;
            this.lblOrderId.Text = "Order ID:";
            this.lblOrderId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderIdValue
            // 
            this.lblOrderIdValue.AutoSize = true;
            this.lblOrderIdValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOrderIdValue.Font = new System.Drawing.Font("Rockwell", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrderIdValue.Location = new System.Drawing.Point(3, 0);
            this.lblOrderIdValue.Name = "lblOrderIdValue";
            this.lblOrderIdValue.Size = new System.Drawing.Size(275, 43);
            this.lblOrderIdValue.TabIndex = 0;
            this.lblOrderIdValue.Text = "";
            this.lblOrderIdValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbChangeOrderStatusForm
            // 
            this.lbChangeOrderStatusForm.AutoSize = true;
            this.lbChangeOrderStatusForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            this.lbChangeOrderStatusForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbChangeOrderStatusForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbChangeOrderStatusForm.Location = new System.Drawing.Point(3, 0);
            this.lbChangeOrderStatusForm.Name = "lbChangeOrderStatusForm";
            this.lbChangeOrderStatusForm.Size = new System.Drawing.Size(275, 36);
            this.lbChangeOrderStatusForm.TabIndex = 2;
            this.lbChangeOrderStatusForm.Text = "Change Order Status";
            this.lbChangeOrderStatusForm.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ChangeOrderStatus
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.CancelButton = this.btnCancel;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(283, 369);
            this.Controls.Add(this.tlpBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ChangeOrderStatus";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ChangeOrderStatus";
            this.tlpBackground.ResumeLayout(false);
            this.tlpBackground.PerformLayout();
            this.tlpButtonBackground.ResumeLayout(false);
            this.tlpCenter.ResumeLayout(false);
            this.tlpStatus.ResumeLayout(false);
            this.tlpStatus.PerformLayout();
            this.tlpOrderDetails.ResumeLayout(false);
            this.tlpOrderDetails.PerformLayout();
            this.ResumeLayout(false);

	}

	#endregion

	private TableLayoutPanel tlpBackground;
	private TableLayoutPanel tlpButtonBackground;
	private Button btnConfirm;
	private Button btnCancel;
	private TableLayoutPanel tlpCenter;
	private TableLayoutPanel tlpOrderDetails;
	private TableLayoutPanel tlpStatus;
	private Label lblOrderId;
	private Label lblStatus;
	private Label lbChangeOrderStatusForm;
	private ComboBox cmbStatus;
	private Label lblCustomerName;
	private Label lblOrderIdValue;
	private Label lblCustomerNameValue;
}