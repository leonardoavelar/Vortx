using System;
using System.Text.Json.Serialization;

namespace VxTel.Site.Domain.DTO
{
    public class TelefoneClienteDTO : BaseDTO
    {
        public int ClienteId { get; set; }

        [JsonIgnore]
        public ClienteDTO Cliente { get; set; }

        public string Ddd { get; set; }

        public long Telefone { get; set; }

        public TelefoneClienteDTO() { }

        public TelefoneClienteDTO(int id, int clienteId, string ddd, long telefone)
            : base (id)
        {
            SetValue(clienteId, ddd, telefone);
        }

        public TelefoneClienteDTO(int clienteId, string ddd, long telefone)
        {
            SetValue(clienteId, ddd, telefone);
        }

        private void SetValue(int clienteId, string ddd, long telefone)
        {
            ClienteId = clienteId;
            Ddd = ddd;
            Telefone = telefone;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is TelefoneClienteDTO cliente &&
                   Id == cliente.Id &&
                   ClienteId == cliente.ClienteId &&
                   Ddd == cliente.Ddd &&
                   Telefone == cliente.Telefone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ClienteId, Ddd, Telefone, Cliente);
        }
    }
}
