using BlazorProject.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorProject.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private static List<Subject> lstSubjects = new List<Subject>()
        {
            new(){ ID = 1, Name="Diskretna matematika", Description="Zelo zanimiv predmet", LectureHours=17, TutorialHours=23, ECTS=6 },
            new(){ ID = 2, Name="Programiranje", Description="Tudi zelo zanimiv predmet", LectureHours=20, TutorialHours=25, ECTS=6 },
            new(){ ID = 3, Name="Razvoj naprednih spletnih uporabniških vmesnikov", Description="Še bolj zanimiv predmet", LectureHours=15, TutorialHours=20, ECTS=6 },
            new(){ ID = 4, Name="Algoritmi", Description="Najbolj zanimiv predmet", LectureHours=20, TutorialHours=25, ECTS=6 }
        };

        public SubjectsController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            return Ok(lstSubjects);
        }

        [HttpGet("{id}")]        
        public async Task<IActionResult> GetSubject(int id)
        {
            var subject = lstSubjects.Where(s => s.ID == id).FirstOrDefault();
            if (subject == null)
                return NotFound($"Subject with ID={id} does not exist!!");
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(Subject subject)
        {            
            if (subject == null)
                return Ok(lstSubjects);

            subject.ID = lstSubjects.Max(x => x.ID + 1);
            lstSubjects.Add(subject);
            return Ok(lstSubjects);
        }
    }
}
