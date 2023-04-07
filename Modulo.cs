using System;
using System.Collections.Generic;

namespace ModuloDeCalificaciones.Core
{
    public class Modulo
    {

        private List<Nota> Notas { get; set; }
        
        
        public Modulo(IModuloDataSource notas)
        {
            Notas = notas.ObtenerNotas();
        }


        public double ObtenerSumaDeTodasLasNotas()
        {
            double sumaTotal = 0;
        
            foreach (Nota item in Notas)
            {
                sumaTotal += item.Calificacion;
            }
        
            return sumaTotal;
        }
        
        
        public int ObtenerCantidadDeNotasCargadas()
        {
            int cantNotasCargadas = 0;
        
            foreach (Nota item in Notas)
            {
                cantNotasCargadas += 1;
            }
        
            return cantNotasCargadas;
        
        }
        
        
        public double ObtenerNotaPromedio()
        {
            return ObtenerSumaDeTodasLasNotas() / ObtenerCantidadDeNotasCargadas();
        }
        
        
        public double ObtenerNota(string legajoAlumno)  
        {
            double nota = 0;
        
            foreach (Nota item in Notas)
            {
                if (item.LegajoAlumno == legajoAlumno)
                {
                    nota = item.Calificacion;
                    break;
                }
                else
                {
                    nota = -1;
                }
            }
        
            return nota;
        }


    }
}
