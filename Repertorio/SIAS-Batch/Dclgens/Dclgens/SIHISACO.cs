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
    public class SIHISACO : VarBasis
    {
        /*"01  DCLSI-HIST-ACOMPANHA.*/
        public SIHISACO_DCLSI_HIST_ACOMPANHA DCLSI_HIST_ACOMPANHA { get; set; } = new SIHISACO_DCLSI_HIST_ACOMPANHA();

    }
}