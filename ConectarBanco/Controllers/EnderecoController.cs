using ConectarBanco.Models;
using ConectarBanco.Repository.Contract;
using Microsoft.AspNetCore.Mvc;

namespace ConectarBanco.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
        public IActionResult Index()
        {
            return View(_enderecoRepositorio.ObterTodosEnderecos());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Cadastrar(endereco);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
