
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.FC0001S;

namespace Sias.Outros.Model
{
    public class FC0001SModel
    {
        public IntBasis LK_IN_COD_CPF { get; set; } = new IntBasis();
        public IntBasis LK_OUT_COD_CPF { get; set; } = new IntBasis();
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis();
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis();

    }
}
