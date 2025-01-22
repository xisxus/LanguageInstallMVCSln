using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstall.Data.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public DateTime RecordTime { get; set; }
        public int MainTableId { get; set; }
        public int TranslateTableId { get; set; }
        public string EnglishText { get; set; }
        public string LangCode { get; set; }
        public string? TranslateText { get; set; }
        public string? Remark { get; set; }
    }
}
