using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fp_stack.core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fp_stack.api.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")] //Atributo Route para configurar rota pelo Controller 
    [Route("api/v{apiVersion}/[controller]")] //Versionando a API (Pelo Controller)
    [EnableCors("Default")] //Usando CORS na controller
    [ApiController]
    public class PerguntasController : Controller
    {
        private readonly Context _context;

        public PerguntasController(Context context)
        {
            _context = context;
        }


        //// GET: api/<controller>
        //[HttpGet]
        //public List<Pergunta> Index()
        //{
        //    return _context.Perguntas.ToList();
        //}


        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Pergunta>))] //Forçando o status code quando retornar o objeto certo
        //[ProducesResponseType(400)] //Forçando o status code quando erro
        //public IActionResult Index()
        //{
        //    //Método Ok para retornar o tipo IActionResult, enquanto encapsula o objeto
        //    var perguntas = _context.Perguntas.ToList();
        //    //Uma pequena regra de validação (Como se fosse o IsValid da ModelState)
        //    if (perguntas.Count() == 3)
        //        return BadRequest(); //Retornar um "Badrequest"

        //    return Ok(perguntas);
        //}


        ////Outra forma de retornar (ActionResult<T>)
        //[HttpGet]
        //public ActionResult<List<Pergunta>> Index()
        //{
        //    //Método Ok para retornar o tipo IActionResult, enquanto encapsula o objeto
        //    var perguntas = _context.Perguntas.ToList();
        //    //Uma pequena regra de validação (Como se fosse o IsValid da ModelState)
        //    if (perguntas.Count() == 3)
        //        return BadRequest(); //Retornar um "Badrequest"

        //    return perguntas;
        //}


        ////Outra forma de retornar (ActionResult<T> com nome Get no método)
        //[Route("")] //Atributo Route para o método
        //public ActionResult<List<Pergunta>> Get()
        //{

        //    var perguntas = _context.Perguntas.ToList();
        //    //Uma pequena regra de validação (Como se fosse o IsValid da ModelState)
        //    if (perguntas.Count() == 0)
        //      return NotFound();

        //    return perguntas;
        //}

        //[HttpPost]
        //[Route("")] //Atributo Route para o método
        //public IActionResult Create(Pergunta pergunta)
        //{
        //    //Apenas um retorno de teste para dizer que foi tudo certo
        //    return Ok();
        //}


        //Retirando os Atributos por causa do ApiController declarado no Controller
        [HttpGet]
        public ActionResult<List<Pergunta>> Get()
        {

            var perguntas = _context.Perguntas.ToList();
            //Uma pequena regra de validação (Como se fosse o IsValid da ModelState)
            //if (perguntas.Count() == 3)
            //    return BadRequest(); //Retornar um "Badrequest"

            return perguntas;
        }
        //Verbo POST para incluir um objeto ao Banco de dados
        //Retirando os Atributos por causa do ApiController declarado no Controller
        [HttpPost]
        public IActionResult Post(Pergunta pergunta)
        {

            if(ModelState.IsValid)
            {
                _context.Perguntas.Add(pergunta);
                _context.SaveChanges(); 
                return Created($"/api/perguntas{pergunta.Id}", pergunta); //Retornando a Url com o ID novo
            }
            //Se não der certo, retorne um "BadRequest" com o ModelState
            return BadRequest(ModelState);
            
        }

        //Verbo PUT para realizar uma atualização
        [HttpPut]
        [Route("{id}")]
        public IActionResult Put(int id,[FromBody]Pergunta pergunta)
        {

            if (ModelState.IsValid)
            {
                //_context.Attach(pergunta); //Não é obrigatório fazer Attach
                _context.Entry(pergunta).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(pergunta); 
            }
            //Se não der certo, retorne um "BadRequest" com o ModelState
            return BadRequest(ModelState);

        }


    }
}
