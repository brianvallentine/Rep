
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTTEXTOS;

namespace Sias.Outros.Model
{
    public class PTTEXTOSModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public GECARTEX_DCLGE_CARTA_TEXTO DCLGE_CARTA_TEXTO { get; set; } = new GECARTEX_DCLGE_CARTA_TEXTO();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
