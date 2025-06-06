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
    public class SISINACO : VarBasis
    {
        /*"01  DCLSI-SINISTRO-ACOMP.*/
        public SISINACO_DCLSI_SINISTRO_ACOMP DCLSI_SINISTRO_ACOMP { get; set; } = new SISINACO_DCLSI_SINISTRO_ACOMP();

    }
}