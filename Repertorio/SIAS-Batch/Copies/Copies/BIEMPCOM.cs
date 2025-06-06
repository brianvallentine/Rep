using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class BIEMPCOM : VarBasis
    {
        /*"01     R6C-EMPRESA-COMPACTADO*/
        public BIEMPCOM_R6C_EMPRESA_COMPACTADO R6C_EMPRESA_COMPACTADO { get; set; } = new BIEMPCOM_R6C_EMPRESA_COMPACTADO();

    }
}