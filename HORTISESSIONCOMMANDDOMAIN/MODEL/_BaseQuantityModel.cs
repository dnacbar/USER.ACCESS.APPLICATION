using System.ComponentModel.DataAnnotations.Schema;

namespace HORTIUSERCOMMAND.DOMAIN.MODEL
{
    public abstract class _BaseQuantityModel
    {
        [NotMapped]
        public int Page { get; set; } = 0;
        [NotMapped]
        public int Quantity { get; set; } = 20;
    }
}
