using Dados.Context;
using Dados.Entidades;
using Clipping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Clipping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contexto _context;

        public HomeController(ILogger<HomeController> logger,Contexto contexto)
        {
            _logger = logger;
            _context = contexto;
        }

        public IActionResult Index(int p = 1)
        {
            var registrosPorPagina = 10;
            var basePaginacao = registrosPorPagina * (p - 1);
            var totalRegistros = _context.Noticias.Count();
            var NumeroPaginas = totalRegistros / registrosPorPagina;
            if ((totalRegistros % registrosPorPagina) > 0)
                NumeroPaginas++;

            var resultado = _context.Noticias.Skip(basePaginacao).Take(registrosPorPagina).ToList();

            ViewBag.PaginaAtual = p;
            ViewBag.TotalRegistros = registrosPorPagina;
            ViewBag.NumeroPaginas = NumeroPaginas;

            return View(resultado);
        }

        public IActionResult Privacy()
        {
           
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
