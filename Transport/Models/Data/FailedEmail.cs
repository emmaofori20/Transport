using System;
using System.Collections.Generic;

#nullable disable

namespace Transport.Models.Data
{
    public partial class FailedEmail
    {
        public int FailedEmailId { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
