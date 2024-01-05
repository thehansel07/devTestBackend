using DevTestBackend.Domain.Entities;
using DevTestBackend.Infrastructure.Commons.Bases.Request;
using DevTestBackend.Infrastructure.Persistence.Context;
using DevTestBackend.Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevTestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        public readonly IUnitOfWork _annoucenmentRepository;
        public readonly DbContextTestBackEnd _dbContext;

        public AnnouncementController(IUnitOfWork annoucenmentRepository, DbContextTestBackEnd dbContext)
        {
            _annoucenmentRepository = annoucenmentRepository;
            _dbContext = dbContext;
        }

        [HttpPost(nameof(ListAnnouncement))]
        public async Task<IActionResult> ListAnnouncement([FromBody] BaseFilterRequest filters)
        {
            var response = await _annoucenmentRepository.Annoucenment.ListAnnouncement(filters);

            return Ok(response);
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult> AnnouncementById([FromBody] int id)
        {
            var response = await _annoucenmentRepository.Annoucenment.AnnouncementById(id);

            return Ok(response);
        }


        [HttpGet("Register")]

        public async Task<IActionResult> RegisterAnnoucenment([FromBody] Announcement announcement)
        {
            var response = await _annoucenmentRepository.Annoucenment.RegisterAnnouncement(announcement);

            return Ok(response);
        }

        [HttpPut("Edit/{id:int}")]
        public async Task<IActionResult> EditAnnouncement([FromBody] Announcement announcement)
        {
            var response = await _annoucenmentRepository.Annoucenment.EditAnnouncement(announcement);

            return Ok(response);
        }

        [HttpPut("Remove/{id:int}")]
        public async Task<IActionResult> RemoveAnnouncement([FromBody] Announcement announcement)
        {
            var response = await _annoucenmentRepository.Annoucenment.EditAnnouncement(announcement);

            return Ok(response);
        }


        [HttpGet(nameof(AddFecthGettingAnnoucenmentFromBitmex))]

        public async Task<IActionResult> AddFecthGettingAnnoucenmentFromBitmex()
        {
            var response = await _annoucenmentRepository.Annoucenment.FecthAnnoucenmentFromBitmex();

            await _dbContext.AddRangeAsync(response);

            _annoucenmentRepository.SaveChangesAsync();

            return Ok(response);
        }


    }
}
