using System;
using System.Collections.Generic;

namespace LTM.Models
{
    public partial class SysUserRank
    {
        public long Id { get; set; }
        public Guid Userid { get; set; }
        public int Rank { get; set; }
        public int Usetimes { get; set; }
        public int Authpasstimes { get; set; }
        public int Anthunpasstimes { get; set; }
    }
}
