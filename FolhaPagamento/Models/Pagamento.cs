using System.ComponentModel.DataAnnotations.Schema;

namespace FolhaPagamento.Models
{
    [Table("Pagamentos")]
    public class Pagamento
    {
        public int PagamentoID { get; set; }
        public int UsuarioID { get; set; }
        public User? Usuario { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Descontos { get; set; }
        public decimal Bonus { get; set; }
        public decimal HorasExtras { get; set; }
        public decimal ValorLiquido { get; set; }
        public string? EstadoPagamento { get; set; }
    }
}
