
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTACOM2S;

namespace Sias.Outros.Model
{
    public class PTACOM2SModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public SIDOCACO_DCLSI_DOCUMENTO_ACOMP DCLSI_DOCUMENTO_ACOMP { get; set; } = new SIDOCACO_DCLSI_DOCUMENTO_ACOMP();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
