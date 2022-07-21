using System;

namespace OnboardingSIGDB1.Domain.Dto
{
    public class FuncionarioConsultaDTO : FuncionarioDTO
    {
        public int? CargoId { get; set; }
        public string CargoDescricao { get; set; }
        public string EmpresaNome { get; set; }
        public DateTime? DataVinculo { get; set; }
    }
}
