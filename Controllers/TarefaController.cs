using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gestorTarefas.Context;

namespace gestorTarefas.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefasContext _meubanco;
        public TarefaController(TarefasContext context)
        {
            _meubanco = context;
        }
        public IActionResult Index()
        {
            var todasTarefas = _meubanco.Tarefas.ToList();
            return View(todasTarefas);

        }
    }
}