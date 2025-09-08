using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Curso
{
    public class _02EjecucionDiferida
    {
        public void Inicio()
        {
            // En este ejercicio veremos cuando se ejecuta el WHERE, por lo tanto colocamos los siguiente:

            int[] numeros = Enumerable.Range(1,5).ToArray();

            //Sintaxis de Metodo
            // var numerosPares = numeros.Where(n => n % 2 == 0).ToList();   // Ejercio 01
            var numerosPares = numeros.Where(n => {
                Console.WriteLine($"Evaluando si {n} es par");
                return n % 2 == 0;
                });

            // foreach();
        }
    }
}
