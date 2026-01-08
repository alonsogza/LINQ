using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _17SelectMany
    {
        public void Inicio()
        {
            ////// ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // SELECT MANY: Se puede MANEJAR varias colecciones de manera SIMULTANEA, para ello se puede aplanar varias colecciones en UNA
            // Una Coleccion APLANADA se puede decir que es una coleccion de elementos o una Lista con todos los elementos  
            //////------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Telefonos = { "123-456", "789-852" } },
                new Persona { Nombre = "Nidia", Telefonos = { "998-478", "568-222" } },
                new Persona { Nombre = "Alejandro", Telefonos = { "714-132" } },
                new Persona { Nombre = "Valentina"}
            };

            // En la coleccion "personas" se observa que algunas personas tienen 2 telefonos, uno o ninguno. 
            // En este ejercicio, se quiere CREAR una coleccion con TODOS los telefonos y se requiere usar SELECT MANY

            var telefonos = personas.SelectMany(p => p.Telefonos).ToList();
            /* Resultado */
            /* Me crea una LISTA con Index y el Valor
               Idx  String
               (0)  123-456
               (1)  789-852
               (2)  998-478
               (3)  568-222
               (4)  714-132
            */

            // LA SIGUIENTE LINEA ES PARA CONOCER LA DIFERENCIA
            var telefonosSelect = personas.Select(p => p.Telefonos).ToList();
            /* Resultado */
            /* Me crea una Coleccion con mas colecciones adentro ---> tres campos ( Lista, Capacidad y Cantidad )

            List,                   List.Capacity, List.Count
            "[123-456, 789-852]",   4,              2
            "[998-478, 568-222]",   4,              2
            [714-132],              4,              1
            [],                     0,              0
            */

            // var a = 1; //////////////////////////// Linea STOP para ver el contenido de las Variables Anteriores


            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: Mezclar dos colecciones");
            // Para este ejercicio, se crea una coleccion de numeros
            int[] numeros = { 1, 2, 3 };
            // Lo que se busca es Mezclar la coleccion "personas", para mezclar con la de "numeros" buscando un resultado de:
            /*
            1 Eduardo
            2 Eduardo
            3 Eduardo
            1 Nidia
            2 Nidia
            3 Nidia
            1 Alejandro.......


            En SQL se podria decir que es un CROSS JOIN
            */

            var personasYNumeros = personas.SelectMany(p => numeros, (persona, numero) => new
            {
                Persona = persona,
                Numero = numero,
            });
            // Con esta instruccion estamos diciendo que COMBINE las PERSONAS con NUMEROS ( personas.SelectMany(p => numeros,...  y de esa combinacion obten persona y numero ( (persona, numero) =>  ... ) para crear un objecto NUEVO con la informacion

            foreach (var item in personasYNumeros)
            {
                Console.WriteLine($" {item.Persona.Nombre} - {item.Numero}");
            }
            /* RESULTADO:

            EJEMPLO: Mezclar dos colecciones
             Eduardo - 1
             Eduardo - 2
             Eduardo - 3
             Nidia - 1
             Nidia - 2
             Nidia - 3
             Alejandro - 1
             Alejandro - 2
             Alejandro - 3
             Valentina - 1
             Valentina - 2
             Valentina - 3
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO 3: Personas y telefonos ( crear un directorio telefonico ) ");
            var personasYTelefonos = personas.SelectMany(p => p.Telefonos, (persona, telefono) => new
            {
                Persona = persona,
                Telefono = telefono,
            });

            foreach (var item in personasYTelefonos)
            {
                Console.WriteLine($" {item.Persona.Nombre} - {item.Telefono}");
            }
            /* RESULTADO:

            EJEMPLO 3: Personas y telefonos ( crear un directorio telefonico )
             Eduardo - 123-456
             Eduardo - 789-852
             Nidia - 998-478
             Nidia - 568-222
             Alejandro - 714-132
            */


            /*------------------------------------------------------------------------------------------------*/
            // [Sintaxis de Querys]
            /*------------------------------------------------------------------------------------------------*/
            var personas_Querys = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Telefonos = { "123-456", "789-852" } },
                new Persona { Nombre = "Nidia", Telefonos = { "998-478", "568-222" } },
                new Persona { Nombre = "Alejandro", Telefonos = { "714-132" } },
                new Persona { Nombre = "Valentina"}
            };

            var telefonos_2 = from p in personas_Querys                // Aqui se seleccionan a las PERSONAS
                              from telefono in p.Telefonos      // Aqui de las peronsas seleccionamos el telefono en la variable "telefono"
                              select telefono;
            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra los Telefonos usando [Sintaxis de Querys]\"");

            foreach (var personaQuery in telefonos_2)
            {
                Console.WriteLine($"El telefono {personaQuery} ");
            }
            /* RESULTADO:

            EJEMPLO: Muestra las Personas usando ahora SELECT [Sintaxis de Querys]"
            El telefono 123-456
            El telefono 789-852
            El telefono 998-478
            El telefono 568-222
            El telefono 714-132
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra las Personas y Telefonos usando [Sintaxis de Querys]\"");

            var personasYNumeros_2 = from p in personas_Querys
                                     from n in numeros
                                     select new
                                     {
                                         Persona = p,
                                         Numero = n
                                     };

            foreach (var personaQuery in personasYNumeros_2)
            {
                Console.WriteLine($"La Persona es {personaQuery.Persona.Nombre} y el Numero es {personaQuery.Numero}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra las Personas y Telefonos usando [Sintaxis de Querys]"
            La Persona es Eduardo y el Numero es 1
            La Persona es Eduardo y el Numero es 2
            La Persona es Eduardo y el Numero es 3
            La Persona es Nidia y el Numero es 1
            La Persona es Nidia y el Numero es 2
            La Persona es Nidia y el Numero es 3
            La Persona es Alejandro y el Numero es 1
            La Persona es Alejandro y el Numero es 2
            La Persona es Alejandro y el Numero es 3
            La Persona es Valentina y el Numero es 1
            La Persona es Valentina y el Numero es 2
            La Persona es Valentina y el Numero es 3
            */












            //Console.Write("\r\n");
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.WriteLine($"EJEMPLO: xXxXxXxXxXxXxXxXxX");
            //
            ///////----------------------------------------------------------------------------- 
            /////// TO-DO: 
            /////// Me quede en minuto 0:01
            ///////-----------------------------------------------------------------------------

        }
    }
}
