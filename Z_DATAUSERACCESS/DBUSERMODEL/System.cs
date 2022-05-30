using System;
using System.Collections.Generic;

namespace Z_DATAUSERACCESS.DBUSERMODEL
{
    public partial class System
    {
        public System()
        {
            Users = new HashSet<User>();
        }

        public Guid IdSystem { get; set; }
        public string DsSystem { get; set; } = null!;
        public string DsDescription { get; set; } = null!;
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
