
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.SPBFC003;

namespace Sias.Outros.Model
{
    public class SPBFC003Model
    {
        public StringBasis LK_IN_COD_SEQ { get; set; } = new StringBasis();
        public IntBasis LK_IN_QTD_SEQ { get; set; } = new IntBasis();
        public IntBasis LK_OUT_NUM_SEQ_INI { get; set; } = new IntBasis();
        public IntBasis LK_OUT_NUM_SEQ_FIM { get; set; } = new IntBasis();
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis();
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis();
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis();
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis();
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis();

    }
}
