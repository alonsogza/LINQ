using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _08First_FirstOrDefault
    {
        public void Inicio()
        {
            // Tambien se puede usar FILTROS por posicion, First o FirstOrDefault

            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            // Ejemplo 1: Obtner la primera persona del objeto con la instruccion First**
            // IMPORTANTE: Se coloca un BreakPoint en Console.WriteLine("----....
            //                  Para ver el contenido en la variable: **primeraPersona
            var primeraPersona = personas.First();
            /* RESULTADO:

            Ejemplo 1
            Eduardo  
            */

            // Ejemplo 2: Obtner la primera persona del objeto pero con la instruccion FirstOnDefualt**
            // IMPORTANTE: Se coloca un BreakPoint en Console.WriteLine("----....
            //                  Para ver el contenido en la variable: **primeraPersonaFirstOrDefault
            var primeraPersonaFirstOrDefault = personas.FirstOrDefault();
            /* RESULTADO:

            Ejemplo 2
            Eduardo  
            */

            Console.WriteLine("---------------------------------------------------------------------------");

            /*
              
            IMPORTANTE:
                First() : Nos va dar el primer elemento del objeto, pero si esta VACIO nos va marcar un ERROR
                FirstOrDefault() : nos va dar el primer elemento del objeto, pero si esta VACIO nos va a proporcionar un DEFAULT del tipo, 
                                    Por ejemplo
                                        de un INTEGER el Default es un CERO
                                        de un STRING el Default es un VACIO
                                        de un LISTA el Default es un NULL

            */

            // Ejemplo para demostrar lo escrito en IMPORTANTE

            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con First();");

            var paises = new List<string>();
            try
            {
                var primerPais = paises.First();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un Error");
                // throw;
            }
            /* RESULTADO:

            Ejemplo con First();
            Ha ocurrido un Error
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con FirstOrDefault();");

            var primerPais_FirstOrDefault = paises.FirstOrDefault();
            // primerPais_FirstOrDefault contiene NULL

            Console.WriteLine($"Valor {primerPais_FirstOrDefault}");
            /* RESULTADO:

            Ejemplo con FirstOrDefault();
            Valor
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con FirstOrDefault() con Numeros;");

            var numeros = new List<int>();
            var primerNumero = numeros.FirstOrDefault();
            Console.WriteLine($"Valor {primerNumero}");
            /* RESULTADO:

            Ejemplo con FirstOrDefault() con Numeros;
            Valor 0            
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo con el Objeto <Persona> FirstOrDefault() para encontrar la primera persona NO Solter@;");

            var primeraPersonaNoSoltera = personas.FirstOrDefault( item => !item.Soltero); // Solo obtiene la primera persona que cumpla la condicion
            Console.WriteLine($"La persona es {primeraPersonaNoSoltera.Nombre}");
            /* RESULTADO:

            Ejemplo con el Objeto <Persona> FirstOrDefault() para encontrar la primera persona NO Solter@;
            La persona es Alejandro           
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Mismo Ejemplo del anterior pero usando Sintaxis de Query");

            var primeraPersonaNoSoltera_Query = (from persona in personas
                                                where !persona.Soltero
                                                select persona).FirstOrDefault();
            // Es importante encerrar el query entre parentisis para usar el FirstOrDefault()

            Console.WriteLine($"La persona es {primeraPersonaNoSoltera_Query.Nombre}");
            /* RESULTADO:

            Mismo Ejemplo del anterior pero usando Sintaxis de Query
            La persona es Alejandro           
            */


        }
    }
}
