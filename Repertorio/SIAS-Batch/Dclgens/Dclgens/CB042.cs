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
    public class CB042 : VarBasis
    {
        /*"01  DCLCB-AVISO-SALDO-ANALITICO.*/
        public CB042_DCLCB_AVISO_SALDO_ANALITICO DCLCB_AVISO_SALDO_ANALITICO { get; set; } = new CB042_DCLCB_AVISO_SALDO_ANALITICO();

    }
}