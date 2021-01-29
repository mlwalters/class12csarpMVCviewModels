using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description can't be longer than 500 characters.")]
        public string Description { get; set; }

        [EmailAddress]                                  // validation attributes, using client side verification
        public string ContactEmail { get; set; }

        [Range(0, 100000, ErrorMessage = "Must be between 0 - 100,000.")]
        public int NoOfAttendees { get; set; }

        public EventType Type { get; set; }
        public List<SelectListItem> EventTypes { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(EventType.Conference.ToString(), ((int)EventType.Conference).ToString()),
            new SelectListItem(EventType.Meetup.ToString(), ((int)EventType.Meetup).ToString()),
            new SelectListItem(EventType.Workshop.ToString(), ((int)EventType.Workshop).ToString()),
            new SelectListItem(EventType.Social.ToString(), ((int)EventType.Social).ToString()),
        };
 

    }
}
