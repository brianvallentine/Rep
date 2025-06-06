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
    public class GE091 : VarBasis
    {
        /*"01  DCLGE-PROD-PREMIO-COBER.*/
        public GE091_DCLGE_PROD_PREMIO_COBER DCLGE_PROD_PREMIO_COBER { get; set; } = new GE091_DCLGE_PROD_PREMIO_COBER();

    }
}