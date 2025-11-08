using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _15Reverse
    {
        public void Inicio()
        {
            //////---------------------------------------------------------------------------------------------------
            // Se puede REVERTIR el orden de una coleccion usando REVERSE, sin embargo hay que 
            // que considerar que la operacion de REVERSE trabaja mejor en un ENUMERABLE que en un LISTADO
            //////---------------------------------------------------------------------------------------------------
            // Ejemplo con un ENUMERABLE
            var numeros = Enumerable.Range(1, 20);

            Console.WriteLine("EJEMPLO: Muestra el Enumerable Ordenarda");
            foreach (var numero in numeros)
            {
                Console.WriteLine($"{numero}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra el Enumerable Ordenarda
            1
            2
            3
            4
            5
            6
            7
            8
            9
            10
            11
            12
            13
            14
            15
            16
            17
            18
            19
            20            
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra el Enumerable usando ahora REVERSE");
            var numerosReverse = Enumerable.Range(1, 20).Reverse();

            foreach (var numero in numerosReverse)
            {
                Console.WriteLine($"{numero}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra el Enumerable usando ahora REVERSE
            20
            19
            18
            17
            16
            15
            14
            13
            12
            11
            10
            9
            8
            7
            6
            5
            4
            3
            2
            1
            */
            /*********************************************************************************************/

            // Ahora con la LISTA DE PERSONAS

            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            // var personasInvertido = personas.Reverse(); 
            // De esta Forma [var personasInvertido = personas.Reverse()] marca error porque quiere REVERTIR el colocamiento de PERSONAS
            // pero no crea un nuevo LISTADO, sin embargo, si lo dejamos asi: "personas.Reverse()" no marca el ERROR
            personas.Reverse();

            var a = 1; // Esta linea es para colocar un BreakPoint y ver la linea anterior ( personas.Reverse(); )

            /* RESULTADO:

            Se muestra: 
            [0] | "Roberto"
            [1] | "Valentina"
            [2] | "Alejandro"
            [3] | "Nidia"
            [4] | "Eduardo"

            */

            //*** sin embargo si QUEREMOS TENER LA INFORMACION se requiere crear una ENUMERABLE
            var personas02 = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };



            // var personasInvertido = personas02.AsEnumerable().Reverse(); // LINEA IMPORTANTE
            var personasInvertido = personas02.AsEnumerable().Reverse().ToList(); // LINEA IMPORTANTE TAMBIEN SE PUEDE USAR con ToList()

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: DE personas02 = new List<Persona>() A personasInvertido = personas02.AsEnumerable().Reverse();");


            foreach (var persona in personasInvertido)
            {
                Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
            }
            /* RESULTADO:
            
            EJEMPLO: DE personas02 = new List<Persona>() A personasInvertido = personas02.AsEnumerable().Reverse();
            Roberto tiene 61 años de edad
            Valentina tiene 19 años de edad
            Alejandro tiene 19 años de edad
            Nidia tiene 19 años de edad
            Eduardo tiene 30 años de edad
            
            */

            /*------------------------------------------------------------------------------------------------*/
            // [Sintaxis de Querys]
            /*------------------------------------------------------------------------------------------------*/

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra el Enumerable usando ahora REVERSE [Sintaxis de Querys]\"");
            var numeros_qry = from n in Enumerable.Range(1, 20).Reverse()
                              select n;
            foreach (var numero in numeros_qry)
            {
                Console.WriteLine($"{numero}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra el Enumerable usando ahora REVERSE [Sintaxis de Querys]"
            20
            19
            18
            17
            16
            15
            14
            13
            12
            11
            10
            9
            8
            7
            6
            5
            4
            3
            2
            1

            */

            // Console.Write("\r\n");
            // Console.WriteLine("---------------------------------------------------------------------------");
            // Console.WriteLine($"EJEMPLO: xXxXxXxXxXxXxXxXxX");

            ///////----------------------------------------------------------------------------- 
            /////// TO-DO: 
            ///             Me quede en minuto 0:01
            ///////-----------------------------------------------------------------------------
            ///
        }
    }
}