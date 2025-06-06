
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTFASESS;

namespace Sias.Outros.Model
{
    public class PTFASESSModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public SISINFAS_DCLSI_SINISTRO_FASE DCLSI_SINISTRO_FASE { get; set; } = new SISINFAS_DCLSI_SINISTRO_FASE();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
