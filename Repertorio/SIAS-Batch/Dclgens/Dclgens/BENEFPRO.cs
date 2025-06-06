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
    public class BENEFPRO : VarBasis
    {
        /*"01  DCLBENEFICIARIOS-PROP.*/
        public BENEFPRO_DCLBENEFICIARIOS_PROP DCLBENEFICIARIOS_PROP { get; set; } = new BENEFPRO_DCLBENEFICIARIOS_PROP();

    }
}