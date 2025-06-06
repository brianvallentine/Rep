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
    public class CBMALPAR : VarBasis
    {
        /*"01  DCLCB-MALA-PARCATRASO.*/
        public CBMALPAR_DCLCB_MALA_PARCATRASO DCLCB_MALA_PARCATRASO { get; set; } = new CBMALPAR_DCLCB_MALA_PARCATRASO();

    }
}