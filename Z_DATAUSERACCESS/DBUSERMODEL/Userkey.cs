using System;
using System.Collections.Generic;

namespace Z_DATAUSERACCESS.DBUSERMODEL
{
    public partial class Userkey
    {
        public Userkey()
        {
            IdUserkeytypes = new HashSet<Userkeytype>();
        }

        public Guid IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public string DsKey { get; set; } = null!;
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Userkeytype> IdUserkeytypes { get; set; }
    }
}
