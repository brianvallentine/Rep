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
    public class VGTERNIV : VarBasis
    {
        /*"01  DCLVG-TERMO-NIVEL.*/
        public VGTERNIV_DCLVG_TERMO_NIVEL DCLVG_TERMO_NIVEL { get; set; } = new VGTERNIV_DCLVG_TERMO_NIVEL();

    }
}