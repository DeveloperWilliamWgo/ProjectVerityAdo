using System;

namespace ProjectVerity.Domain.Entities
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
