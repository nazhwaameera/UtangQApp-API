using System.Data;
using AutoMapper;
using UtangQApp_API_BLL.DTOs.Reports;
using UtangQApp_API_BLL.DTOs.Transactions;
using UtangQApp_API_BLL.DTOs.Users;
using UtangQApp_Domain.Reports;
using UtangQApp_Domain.Transactions;
using UtangQApp_Domain.Users;

namespace UtangQApp_API_BLL.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Users
            CreateMap<Bill, BillDTO>().ReverseMap();
            CreateMap<BillCreateDTO, Bill>();
            CreateMap<Friendship, FriendshipDTO>().ReverseMap();
            CreateMap<FriendshipList, FriendshipListDTO>().ReverseMap();
            CreateMap<FriendshipStatus, FriendshipStatusDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserCreateDTO, User>();
            CreateMap<Wallet, WalletDTO>().ReverseMap();
            CreateMap<WalletCreateDTO, Wallet>();

            //Transactions
            CreateMap<BillRecipient, BillRecipientDTO>().ReverseMap();
            CreateMap<BillRecipientWithDesc,  BillRecipientWithDescDTO>().ReverseMap();
            CreateMap<BillRecipientCreateDTO, BillRecipient>();
            CreateMap<BillRecipientCreateDTO, BillRecipientCreate>();
            CreateMap<BillStatus, BillStatusDTO>().ReverseMap();
            CreateMap<BillStatusCreateDTO, BillStatus>();
            CreateMap<PaymentReceipt, PaymentReceiptDTO>().ReverseMap();
            CreateMap<PaymentReceiptCreateDTO, PaymentReceipt>();
            CreateMap<TaxStatus, TaxStatusDTO>().ReverseMap();
            CreateMap<TaxStatusCreateDTO,  TaxStatus>();
            CreateMap<WalletTransaction,  WalletTransactionDTO>().ReverseMap();
            CreateMap<WalletTransactionCreateDTO, WalletTransaction>();

            //Reports
            CreateMap<BillPaymentReport, BillPaymentReportDTO>().ReverseMap();
            CreateMap<BillRecipientStatusReport,  BillRecipientStatusReportDTO>().ReverseMap();
            CreateMap<PaymentReceiptReport, PaymentReceiptReportDTO>().ReverseMap();
            CreateMap<TransactionHistoryReport, TransactionHistoryReportDTO>().ReverseMap();
            CreateMap<WalletBalanceReport, WalletBalanceReportDTO>().ReverseMap();

        }

    }
}
