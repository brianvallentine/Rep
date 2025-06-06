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
    public class MOVIMVGA : VarBasis
    {
        /*"01  DCLMOVIMENTO-VGAP.*/
        public MOVIMVGA_DCLMOVIMENTO_VGAP DCLMOVIMENTO_VGAP { get; set; } = new MOVIMVGA_DCLMOVIMENTO_VGAP();

    }
}