#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.Services;

public sealed class RolesService : IRolesActionable, ICustomerActionable
{
    private readonly ICustomerActionable _customerRepository;
    private readonly IRolesActionable _rolesRepository;

    public RolesService(IRolesActionable rolesRepository, ICustomerActionable customerRepository)
    {
        _rolesRepository = rolesRepository;
        _customerRepository = customerRepository;
    }

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
    public bool AddHomeDeliveryAddress(Customer customer, Address address)
    {
        return _customerRepository.AddHomeDeliveryAddress(customer, address);
    }

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
    public bool RemoveHomeDeliveryAddressFromCustomer(Customer customer, Address address)
    {
        return _customerRepository.RemoveHomeDeliveryAddressFromCustomer(customer, address);
    }

    /// <summary>
    ///     Updates the shop <see cref="T:BusinessLogic.BL_Classes.Address" /> for a
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" /> or
    ///     <see cref="T:BusinessLogic.BL_Classes.ShopWorker" />object.
    /// </summary>
    /// <param name="role">
    ///     An object of type
    ///     <see cref="T:BusinessLogic.BL_Classes.Customer" /> or
    ///     <see cref="T:BusinessLogic.BL_Classes.ShopWorker" />,both implementations
    ///     of  <see cref="T:BusinessLogic.BL_Interfaces.IRole" />
    /// </param>
    /// <param name="address">
    ///     The  <see cref="T:BusinessLogic.BL_Classes.Address" />
    ///     which will be set.
    /// </param>
    /// <returns>
    ///     <see langword="true" /> if the specified
    ///     <see cref="T:BusinessLogic.BL_Interfaces.IRole" /> was updated
    ///     successfully, otherwise <see langword="false" />.
    /// </returns>
    public bool UpdateShopAddress(IRole role, Address address)
    {
        return _rolesRepository.UpdateShopAddress(role, address);
    }
}