#region

using BusinessLogic.BL_Classes;
using BusinessLogic.BL_Interfaces;

#endregion

namespace BusinessLogic.BL_DaL_Interfaces;

public interface IRolesActionable
{

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
    protected internal bool UpdateShopAddress(IRole role, Address address);
}