using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnquiryAPI.Model
{
    public class EnquiryType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int typeId {  get; set; }
        [Required]
        public string typeName { get; set; } = string.Empty;
    }
}
