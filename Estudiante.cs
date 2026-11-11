using System;
using System.Collections.Generic;
using System.Text;

namespace M12_NotasEf
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Nota { get; set; }
        public string Ciudad { get; set; }
        public string? Email { get; set;}
    }
}