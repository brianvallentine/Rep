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
    public class EF050 : VarBasis
    {
        /*"01  DCLEF-CONTRATO.*/
        public EF050_DCLEF_CONTRATO DCLEF_CONTRATO { get; set; } = new EF050_DCLEF_CONTRATO();

    }
}