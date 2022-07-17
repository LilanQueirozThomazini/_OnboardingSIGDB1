using System;
using System.ComponentModel.DataAnnotations;

namespace OnboardingSIGDB1.API.Models
{
    public class BaseViewModel
    {
        [Required]
        public string Nome { get; set; }
        public DateTime? dtInicial { get; set; }
        public DateTime? dfFinal { get; set; }
    }
}
