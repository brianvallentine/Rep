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
    public class CBAPOVIG : VarBasis
    {
        /*"01  DCLCB-APOLICE-VIGPROP.*/
        public CBAPOVIG_DCLCB_APOLICE_VIGPROP DCLCB_APOLICE_VIGPROP { get; set; } = new CBAPOVIG_DCLCB_APOLICE_VIGPROP();

    }
}