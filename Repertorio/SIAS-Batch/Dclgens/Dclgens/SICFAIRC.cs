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
    public class SICFAIRC : VarBasis
    {
        /*"01  DCLSICOB-FAIXA-RCAP.*/
        public SICFAIRC_DCLSICOB_FAIXA_RCAP DCLSICOB_FAIXA_RCAP { get; set; } = new SICFAIRC_DCLSICOB_FAIXA_RCAP();

    }
}