using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _16Select
    {
        public void Inicio()
        {
            //////---------------------------------------------------------------------------------------------------
            // SELECT: Se puede mostrar algunas propiedades de la clase
            //////---------------------------------------------------------------------------------------------------
            /// Ejemplo: SOLO SELECCIONA NOMBRE
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true },
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true },
                new Persona { Nombre = "Alejandro", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false },
                new Persona { Nombre = "Valentina", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false },
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false }
            };

            var nombres = personas.Select(p => p.Nombre).ToList();

            Console.Write("\r\n");
             Console.WriteLine("---------------------------------------------------------------------------");
             Console.WriteLine($"EJEMPLO: SELECT");


            foreach (var persona in nombres)
            {
                Console.WriteLine($"El Nombre de la persona es: {persona}");
            }
            /* RESULTADO:
              
            EJEMPLO: SELECT
            El Nombre de la persona es: Eduardo
            El Nombre de la persona es: Nidia
            El Nombre de la persona es: Alejandro
            El Nombre de la persona es: Valentina
            El Nombre de la persona es: Roberto

            */

            /*********************************************************************************************/
            /// Ejemplo 2: SELECCIONAR Nombre y Edad

            // Aqui seria instanciar a un OBJETO ANONIMO ( =>  new { ..... )
            var nombresYEdades = personas.Select(p => new { 
                Nombre = p.Nombre,
                Edad = p.Edad,
            }).ToList();

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: SELECT con Nombre y Edad");


            foreach (var persona in nombresYEdades)
            {
                Console.WriteLine($"El Nombre de la persona es: {persona.Nombre} y su Edad es {persona.Edad}");
            }
            /* RESULTADO:

            EJEMPLO: SELECT con Nombre y Edad
            El Nombre de la persona es: Eduardo y su Edad es 30
            El Nombre de la persona es: Nidia y su Edad es 19
            El Nombre de la persona es: Alejandro y su Edad es 19
            El Nombre de la persona es: Valentina y su Edad es 19
            El Nombre de la persona es: Roberto y su Edad es 61

            */

            /*********************************************************************************************/
            /// Ejemplo 3: SELECCIONAR Nombre y Edad para que lo tome una clase DTO

            // Aqui seria instanciar/proyectar a una CLASE DTO (Data Transfer Object) ( => new PersonaDTO { ..... )
            // Aqui se creo una clase PersonaDTO

            var nombresYEdadesDTO = personas.Select(p => new PersonaDTO
            {
                Nombre = p.Nombre,
                Edad = p.Edad,
            }).ToList();

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: SELECT con Nombre y Edad pero usando una Clase DTO");

            foreach (var persona in nombresYEdadesDTO)
            {
                Console.WriteLine($"El Nombre de la persona es: {persona.Nombre} y su Edad es {persona.Edad}");
            }
            /* RESULTADO:

            EJEMPLO: SELECT con Nombre y Edad pero usando una Clase DTO
            El Nombre de la persona es: Eduardo y su Edad es 30
            El Nombre de la persona es: Nidia y su Edad es 19
            El Nombre de la persona es: Alejandro y su Edad es 19
            El Nombre de la persona es: Valentina y su Edad es 19
            El Nombre de la persona es: Roberto y su Edad es 61

            */

            /*********************************************************************************************/
            /// Ejemplo 4: Creamos operacione dentro del SELECT
            /// 
            var numeros = Enumerable.Range(1, 5).ToList();
            var numerosDuplicados = numeros.Select(n => 2 * n).ToList();

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: De una Lista podemos Multiplicar el contenido por 2 ");

            foreach (var numero in numerosDuplicados)
            {
                Console.WriteLine($"El Numero multiplicado : {numero}");
            }
            /* RESULTADO:

            EJEMPLO: De una Lista podemos Multiplicar el contenido por 2
            El Numero multiplicado : 2
            El Numero multiplicado : 4
            El Numero multiplicado : 6
            El Numero multiplicado : 8
            El Numero multiplicado : 10

            */

            /*********************************************************************************************/
            /// Ejemplo 5: Podemos pasar tambien la POSICION ( INDICE ) que contiene en la lista
            /// 
            /// ESTO es la CLAVE: (p,indce) donde se solicita DOS parametros 


            var personasConIndice = personas.Select((p, indice) => new { 
                Persona = p, 
                Indice = indice
            }).ToList();
            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: Conocer el INDICE que tiene el elemento ");

            foreach (var personaConIdx in personasConIndice)
            {
                Console.WriteLine($"{personaConIdx.Indice} ) {personaConIdx.Persona.Nombre}, su edad es {personaConIdx.Persona.Edad}");
            }
            /* RESULTADO:

            EJEMPLO: Conocer el INDICE que tiene el elemento
            0 ) Eduardo, su edad es 30
            1 ) Nidia, su edad es 19
            2 ) Alejandro, su edad es 19
            3 ) Valentina, su edad es 19
            4 ) Roberto, su edad es 61
            */

            /*------------------------------------------------------------------------------------------------*/
            // [Sintaxis de Querys]
            /*------------------------------------------------------------------------------------------------*/

            var nombres_2 = (from p in personas
                            select p.Nombre).ToList();
            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra las Personas usando ahora SELECT [Sintaxis de Querys]\"");

            foreach (var personaQuery in nombres_2)
            {
                Console.WriteLine($"La persona {personaQuery} ");
            }
            /* RESULTADO:

            EJEMPLO: Muestra las Personas usando ahora SELECT [Sintaxis de Querys]"
            La persona Eduardo
            La persona Nidia
            La persona Alejandro
            La persona Valentina
            La persona Roberto
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra las Personas y Edad usando ahora SELECT [Sintaxis de Querys]\"");

            var nombresYEdades_2 = ( from p in personas
                                    select new { /// Para tener MAS de uno, ser crea un objeto ANONIMO **************************************
                                        _Nombre = p.Nombre,
                                        _Edad = p.Edad
                                    }
                                    ).ToList();

            foreach (var personaQuery in nombresYEdades_2)
            {
                Console.WriteLine($"La persona {personaQuery._Nombre} tiene {personaQuery._Edad}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra las Personas y Edad usando ahora SELECT [Sintaxis de Querys]"
            La persona Eduardo tiene 30
            La persona Nidia tiene 19
            La persona Alejandro tiene 19
            La persona Valentina tiene 19
            La persona Roberto tiene 61
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("EJEMPLO: Muestra los DUPLICADOS usando ahora SELECT [Sintaxis de Querys]\"");

            var numerosDuplicados_2 = from n in numeros
                                      select 2 * n;

            foreach (var personaQuery in numerosDuplicados_2)
            {
                Console.WriteLine($"El doble es {personaQuery}");
            }
            /* RESULTADO:

            EJEMPLO: Muestra los DUPLICADOS usando ahora SELECT [Sintaxis de Querys]"
            El doble es 2
            El doble es 4
            El doble es 6
            El doble es 8
            El doble es 10
            */

            Console.Write("\r\n");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine($"EJEMPLO: Conocer el INDICE que tiene el elemento usando ahora SELECT [Sintaxis de Querys]");

            // ************** NO HAY UN EQUIVALENTE en el uso de QUERY para obtener los indices
            /* Esto: 
              
            var personasConIndice = personas.Select((p, indice) => new { 
                Persona = p, 
                Indice = indice
            }).ToList();             

            NO EXISTE para Sintaxis de Query*/

            Console.WriteLine($"NO EXISTE PARA OBTENER ESTO");

            /* RESULTADO:
             
            EJEMPLO: Conocer el INDICE que tiene el elemento usando ahora SELECT [Sintaxis de Querys]
            NO EXISTE PARA OBTENER ESTO             
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
