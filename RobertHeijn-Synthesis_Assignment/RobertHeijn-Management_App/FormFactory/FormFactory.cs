#region

using BusinessLogic.BL_Classes;
using RobertHeijn_Management_App.Forms;
using RobertHeijn_Management_App.Forms.Popups;

#endregion

namespace RobertHeijn_Management_App.FormFactory;

public class FormFactory : IFormFactory
{
    private static IFormFactory _provider = null!;

    public LoginForm CreateLoginForm()
    {
        return _provider.CreateLoginForm();
    }

    public ShopWorkerForm CreateShopWorkerForm(Form parentForm, Person person)
    {
        return _provider.CreateShopWorkerForm(parentForm, person);
    }

    public AddProductPopUp CreateAddProductPopUp()
    {
        return _provider.CreateAddProductPopUp();
    }
    public ChangeOrderStatus CreateChangeOrderStatusPopUp(Order order)
	{
		return _provider.CreateChangeOrderStatusPopUp(order);
	}

    public static void SetProvider(IFormFactory provider)
    {
        _provider = provider;
    }
}