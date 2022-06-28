using System.Collections.Generic;

namespace VxTel.Domain.Entity
{
    public partial class Cliente : BaseEntity
    {
        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public virtual ICollection<Chamada> Chamadas { get; private set; }

        public virtual ICollection<Consumo> Consumos { get; private set; }

        public virtual ICollection<Contrato> Contratos { get; private set; }

        public virtual ICollection<TelefoneCliente> TelefonesCliente { get; private set; }

        public Cliente(int id, string nome, string documento)
            : base(id)
        {
            Nome = nome;
            Documento = documento;
            Chamadas = new HashSet<Chamada>();
            Consumos = new HashSet<Consumo>();
            Contratos = new HashSet<Contrato>();
            TelefonesCliente = new HashSet<TelefoneCliente>();
        }
    }
}
