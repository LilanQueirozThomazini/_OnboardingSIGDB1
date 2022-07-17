using System.ComponentModel.DataAnnotations;

namespace OnboardingSIGDB1.API.Models
{
    public class FuncionarioViewModel : BaseViewModel
    {
        [Required]
        public string CPF { get; set; }
    }
}
