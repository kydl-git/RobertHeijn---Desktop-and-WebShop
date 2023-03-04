#region

using BusinessLogic.BL_Classes;
using Microsoft.Extensions.DependencyInjection;
using RobertHeijn_Management_App.Forms;
using RobertHeijn_Management_App.Forms.Popups;

#endregion

namespace RobertHeijn_Management_App.FormFactory;

public class FormFactoryImpl : IFormFactory
{
    private readonly IServiceProvider _serviceProvider;

    public FormFactoryImpl(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public LoginForm CreateLoginForm()
    {
        return _serviceProvider.GetRequiredService<LoginForm>();
    }

    public ShopWorkerForm CreateShopWorkerForm(Form parentForm, Person person)
    {
        var shopWorkerForm = _serviceProvider.GetRequiredService<Func<Form, Person, ShopWorkerForm>>();
        return shopWorkerForm(parentForm, person);
    }
    public ChangeOrderStatus CreateChangeOrderStatusPopUp(Order order)
	{
		var changeOrderStatusForm = _serviceProvider.GetRequiredService<Func<Order, ChangeOrderStatus>>();
		return changeOrderStatusForm(order);
	}
    public AddProductPopUp CreateAddProductPopUp()
    {
        return _serviceProvider.GetRequiredService<AddProductPopUp>();
    }

}