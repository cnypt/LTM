using System;
using System.Collections.Generic;

namespace LTM.Models
{
    public partial class SysLicensePlateData
    {
        public long Id { get; set; }
        public int Licenseplatetype { get; set; }
        public string Licenseplate { get; set; }
        public string Password { get; set; }
        public DateTime Createdate { get; set; }
        public Guid Createuserid { get; set; }
        public int Authstatus { get; set; }
        public DateTime? Authpassdate { get; set; }
        public Guid? Authpassuserid { get; set; }
        public DateTime? Authunpassdate { get; set; }
        public Guid? Anthunpassuserid { get; set; }
    }
}
