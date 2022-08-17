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

        public IActionResult Sumary() 
        {
            var Categorizadas = _context.Noticias.Where(n => n.Positiva || n.Negativa || n.Neutra).Count();
            var Positivas = _context.Noticias.Where(n => n.Positiva).Count();
            var Negativas = _context.Noticias.Where(n => n.Negativa).Count();
            var Neutras = _context.Noticias.Where(n => n.Neutra).Count();

            ViewBag.Categorizadas = Categorizadas;
            if (Categorizadas > 0)
            {
                ViewBag.PercentualPositivas = decimal.Divide(Positivas, Categorizadas) * 100;
                ViewBag.PercentualNegativas = decimal.Divide(Negativas, Categorizadas) * 100;
                ViewBag.PercentualNeutras = decimal.Divide(Neutras, Categorizadas) * 100;
            }
            else
            {
                ViewBag.PercentualPositivas = 0;
                ViewBag.PercentualNegativas = 0;
                ViewBag.PercentualNeutras = 0;
            }

            return View();
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

        [Route("/home/positiva")]
        [HttpGet]
        public IActionResult Positiva(int id)
        {
            try
            {
                var noticia = _context.Noticias.First(p => p.Id == id);
                noticia.Positiva = true;
                noticia.Negativa = false;
                noticia.Neutra = false;
                _context.SaveChanges();
                return Ok(new { status = true });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, mensagem = ex.Message });
            }
        }
        [Route("/home/negativa")]
        [HttpGet]
        public IActionResult Negativa(int id)
        {
            try
            {
                var noticia = _context.Noticias.First(p => p.Id == id);
                noticia.Positiva = false;
                noticia.Negativa = true;
                noticia.Neutra = false;
                _context.SaveChanges();
                return Ok(new { status = true });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, mensagem = ex.Message });
            }
        }
        [Route("/home/neutra")]
        [HttpGet]
        public IActionResult Neutra(int id)
        {
            try
            {
                var noticia = _context.Noticias.First(p => p.Id == id);
                noticia.Positiva = false;
                noticia.Negativa = false;
                noticia.Neutra = true;
                _context.SaveChanges();
                return Ok(new { status = true });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, mensagem = ex.Message });
            }
        }


    }
}
