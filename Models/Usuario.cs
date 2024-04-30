using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EsteticaEProcedimentos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public byte []? PasswordHash { get; set; }
        public byte []? PasswordSalt { get; set; }
        public DateTime? DataAcesso { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        [NotMapped]
        public string PasswordString { get; set; } = string.Empty;
        public List<Clientes> Clientes { get; set; } = new List<Clientes>();
    }
}