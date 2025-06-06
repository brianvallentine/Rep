
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.BI0230B;

namespace Sias.Bilhetes.Model
{
    public class BI0230BModel
    {
        public BI0230B_LK_PARAM LK_PARAM { get; set; } = new BI0230B_LK_PARAM();
        public string ARQSIG01 { get; set; }
        public string ARQSIG02 { get; set; }

    }
}
