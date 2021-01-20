using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using CodingEvents.Data;
using CodingEvents.ViewModels;


namespace CodingEvents.Controllers                      // CONTINUATION OF CLASS 10,11 VIEWS & MODELS
{
    public class EventsController : Controller
    {


        // GET : /<controller>/
        [HttpGet]
        public IActionResult Index()
        {

            List<Event> events = new List<Event>(EventData.GetAll());

            return View(events);
        }

        [HttpGet]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        [HttpPost]  //annotations, request type attribute
        public IActionResult Add(AddEventViewModel addEventViewModel)       // ViewModel
        {
            if(ModelState.IsValid)
            {
                Event newEvent = new Event
                {                                                           // directly assign properties to Event Model using ViewModel
                    Name = addEventViewModel.Name,
                    Location = addEventViewModel.Location,
                    Description = addEventViewModel.Description,
                    NoOfAttendees = addEventViewModel.NoOfAttendees,
                    ContactEmail = addEventViewModel.ContactEmail
                };

                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
                ViewBag.Title = "Edit Event " + EventData.GetById(eventId).Name + "(" + eventId + ")";
                ViewBag.editEvent = EventData.GetById(eventId);
                return View();
        }

        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description, string location, int noOfAttendees, string contactEmail)
        {
            Event toBeEdited = EventData.GetById(eventId);
            toBeEdited.Name = name;
            toBeEdited.Description = description;
            toBeEdited.Location = location;
            toBeEdited.NoOfAttendees = noOfAttendees;
            toBeEdited.ContactEmail = contactEmail;

            return Redirect("/Events");
        }
    }
}
