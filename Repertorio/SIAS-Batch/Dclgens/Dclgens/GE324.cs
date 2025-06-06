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
    public class GE324 : VarBasis
    {
        /*"01  DCLGE-DNE-LOCALIDADE.*/
        public GE324_DCLGE_DNE_LOCALIDADE DCLGE_DNE_LOCALIDADE { get; set; } = new GE324_DCLGE_DNE_LOCALIDADE();

    }
}