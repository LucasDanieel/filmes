using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;

namespace Cinema.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
   
        private readonly DataContext _context;

        public FilmeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Filme> Create(Filme filme)
        {
            _context.Filme.Add(filme);
            await _context.SaveChangesAsync(); 
            return filme;
        }

        public async Task Delete(int id)
        {
            var filme = await _context.Filme.FindAsync(id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();            
        }

        public async Task<IEnumerable<Filme>> Get()
        {
            return await _context.Filme.ToListAsync();
        }

        public async Task<Filme> Get(int id)
        {
            return await _context.Filme.FindAsync(id);
        }

        public async Task Update(Filme filme)
        {
            _context.Entry(filme).State = EntityState.Modified;
           await _context.SaveChangesAsync();
        }

        public bool FindId(int id)
        {
            var result = _context.Filme.Find(id);
            if(result == null)
            {
                return false;
            }
            return true;
        }
    }
}