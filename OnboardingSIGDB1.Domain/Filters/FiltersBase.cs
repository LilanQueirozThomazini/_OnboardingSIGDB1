using System;

namespace OnboardingSIGDB1.Domain.Filters
{
    public class FiltersBase
    {
        public string Nome { get; set; }
        public DateTime? dtInicial { get; set; }
        public DateTime? dfFinal { get; set; }
    }
}
