using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.BookStore.Core.Models
{
    [Table("Publisher", Schema = "common")]
    public class Publisher
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(50, ErrorMessage = "The {0} not exceed {1} characters")]
        public string Name { get; set; }

        [StringLength(1024, ErrorMessage = "The {0} not exceed {1} characters")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}