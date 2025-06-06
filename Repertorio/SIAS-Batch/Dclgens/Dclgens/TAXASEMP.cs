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
    public class TAXASEMP : VarBasis
    {
        /*"01  DCLTAXAS-EMPRESARIAL.*/
        public TAXASEMP_DCLTAXAS_EMPRESARIAL DCLTAXAS_EMPRESARIAL { get; set; } = new TAXASEMP_DCLTAXAS_EMPRESARIAL();

    }
}