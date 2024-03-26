using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using UtangQApp_API_BLL.BLLs.Reports;
using UtangQApp_API_BLL.BLLs.Transactions;
using UtangQApp_API_BLL.BLLs.Users;
using UtangQApp_API_BLL.Interfaces.Report;
using UtangQApp_API_BLL.Interfaces.Transaction;
using UtangQApp_API_BLL.Interfaces.User;
using UtangQApp_Data;
using UtangQApp_Data.DAL.Reports;
using UtangQApp_Data.DAL.Transactions;
using UtangQApp_Data.DAL.Users;
using UtangQApp_Data.Interfaces.Reports;
using UtangQApp_Data.Interfaces.Transactions;
using UtangQApp_Data.Interfaces.Users;
using UtangQApp_API.Helpers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register DI
builder.Services.AddScoped<IBill, BillData>();
builder.Services.AddScoped<IFriendship, FriendshipData>();
builder.Services.AddScoped<IFriendshipList, FriendshipListData>();
builder.Services.AddScoped<IFriendshipStatus, FriendshipStatusData>();
builder.Services.AddScoped<IUser, UserData>();
builder.Services.AddScoped<IWallet, WalletData>();

builder.Services.AddScoped<IBillBLL, BillBLL>();
builder.Services.AddScoped<IFriendshipBLL, FriendshipBLL>();
builder.Services.AddScoped<IFriendshipListBLL, FriendshipListBLL>();
builder.Services.AddScoped<IFriendshipStatusBLL, FriendshipStatusBLL>();
builder.Services.AddScoped<IUserBLL, UserBLL>();
builder.Services.AddScoped<IWalletBLL, WalletBLL>();

builder.Services.AddScoped<IBillRecipient, BillRecipientData>();
builder.Services.AddScoped<IBillStatus, BillStatusData>();
builder.Services.AddScoped<IPaymentReceipt, PaymentReceiptData>();
builder.Services.AddScoped<ITaxStatus, TaxStatusData>();
builder.Services.AddScoped<IWalletTransaction, WalletTransactionData>();

builder.Services.AddScoped<IBillRecipientBLL, BillRecipientBLL>();
builder.Services.AddScoped<IBillStatusBLL, BillStatusBLL>();
builder.Services.AddScoped<IPaymentReceiptBLL, PaymentReceiptBLL>();
builder.Services.AddScoped<ITaxStatusBLL, TaxStatusBLL>();
builder.Services.AddScoped<IWalletTransactionBLL, WalletTransactionBLL>();

builder.Services.AddScoped<IBillPaymentReport, BillPaymentReportData>();
builder.Services.AddScoped<IBillRecipientStatusReport, BillRecipientStatusReportData>();
builder.Services.AddScoped<IPaymentReceiptReport, PaymentReceiptReportData>();
builder.Services.AddScoped<ITransactionHistoryReport, TransactionHistoryReportData>();
builder.Services.AddScoped<IWalletBalanceReport, WalletBalanceReportData>();

builder.Services.AddScoped<IView_BillPaymentReportBLL, BillPaymentReportBLL>();
builder.Services.AddScoped<IView_BillRecipientStatusReportBLL, BillRecipientStatusReportBLL>();
builder.Services.AddScoped<IView_PaymentReceiptReportBLL, PaymentReceiptReportBLL>();
builder.Services.AddScoped<IView_TransactionHistoryReportBLL, TransactionHistoryReportBLL>();
builder.Services.AddScoped<IView_WalletBalanceReportBLL, WalletBalanceReportBLL>();

//automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//inject db context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnectionString")));

var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
