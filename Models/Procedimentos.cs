using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsteticaEProcedimentos.Models
{
    public class Procedimentos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descriçao { get; set; }
        public double ValorProcedimento { get; set; }
        public string ProfissionalResponsavel { get; set; }
        
    }
}