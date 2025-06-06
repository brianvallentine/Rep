
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTACOMPS;

namespace Sias.Outros.Model
{
    public class PTACOMPSModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public GECARACO_DCLGE_CARTA_ACOMP DCLGE_CARTA_ACOMP { get; set; } = new GECARACO_DCLGE_CARTA_ACOMP();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
