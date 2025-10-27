using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _13OrderBy_OrderByDescending
    {
        public void Inicio()
        {
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };


            Console.WriteLine("Ejemplo: Ordenar las Personas por la Edad");
            var personasOrdenadasPorEdad = personas.OrderBy( item => item.Edad);

            foreach (var persona in personasOrdenadasPorEdad)
            { 
                Console.WriteLine($"{ persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:

            Ejemplo: Ordenar las Personas por la Edad
            Nidia tiene 19 años de edad
            Valentina tiene 24 años de edad
            Eduardo tiene 30 años de edad
            Alejandro tiene 45 años de edad
            Roberto tiene 61 años de edad
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar de forma DESCENDIENTE");

            var personaOrdenadaPorDescendiente = personas.OrderByDescending( x => x.Edad);
            foreach (var persona in personaOrdenadaPorDescendiente)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:
            
            ---------------------------------------------------------------------------
            Ejemplo: Ordenar de forma DESCENDIENTE
            Roberto tiene 61 años de edad
            Alejandro tiene 45 años de edad
            Eduardo tiene 30 años de edad
            Valentina tiene 24 años de edad
            Nidia tiene 19 años de edad
            */
            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar los numeros");

            int[] numeros = { 1, 5, 12, 2, 3, 111, 6 };

            // Tambien podemos ordenarlos en el foreach
            foreach (var numero in numeros.OrderBy(valor => valor)) // valor => valor : es por el valor de SI MISMO
            {
                Console.WriteLine(numero);
            }
            /* RESULTADO:
            
            ---------------------------------------------------------------------------
            Ejemplo: Ordenar los numeros
            1
            2
            3
            5
            6
            12
            111
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar los numeros por [Sintaxis de Querys]");
            
            var numeros_qry = from n in numeros
                              orderby n
                              select n;

            // Tambien podemos ordenarlos en el foreach
            foreach (var numero in numeros_qry) // valor => valor : es por el valor de SI MISMO
            {
                Console.WriteLine(numero);
            }
            /* RESULTADO:
            
            ---------------------------------------------------------------------------
            Ejemplo: Ordenar los numeros
            1
            2
            3
            5
            6
            12
            111
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"Ejemplo: Ordenar de forma DESCENDIENTE por [Sintaxis de Querys]\"");

            var personaOrdenadaPorDescendiente_Qry = from p in personas
                                                     orderby p.Edad descending
                                                     select p;

            foreach (var persona in personaOrdenadaPorDescendiente_Qry)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:
            
            ---------------------------------------------------------------------------
            Ejemplo: Ordenar de forma DESCENDIENTE por [Sintaxis de Querys]"
            Roberto tiene 61 años de edad
            Alejandro tiene 45 años de edad
            Eduardo tiene 30 años de edad
            Valentina tiene 24 años de edad
            Nidia tiene 19 años de edad
            */
        }
    }
}
