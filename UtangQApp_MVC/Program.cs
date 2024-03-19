using UtangQAppBLL;
using UtangQAppBLL.Interfaces.Report;
using UtangQAppBLL.Interfaces.Transaction;
using UtangQAppBLL.Interfaces.User;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Registering the BLL services
builder.Services.AddScoped<UserBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IBillBLL, BillBLL>();
builder.Services.AddScoped<IWalletBLL, WalletBLL>();
builder.Services.AddScoped<IFriendshipBLL, FriendshipBLL>();
builder.Services.AddScoped<IFriendshipListBLL, FriendshipListBLL>();
builder.Services.AddScoped<FriendshipStatusBLL>();
builder.Services.AddScoped<IFriendshipStatusBLL, FriendshipStatusBLL>();
builder.Services.AddScoped<IBillRecipientBLL, BillRecipientBLL>();
builder.Services.AddScoped<IPaymentReceiptBLL, PaymentReceiptBLL>();
builder.Services.AddScoped<IWalletTransactionBLL, WalletTransactionBLL>();
builder.Services.AddScoped<IBillStatusBLL, BillStatusBLL>();
builder.Services.AddScoped<ITaxStatusBLL, TaxStatusBLL>();
builder.Services.AddScoped<IView_BillPaymentReportBLL, View_BillPaymentReportBLL>();
builder.Services.AddScoped<IView_BillRecipientStatusReportBLL, View_BillRecipientStatusReportBLL>();
builder.Services.AddScoped<IView_PaymentReceiptReportBLL, View_PaymentReceiptReportBLL>();
builder.Services.AddScoped<IView_TransactionHistoryReportBLL, View_TransactionHistoryReportBLL>();
builder.Services.AddScoped<IView_WalletBalanceReportBLL, View_WalletBalanceReportBLL>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


