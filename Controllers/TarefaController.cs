
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using gestorTarefas.Context;
using gestorTarefas.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _meubanco.Tarefas.Add(tarefa);
                _meubanco.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Detalhes(int id)
        {
            var busca = _meubanco.Tarefas.Find(id);
            return View(busca);
        }

        public IActionResult Editar(int id)
        {
            var busca = _meubanco.Tarefas.Find(id);
            if (busca == null)
                return RedirectToAction(nameof(Index));
            return View(busca);
        }
        [HttpPost]
        public IActionResult Editar(Tarefa tarefa)
        {
            var tarefaBanco = _meubanco.Tarefas.Find(tarefa.Id);

            tarefaBanco.Titulo = tarefa.Titulo;
            tarefaBanco.Descricao = tarefa.Descricao;
            tarefaBanco.Data = tarefa.Data;
            tarefaBanco.Status = tarefa.Status;

            _meubanco.Tarefas.Update(tarefaBanco);
            _meubanco.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int id)
        {
            var busca = _meubanco.Tarefas.Find(id);
            if (busca == null)
                return RedirectToAction(nameof(Index));
            return View(busca);
        }
        [HttpPost]
        public IActionResult Deletar(Tarefa tarefa)
        {
            var tarefaBanco = _meubanco.Tarefas.Find(tarefa.Id);

            _meubanco.Remove(tarefaBanco);
            _meubanco.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Buscar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buscar(string titulo)
        {
            var buscaBanco = _meubanco.Tarefas.FirstOrDefault(x => x.Titulo == titulo);
            return View(buscaBanco);
        }
    }
}