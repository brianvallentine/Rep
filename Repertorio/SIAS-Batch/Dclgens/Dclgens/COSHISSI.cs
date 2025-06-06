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
    public class COSHISSI : VarBasis
    {
        /*"01  DCLCOSSEGURO-HIST-SIN.*/
        public COSHISSI_DCLCOSSEGURO_HIST_SIN DCLCOSSEGURO_HIST_SIN { get; set; } = new COSHISSI_DCLCOSSEGURO_HIST_SIN();

    }
}