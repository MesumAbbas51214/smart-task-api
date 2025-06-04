using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTaskApi.Data;
using SmartTaskApi.DTO_s;
using SmartTaskApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace SmartTaskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
       private readonly AppDbContext _context;
       private readonly IMapper _mapper;
        public TaskController(AppDbContext context, IMapper mapper) { 
        
            _context = context;
            _mapper = mapper;   
        }
       
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskReadDto>>> GetTasks([FromQuery] bool? isComplete)
        {
            var query = _context.Tasks.AsQueryable();

            if (isComplete.HasValue)
            {
                query = query.Where(t => t.IsComplete == isComplete.Value);
            }

            var tasks = await query.ToListAsync();

            var result = _mapper.Map<List<TaskReadDto>>(tasks);

            return Ok(result);
        }




        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
                return NotFound();

            var result = new TaskReadDto
            {
                Id = tasks.Id,
                Title = tasks.Title,
                IsComplete = tasks.IsComplete
            };

            return Ok(result);

        }

        // POST: api/tasks
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TaskReadDto>> CreateTask(TaskCreateDto taskDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = new TaskItem
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsComplete = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, new TaskReadDto
            {
                Id = task.Id,
                Title = task.Title,
                IsComplete = task.IsComplete
            });
        }



        // PUT: api/tasks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskUpdateDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            // Map updated fields
            task.Title = updateDto.Title;
            task.Description = updateDto.Description;
            task.IsComplete = updateDto.IsComplete;

            await _context.SaveChangesAsync();

            return NoContent(); // 204 - successful with no response body
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
