#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.Data_Exceptions;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.Behaviours;
using RobertHeijn_Management_App.UI_Validation;

#endregion

namespace RobertHeijn_Management_App.Forms;

public partial class LoginForm : Form
{
	private readonly ICredentialsActionable _credentialsService;
	private readonly ILogger<LoginForm> _logger;
	private readonly IPersonActionable _personService;
	private readonly Responsive _responsive;

	public LoginForm(ICredentialsActionable credentialsService, ILogger<LoginForm> logger, IPersonActionable personService)
	{
		InitializeComponent();
		_credentialsService = credentialsService;
		_logger = logger;
		_personService = personService;
		_responsive = new Responsive(Screen.PrimaryScreen.Bounds);
		_responsive.SetMultiplicationFactor();
	}

	/// <summary>
	///     Event triggered on closing form.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The event.</param>
	private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (e.CloseReason == CloseReason.UserClosing)
		{
			if (MessageBox.Show(@"Are you sure you want to exit?", @"Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_logger.LogInformation("User has exited the application");
				Application.Exit();
			}
			else
			{
				e.Cancel = true;
			}
		}
	}

	private void LoginForm_Load(object sender, EventArgs e)
	{
		Width = _responsive.GetMetrics(Width, "Width");
		Height = _responsive.GetMetrics(Height, "Height");
		Left = Screen.GetBounds(this).Width / 2 - Width / 2;
		Top = Screen.GetBounds(this).Height / 2 - Height / 2 - 30;
		foreach (Control ctl in Controls)
		{
			if (ctl is not PictureBox)
				ctl.Font = new Font("Segoe UI", _responsive.GetMetrics((int)ctl.Font.Size), FontStyle.Regular, GraphicsUnit.Point);
			ctl.Width = _responsive.GetMetrics(ctl.Width, "Width");
			ctl.Height = _responsive.GetMetrics(ctl.Height, "Height");
			ctl.Top = _responsive.GetMetrics(ctl.Top, "Top");
			ctl.Left = _responsive.GetMetrics(ctl.Left, "Left");
		}

		_logger.LogInformation("Login form loaded, with a width of {Width} and a height of {Height}", Width, Height);
	}

	private void BtnFillValues_Click(object sender, EventArgs e)
	{
		tbxEmail.Text = @"daniel456@robertheijn.com";
		tbxPassword.Text = @"apples";
	}

	private void BtnLogin_Click(object sender, EventArgs e)
	{
		var email = tbxEmail.Text;
		var password = tbxPassword.Text;
		Login(email, password);
	}

	private void Login(string? email, string? password)
	{
		if (!(email.ValidateNotNullOrEmpty(lblEmailError) & password.ValidateNotNullOrEmpty(lblPasswordError)) || !email.ValidateEmail(lblEmailError)) return;
		try
		{
			var credentials = new Credentials(email, password);
			var user = credentials.Login(_credentialsService);
			if (user == null)
			{
				_logger.LogInformation("{PageName} => Provided email: {InputEmail} does not match provided password", "Login Page", email);
				MessageBox.Show(@"Invalid credentials");
			}
			else
			{
				var person = new Person(user);
				person = person.GetPerson(_personService);
				if (person.Role is ShopWorker)
				{
					var shopWorkerForm = new FormFactory.FormFactory().CreateShopWorkerForm(this, person);
					shopWorkerForm.Show();
					Hide();
				}
				else
				{
					MessageBox.Show(@"Access denied");
				}
			}
		}
		catch (ConnectionUnavailableException con)
		{
			_logger.LogCritical("{PageName} => {Error}", "Login Page", con.Message);
			MessageBox.Show(@$"{con.Message}");
		}
		catch (NoDataFoundException ndf)
		{
			_logger.LogError("{PageName} => {Error}", "Login Page", ndf.Message);
			MessageBox.Show(@$"{ndf.Message}");
		}
		catch (Exception e)
		{
			//log the error but don't show it to the user. User should not know what went wrong, but for debugging purposes it is useful for us to know.
			_logger.LogCritical("{PageName} => {Error}", "Login Page", e.Message);
			MessageBox.Show(@"An error occurred. Please try again later.");

		}
	}
}