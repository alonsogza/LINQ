using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _12FiltrandoPorTipo_OfType
    {
        // INI -- Este codigo se usa el ejemplo 2 HERENCIA
        public abstract class Animal
        {
            public abstract string? Nombre { get; set; }
        }

        // ****** LAS CLASES DERIVADAS DE ANIMAL TIENE QUE IMPLEMENTAR **NOMBRE**
        // Por eso las clases Perro y Gato heredan de Animal la propiedad Nombre

        public class Perro : Animal
        {
            public override string? Nombre { get; set; }
        }

        public class Gato : Animal
        {
            public override string? Nombre { get; set; }
        }
        // FIN

        public void Inicio()
        {
            // Listado de Objetos
            var listado = new List<Object>() { "Felipe", 1, 2, "Claudia", true };

            // Ejemplo: extraer en un listado los numeros y otro listado los strings
            var strings = listado.OfType<String>(); // Con esta instruccion solo vamos a obtener los strings de ese listado

            Console.WriteLine($"Lista donde solo se tiene los strings");
            foreach (var str in strings)
            {
                Console.WriteLine(str);
            }
            /* RESULTADO:

            Lista donde solo se tiene los strings
            Felipe
            Claudia
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine($"Lista donde solo se tiene los numeros");

            var numeros = listado.OfType<int>();

            foreach (var numero in numeros)
            {
                Console.WriteLine(numero.ToString());
            }
            /* RESULTADO:

            Lista donde solo se tiene los strings
            1
            2
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            Console.WriteLine($"Lista donde solo se tiene los strings -Sintaxis de QUERY-");
            // Sintaxis por QUERY
            var strings_QUERY = from s in listado.OfType<string>()
                                select s;

            foreach (var str in strings_QUERY)
            {
                Console.WriteLine(str.ToString());
            }
            /* RESULTADO:

            Lista donde solo se tiene los strings -Sintaxis de QUERY-
            Felipe
            Claudia
            */


            /*******************************************************************************************************************/
            // Ejemplo 2: HERENCIA
            /*******************************************************************************************************************/

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine($"Ejemplo de HERENCIAS");
            
            // Para este ejercicio, se va ocupar la siguientes estructura de Animales ( Clases Creadas al Inicio )

            var listadoAnimales = new List<Animal>()
            // Por Poliformismo podemos colocar Perro, Gato, asi como se muestra
            { 
                new Perro() { Nombre = "Firulais"},
                new Gato() {  Nombre = "Felix"}
            };

            var perros = listadoAnimales.OfType<Perro>(); // Aqui con OfType, podemos extraer determinadas clases derivadas de una clase abstracta
                                                            // Muy utili cuando utilizamos herencia don SQL Server y EF podemos extraer a travez de un query una categoria en especifico de una entidad 
            foreach (var perro in perros)
            { 
                Console.WriteLine(perro.ToString());
            };
            /* RESULTADO:
            
            Ejemplo de HERENCIAS
            LINQ.Curso._12FiltrandoPorTipo_OfType+Perro
            */

            Console.WriteLine("-- Mostramos el Nombre del Perro --");
            foreach (var perro in perros)
            {
                Console.WriteLine(perro.Nombre.ToString());
            };
            /* RESULTADO:
            
            -- Mostramos el Nombre del Perro --
            Firulais
            */


        }
    }
}
