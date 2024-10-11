using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [MaxLength(200)]
        public string Endereco { get; set; }

        [Required]
        public DateTime DataContratacao { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal ComissaoPercentual { get; set; }

        [Required]
        public decimal MetaMensal { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}