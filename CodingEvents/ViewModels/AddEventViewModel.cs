using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;            // viewmodel library
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 100 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        [Range(0, 100000, ErrorMessage = "Must be between 0 - 100,000.")]
        public int NoOfAttendees { get; set; }

        [EmailAddress]                                  // validation attributes
        public string ContactEmail { get; set; } 
    }
}
