using System;
using System.Collections.Generic;

namespace Z_DATAUSERACCESS.DBUSERMODEL
{
    public partial class User
    {
        public Guid IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public string DsEmail { get; set; } = null!;
        public string DsUser { get; set; } = null!;
        public string? DsPhone { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual System IdSystemNavigation { get; set; } = null!;
        public virtual Userkey Userkey { get; set; } = null!;
    }
}
