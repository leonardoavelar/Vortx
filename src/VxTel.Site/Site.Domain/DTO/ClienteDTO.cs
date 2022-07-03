using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VxTel.Site.Domain.DTO
{
    public class ClienteDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(100)]
        [Display(Name = "Nome Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 18, MinimumLength = 14)]
        [Display(Name = "CPF / CNPJ")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Display(Name = "DDD")]
        public string Ddd { get; set; }

        [Required(ErrorMessage = "{0} required")]
        //[StringLength(maximumLength: 8, MinimumLength = 9)]
        //[MinLength(8)]
        //[MaxLength(9)]
        [Display(Name = "Telefone")]
        public long Telefone { get; set; }

        public ICollection<ChamadaDTO> Chamadas { get; set; }

        public ICollection<ConsumoDTO> Consumos { get; set; }

        public ICollection<ContratoDTO> Contratos { get; set; }

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
                   Documento == cliente.Documento &&
                   Ddd == cliente.Ddd &&
                   Telefone == cliente.Telefone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Documento, Ddd, Telefone);
        }
    }
}
