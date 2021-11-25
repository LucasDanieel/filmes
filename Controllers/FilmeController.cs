using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Repository;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

[Route("Filme")]
    [ApiController]
    public class FilmeController : ControllerBase
    {

        private readonly IFilmeRepository _repository;

        public FilmeController(IFilmeRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Filme>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Filme>> GetById(int id)
        {
            if(_repository.FindId(id) == false)
            {
                return NotFound("Id do filme não identificado");
            }
            return await _repository.Get(id);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult> Put(int id, [FromBody] Filme filme)
        {
            if(id != filme.Id)
            {
                return NotFound("Filme não encontrado");
            }
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.Update(filme);

            return Ok("Filme modificado");
        }

        [HttpPost]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult<List<Filme>>> Post([FromBody] Filme filme)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState.ToList());
            }
            await _repository.Create(filme);
            return Ok("Filme colocado na lista");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public async Task<ActionResult> Del(int id)
        {
            if(_repository.FindId(id) == false)
            {
                return NotFound("Filme não encontrado");
            }
            await _repository.Delete(id);
            return Ok("Filme deletado");
        }
    }