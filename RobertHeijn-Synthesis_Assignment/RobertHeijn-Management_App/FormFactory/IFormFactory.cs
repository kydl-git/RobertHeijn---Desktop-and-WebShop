#region

using BusinessLogic.BL_Classes;
using RobertHeijn_Management_App.Forms;
using RobertHeijn_Management_App.Forms.Popups;

#endregion

namespace RobertHeijn_Management_App.FormFactory;

public interface IFormFactory
{
    LoginForm CreateLoginForm();
    ShopWorkerForm CreateShopWorkerForm(Form parentForm, Person person);
    AddProductPopUp CreateAddProductPopUp();
    ChangeOrderStatus CreateChangeOrderStatusPopUp(Order order);
}