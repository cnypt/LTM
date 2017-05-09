using System;
using System.Collections.Generic;

namespace LTM.Models
{
    public partial class SysUser
    {
        public long Id { get; set; }
        public Guid Userid { get; set; }
        public string Userphone { get; set; }
        public string Useremail { get; set; }
        public string Password { get; set; }
        public Guid? Roleid { get; set; }
        public int Userstatus { get; set; }
        public string Wechatopenid { get; set; }
        public string Qqopenid { get; set; }
        public string Weiboopenid { get; set; }
        public DateTime? Createdate { get; set; }
    }
}
