#region

using BusinessLogic.BL_Validation;
using Humanizer;
using System.Runtime.CompilerServices;

#endregion

namespace RobertHeijn_Management_App.UI_Validation;

internal static class UiValidator
{
	private static readonly Validator Validatable = new();

	public static bool ValidateNotNullOrEmpty(this string? field, Label errorLabel, [CallerArgumentExpression("field")] string? fieldName = null)
	{
		errorLabel.Visible = false;
		if (!string.IsNullOrEmpty(field)) return true;
		errorLabel.Text = @$"Please enter a valid {fieldName.Humanize(LetterCasing.LowerCase)}.";
		errorLabel.Visible = true;
		return false;
	}

	public static bool CheckNotDefault<T>(this T field, Label errorLabel, [CallerArgumentExpression("field")] string? fieldName = null)
	{
		errorLabel.Visible = false;
		if (!Equals(field, default(T))) return true;
		errorLabel.Text = @$"Please enter a valid {fieldName.Humanize(LetterCasing.LowerCase)}.";
		errorLabel.Visible = true;
		return false;
	}
	public static bool ValidateEmail(this string? email, Label errorLabel)
	{
		errorLabel.Visible = false;
		if (Validatable.ValidateEmail(email)) return true;
		errorLabel.Text = @"Please enter a valid email.";
		errorLabel.Visible = true;
		return false;
	}
}