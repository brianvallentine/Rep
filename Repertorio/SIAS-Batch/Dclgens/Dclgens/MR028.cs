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
    public class MR028 : VarBasis
    {
        /*"01  DCLMR-PROP-RENOVACAO.*/
        public MR028_DCLMR_PROP_RENOVACAO DCLMR_PROP_RENOVACAO { get; set; } = new MR028_DCLMR_PROP_RENOVACAO();

    }
}