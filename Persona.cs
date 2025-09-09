using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// --------------------------------------------------------------------------
// --------------- Funcion WHERE con Objetos ( Clase 7 ) --------------
// --------------------------------------------------------------------------

namespace CursoLINQ
{
    [DebuggerDisplay("{Nombre}")] // Con esta linea nos va ayudar cuando estemos en modo DEBUG
    internal class Persona
    {
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public bool Soltero { get; set; }
        public DateTime FechaIngresoAlaEmpresa { get; set; }
        public List<string> Telefonos = new List<string>();
        public int EmpresaId { get; set; }
    }
}
