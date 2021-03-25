using System;
using System.Collections.Generic;

#nullable disable

namespace Z_DATAHORTI.EF_SCAFFOLD
{
    public partial class User
    {
        public string DsLogin { get; set; }
        public string DsPassword { get; set; }
        public bool? BoActive { get; set; }
        public DateTime DtCreation { get; set; }
        public DateTime DtAtualization { get; set; }
    }
}
