
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.VG9020S;

namespace Sias.VidaEmGrupo.Model
{
    public class VG9020SModel
    {
        public IntBasis CSP_NRCERTIF { get; set; } = new IntBasis();
        public IntBasis H_OUT_COD_RETORNO { get; set; } = new IntBasis();
        public IntBasis H_OUT_COD_RETORNO_SQL { get; set; } = new IntBasis();
        public StringBasis H_OUT_MENSAGEM { get; set; } = new StringBasis();
        public StringBasis H_OUT_SQLERRMC { get; set; } = new StringBasis();
        public StringBasis H_OUT_SQLSTATE { get; set; } = new StringBasis();

    }
}
