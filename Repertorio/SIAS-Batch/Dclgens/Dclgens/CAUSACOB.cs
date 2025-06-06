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
    public class CAUSACOB : VarBasis
    {
        /*"01  DCLCAUSA-COBERTURA.*/
        public CAUSACOB_DCLCAUSA_COBERTURA DCLCAUSA_COBERTURA { get; set; } = new CAUSACOB_DCLCAUSA_COBERTURA();

    }
}