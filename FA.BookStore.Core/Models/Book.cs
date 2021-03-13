using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.BookStore.Core.Models
{
    [Table("Book", Schema = "common")]
    public class Book
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(255, ErrorMessage = "The {0} not exceed {1} characters")]
        public string Title { get; set; }

        [StringLength(2000, ErrorMessage = "The {0} not exceed {1} characters")]
        public string Summary { get; set; }

        [Required(ErrorMessage = "Please select book image.")]
        [Display(Name = "Image Thumbnail")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Please enter book price")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Quantity")]
        [DefaultValue(0)]
        public int Quantity { get; set; }

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; }

        [Display(Name = "Modified Date")]
        public DateTimeOffset ModifiedDate { get; set; }

        [Display(Name = "Is Active?")]
        [DefaultValue(false)]
        public bool IsActive { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("Publisher")]
        public Guid PublisherId { get; set; }

        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}