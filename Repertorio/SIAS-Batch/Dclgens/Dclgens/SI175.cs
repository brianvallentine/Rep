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
    public class SI175 : VarBasis
    {
        /*"01  DCLSI-PESS-SINISTRO.*/
        public SI175_DCLSI_PESS_SINISTRO DCLSI_PESS_SINISTRO { get; set; } = new SI175_DCLSI_PESS_SINISTRO();

    }
}