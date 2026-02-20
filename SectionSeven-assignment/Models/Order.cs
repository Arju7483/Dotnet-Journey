using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using SectionSeven_assignment.CustomValidators;

namespace SectionSeven_assignment.Models
{
    public class Order: IValidatableObject
    {
        [BindNever]
        public int? OrderNo { get; set; }

        [DateValidator("2000-01-01")]
        public DateTime OrderDate { get; set; }

        [Required]
        public double InvoicePrice { get; set; }

        [Required]
        public List<Product> Products { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Products.Count < 1) yield return new ValidationResult("Atleast on product must include", new[] {nameof(Products)});
            var total = Products.Sum(x => x.Quantity * x.Price);
            if (total != InvoicePrice) yield return new ValidationResult("Invoice price must equal sum of products", new[] {nameof(InvoicePrice)});
        }
    }
}
