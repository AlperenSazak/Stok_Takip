using System.ComponentModel.DataAnnotations;

namespace Stok_Takip.Models
{
    public interface IEntity
    {
        [Key]
        public int Id { get; set; }
    }

}
