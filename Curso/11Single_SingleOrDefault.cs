using CursoLINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _11Single_SingleOrDefault
    {
        public void Inicio()
        {
            // SINGLE: sirve para REVISAR que una Coleccion SOLO tenga un ELEMENTO, en caso que tenga CERO o MAS de UNO va a mostrar un error.
            // SINGLEorDEFAULT: si la Coleccion NO TIENE elementos (cero) NO muestra error pero si tiene MAS de UNO si va a mostrar un error.
            var personas = new List<Persona>()
            {
                new Persona { Nombre = "Eduardo", Edad = 30, FechaIngresoAlaEmpresa = new DateTime(2021, 1, 2), Soltero = true},
                new Persona { Nombre = "Nidia", Edad = 19, FechaIngresoAlaEmpresa = new DateTime(2015, 11, 22), Soltero = true},
                new Persona { Nombre = "Alejandro", Edad = 45, FechaIngresoAlaEmpresa = new DateTime(2020, 4, 12), Soltero = false},
                new Persona { Nombre = "Valentina", Edad = 24, FechaIngresoAlaEmpresa = new DateTime(2025, 7, 8), Soltero = false},
                new Persona { Nombre = "Roberto", Edad = 61, FechaIngresoAlaEmpresa = DateTime.Now.AddDays(-1), Soltero = false}
            };

            Console.WriteLine("Ejemplo con SINGLE donde buscamos personas mayores a 60 años");
            var personaMayorDe60 = personas.Single( p => p.Edad > 60);
            // En este ejemplo no marca error, ya que SOLO tenemos una persona que si cumple la condición.
            // Es la fortaleza de este metodo, donde VALIDA tener SOLO un ELEMENTO
            Console.WriteLine($"La persona {personaMayorDe60.Nombre} es mayor de 60 años");
            /* RESULTADO:

            Ejemplo con SINGLE donde buscamos personas mayores a 60 años
            La persona Roberto es mayor de 60 años
            */

            // Sintaxis de QUERY
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Mismo ejemplo del Anterior pero usando -- Sintaxis de QUERY --");
            var personaMayorDe60_QUERY = (from persona in personas
                                          where persona.Edad > 60
                                          select persona).Single();
            Console.WriteLine($"La persona {personaMayorDe60.Nombre} es mayor de 60 años");
            /* RESULTADO:

            Mismo ejemplo del Anterior pero usando -- Sintaxis de QUERY --
            La persona Roberto es mayor de 60 años
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo donde la consulta es CERO ELEMENTOS porque no tenemos personas mayores a 100 ( va mostrar ERROR)");
            try
            {
                var personaMayoresA100 = personas.Single(item => item.Edad > 100);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un Error, arreglo vacio");
                // throw;
            }
            /* RESULTADO:

            Ejemplo donde la consulta es CERO ELEMENTOS porque no tenemos personas mayores a 100 ( va mostrar ERROR)
            Ha ocurrido un Error, arreglo vacio
            */


            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo donde la consulta CONTIENE MAS DE UN ELEMENTO porque tenemos personas mayores a 5 ( va mostrar ERROR)");
            try
            {
                var personasMayoresA5 = personas.Single( p => p.Edad > 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un Error, arreglo tiene MAS de un Elemento");
                // throw;
            }
            /* RESULTADO:

            Ejemplo donde la consulta CONTIENE MAS DE UN ELEMENTO porque tenemos personas mayores a 5 ( va mostrar ERROR)
            Ha ocurrido un Error, arreglo tiene MAS de un Elemento             
             */


            /*******************************************************************************************************************/
            // SingleOrDefualt
            /*******************************************************************************************************************/
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo donde la consulta es CERO ELEMENTOS pero USANDO -SingleOrDefault- ");
            try
            {
                var personaMayoresA100 = personas.SingleOrDefault(item => item.Edad > 100);
                Console.WriteLine($"USANDO -SingleOrDefault- personas mayores a 100 {personaMayoresA100} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >.< ");
                // throw;
            }
            /* RESULTADO:

            Ejemplo donde la consulta es CERO ELEMENTOS pero USANDO -SingleOrDefault-
            USANDO -SingleOrDefault- personas mayores a 100
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Ejemplo donde la consulta CONTIENE MAS DE UN ELEMENTO pero USANDO -SingleOrDefault- ( va mostrar ERROR)");
            try
            {
                var personasMayoresA5 = personas.SingleOrDefault(p => p.Edad > 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un Error, arreglo tiene MAS de un Elemento");
                // throw;
            }
            /* RESULTADO:

            Ejemplo donde la consulta CONTIENE MAS DE UN ELEMENTO pero USANDO -SingleOrDefault- ( va mostrar ERROR)
            Ha ocurrido un Error, arreglo tiene MAS de un Elemento            
             */


        }
    }
}
