using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _09Last_LastOrDefault
    {
        public void Inicio()
        {
            // Es el INVERSO de First y FirstOrDefault, para los metodos: Last y LastOrDefault busca los ULTIMOS ELEMENTOS
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            Console.WriteLine("Ejemplo con Last();");
            var ultimaPersona = personas.Last();
            Console.WriteLine($"La ultima persona es {ultimaPersona.Nombre}");
            /* RESULTADO:

            Ejemplo con Last();
            La ultima persona es Roberto
            */


            /*              
            IMPORTANTE:
                Last() : Nos va dar el ULTIMO elemento del objeto, pero si esta VACIO nos va marcar un ERROR
                LastOrDefault() : nos va dar el ULTIMO elemento del objeto, pero si esta VACIO nos va a proporcionar un DEFAULT del tipo, 
                                    Por ejemplo
                                        de un INTEGER el Default es un CERO
                                        de un STRING el Default es un VACIO
                                        de un LISTA el Default es un NULL
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con Busqueda");

            var ultimaPersonaSoltera = personas.Last( item => item.Soltero);
            Console.WriteLine($"La última persona soltera es {ultimaPersonaSoltera.Nombre}");

            /* RESULTADO:

            Ejemplo con Busqueda
            La última persona soltera es Nidia
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Mismo Ejemplo del anterior pero usando Sintaxis de Query");

            var ultimaPersonaSoltera_QUERY = (from p in personas
                                             where p.Soltero
                                             select p).Last();
            // Es importante encerrar el query entre parentisis para usar el Last() o LastOrDefault()

            Console.WriteLine($"La última persona soltera es {ultimaPersonaSoltera_QUERY.Nombre}");

            /* RESULTADO:

            Mismo Ejemplo del anterior pero usando Sintaxis de Query
            La última persona soltera es Nidia
            */

        }
    }
}
