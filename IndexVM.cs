using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final2MVCCore.DAL;
using System.ComponentModel.DataAnnotations;

namespace Final2MVCCore.Models
{
    public class IndexVM
    {
        public string Nombre { get; set; }
        public int PorcentajeDeVotos { get; set; }
        public Candidato Candidato { get; set; }
        public List<Candidato> Candidatos { get; set; }
    }
}