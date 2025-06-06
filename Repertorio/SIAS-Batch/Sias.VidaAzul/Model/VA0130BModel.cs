
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.VA0130B;

namespace Sias.VidaAzul.Model
{
    public class VA0130BModel
    {
        public VA0130B_LK_PARAMETRO LK_PARAMETRO { get; set; } = new VA0130B_LK_PARAMETRO();
        public string VAMOVTO { get; set; }
        public string MOVCORR { get; set; }
        public string MOVDESP { get; set; }

    }
}
