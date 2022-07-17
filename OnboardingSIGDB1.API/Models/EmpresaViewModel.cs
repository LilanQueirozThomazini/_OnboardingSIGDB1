using System.ComponentModel.DataAnnotations;

namespace OnboardingSIGDB1.API.Models
{
    public class EmpresaViewModel : BaseViewModel
    {
        [Required]
        public string CNPJ { get; set; }
    }
}
