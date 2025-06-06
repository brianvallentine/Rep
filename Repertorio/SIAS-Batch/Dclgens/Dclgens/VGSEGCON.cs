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
    public class VGSEGCON : VarBasis
    {
        /*"01  DCLVG-SEGUR-CONSORCIO.*/
        public VGSEGCON_DCLVG_SEGUR_CONSORCIO DCLVG_SEGUR_CONSORCIO { get; set; } = new VGSEGCON_DCLVG_SEGUR_CONSORCIO();

    }
}