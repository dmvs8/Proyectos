using System;
using ModuloDeCalificaciones.Core;
using ModuloDeCalificaciones.Data.Production; // Se puede intercambiar entre "Mock" y "Production"


IModuloDataSource dataSource = new ModuloDataSource();

Modulo modulo1 = new Modulo(dataSource);



Console.WriteLine("Suma de todas las notas: " + modulo1.ObtenerSumaDeTodasLasNotas());


Console.WriteLine();
Console.WriteLine("Cantidad de notas cargadas: " + modulo1.ObtenerCantidadDeNotasCargadas());


Console.WriteLine();
Console.WriteLine("Nota promedio: " + modulo1.ObtenerNotaPromedio());


string alumno = "A-43";
Console.WriteLine();
Console.WriteLine("La nota del alumno " + alumno  + " es " + modulo1.ObtenerNota(alumno));