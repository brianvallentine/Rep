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
    public class EF047 : VarBasis
    {
        /*"01  DCLEF-CONTRTE-CONTR.*/
        public EF047_DCLEF_CONTRTE_CONTR DCLEF_CONTRTE_CONTR { get; set; } = new EF047_DCLEF_CONTRTE_CONTR();

    }
}