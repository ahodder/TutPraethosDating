using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PraethosDating.Net.Data;
using PraethosDating.Net.Models;

namespace PraethosDating.Net.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();
        return Ok(users);
    }

    [HttpGet("{id}")] // /api/users/2
    public async Task<ActionResult<ApplicationUser>> GetUser(string id)
    {
        return await _context.Users.FirstAsync(user => user.Id == id);
    }

    [HttpGet("numbers")]
    public async Task<ActionResult<int[]>> GetNumbers()
    {
        var result = await Task.Run(() => new[] { 0, 1, 2, 3, 4 });
        return Ok(result);
    }
}