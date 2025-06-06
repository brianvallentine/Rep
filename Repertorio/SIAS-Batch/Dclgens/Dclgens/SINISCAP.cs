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
    public class SINISCAP : VarBasis
    {
        /*"01  DCLSINISTRO-CAPALOTE1.*/
        public SINISCAP_DCLSINISTRO_CAPALOTE1 DCLSINISTRO_CAPALOTE1 { get; set; } = new SINISCAP_DCLSINISTRO_CAPALOTE1();

    }
}