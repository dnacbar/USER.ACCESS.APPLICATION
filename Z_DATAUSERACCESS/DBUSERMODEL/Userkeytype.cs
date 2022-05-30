﻿using System;
using System.Collections.Generic;

namespace Z_DATAUSERACCESS.DBUSERMODEL
{
    public partial class Userkeytype
    {
        public Userkeytype()
        {
            Userkeys = new HashSet<Userkey>();
        }

        public Guid IdUserkeytype { get; set; }
        public string DsKeytype { get; set; } = null!;

        public virtual ICollection<Userkey> Userkeys { get; set; }
    }
}
