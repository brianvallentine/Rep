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
    public class AVISOCRE : VarBasis
    {
        /*"01  DCLAVISO-CREDITO.*/
        public AVISOCRE_DCLAVISO_CREDITO DCLAVISO_CREDITO { get; set; } = new AVISOCRE_DCLAVISO_CREDITO();

    }
}