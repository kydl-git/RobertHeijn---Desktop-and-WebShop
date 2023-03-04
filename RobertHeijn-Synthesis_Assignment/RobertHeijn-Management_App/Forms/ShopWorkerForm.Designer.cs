using RobertHeijn_Management_App.Controls;

namespace RobertHeijn_Management_App.Forms
{
    partial class ShopWorkerForm
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
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.tlpTopNav = new System.Windows.Forms.TableLayoutPanel();
            this.tlpRobertHeijn = new System.Windows.Forms.TableLayoutPanel();
            this.lblRoleTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tlpAvatar = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAvatar = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tlpSideMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnStockManagement = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.tbcStockManagement = new RobertHeijn_Management_App.Controls.TabControlWithoutHeader();
            this.tabStockManagement = new System.Windows.Forms.TabPage();
            this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLowerBackground = new System.Windows.Forms.TableLayoutPanel();
            this.btnViewOrders = new System.Windows.Forms.Button();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.tlpTopNav.SuspendLayout();
            this.tlpRobertHeijn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tlpAvatar.SuspendLayout();
            this.tlpSideMenu.SuspendLayout();
            this.tbcStockManagement.SuspendLayout();
            this.tlpBackground.SuspendLayout();
            this.tlpLowerBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogo.BackgroundImage = global::RobertHeijn_Management_App.Properties.Resources.logo_100;
            this.pnlLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogo.Location = new System.Drawing.Point(3, 3);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(216, 170);
            this.pnlLogo.TabIndex = 0;
            // 
            // tlpTopNav
            // 
            this.tlpTopNav.ColumnCount = 3;
            this.tlpTopNav.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpTopNav.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpTopNav.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpTopNav.Controls.Add(this.pnlLogo, 0, 0);
            this.tlpTopNav.Controls.Add(this.tlpRobertHeijn, 1, 0);
            this.tlpTopNav.Controls.Add(this.tlpAvatar, 2, 0);
            this.tlpTopNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopNav.Location = new System.Drawing.Point(0, 0);
            this.tlpTopNav.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopNav.Name = "tlpTopNav";
            this.tlpTopNav.RowCount = 1;
            this.tlpTopNav.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopNav.Size = new System.Drawing.Size(1484, 176);
            this.tlpTopNav.TabIndex = 1;
            // 
            // tlpRobertHeijn
            // 
            this.tlpRobertHeijn.ColumnCount = 1;
            this.tlpRobertHeijn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRobertHeijn.Controls.Add(this.lblRoleTitle, 0, 1);
            this.tlpRobertHeijn.Controls.Add(this.pictureBox1, 0, 0);
            this.tlpRobertHeijn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRobertHeijn.Location = new System.Drawing.Point(225, 3);
            this.tlpRobertHeijn.Name = "tlpRobertHeijn";
            this.tlpRobertHeijn.RowCount = 2;
            this.tlpRobertHeijn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpRobertHeijn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpRobertHeijn.Size = new System.Drawing.Size(958, 170);
            this.tlpRobertHeijn.TabIndex = 0;
            // 
            // lblRoleTitle
            // 
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRoleTitle.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoleTitle.Location = new System.Drawing.Point(3, 136);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Size = new System.Drawing.Size(952, 34);
            this.lblRoleTitle.TabIndex = 3;
            this.lblRoleTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::RobertHeijn_Management_App.Properties.Resources.RobertHeijn3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(958, 136);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // tlpAvatar
            // 
            this.tlpAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tlpAvatar.ColumnCount = 1;
            this.tlpAvatar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAvatar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpAvatar.Controls.Add(this.pnlAvatar, 0, 0);
            this.tlpAvatar.Controls.Add(this.lblWelcome, 0, 1);
            this.tlpAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAvatar.Location = new System.Drawing.Point(1186, 0);
            this.tlpAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.tlpAvatar.Name = "tlpAvatar";
            this.tlpAvatar.RowCount = 2;
            this.tlpAvatar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpAvatar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpAvatar.Size = new System.Drawing.Size(298, 176);
            this.tlpAvatar.TabIndex = 1;
            // 
            // pnlAvatar
            // 
            this.pnlAvatar.BackgroundImage = global::RobertHeijn_Management_App.Properties.Resources.user_avatar;
            this.pnlAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvatar.Location = new System.Drawing.Point(0, 0);
            this.pnlAvatar.Margin = new System.Windows.Forms.Padding(0);
            this.pnlAvatar.Name = "pnlAvatar";
            this.pnlAvatar.Size = new System.Drawing.Size(298, 123);
            this.pnlAvatar.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Location = new System.Drawing.Point(3, 123);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(292, 53);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpSideMenu
            // 
            this.tlpSideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.tlpSideMenu.ColumnCount = 1;
            this.tlpSideMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSideMenu.Controls.Add(this.btnStockManagement, 0, 0);
            this.tlpSideMenu.Controls.Add(this.btnAddProduct, 0, 2);
            this.tlpSideMenu.Controls.Add(this.btnViewOrders, 0, 4);
            this.tlpSideMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSideMenu.Location = new System.Drawing.Point(0, 0);
            this.tlpSideMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tlpSideMenu.Name = "tlpSideMenu";
            this.tlpSideMenu.RowCount = 8;
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpSideMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpSideMenu.Size = new System.Drawing.Size(148, 705);
            this.tlpSideMenu.TabIndex = 2;
            // 
            // btnStockManagement
            // 
            this.btnStockManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnStockManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStockManagement.FlatAppearance.BorderSize = 0;
            this.btnStockManagement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnStockManagement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnStockManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockManagement.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStockManagement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnStockManagement.Location = new System.Drawing.Point(0, 0);
            this.btnStockManagement.Margin = new System.Windows.Forms.Padding(0);
            this.btnStockManagement.Name = "btnStockManagement";
            this.btnStockManagement.Size = new System.Drawing.Size(148, 105);
            this.btnStockManagement.TabIndex = 4;
            this.btnStockManagement.Text = "Stock Management";
            this.btnStockManagement.UseVisualStyleBackColor = false;
            this.btnStockManagement.Click += new System.EventHandler(this.btnStockManagement_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnAddProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddProduct.Location = new System.Drawing.Point(0, 175);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(148, 105);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "Add a new product";
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.BtnAddProduct_Click);
            // 
            // tbcStockManagement
            // 
            this.tbcStockManagement.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tbcStockManagement.Controls.Add(this.tabStockManagement);
            this.tbcStockManagement.Controls.Add(this.tabOrders);
            this.tbcStockManagement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcStockManagement.ItemSize = new System.Drawing.Size(0, 1);
            this.tbcStockManagement.Location = new System.Drawing.Point(148, 0);
            this.tbcStockManagement.Margin = new System.Windows.Forms.Padding(0);
            this.tbcStockManagement.Multiline = true;
            this.tbcStockManagement.Name = "tbcStockManagement";
            this.tbcStockManagement.SelectedIndex = 0;
            this.tbcStockManagement.Size = new System.Drawing.Size(1336, 705);
            this.tbcStockManagement.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbcStockManagement.TabIndex = 3;
            this.tbcStockManagement.TabStop = false;
            // 
            // tabStockManagement
            // 
            this.tabStockManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.tabStockManagement.Location = new System.Drawing.Point(4, 5);
            this.tabStockManagement.Name = "tabStockManagement";
            this.tabStockManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tabStockManagement.Size = new System.Drawing.Size(1328, 696);
            this.tabStockManagement.TabIndex = 0;
            this.tabStockManagement.Text = "tabStockManagement";
            // 
            // tlpBackground
            // 
            this.tlpBackground.AutoScroll = true;
            this.tlpBackground.BackColor = System.Drawing.Color.Transparent;
            this.tlpBackground.CausesValidation = false;
            this.tlpBackground.ColumnCount = 1;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBackground.Controls.Add(this.tlpLowerBackground, 0, 1);
            this.tlpBackground.Controls.Add(this.tlpTopNav, 0, 0);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(0, 0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 2;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tlpBackground.Size = new System.Drawing.Size(1484, 881);
            this.tlpBackground.TabIndex = 1;
            // 
            // tlpLowerBackground
            // 
            this.tlpLowerBackground.ColumnCount = 2;
            this.tlpLowerBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpLowerBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tlpLowerBackground.Controls.Add(this.tbcStockManagement, 1, 0);
            this.tlpLowerBackground.Controls.Add(this.tlpSideMenu, 0, 0);
            this.tlpLowerBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLowerBackground.Location = new System.Drawing.Point(0, 176);
            this.tlpLowerBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tlpLowerBackground.Name = "tlpLowerBackground";
            this.tlpLowerBackground.RowCount = 1;
            this.tlpLowerBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLowerBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLowerBackground.Size = new System.Drawing.Size(1484, 705);
            this.tlpLowerBackground.TabIndex = 0;
            // 
            // btnViewOrders
            // 
            this.btnViewOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnViewOrders.FlatAppearance.BorderSize = 0;
            this.btnViewOrders.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnViewOrders.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnViewOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrders.Font = new System.Drawing.Font("Myanmar Text", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnViewOrders.Location = new System.Drawing.Point(0, 350);
            this.btnViewOrders.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewOrders.Name = "btnViewOrders";
            this.btnViewOrders.Size = new System.Drawing.Size(148, 105);
            this.btnViewOrders.TabIndex = 6;
            this.btnViewOrders.Text = "View Orders";
            this.btnViewOrders.UseVisualStyleBackColor = false;
            this.btnViewOrders.Click += new System.EventHandler(this.btnViewOrders_Click);
            // 
            // tabOrders
            // 
            this.tabOrders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(215)))), ((int)(((byte)(219)))));
            this.tabOrders.Location = new System.Drawing.Point(4, 5);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Size = new System.Drawing.Size(1328, 696);
            this.tabOrders.TabIndex = 1;
            this.tabOrders.Text = "tabOrders";
            // 
            // ShopWorkerForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1484, 881);
            this.Controls.Add(this.tlpBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(1500, 920);
            this.Name = "ShopWorkerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shop Worker Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShopWorkerForm_FormClosing);
            this.Load += new System.EventHandler(this.ShopWorkerForm_Load);
            this.tlpTopNav.ResumeLayout(false);
            this.tlpRobertHeijn.ResumeLayout(false);
            this.tlpRobertHeijn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tlpAvatar.ResumeLayout(false);
            this.tlpAvatar.PerformLayout();
            this.tlpSideMenu.ResumeLayout(false);
            this.tbcStockManagement.ResumeLayout(false);
            this.tlpBackground.ResumeLayout(false);
            this.tlpLowerBackground.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private Panel pnlLogo;
        private TableLayoutPanel tlpTopNav;
        private TableLayoutPanel tlpRobertHeijn;
        private TableLayoutPanel tlpAvatar;
        private Panel pnlAvatar;
        private Label lblWelcome;
        private TableLayoutPanel tlpSideMenu;
        private Button btnStockManagement;
        private TabControlWithoutHeader tbcStockManagement;
        private TabPage tabStockManagement;
        private TableLayoutPanel tlpBackground;
        private TableLayoutPanel tlpLowerBackground;
        private Label lblRoleTitle;
        private Button btnAddProduct;
        private PictureBox pictureBox1;
		private Button btnViewOrders;
		private TabPage tabOrders;
	}
}