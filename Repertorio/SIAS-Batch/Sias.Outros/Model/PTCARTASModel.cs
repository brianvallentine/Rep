
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.PTCARTAS;

namespace Sias.Outros.Model
{
    public class PTCARTASModel
    {
        public LBWCT001_PROTOCOLO_RECEBIDO PROTOCOLO_RECEBIDO { get; set; } = new LBWCT001_PROTOCOLO_RECEBIDO();
        public GECARTA_DCLGE_CARTA DCLGE_CARTA { get; set; } = new GECARTA_DCLGE_CARTA();
        public LBWCT002_PROTOCOLO_ENVIO PROTOCOLO_ENVIO { get; set; } = new LBWCT002_PROTOCOLO_ENVIO();

    }
}
