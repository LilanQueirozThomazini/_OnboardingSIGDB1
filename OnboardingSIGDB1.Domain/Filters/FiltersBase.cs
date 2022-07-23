using System;

namespace OnboardingSIGDB1.Domain.Filters
{
    public class FiltersBase
    {
        public string Nome { get; set; }
        public DateTime? dtInicial { get; set; }
        public DateTime? dtFinal { get; set; }

        public bool DateTimeValidate()
        {
            if (!dtInicial.HasValue || !dtFinal.HasValue)
                return false;
            if (dtInicial.Value > dtFinal.Value)
                return false;

            return true;
        }

    }
}
