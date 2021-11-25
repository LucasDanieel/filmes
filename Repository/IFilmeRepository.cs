using System.Threading.Tasks;
using System.Collections.Generic;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Repository
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> Get();
        Task<Filme> Get(int id);
        Task<Filme> Create(Filme filme);
        Task Update(Filme filme);
        Task Delete(int id);
        bool FindId(int id);
    } 
}