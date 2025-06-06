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
    public class COBPRPVA : VarBasis
    {
        /*"01  DCLHIS-COBER-PROPOST.*/
        public COBPRPVA_DCLHIS_COBER_PROPOST DCLHIS_COBER_PROPOST { get; set; } = new COBPRPVA_DCLHIS_COBER_PROPOST();

    }
}