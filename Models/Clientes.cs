using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsteticaEProcedimentos.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public long Telefone { get; set; }
        public string Endereço { get; set; }
        public string Email { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        private int ContarCaracteres(string dado)
        {
            return dado.Length;
        }
        public bool ValidarCpf()
        {
            if(ContarCaracteres(CPF) == 11)
                return true;
            else
                return false;
        }
    }
}