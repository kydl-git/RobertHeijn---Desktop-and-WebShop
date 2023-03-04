#region

using BusinessLogic.BL_Classes;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface ICustomerActionable
{
    /// <summary>
    ///     Add a <see cref="T:BusinessLogic.BL_Classes.Address" />  to the
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" />
    /// </summary>
    /// <param name="customer">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Customer" />
    ///     object.
    /// </param>
    /// <param name="address">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     object.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Address" /> was added successfully,
    ///     otherwise <see langword="false" />.
    /// </returns>
    protected internal bool AddHomeDeliveryAddress(Customer customer, Address address);

    /// <summary>
    ///     Remove a <see cref="T:BusinessLogic.BL_Classes.Address" />  from the
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" />
    /// </summary>
    /// <param name="customer">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Customer" />
    ///     object.
    /// </param>
    /// <param name="address">
    ///     The <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     object.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Classes.Address" /> was removed successfully,
    ///     otherwise <see langword="false" />.
    /// </returns>
    protected internal bool RemoveHomeDeliveryAddressFromCustomer(Customer customer, Address address);
}