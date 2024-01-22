using Dapper.Contrib.Extensions;

namespace Business.Case.Raizen.Api.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataNascimento { get; set; }
        public string cep { get; set; }
    }
}
