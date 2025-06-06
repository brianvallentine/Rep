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
    public class SINBENCB : VarBasis
    {
        /*"01  DCLSINI-BENEF-CBASICA.*/
        public SINBENCB_DCLSINI_BENEF_CBASICA DCLSINI_BENEF_CBASICA { get; set; } = new SINBENCB_DCLSINI_BENEF_CBASICA();

    }
}