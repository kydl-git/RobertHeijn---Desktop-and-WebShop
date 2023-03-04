#region

using BusinessLogic.BL_DaL_Interfaces;
using BusinessLogic.BL_Validation;
using BusinessLogic.Services;
using DataAccessLayer;
using DataAccessLayer.RepositoryClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using RobertHeijn_Web_App.Configuration;

#endregion

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddSingleton(_ =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var dbQueries = new DbQueries(connectionString!);
    return dbQueries;
});
// Resolved injection to repository classes
// Add Singleton for data access layer instances
builder.Services.AddSingleton<ICredentialsActionable, CredentialsRepository>();
// Decorate for business logic instances
builder.Services.Decorate<ICredentialsActionable, CredentialsService>();

builder.Services.AddSingleton<IRolesActionable, RolesRepository>();
builder.Services.AddSingleton<ICustomerActionable, RolesRepository>();
builder.Services.Decorate<IRolesActionable, RolesService>();
builder.Services.Decorate<ICustomerActionable, RolesService>();

builder.Services.AddSingleton<IAddressActionable, AddressRepository>();
builder.Services.Decorate<IAddressActionable, AddressService>();

builder.Services.AddSingleton<IHomeDeliveryActionable, HomeDeliveryRepository>();
builder.Services.Decorate<IHomeDeliveryActionable, HomeDeliveryService>();

builder.Services.AddSingleton<IPersonActionable, PersonRepository>();
builder.Services.Decorate<IPersonActionable, PersonService>();

builder.Services.AddSingleton<ICategoryActionable, CategoryRepository>();
builder.Services.Decorate<ICategoryActionable, CategoryService>();

builder.Services.AddSingleton<IProductActionable, ProductRepository>();
builder.Services.Decorate<IProductActionable, ProductService>();

builder.Services.AddSingleton<IInventoryActionable, InventoryRepository>();
builder.Services.Decorate<IInventoryActionable, InventoryService>();

builder.Services.AddSingleton<IOrderActionable, OrderRepository>();
builder.Services.Decorate<IOrderActionable, OrderService>();

builder.Services.AddSingleton<IShoppingCartActionable, ShoppingCartRepository>();
builder.Services.Decorate<IShoppingCartActionable, ShoppingCartService>();

builder.Services.AddSingleton<IValidatable, Validator>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => true;
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});
builder.Services.Configure<CookieTempDataProviderOptions>(options =>
{
    options.Cookie.Name = "MyTempDataCookie";
    options.Cookie.IsEssential = true;
});
builder.Services.AddScoped<RevokeAccessEvents>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        options =>
        {
            options.EventsType = typeof(RevokeAccessEvents);
            options.ExpireTimeSpan = TimeSpan.FromMinutes(ApplicationCookiesConstants.ValidityMinutesPeriod);
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/AccessDenied";
            options.Cookie.Name = ApplicationCookiesConstants.IdentifierCookieName;
            options.Cookie.IsEssential = true;
            options.Cookie.HttpOnly = true;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.SameSite = SameSiteMode.Lax;
        });
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizePage("/Basket/Checkout"); })
    .AddNToastNotifyToastr(new ToastrOptions
    {
        ProgressBar = true,
        CloseButton = true,
        TimeOut = 10000,
        PositionClass = ToastPositions.BottomRight,
        NewestOnTop = true
    });
builder.Services.AddMemoryCache();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
var app = builder.Build();

app.UseNToastNotify();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.Logger.LogInformation("RobertHeijn - Non-Development environment...");
    app.UseExceptionHandler(errorBuilder =>
    {
        errorBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
            await context.Response.WriteAsync("\tRobertHeijn.");
            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
            var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionHandlerPathFeature!.Error is FileNotFoundException fileNotFoundException) await context.Response.WriteAsync($" File Error: {fileNotFoundException.Message}\r\n");
            await context.Response.WriteAsync("<hr /><a href=\"/\">Home</a>\r\n");
            await context.Response.WriteAsync("</body></html>\r\n");
            await context.Response.WriteAsync(new string(' ', 512));
        });
    });
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.Logger.LogInformation("RobertHeijn - Development environment");
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.Logger.LogInformation("RobertHeijn - Application started");
app.Run();