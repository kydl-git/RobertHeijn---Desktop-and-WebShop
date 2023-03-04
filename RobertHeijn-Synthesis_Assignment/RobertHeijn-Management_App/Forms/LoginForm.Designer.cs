using System.ComponentModel;

namespace RobertHeijn_Management_App.Forms;

partial class LoginForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.tlpBackground = new System.Windows.Forms.TableLayoutPanel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.tlpLoginButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCenterLogin = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tlpEmail = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmailError = new System.Windows.Forms.Label();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tlpPassword = new System.Windows.Forms.TableLayoutPanel();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.tlpLoginBtn = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tlpGrp = new System.Windows.Forms.TableLayoutPanel();
            this.grpDevelopment = new System.Windows.Forms.GroupBox();
            this.btnFillValues = new System.Windows.Forms.Button();
            this.tlpBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.tlpCenter.SuspendLayout();
            this.tlpLoginButtons.SuspendLayout();
            this.tlpCenterLogin.SuspendLayout();
            this.tlpEmail.SuspendLayout();
            this.tlpPassword.SuspendLayout();
            this.tlpLoginBtn.SuspendLayout();
            this.tlpGrp.SuspendLayout();
            this.grpDevelopment.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBackground
            // 
            this.tlpBackground.ColumnCount = 1;
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBackground.Controls.Add(this.pbxLogo, 0, 0);
            this.tlpBackground.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBackground.Location = new System.Drawing.Point(0, 0);
            this.tlpBackground.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBackground.Name = "tlpBackground";
            this.tlpBackground.RowCount = 2;
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpBackground.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpBackground.Size = new System.Drawing.Size(1500, 858);
            this.tlpBackground.TabIndex = 0;
            // 
            // pbxLogo
            // 
            this.pbxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxLogo.Image = global::RobertHeijn_Management_App.Properties.Resources.main_banner;
            this.pbxLogo.Location = new System.Drawing.Point(0, 0);
            this.pbxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(1500, 257);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 5;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.09091F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.81818F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.181818F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.727273F));
            this.tlpCenter.Controls.Add(this.tlpLoginButtons, 1, 1);
            this.tlpCenter.Controls.Add(this.tlpGrp, 3, 1);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(3, 260);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 3;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpCenter.Size = new System.Drawing.Size(1494, 595);
            this.tlpCenter.TabIndex = 3;
            // 
            // tlpLoginButtons
            // 
            this.tlpLoginButtons.ColumnCount = 1;
            this.tlpLoginButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoginButtons.Controls.Add(this.tlpCenterLogin, 0, 1);
            this.tlpLoginButtons.Controls.Add(this.tlpLoginBtn, 0, 2);
            this.tlpLoginButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoginButtons.Location = new System.Drawing.Point(437, 122);
            this.tlpLoginButtons.Name = "tlpLoginButtons";
            this.tlpLoginButtons.RowCount = 4;
            this.tlpLoginButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLoginButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLoginButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpLoginButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpLoginButtons.Size = new System.Drawing.Size(618, 410);
            this.tlpLoginButtons.TabIndex = 1;
            // 
            // tlpCenterLogin
            // 
            this.tlpCenterLogin.ColumnCount = 2;
            this.tlpCenterLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCenterLogin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpCenterLogin.Controls.Add(this.lblEmail, 0, 0);
            this.tlpCenterLogin.Controls.Add(this.lblPassword, 0, 1);
            this.tlpCenterLogin.Controls.Add(this.tlpEmail, 1, 0);
            this.tlpCenterLogin.Controls.Add(this.tlpPassword, 1, 1);
            this.tlpCenterLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenterLogin.Location = new System.Drawing.Point(3, 85);
            this.tlpCenterLogin.Name = "tlpCenterLogin";
            this.tlpCenterLogin.RowCount = 2;
            this.tlpCenterLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenterLogin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenterLogin.Size = new System.Drawing.Size(612, 178);
            this.tlpCenterLogin.TabIndex = 0;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.Location = new System.Drawing.Point(5, 5);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(173, 79);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(5, 94);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(5);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(173, 79);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpEmail
            // 
            this.tlpEmail.ColumnCount = 1;
            this.tlpEmail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpEmail.Controls.Add(this.lblEmailError, 0, 2);
            this.tlpEmail.Controls.Add(this.tbxEmail, 0, 1);
            this.tlpEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpEmail.Location = new System.Drawing.Point(186, 3);
            this.tlpEmail.Name = "tlpEmail";
            this.tlpEmail.RowCount = 3;
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpEmail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpEmail.Size = new System.Drawing.Size(423, 83);
            this.tlpEmail.TabIndex = 0;
            // 
            // lblEmailError
            // 
            this.lblEmailError.AutoSize = true;
            this.lblEmailError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmailError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmailError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
            this.lblEmailError.Location = new System.Drawing.Point(5, 60);
            this.lblEmailError.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblEmailError.Name = "lblEmailError";
            this.lblEmailError.Size = new System.Drawing.Size(418, 23);
            this.lblEmailError.TabIndex = 1;
            this.lblEmailError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmailError.Visible = false;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEmail.Location = new System.Drawing.Point(3, 25);
            this.tbxEmail.MaxLength = 50;
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.PlaceholderText = "Enter email";
            this.tbxEmail.Size = new System.Drawing.Size(417, 33);
            this.tbxEmail.TabIndex = 0;
            // 
            // tlpPassword
            // 
            this.tlpPassword.ColumnCount = 1;
            this.tlpPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPassword.Controls.Add(this.lblPasswordError, 0, 2);
            this.tlpPassword.Controls.Add(this.tbxPassword, 0, 1);
            this.tlpPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPassword.Location = new System.Drawing.Point(186, 92);
            this.tlpPassword.Name = "tlpPassword";
            this.tlpPassword.RowCount = 3;
            this.tlpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tlpPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tlpPassword.Size = new System.Drawing.Size(423, 83);
            this.tlpPassword.TabIndex = 1;
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPasswordError.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPasswordError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(14)))), ((int)(((byte)(17)))));
            this.lblPasswordError.Location = new System.Drawing.Point(5, 60);
            this.lblPasswordError.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.Size = new System.Drawing.Size(418, 23);
            this.lblPasswordError.TabIndex = 4;
            this.lblPasswordError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPasswordError.Visible = false;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPassword.Location = new System.Drawing.Point(3, 25);
            this.tbxPassword.MaxLength = 50;
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '*';
            this.tbxPassword.PlaceholderText = "Enter password";
            this.tbxPassword.Size = new System.Drawing.Size(417, 33);
            this.tbxPassword.TabIndex = 1;
            // 
            // tlpLoginBtn
            // 
            this.tlpLoginBtn.ColumnCount = 3;
            this.tlpLoginBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLoginBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpLoginBtn.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpLoginBtn.Controls.Add(this.btnLogin, 1, 0);
            this.tlpLoginBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLoginBtn.Location = new System.Drawing.Point(3, 269);
            this.tlpLoginBtn.Name = "tlpLoginBtn";
            this.tlpLoginBtn.RowCount = 1;
            this.tlpLoginBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLoginBtn.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLoginBtn.Size = new System.Drawing.Size(612, 55);
            this.tlpLoginBtn.TabIndex = 2;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnLogin.Location = new System.Drawing.Point(186, 3);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(238, 49);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // tlpGrp
            // 
            this.tlpGrp.ColumnCount = 1;
            this.tlpGrp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrp.Controls.Add(this.grpDevelopment, 0, 1);
            this.tlpGrp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGrp.Location = new System.Drawing.Point(1183, 122);
            this.tlpGrp.Name = "tlpGrp";
            this.tlpGrp.RowCount = 3;
            this.tlpGrp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpGrp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpGrp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpGrp.Size = new System.Drawing.Size(265, 410);
            this.tlpGrp.TabIndex = 3;
            // 
            // grpDevelopment
            // 
            this.grpDevelopment.Controls.Add(this.btnFillValues);
            this.grpDevelopment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDevelopment.Location = new System.Drawing.Point(3, 167);
            this.grpDevelopment.Name = "grpDevelopment";
            this.grpDevelopment.Size = new System.Drawing.Size(259, 76);
            this.grpDevelopment.TabIndex = 3;
            this.grpDevelopment.TabStop = false;
            this.grpDevelopment.Text = "Only For Development";
            // 
            // btnFillValues
            // 
            this.btnFillValues.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(216)))), ((int)(((byte)(255)))));
            this.btnFillValues.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFillValues.FlatAppearance.BorderSize = 0;
            this.btnFillValues.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(118)))), ((int)(((byte)(122)))));
            this.btnFillValues.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(188)))), ((int)(((byte)(213)))));
            this.btnFillValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFillValues.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFillValues.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.btnFillValues.Location = new System.Drawing.Point(3, 29);
            this.btnFillValues.Name = "btnFillValues";
            this.btnFillValues.Size = new System.Drawing.Size(253, 44);
            this.btnFillValues.TabIndex = 3;
            this.btnFillValues.Text = "Fill Values";
            this.btnFillValues.UseVisualStyleBackColor = false;
            this.btnFillValues.Click += new System.EventHandler(this.BtnFillValues_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(189)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(1500, 858);
            this.Controls.Add(this.tlpBackground);
            this.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(38)))), ((int)(((byte)(45)))));
            this.MinimumSize = new System.Drawing.Size(1500, 858);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Robert Heijn Management Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.tlpBackground.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.tlpCenter.ResumeLayout(false);
            this.tlpLoginButtons.ResumeLayout(false);
            this.tlpCenterLogin.ResumeLayout(false);
            this.tlpCenterLogin.PerformLayout();
            this.tlpEmail.ResumeLayout(false);
            this.tlpEmail.PerformLayout();
            this.tlpPassword.ResumeLayout(false);
            this.tlpPassword.PerformLayout();
            this.tlpLoginBtn.ResumeLayout(false);
            this.tlpGrp.ResumeLayout(false);
            this.grpDevelopment.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlpBackground;
        private PictureBox pbxLogo;
        private TableLayoutPanel tlpCenter;
        private GroupBox grpDevelopment;
        private TableLayoutPanel tlpLoginButtons;
        private TableLayoutPanel tlpCenterLogin;
        private Label lblEmail;
        private TextBox tbxEmail;
        private TextBox tbxPassword;
        private Label lblPassword;
        private Button btnLogin;
        private TableLayoutPanel tlpLoginBtn;
        private TableLayoutPanel tlpGrp;
        private Button btnFillValues;
        private TableLayoutPanel tlpEmail;
        private TableLayoutPanel tlpPassword;
    private Label lblEmailError;
    private Label lblPasswordError;
}