using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VxTel.Api.Domain.DTO
{
    public class ClienteDTO : BaseDTO
    {
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Ddd { get; set; }

        public long Telefone { get; set; }

        [JsonIgnore]
        public ICollection<ChamadaDTO> Chamadas { get; set; }

        [JsonIgnore]
        public ICollection<ConsumoDTO> Consumos { get; set; }

        public ICollection<ContratoDTO> Contratos { get; set; }

        public ClienteDTO() { }

        public ClienteDTO(int id, string nome, string documento, string ddd, long telefone)
            : base(id)
        {
            SetValue(nome, documento, ddd, telefone);
        }

        public ClienteDTO(string nome, string documento, string ddd, long telefone)
        {
            SetValue(nome, documento, ddd, telefone);
        }

        private void SetValue(string nome, string documento, string ddd, long telefone)
        {
            Nome = nome;
            Documento = documento;
            Ddd = ddd;
            Telefone = telefone;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ClienteDTO cliente &&
                   Id == cliente.Id &&
                   Nome == cliente.Nome &&
                   Documento == cliente.Documento &&
                   Ddd == cliente.Ddd &&
                   Telefone == cliente.Telefone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Documento);
        }
    }
}
