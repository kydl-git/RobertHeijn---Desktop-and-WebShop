#region

using System.Configuration;
using BusinessLogic.BL_Classes;
using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Validation;
using BusinessLogic.Services;
using DataAccessLayer;
using DataAccessLayer.RepositoryClasses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RobertHeijn_Management_App.FormFactory;
using RobertHeijn_Management_App.Forms;
using RobertHeijn_Management_App.Forms.Popups;
using Serilog;

#endregion

namespace RobertHeijn_Management_App;

internal static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        var formFactory = CompositionRoot();
        ApplicationConfiguration.Initialize();
        Application.Run(formFactory.CreateLoginForm());
    }

    private static IFormFactory CompositionRoot()
    {
        FormFactoryImpl formFactory = new(CreateHostBuilder().Build().Services);
        FormFactory.FormFactory.SetProvider(formFactory);

        return formFactory;
    }

    private static IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddSingleton(_ =>
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                    return new DbQueries(connectionString!);
                });
                var serilogLogger = new LoggerConfiguration()
                    .WriteTo.Logger(lc => lc.WriteTo.File(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Logs\\log-.txt")), rollingInterval: RollingInterval.Day))
                    .WriteTo.Logger(lc => lc.WriteTo.Console())
                    .WriteTo.Logger(lc => lc.WriteTo.Debug()).CreateLogger();
                services.AddLogging(logger => logger.AddSerilog(serilogLogger, true));
                services.AddSingleton(Log.Logger);
                services.AddSingleton<ICredentialsActionable, CredentialsRepository>();
                services.Decorate<ICredentialsActionable, CredentialsService>();

                services.AddSingleton<IRolesActionable, RolesRepository>();
                services.AddSingleton<ICustomerActionable, RolesRepository>();
                services.Decorate<IRolesActionable, RolesService>();
                services.Decorate<ICustomerActionable, RolesService>();

                services.AddSingleton<IAddressActionable, AddressRepository>();
                services.Decorate<IAddressActionable, AddressService>();

                services.AddSingleton<IHomeDeliveryActionable, HomeDeliveryRepository>();
                services.Decorate<IHomeDeliveryActionable, HomeDeliveryService>();

                services.AddSingleton<IPersonActionable, PersonRepository>();
                services.Decorate<IPersonActionable, PersonService>();

                services.AddSingleton<ICategoryActionable, CategoryRepository>();
                services.Decorate<ICategoryActionable, CategoryService>();

                services.AddSingleton<IProductActionable, ProductRepository>();
                services.Decorate<IProductActionable, ProductService>();

                services.AddSingleton<IInventoryActionable, InventoryRepository>();
                services.Decorate<IInventoryActionable, InventoryService>();

                services.AddSingleton<IOrderActionable, OrderRepository>();
                services.Decorate<IOrderActionable, OrderService>();

                services.AddSingleton<IShoppingCartActionable, ShoppingCartRepository>();
                services.Decorate<IShoppingCartActionable, ShoppingCartService>();
                services.AddSingleton<IValidatable, Validator>();
                services.AddTransient<LoginForm>();
                services.AddSingleton<Func<Form, Person, ShopWorkerForm>>(container =>
                    (form, person) =>
                    {
                        var categoryService = container.GetRequiredService<ICategoryActionable>();
                        var productService = container.GetRequiredService<IProductActionable>();
                        var inventoryService = container.GetRequiredService<IInventoryActionable>();
                        var orderService = container.GetRequiredService<IOrderActionable>();
                        var personService = container.GetRequiredService<IPersonActionable>();
                        var logger = container.GetRequiredService<ILoggerFactory>();
                        return new ShopWorkerForm(form, person, categoryService, productService, inventoryService, orderService, personService, logger);
                    });
                services.AddTransient<AddProductPopUp>();
                services.AddTransient<Func<Order, ChangeOrderStatus>>(container => (order) =>
                {
	                var orderService = container.GetRequiredService<IOrderActionable>();
	                var logger = container.GetRequiredService<ILoggerFactory>();
	                return new ChangeOrderStatus(order, orderService, logger);
                });
            });

    }
}