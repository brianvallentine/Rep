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
    public class VGPROSIA : VarBasis
    {
        /*"01  DCLVG-PRODUTO-SIAS.*/
        public VGPROSIA_DCLVG_PRODUTO_SIAS DCLVG_PRODUTO_SIAS { get; set; } = new VGPROSIA_DCLVG_PRODUTO_SIAS();

    }
}