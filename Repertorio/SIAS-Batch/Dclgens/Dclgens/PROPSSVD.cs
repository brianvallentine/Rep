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
    public class PROPSSVD : VarBasis
    {
        /*"01  DCLPROP-SASSE-VIDA.*/
        public PROPSSVD_DCLPROP_SASSE_VIDA DCLPROP_SASSE_VIDA { get; set; } = new PROPSSVD_DCLPROP_SASSE_VIDA();

    }
}