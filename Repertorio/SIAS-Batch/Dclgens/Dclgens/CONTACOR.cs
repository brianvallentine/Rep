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
    public class CONTACOR : VarBasis
    {
        /*"01  DCLCONTA-CORRENTE.*/
        public CONTACOR_DCLCONTA_CORRENTE DCLCONTA_CORRENTE { get; set; } = new CONTACOR_DCLCONTA_CORRENTE();

    }
}