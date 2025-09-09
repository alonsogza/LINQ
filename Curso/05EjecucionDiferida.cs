using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _05EjecucionDiferida
    {
        public void Inicio()
        {
            // En este ejercicio veremos cuando se ejecuta el WHERE, por lo tanto colocamos los siguiente:

            int[] numeros = Enumerable.Range(1,5).ToArray();

            //Sintaxis de Metodo
            // var numerosPares = numeros.Where(n => n % 2 == 0).ToList();   // Es del ejercio 01

            var numerosPares = numeros.Where(n => {
                Console.WriteLine($"Evaluando si {n} es par");
                return n % 2 == 0;
                });

            // IMPORTANTE, para este ejercicio, colocamos un BreackPoint en el "foreach..." para ver que
            //      las lineas "var numerosPares = numeros.Where(n => {..." AUN NO SE HAN EJECUTADO por esa RAZON no se ve en CONSOLA,
            //      se evaluara cuando pasemos el foreach
            foreach ( var numero in numerosPares)
            {
                Console.WriteLine($"Si, el {numero} es par.");
            }
            // Cuando pasamos el foreach, este es el RESULTADO:
            /*
            Evaluando si 1 es par
            Evaluando si 2 es par
            Si, el 2 es par.
            Evaluando si 3 es par
            Evaluando si 4 es par
            Si, el 4 es par.
            Evaluando si 5 es par
            */

            // LOS WHERE SE EVALUAN CONFORME SE NECESITA, en caso contrario, si agregamos un .ToList() o .ToArray(),
            //      esto provaca que SI se EVALUE, forzando la evaluacion

            Console.WriteLine("---------------------------------------------------------------------------");

            // Ejemplo 2: agregando .ToList()
            var numerosPares02 = numeros.Where(n => {
                Console.WriteLine($"Evaluando si {n} es par");
                return n % 2 == 0;
            }).ToList();

            // Colocar un BrakPoint en este foreach y veremos en consola que ya pinta datos
            foreach (var numero in numerosPares02)
            {
                Console.WriteLine($"Si, el {numero} es par.");
            }
            /*
            RESULTADO teniendo el BREAKPOINT en foreach:

            ---------------------------------------------------------------------------
            Evaluando si 1 es par
            Evaluando si 2 es par
            Evaluando si 3 es par
            Evaluando si 4 es par
            Evaluando si 5 es par             
            */

            // Le damos Continuar al BreakPoint y esto es lo que muestra la consola ( Programa Finalizado )
            /*
            Evaluando si 1 es par
            Evaluando si 2 es par
            Evaluando si 3 es par
            Evaluando si 4 es par
            Evaluando si 5 es par
            Si, el 2 es par.
            Si, el 4 es par.
            */


        }
    }
}
