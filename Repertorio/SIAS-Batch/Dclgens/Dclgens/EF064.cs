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
    public class EF064 : VarBasis
    {
        /*"01  DCLEF-CONTRATO-SEGURO.*/
        public EF064_DCLEF_CONTRATO_SEGURO DCLEF_CONTRATO_SEGURO { get; set; } = new EF064_DCLEF_CONTRATO_SEGURO();

    }
}