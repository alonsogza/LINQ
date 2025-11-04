using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _14ThenBy_ThenByDescending
    {
        public void Inicio()
        {
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };


            // con .ThenBy() podemos solicitar el orden con OTRAS PROPIEDADES 
            Console.WriteLine("Ejemplo: Ordenar las Personas por la Edad, Nombre");
            var personasOrdenadasPorEdad = personas.OrderBy(item => item.Edad).ThenBy(x => x.Nombre);

            foreach (var persona in personasOrdenadasPorEdad)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:

            Ejemplo: Ordenar las Personas por la Edad, Nombre
            Alejandro tiene 19 años de edad                     ****
            Nidia tiene 19 años de edad                         ****
            Valentina tiene 19 años de edad                     ****
            Eduardo tiene 30 años de edad
            Roberto tiene 61 años de edad

            ***** 3 Personas tiene la misma edad (19), despues se ordena por Nombre.
            */


            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar de forma ASCENTENTE para la Edad y DESCENDIENTE en Nombre");

            var personasOrdenadasPorEdad_yDescendentePorNombre = personas.OrderBy(item => item.Edad).ThenByDescending(x => x.Nombre);

            foreach (var persona in personasOrdenadasPorEdad_yDescendentePorNombre)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:
              
            Ejemplo: Ordenar de forma ASCENTENTE para la Edad y DESCENDIENTE en Nombre
            Valentina tiene 19 años de edad                     ****
            Nidia tiene 19 años de edad                         ****
            Alejandro tiene 19 años de edad                     ****
            Eduardo tiene 30 años de edad
            Roberto tiene 61 años de edad

            ***** 3 Personas tiene la misma edad (19), despues se ordena descendente por Nombre.
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar de forma ASCENTENTE por la Edad y DESCENDIENTE por Nombre [Sintaxis de Querys]\"");

            var personasOrdenadasPorEdad_Qry = from p in personas
                                                     orderby p.Edad, p.Nombre descending
                                                     select p;

            foreach (var persona in personasOrdenadasPorEdad_Qry)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:

            Ejemplo: Ordenar de forma ASCENTENTE por la Edad y DESCENDIENTE por Nombre [Sintaxis de Querys]"
            Valentina tiene 19 años de edad
            Nidia tiene 19 años de edad
            Alejandro tiene 19 años de edad
            Eduardo tiene 30 años de edad
            Roberto tiene 61 años de edad
            */
        }
    }
}