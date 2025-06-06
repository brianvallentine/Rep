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
    public class VGFUNCOB : VarBasis
    {
        /*"01  DCLVG-FUNC-COBERTURA.*/
        public VGFUNCOB_DCLVG_FUNC_COBERTURA DCLVG_FUNC_COBERTURA { get; set; } = new VGFUNCOB_DCLVG_FUNC_COBERTURA();

    }
}