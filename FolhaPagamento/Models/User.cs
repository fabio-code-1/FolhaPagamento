using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FolhaPagamento.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Username { get; set; }

        [Required]
        [StringLength(100)]
        public string? Password { get; set; }

        [Required]
        public int UserRole { get; set; }
        public string UserRoleDescription
        {
            get
            {
                return UserRole == 1 ? "Administrador" : UserRole == 2 ? "Colaborador" : "Desconhecido";
            }
        }

        [Required]
        [StringLength(100)]
        public string? Cargo { get; set; }

        // Campos específicos do funcionário
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string? Endereco { get; set; }

        [Required]
        [StringLength(20)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(20)]
        public string? RG { get; set; }

        [Required]
        [StringLength(20)]
        public string? CPF { get; set; }
    }
}
