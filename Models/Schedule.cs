using System;
using System.ComponentModel.DataAnnotations;

namespace NVPapi.Models
{
    public class Schedule
    {
        public int Document_ID { get; set; } // autoincrement on insert
        public bool Processed_Flag { get; set; }  // autoset to false (0) on insert
        public String From_IP { get; set; }
        public String Location_ID { get; set; }
        [Required]
        public String PDF_Path { get; set; }
        [Required]
        public String Document_Text { get; set; }
        public DateTime Create_Date { get; set; } // autofilled
        public String Created_By { get; set; } // autofilled
        public DateTime Update_Date { get; set; } // autofilled
        public String Updated_By { get; set; } // autofilled
    }
}
