
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.FC0105S;

namespace Sias.Outros.Model
{
    public class FC0105SModel
    {
        public IntBasis LK_NUM_PLANO { get; set; } = new IntBasis();
        public IntBasis LK_NUM_SERIE { get; set; } = new IntBasis();
        public IntBasis LK_NUM_TITULO { get; set; } = new IntBasis();
        public DoubleBasis LK_NUM_PROPOSTA { get; set; } = new DoubleBasis();
        public IntBasis LK_QTD_TITULOS { get; set; } = new IntBasis();
        public DoubleBasis LK_VLR_TITULO { get; set; } = new DoubleBasis();
        public IntBasis LK_EMP_PARCEIRA { get; set; } = new IntBasis();
        public IntBasis LK_COD_RAMO { get; set; } = new IntBasis();
        public IntBasis LK_NUM_NSA { get; set; } = new IntBasis();
        public StringBasis LK_TRACE { get; set; } = new StringBasis();
        public IntBasis LK_OUT_COD_RETORNO { get; set; } = new IntBasis();
        public IntBasis LK_OUT_SQLCODE { get; set; } = new IntBasis();
        public StringBasis LK_OUT_MENSAGEM { get; set; } = new StringBasis();
        public StringBasis LK_OUT_SQLERRMC { get; set; } = new StringBasis();
        public StringBasis LK_OUT_SQLSTATE { get; set; } = new StringBasis();

    }
}
