using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Cinema.Services;

namespace Cinema.Controllers
{
    [Route("Users")]
    public class UserController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<List<User>>> Get([FromServices] DataContext context)
        {
            var users = await context.User.AsNoTracking().ToListAsync();
            return users;
        }

        [HttpPost]
        // [AllowAnonymous]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody]User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //model.Role = "employee";

                context.User.Add(model);
                await context.SaveChangesAsync();

                model.Password = "";
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<User>> Put(
            [FromServices] DataContext context,
            int id,
            [FromBody]User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != model.Id)
                return NotFound(new { message = "Usuário não encontrada" });

            try
            {
                context.Entry(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });

            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(
            [FromServices] DataContext context,
            [FromBody]User model)
        {
            var user = await context.User
                .AsNoTracking()
                .Where(x => x.Name == model.Name && x.Password == model.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}