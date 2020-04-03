using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers
{
    [Route("api/v1/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterTodasAsPessoas(
            [FromServices]ApiDbContext dbContext
        )
        {
            return Ok(await dbContext.Pessoas.AsNoTracking().ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> IncluirPessoa(
            Pessoa pessoa,
            [FromServices]ApiDbContext dbContext
        )
        {
            await dbContext.Pessoas.AddAsync(pessoa);
            var result = await dbContext.SaveChangesAsync();

            return Ok(new
            {
                success = result > 0 ? true : false
            });
        }
    }
}
