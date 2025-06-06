
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTACOMOS;

namespace Sias.Outros.Model
{
    public class PTACOMOSModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public SISINACO_DCLSI_SINISTRO_ACOMP DCLSI_SINISTRO_ACOMP { get; set; } = new SISINACO_DCLSI_SINISTRO_ACOMP();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
