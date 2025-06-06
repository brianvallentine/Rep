
using Copies;
using Dclgens;
using IA_ConverterCommons;
using static Code.SI5001B;

namespace Sias.Sinistro.Model
{
    public class SI5001BModel
    {
        public SI5001B_LINK_PARM_CONV_PROCESSADO LINK_PARM_CONV_PROCESSADO { get; set; } = new SI5001B_LINK_PARM_CONV_PROCESSADO();
        public string MVDBCCOR { get; set; }
        public string PRINTER { get; set; }

    }
}
