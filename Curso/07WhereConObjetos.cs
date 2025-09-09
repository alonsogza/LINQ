using CursoLINQ;
using LINQ.Curso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _07WhereConObjetos
    {
        public void Inicio()
        {
            // Para este ejercicio se ocupa la clase Persona.cs

            // WHERE con OBJETOS
            var personas = new List<Persona>() 
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            // Ejemplo 1, Buscar a las Personas que son menores a 25 años 
            var personasDe25AñosOMenos = personas.Where(item => item.Edad <= 25).ToList();

            Console.WriteLine("Ejemplo 1");
            foreach (var persona in personasDe25AñosOMenos)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años.");
            };
            /* RESULTADO:

            Ejemplo 1
            Nidia tiene 19 años.
            Valentina tiene 24 años.          
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            // Ejemplo 2, Buscar a las Personas que son Solteros ( true )
            var solteros = personas.Where(p => p.Soltero).ToList();

            Console.WriteLine("Ejemplo 2");
            foreach (var persona in solteros)
            {
                Console.WriteLine($"{persona.Nombre} es soltero/a");
            }
            /* RESULTADO:

            Ejemplo 2
            Eduardo es soltero/a
            Nidia es soltero/a
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            // Ejemplo 3, Buscar a las Personas que son Solteros ( true ) Y que sea menor a 25 años
            var solterosYMayoresDe25 = personas.Where(p => p.Soltero && p.Edad <= 25).ToList();

            Console.WriteLine("Ejemplo 3");
            foreach (var persona in solterosYMayoresDe25)
            {
                Console.WriteLine($"{persona.Nombre} es soltero/a y es Mayor a 25 años");
            }
            /* RESULTADO:

            Ejemplo 3
            Nidia es soltero/a y es Mayor a 25 años            
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            // Ejemplo 4, Buscar a las personas que tengan menos de 3 meses en la empresa 
            var personasConMenosDe3MesesEnLaEmpresa = personas
                                                    .Where(p => p.FechaIngresoAlaEmpresa >= DateTime.Now.AddMonths(-3)).ToList();

            Console.WriteLine("Ejemplo 4");
            foreach (var persona in personasConMenosDe3MesesEnLaEmpresa)
            {
                Console.WriteLine($"{persona.Nombre} tiene menos de 3 meses en la empresa.");
            }

            /* SALIDA: /// Dato Importante, este ejercio lo realice el 9 de Sep 2025 por eso sale Valentina

            Ejemplo 4
            Valentina tiene menos de 3 meses en la empresa.
            Roberto tiene menos de 3 meses en la empresa.
            */
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            // Ejemplo 5, mismo que el ejemplo 4 pero ahora con sintaxis de Query
            // Sintaxis de Query
            var personasConMenosDe3MesesEnLaEmpresaQuery = from p in personas
                                                           where p.FechaIngresoAlaEmpresa >= DateTime.Now.AddMonths(-3)
                                                           select p;

            Console.WriteLine("Ejemplo 5 - Sintaxis por QUERY");
            foreach (var persona in personasConMenosDe3MesesEnLaEmpresaQuery)
            {
                Console.WriteLine($"{persona.Nombre} tiene menos de 3 meses en la empresa. ");
            }

            /* SALIDA: /// Dato Importante, este ejercio lo realice el 9 de Sep 2025 por eso sale Valentina

            Ejemplo 5 - Sintaxis por QUERY
            Valentina tiene menos de 3 meses en la empresa.
            Roberto tiene menos de 3 meses en la empresa.
            */
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

        }
    }
}
