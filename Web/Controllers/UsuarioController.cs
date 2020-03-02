using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IAppUsuario _appUsuario;

        public UsuarioController(IAppUsuario appUsuario)
        {
            _appUsuario = appUsuario;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Titulo"] = "Página Inicial";

            var usuariosModel = new List<UsuarioModel>();

            _appUsuario.Listar()
                .ForEach(u => usuariosModel.Add(new UsuarioModel()
                {
                    IdDoUsuario = u.Id,
                    NomeDoUsuario = u.NomeDoUsuario,
                    EmailDoUsuario = u.EmailDoUsuario,
                    SenhaDoUsuario = u.SenhaDoUsuario
                })); ;

            return View(usuariosModel);
        }

        [HttpGet]
        public IActionResult CadastrarUsuario()
        {
            ViewData["Titulo"] = "Novo Usuário";

            return View(new UsuarioModel());
        }

        [HttpPost]
        public IActionResult CadastrarUsuario(UsuarioModel usuarioModel)
        {
            _appUsuario.Adicionar(new Usuario()
            {
                NomeDoUsuario = usuarioModel.NomeDoUsuario,
                EmailDoUsuario = usuarioModel.EmailDoUsuario,
                SenhaDoUsuario = usuarioModel.SenhaDoUsuario
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditarUsuario(int id)
        {
            ViewData["Tituto"] = "Editar Usuário";

            var usuarioModel = _appUsuario.Listar()
                .Where(u => u.Id == id)
                .Select(u => new UsuarioModel()
                {
                    IdDoUsuario = id,
                    NomeDoUsuario = u.NomeDoUsuario,
                    EmailDoUsuario = u.EmailDoUsuario,
                    SenhaDoUsuario = u.SenhaDoUsuario
                }).Single();

            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuarioModel usuarioModel)
        {
            var usuario = _appUsuario.Listar()
                .Where(u => u.Id == usuarioModel.IdDoUsuario)
                .Select(u => new Usuario()
                {
                    Id = usuarioModel.IdDoUsuario,
                    NomeDoUsuario = usuarioModel.NomeDoUsuario,
                    EmailDoUsuario = usuarioModel.EmailDoUsuario,
                    SenhaDoUsuario = usuarioModel.SenhaDoUsuario
                })
                .Single();

            _appUsuario.Editar(usuario);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExcluirUsuario(int id)
        {
            ViewData["Titulo"] = "Excluir Usuário";

            var usuarioModel = _appUsuario.Listar()
                .Where(u => u.Id == id)
                .Select(u => new UsuarioModel()
                {
                    IdDoUsuario = id,
                    NomeDoUsuario = u.NomeDoUsuario,
                    EmailDoUsuario = u.EmailDoUsuario,
                    SenhaDoUsuario = u.SenhaDoUsuario
                })
                .Single();

            return View(usuarioModel);
        }

        [HttpPost]
        public IActionResult ExcluirUsuario(UsuarioModel usuarioModel)
        {
            var usuario = _appUsuario.Listar()
                .Where(u => u.Id == usuarioModel.IdDoUsuario)
                .Select(p => new Usuario()
                {
                    Id = usuarioModel.IdDoUsuario
                })
                .Single();

            _appUsuario.Excluir(usuario.Id);

            return RedirectToAction("Index");
        }
    }
}
