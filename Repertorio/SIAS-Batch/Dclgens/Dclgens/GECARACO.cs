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
    public class GECARACO : VarBasis
    {
        /*"01  DCLGE-CARTA-ACOMP.*/
        public GECARACO_DCLGE_CARTA_ACOMP DCLGE_CARTA_ACOMP { get; set; } = new GECARACO_DCLGE_CARTA_ACOMP();

    }
}