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
    public class HISLANCT : VarBasis
    {
        /*"01  DCLHIST-LANC-CTA.*/
        public HISLANCT_DCLHIST_LANC_CTA DCLHIST_LANC_CTA { get; set; } = new HISLANCT_DCLHIST_LANC_CTA();

    }
}