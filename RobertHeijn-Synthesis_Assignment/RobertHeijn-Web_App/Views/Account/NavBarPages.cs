using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RobertHeijn_Web_App.Views.Account;

public static class NavBarPages
{
	public static string ActivePageKey => "ActivePage";
	public static string Edit => "EditAccount";
	public static string ChangePassword => "ChangePassword";
	
	public static string EditAccountNavClass(ViewContext viewContext) => PageNavClass(viewContext, Edit);
	public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);
	
	private static string PageNavClass(ViewContext viewContext, string page)
	{
		var activePage = viewContext.ViewData["ActivePage"] as string;
		return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : string.Empty;
	}
	public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
}