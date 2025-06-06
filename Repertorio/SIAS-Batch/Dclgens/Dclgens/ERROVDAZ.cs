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
    public class ERROVDAZ : VarBasis
    {
        /*"01  DCLERROS-VIDAZUL.*/
        public ERROVDAZ_DCLERROS_VIDAZUL DCLERROS_VIDAZUL { get; set; } = new ERROVDAZ_DCLERROS_VIDAZUL();

    }
}