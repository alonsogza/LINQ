using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _01Linq
    {
        public void Incio()
        {
            // Ejemplo 01: Obtener numeros pares
            // int[] numeros = { 1, 2, 3, 4, 5 };
            int[] numeros = Enumerable.Range(1,5).ToArray(); // Con esta instruccion podemos generar un rango de numeros.



            // Sintaxis 1: Sintasis de Metodo ****
            var numerosPares = numeros.Where( n=> n % 2 == 0 ).ToList();
            // .ToList() : Es para tener la lista de ese where.

            foreach (var n in numerosPares)
            {
                Console.WriteLine($"Los numeros pares son {n}");
            }

            Console.WriteLine("------------------------");

            // Sintaxis 2: Sintasis de Query (Declaracion declarativa) ****
            var numerosParesQuery = (from n in numeros
                                    where n % 2 == 0
                                    select n).ToList();
            // Se encierra entre parentesis y se pone .ToList para poderlo recorrer y mostrar 

            foreach (var n in numerosParesQuery)
            {
                Console.WriteLine($"Los numeros pares son {n}");
            }

        }
    }
}
