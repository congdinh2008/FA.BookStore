using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.BookStore.Core.Models
{
    [Table("Comment", Schema = "common")]
    public class Comment
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(500, ErrorMessage = "The {0} not exceed {1} characters")]
        public string Content { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}
