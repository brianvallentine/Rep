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
    public class COMFEDCA : VarBasis
    {
        /*"01  DCLCOMUNIC-FED-CAP-VA.*/
        public COMFEDCA_DCLCOMUNIC_FED_CAP_VA DCLCOMUNIC_FED_CAP_VA { get; set; } = new COMFEDCA_DCLCOMUNIC_FED_CAP_VA();

    }
}