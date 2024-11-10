using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.DataBase;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly TaskContext _context;

        public UserLoginsController(TaskContext context)
        {
            _context = context;
        }

        //// GET: api/UserLogins
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<UserLogin>>> GetUserLogin()
        //{
        //    return await _context.UserLogin.ToListAsync();
        //}

        //// GET: api/UserLogins/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<UserLogin>> GetUserLogin(Guid id)
        //{
        //    var userLogin = await _context.UserLogin.FindAsync(id);

        //    if (userLogin == null)
        //    {
        //        return NotFound();
        //    }

        //    return userLogin;
        //}

        //// PUT: api/UserLogins/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUserLogin(Guid id, UserLogin userLogin)
        //{
        //    if (id != userLogin.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(userLogin).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserLoginExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/UserLogins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<UserLogin>> PostUserLogin(UserLogin userLogin)
        //{
        //    _context.UserLogin.Add(userLogin);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUserLogin", new { id = userLogin.UserId }, userLogin);
        //}
        [HttpPost]
        public async Task<IActionResult>Register(UserModel userModel)
        {
            try
            {
                var UserReq = new UserLogin
                {
                    FullName = userModel.FullName,
                    Email = userModel.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(userModel.Password),
                    Roles = userModel.Role,

                };
                var data = await _context.UserLogin.AddAsync(UserReq);
                await _context.SaveChangesAsync();

                var response = new UserModel
                {
                    UserId = data.Entity.UserId,
                    FullName = data.Entity.FullName,
                    Email = data.Entity.Email,
                };
                return Ok(response);
            }catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE: api/UserLogins/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserLogin(Guid id)
        //{
        //    var userLogin = await _context.UserLogin.FindAsync(id);
        //    if (userLogin == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.UserLogin.Remove(userLogin);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool UserLoginExists(Guid id)
        //{
        //    return _context.UserLogin.Any(e => e.UserId == id);
        //}
    }
}
