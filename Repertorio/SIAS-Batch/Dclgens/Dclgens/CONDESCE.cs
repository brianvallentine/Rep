using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Dclgens
{
    public class CONDESCE : VarBasis
    {
        /*"01  DCLCONTROL-DESPES-CEF.*/
        public CONDESCE_DCLCONTROL_DESPES_CEF DCLCONTROL_DESPES_CEF { get; set; } = new CONDESCE_DCLCONTROL_DESPES_CEF();

    }
}