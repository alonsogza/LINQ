using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _10ElementAt_ElementAtOrDefault
    {
        public void Inicio()
        {
            // Podemos seleccionar un Elemento en un lugar en especifico, para esto se usa ElementAt y ElementAtOrDefault
            // es como seleccionar el Elemento que se encuentre en lugar 3, por ejemplo
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            Console.WriteLine("Ejemplo con ElementAt (tercera posicion)");
            var terceraPersona = personas.ElementAt(2);
            Console.WriteLine($"La persona que se encuentra en la tercera posicion es {terceraPersona.Nombre}");
            /* RESULTADO:

            Ejemplo con ElementAt (tercera posicion)
            La persona que se encuentra en la tercera posicion es Alejandro
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con ElementAtOrDefault (Sexta posicion // NO EXISTE)");
            var sextaPersona = personas.ElementAtOrDefault(5);

            Console.WriteLine($"La persona que se encuentra en la sexta posicion es {sextaPersona}");
            /* RESULTADO:

            Ejemplo con ElementAtOrDefault (Sexta posicion // NO EXISTE)
            La persona que se encuentra en la sexta posicion es
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Mismo ejemplo del anterior pero usando sintaxis de Query");
            var sextaPersona_QUERY = (from p in personas
                                    select p).ElementAtOrDefault(5);
            
            Console.WriteLine($"La persona que se encuentra en la sexta posicion es {sextaPersona_QUERY}");
            /* RESULTADO:

            Mismo ejemplo del anterior pero usando sintaxis de Query
            La persona que se encuentra en la sexta posicion es
            */


        }
    }
}
