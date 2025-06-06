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
    public class GE353 : VarBasis
    {
        /*"01  DCLGE-DNE-TRIAGEM.*/
        public GE353_DCLGE_DNE_TRIAGEM DCLGE_DNE_TRIAGEM { get; set; } = new GE353_DCLGE_DNE_TRIAGEM();

    }
}