using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fp_stack.api.Controllers
{
    
    public class PerguntasController : Controller
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }


        // GET: api/<controller>
        [HttpGet]
        public List<Pergunta> Index()
        {
            return _context.Perguntas.ToList();
        }


    }
}
