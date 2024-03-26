namespace UtangQApp_API_BLL.DTOs.Reports
{
    public class BillRecipientStatusReportDTO
    {
        public int BillRecipientID { get; set; }
        public int BillID { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; }
    }
}
