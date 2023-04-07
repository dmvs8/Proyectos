using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Final2MVCCore.DAL;
using Final2MVCCore.Models;

namespace Final2MVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly CandidatoDBContext context;

        public HomeController()
        {
            context = new CandidatoDBContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var todosLosCandidatos = context.Candidatos.ToList();
            context.Candidatos.RemoveRange(todosLosCandidatos);
            context.SaveChanges();

            IndexVM model = new IndexVM();

            model.Candidatos = context.Candidatos.ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Agregar(IndexVM model)
        {
            Candidato candidatoAagregar = new Candidato();
            candidatoAagregar.Nombre = model.Nombre;
            candidatoAagregar.PorcentajeDeVotos = model.PorcentajeDeVotos;

            context.Candidatos.Add(candidatoAagregar);
            context.SaveChanges();

            model.Candidatos = context.Candidatos.ToList();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult Index(int id,
                                   string cmdEliminar,
                                   string cmdClonar,
                                   string cmdPorcentajeMenosUno,
                                   string cmdMayMin)
        {


            ModelState.Clear();

            IndexVM model = new IndexVM();

            if (cmdEliminar != null)
            {
                Candidato candidato = context.Candidatos.Find(id);
                if (candidato.PorcentajeDeVotos == 0)
                {
                    context.Candidatos.Remove(candidato);
                    context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", $"El candidato '{candidato.Nombre}' no puede ser eliminado ya que tiene {candidato.PorcentajeDeVotos}% de votos.");
                }
            }
            else if (cmdClonar != null)
            {
                Candidato candidato = context.Candidatos.Find(id);
                Candidato candidatoClon = new Candidato();

                candidatoClon.Nombre = candidato.Nombre + "-Copia";
                candidatoClon.PorcentajeDeVotos = candidato.PorcentajeDeVotos;
                context.Candidatos.Add(candidatoClon);

                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    ModelState.AddModelError("", $"El nombre '{candidatoClon.Nombre}' ya existe.");
                }
            }
            else if (cmdPorcentajeMenosUno != null)
            {
                Candidato candidato = context.Candidatos.Find(id);

                if (candidato.PorcentajeDeVotos > 0)
                {
                    candidato.PorcentajeDeVotos--;
                    context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("", "Porcentaje no puede ser negativo.");
                }
            }
            else if (cmdMayMin != null)
            {
            }

            model.Candidatos = context.Candidatos.ToList();
            return View("Index", model);
        }

    }
}
