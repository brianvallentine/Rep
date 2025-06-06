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
    public class COBMENVG : VarBasis
    {
        /*"01  DCLCOBRANCA-MENS-VGAP.*/
        public COBMENVG_DCLCOBRANCA_MENS_VGAP DCLCOBRANCA_MENS_VGAP { get; set; } = new COBMENVG_DCLCOBRANCA_MENS_VGAP();

    }
}