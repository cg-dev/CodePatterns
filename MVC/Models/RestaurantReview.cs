namespace MVC.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Range(1,10)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "anonymous")]
        public string ReviewerName { get; set; }

        public int RestaurantId { get; set; } // optional

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Rating < 2 && ReviewerName.ToLower().StartsWith("chris"))
            {
                yield return new ValidationResult(string.Format("{0} you can't be that mean all of the time!", ReviewerName));
            }
        }
    }
}