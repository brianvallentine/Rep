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
    public class LBFCT000 : VarBasis
    {
        /*"01      REGISTRO-ENDOSSOS*/
        public LBFCT000_REGISTRO_ENDOSSOS REGISTRO_ENDOSSOS { get; set; } = new LBFCT000_REGISTRO_ENDOSSOS();

    }
}