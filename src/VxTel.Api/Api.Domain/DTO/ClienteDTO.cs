using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VxTel.Api.Domain.DTO
{
    public class ClienteDTO : BaseDTO
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        [JsonIgnore]
        public ICollection<ChamadaDTO> Chamadas { get; set; }

        [JsonIgnore]
        public ICollection<ConsumoDTO> Consumos { get; set; }

        public ICollection<ContratoDTO> Contratos { get; set; }

        public ICollection<TelefoneClienteDTO> TelefonesCliente { get; set; }

        public ClienteDTO() { }

        public ClienteDTO(int id, string nome, string documento)
            : base(id)
        {
            SetValue(nome, documento);
        }

        public ClienteDTO(string nome, string documento)
        {
            SetValue(nome, documento);
        }

        private void SetValue(string nome, string documento)
        {
            Nome = nome;
            Documento = documento;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ClienteDTO cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Documento == cliente.Documento;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Documento);
        }
    }
}
