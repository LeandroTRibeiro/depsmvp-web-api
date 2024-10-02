using DepsMvp.Application.Services;
using depsmvp.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace depsmvp.insfrastructure.DB.Repositories;

public class PepsRepository : IPepsRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PepsRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task AddRangePepsAsync(List<Pep> peps, string cpf)
    {
        var pepsToAdd = new List<Pep>();
    
        foreach (var pep in peps)
        {
            var existingPep = await _dbContext.Peps
                .FirstOrDefaultAsync(p => 
                    p.Cpf == pep.Cpf &&
                    p.Nome == pep.Nome &&
                    p.SiglaFuncao == pep.SiglaFuncao &&
                    p.DescricaoFuncao == pep.DescricaoFuncao &&
                    p.NivelFuncao == pep.NivelFuncao &&
                    p.CodOrgao == pep.CodOrgao &&
                    p.NomeOrgao == pep.NomeOrgao &&
                    p.DtInicioExercicio == pep.DtInicioExercicio &&
                    p.DtFimExercicio == pep.DtFimExercicio &&
                    p.DtFimCarencia == pep.DtFimCarencia);
    
            if (existingPep == null)
            {
                pep.SearchDate = DateTime.UtcNow;
                pep.Cpf = cpf;
                pepsToAdd.Add(pep);
            }
        }
        
        if (pepsToAdd.Any())
        {
            await _dbContext.Peps.AddRangeAsync(pepsToAdd);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task<List<Pep>> GetAllPepsByCpfAsync(string cpf)
    {
        var peps = await _dbContext.Peps.Where(p => p.Cpf!.Equals(cpf)).ToListAsync();
        
        return peps;
    }
}