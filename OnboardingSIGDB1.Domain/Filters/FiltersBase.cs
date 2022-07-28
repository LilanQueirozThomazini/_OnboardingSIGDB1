using System;

namespace OnboardingSIGDB1.Domain.Filters
{
    public class FiltersBase
    {
        public string Nome { get; set; }
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }

        public bool DateTimeValidate()
        {
            if (!DtInicial.HasValue || !DtFinal.HasValue)
                return false;
            if (DtInicial.Value > DtFinal.Value)
                return false;

            return true;
        }

    }
}
