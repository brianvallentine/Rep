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
    public class SISINCHE : VarBasis
    {
        /*"01  DCLSI-SINI-CHEQUE.*/
        public SISINCHE_DCLSI_SINI_CHEQUE DCLSI_SINI_CHEQUE { get; set; } = new SISINCHE_DCLSI_SINI_CHEQUE();

    }
}