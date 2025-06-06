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
    public class MOVVGAP : VarBasis
    {
        /*"01  DCLMOVIMENTO-VGAP.*/
        public MOVVGAP_DCLMOVIMENTO_VGAP DCLMOVIMENTO_VGAP { get; set; } = new MOVVGAP_DCLMOVIMENTO_VGAP();

    }
}