using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CicloDeVidaIDController : ControllerBase
    {
        public readonly IExemploScoped _exemploScoped;

        public CicloDeVidaIDController(IExemploScoped exemploScoped)                                
        {
            _exemploScoped = exemploScoped;
        }

        [HttpGet]
        public Task<string> Get()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Scoped : {_exemploScoped.Id}");

            return Task.FromResult(stringBuilder.ToString());
        }
    }
    public interface IExemploGeral
    {
        public Guid Id { get; }
    }

    public interface IExemploSingleton :IExemploGeral
    { }

    public interface IExemploScoped : IExemploGeral
    { }

    public interface IExemploTransient : IExemploGeral
    { }

    public class ExemploCicloDeVida :  IExemploScoped
    {
        private readonly Guid _guid;

        public ExemploCicloDeVida()
        {
            _guid = Guid.NewGuid();
        }

        public Guid Id => _guid;
    }

}
