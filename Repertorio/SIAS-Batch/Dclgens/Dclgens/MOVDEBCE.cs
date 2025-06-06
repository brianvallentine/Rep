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
    public class MOVDEBCE : VarBasis
    {
        /*"01  DCLMOVTO-DEBITOCC-CEF.*/
        public MOVDEBCE_DCLMOVTO_DEBITOCC_CEF DCLMOVTO_DEBITOCC_CEF { get; set; } = new MOVDEBCE_DCLMOVTO_DEBITOCC_CEF();

    }
}