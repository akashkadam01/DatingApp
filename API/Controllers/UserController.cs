using System.Threading;
using System;
using Microsoft.EntityFrameworkCore;
namespace API;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context){
            _context=context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        [HttpGet("{id:int}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return user;
        }
    }
    
    
