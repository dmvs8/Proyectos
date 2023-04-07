using System;
using System.Collections.Generic;
using ModuloDeCalificaciones.Core;

namespace ModuloDeCalificaciones.Data.Mock
{
    public class ModuloDataSource : IModuloDataSource
    {
        public List<Nota> ObtenerNotas()
        {
            return new List<Nota>()
            {
                new Nota() {
                    LegajoAlumno = "A-43",
                    Curso = 4,
                    Division = "A",
                    Calificacion = 10
                },

                new Nota() {
                    LegajoAlumno = "H-94",
                    Curso = 4,
                    Division = "A",
                    Calificacion = 9
                },

                new Nota() {
                    LegajoAlumno = "M-73",
                    Curso = 7,
                    Division = "D",
                    Calificacion = 9
                },

                new Nota() {
                    LegajoAlumno = "WW-03",
                    Curso = 5,
                    Division = "B",
                    Calificacion = 3
                },

                new Nota() {
                    LegajoAlumno = "L-50",
                    Curso = 9,
                    Division = "C",
                    Calificacion = 8
                }

            };
        }

    }
}
