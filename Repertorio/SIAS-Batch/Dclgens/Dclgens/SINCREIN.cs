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
    public class SINCREIN : VarBasis
    {
        /*"01  DCLSINISTRO-CRED-INT.*/
        public SINCREIN_DCLSINISTRO_CRED_INT DCLSINISTRO_CRED_INT { get; set; } = new SINCREIN_DCLSINISTRO_CRED_INT();

    }
}