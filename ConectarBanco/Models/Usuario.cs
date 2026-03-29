using System.ComponentModel.DataAnnotations;

namespace ConectarBanco.Models
{
    public class Usuario
    {
        [Display(Name = "Código")]
        public int? IdUsu {  get; set; }

        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string nomeUsu { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string Cargo { get; set; }

        [Display(Name = "Nascimento")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [DataType(DataType.DateTime)]   
        public DateTime DataNasc { get; set; }

        [Display(Name = "CEP", Description = "CEP.")]
        [MaxLength(10, ErrorMessage = "O cep deve ter entre 6 e 10 caracteres")]
        [Required(ErrorMessage = "O CEP é obrigatório.")]
        public string CEP { get; set; }

        [Display(Name = "Estado", Description = "Estado.")]
        [Required(ErrorMessage = "O Estado é obrigatório.")]
        public string Estado { get; set; }

        [Display(Name = "Cidade", Description = "Cidade.")]
        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro", Description = "Bairro.")]
        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Display(Name = "Endereco", Description = "Endereco.")]
        [Required(ErrorMessage = "O Endereco é obrigatório.")]
        public string Logradouro { get; set; }

        [Display(Name = "Complemento", Description = "Complemento.")]
        [Required(ErrorMessage = "O Complemento é obrigatório.")]
        public string Complemento { get; set; }

        [Display(Name = "Número", Description = "Complemento.")]
        public string Numero { get; set; }
    }
}
