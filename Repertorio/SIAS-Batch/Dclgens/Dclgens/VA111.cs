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
    public class VA111 : VarBasis
    {
        /*"01  DCLVA-CAMPANHA-CARENCIA.*/
        public VA111_DCLVA_CAMPANHA_CARENCIA DCLVA_CAMPANHA_CARENCIA { get; set; } = new VA111_DCLVA_CAMPANHA_CARENCIA();

    }
}