using Core.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("Blog")]
    public class Blog : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
