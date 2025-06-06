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
    public class SI112 : VarBasis
    {
        /*"01  DCLSI-RESSARC-ACORDO.*/
        public SI112_DCLSI_RESSARC_ACORDO DCLSI_RESSARC_ACORDO { get; set; } = new SI112_DCLSI_RESSARC_ACORDO();

    }
}