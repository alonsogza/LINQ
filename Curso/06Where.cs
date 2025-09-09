using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LINQ.Curso
{
    public class _06Where
    {

        public void Inicio()
        {
            int[] numeros = Enumerable.Range(0, 20).ToArray();

            // Ejemplo con una SOLA condicion
            var numerosImpares = numeros.Where( item => item % 2 == 1).ToList();

            Console.WriteLine("Los numeros Impares son: ");
            foreach (var numero in numerosImpares)
            {
                Console.WriteLine(numero);
            }
            /* RESULTADO:
              
            Los numeros Impares son:
            1
            3
            5
            7
            9
            11
            13
            15
            17
            19              
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");

            // ---- Ejemplo con DOS condicion ( Impar y Mayores a 10 ) ---- 

            // Sintaxis de Metodo o Lamnda
            var numerosImparesMayoresQue10 = numeros.Where( item =>  (item % 2 == 1 && item > 10)).ToList();

            Console.WriteLine("Los numeros Impares MAYORES a 10 son: ");
            foreach (var numero in numerosImparesMayoresQue10) 
            { 
                Console.WriteLine($"{numero}"); 
            }
            /* RESULTADO:
              
            Los numeros Impares MAYORES a 10 son:
            11
            13
            15
            17
            19
            */

            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\r\n");
            Console.WriteLine("Sintaxis de Query");

            var numerosImparesMayoresQue10_QUERY = from item in numeros
                                                   where item % 2 == 1 && item > 10
                                                   select item;

            foreach (var numero in numerosImparesMayoresQue10_QUERY)
            {
                Console.WriteLine($"{numero}");
            }
            /* RESULTADO:

            Sintaxis de Query
            11
            13
            15
            17
            19
            */
        }
    }
}
