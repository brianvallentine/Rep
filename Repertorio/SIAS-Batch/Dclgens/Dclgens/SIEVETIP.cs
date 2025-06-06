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
    public class SIEVETIP : VarBasis
    {
        /*"01  DCLSI-EVENTO-TIPO.*/
        public SIEVETIP_DCLSI_EVENTO_TIPO DCLSI_EVENTO_TIPO { get; set; } = new SIEVETIP_DCLSI_EVENTO_TIPO();

    }
}