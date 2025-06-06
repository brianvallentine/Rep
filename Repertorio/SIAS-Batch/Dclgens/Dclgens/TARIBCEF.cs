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
    public class TARIBCEF : VarBasis
    {
        /*"01  DCLTARIFA-BALCAO-CEF.*/
        public TARIBCEF_DCLTARIFA_BALCAO_CEF DCLTARIFA_BALCAO_CEF { get; set; } = new TARIBCEF_DCLTARIFA_BALCAO_CEF();

    }
}