using System;
using System.Collections.Generic;
using ModuloDeCalificaciones.Core;

namespace ModuloDeCalificaciones.Data.Production
{
    public class ModuloDataSource : IModuloDataSource
    {
        public List<Nota> ObtenerNotas()
        {
            return new List<Nota>()
            {
                new Nota() {
                    LegajoAlumno = "B-88",
                    Curso = 2,
                    Division = "C",
                    Calificacion = 10
                },

                new Nota() {
                    LegajoAlumno = "Z-30",
                    Curso = 4,
                    Division = "D",
                    Calificacion = 5
                },

                new Nota() {
                    LegajoAlumno = "O-63",
                    Curso = 8,
                    Division = "B",
                    Calificacion = 6
                },

                new Nota() {
                    LegajoAlumno = "F-70",
                    Curso = 6,
                    Division = "A",
                    Calificacion = 9
                },

                new Nota() {
                    LegajoAlumno = "YY-94",
                    Curso = 5,
                    Division = "A",
                    Calificacion = 10
                }

            };
        }

    }
}
