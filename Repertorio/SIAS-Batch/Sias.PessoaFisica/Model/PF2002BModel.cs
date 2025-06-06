
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PF2002B;

namespace Sias.PessoaFisica.Model
{
    public class PF2002BModel
    {
        public PF2002B_PF2002B_SYSIN PF2002B_SYSIN { get; set; } = new PF2002B_PF2002B_SYSIN();
        public string SORTWK01 { get; set; }
        public string MOVCOB { get; set; }
        public string ARQSAI1 { get; set; }

    }
}
