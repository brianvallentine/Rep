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
    public class FONTES : VarBasis
    {
        /*"01  DCLFONTES.*/
        public FONTES_DCLFONTES DCLFONTES { get; set; } = new FONTES_DCLFONTES();

    }
}