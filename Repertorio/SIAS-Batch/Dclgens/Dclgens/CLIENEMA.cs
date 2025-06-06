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
    public class CLIENEMA : VarBasis
    {
        /*"01  DCLCLIENTE-EMAIL.*/
        public CLIENEMA_DCLCLIENTE_EMAIL DCLCLIENTE_EMAIL { get; set; } = new CLIENEMA_DCLCLIENTE_EMAIL();

    }
}