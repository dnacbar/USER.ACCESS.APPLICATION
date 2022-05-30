using System;
using System.Collections.Generic;

namespace Z_DATAUSERACCESS.DBUSERMODEL
{
    public partial class Userkeytypejoin
    {
        public Guid IdSystem { get; set; }
        public string DsLogin { get; set; } = null!;
        public Guid IdUserkeytype { get; set; }
    }
}
