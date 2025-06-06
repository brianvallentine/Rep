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
    public class SIHISACM : VarBasis
    {
        /*"01  DCLSI-HIST-ACOMP.*/
        public SIHISACM_DCLSI_HIST_ACOMP DCLSI_HIST_ACOMP { get; set; } = new SIHISACM_DCLSI_HIST_ACOMP();

    }
}