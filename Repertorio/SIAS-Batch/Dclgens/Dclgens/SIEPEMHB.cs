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
    public class SIEPEMHB : VarBasis
    {
        /*"01  DCLSI-ESTIP-EMIS-HAB.*/
        public SIEPEMHB_DCLSI_ESTIP_EMIS_HAB DCLSI_ESTIP_EMIS_HAB { get; set; } = new SIEPEMHB_DCLSI_ESTIP_EMIS_HAB();

    }
}