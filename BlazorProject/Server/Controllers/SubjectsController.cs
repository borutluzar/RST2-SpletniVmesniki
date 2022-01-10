using BlazorProject.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ILogger<SubjectsController> _logger;
        private readonly BlazorDbContext _dbContext;

        public SubjectsController(ILogger<SubjectsController> logger, DbContextOptions<BlazorDbContext> options)
        {
            _logger = logger;
            _dbContext = new BlazorDbContext(options);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _dbContext.Subjects.ToListAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var subject = await _dbContext.Subjects.Where(s => s.ID == id).FirstOrDefaultAsync();
            if (subject == null)
                return NotFound($"Subject with ID={id} does not exist!!");
            return Ok(subject);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(Subject subject)
        {
            if (subject == null)
                return NotFound("No object has been sent.");

            subject.DateCreated = DateTime.Now;
            subject.DateUpdated = subject.DateCreated;
            
            _dbContext.Subjects.Add(subject);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubject(Subject subject, int id)
        {
            if (subject == null)
                return NotFound($"The subject with {id} was not found!");

            var subOrig = _dbContext.Subjects.Find(id);
            subOrig.Name = subject.Name;
            subOrig.Description = subject.Description;
            subOrig.ECTS = subject.ECTS;
            subOrig.TutorialHours = subject.TutorialHours;
            subOrig.LectureHours = subject.LectureHours;
            subOrig.DateUpdated = DateTime.Now;
            _dbContext.Update(subOrig);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id) // Pazite na ime parametra, biti mora enak!
        {
            var subjectDelete = await _dbContext.Subjects.FindAsync(id);
            if (subjectDelete == null)
                return NotFound();
            
            _dbContext.Subjects.Remove(subjectDelete);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
