using System;
using System.Collections.Generic;
using System.Text;

namespace UtangQAppBLL.DTOs.Report
{
    public class BillRecipientStatusReportDTO
    {
        public int BillRecipientID { get; set; }
        public int BillID { get; set; }
        public DateTime SentDate { get; set; }
        public string Status { get; set; }
    }
}
