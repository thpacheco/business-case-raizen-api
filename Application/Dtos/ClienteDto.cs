using System.ComponentModel.DataAnnotations;

namespace Business.Case.Raizen.Api.Application.Dtos
{
    public class ClienteDto
    {
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cep { get; set; }
    }
}
