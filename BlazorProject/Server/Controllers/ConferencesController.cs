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
    public class ConferencesController : ControllerBase
    {
        private readonly ILogger<ConferencesController> _logger;
        private readonly BlazorDbContext _dbContext;

        public ConferencesController(ILogger<ConferencesController> logger, DbContextOptions<BlazorDbContext> options)
        {
            _logger = logger;
            _dbContext = new BlazorDbContext(options);
        }

        [HttpGet]
        public async Task<IActionResult> GetEntities()
        {
            var entities = await _dbContext.Conferences.ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntity(Guid id)
        {
            var entities = await _dbContext.Conferences.Where(s => s.ID == id).FirstOrDefaultAsync();
            if (entities == null)
                return NotFound($"Conference with ID={id} does not exist!!");
            return Ok(entities);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(Conference entity)
        {
            if (entity == null)
                return NotFound("No object has been sent.");

            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = entity.DateCreated;
            
            _dbContext.Conferences.Add(entity);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(Conference conference, Guid id)
        {
            if (conference == null)
                return NotFound($"The conference with {id} was not found!");

            var entityOrig = _dbContext.Conferences.Find(conference.ID);
            entityOrig.TalkTitle = conference.TalkTitle;
            entityOrig.Remark = conference.Remark;
            entityOrig.IsInvitedTalk = conference.IsInvitedTalk;
            entityOrig.Place = conference.Place;
            entityOrig.PresentationDate = conference.PresentationDate;
            entityOrig.DateUpdated = DateTime.Now;
            _dbContext.Update(entityOrig);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            var entityDelete = await _dbContext.Conferences.FindAsync(id);
            if (entityDelete == null)
                return NotFound();
            _dbContext.Conferences.Remove(entityDelete);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
