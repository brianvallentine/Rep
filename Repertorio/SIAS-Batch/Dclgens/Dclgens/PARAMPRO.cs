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
    public class PARAMPRO : VarBasis
    {
        /*"01  DCLPARAM-PRODUTO.*/
        public PARAMPRO_DCLPARAM_PRODUTO DCLPARAM_PRODUTO { get; set; } = new PARAMPRO_DCLPARAM_PRODUTO();

    }
}