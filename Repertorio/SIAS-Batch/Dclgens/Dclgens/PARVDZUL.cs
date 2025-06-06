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
    public class PARVDZUL : VarBasis
    {
        /*"01  DCLPARCELAS-VIDAZUL.*/
        public PARVDZUL_DCLPARCELAS_VIDAZUL DCLPARCELAS_VIDAZUL { get; set; } = new PARVDZUL_DCLPARCELAS_VIDAZUL();

    }
}