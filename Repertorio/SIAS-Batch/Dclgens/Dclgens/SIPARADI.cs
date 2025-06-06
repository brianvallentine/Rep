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
    public class SIPARADI : VarBasis
    {
        /*"01  DCLSI-PARAM-ADIANT.*/
        public SIPARADI_DCLSI_PARAM_ADIANT DCLSI_PARAM_ADIANT { get; set; } = new SIPARADI_DCLSI_PARAM_ADIANT();

    }
}