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
    public class PARCEVID : VarBasis
    {
        /*"01  DCLPARCELAS-VIDAZUL.*/
        public PARCEVID_DCLPARCELAS_VIDAZUL DCLPARCELAS_VIDAZUL { get; set; } = new PARCEVID_DCLPARCELAS_VIDAZUL();

    }
}