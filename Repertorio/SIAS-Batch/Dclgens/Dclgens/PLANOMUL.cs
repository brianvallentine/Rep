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
    public class PLANOMUL : VarBasis
    {
        /*"01  DCLPLANOS-MULTISAL.*/
        public PLANOMUL_DCLPLANOS_MULTISAL DCLPLANOS_MULTISAL { get; set; } = new PLANOMUL_DCLPLANOS_MULTISAL();

    }
}