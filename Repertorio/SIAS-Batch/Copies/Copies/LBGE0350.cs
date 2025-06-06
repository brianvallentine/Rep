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
    public class LBGE0350 : VarBasis
    {
        /*"01  REGISTRO-LINKAGE-GE0350S*/
        public LBGE0350_REGISTRO_LINKAGE_GE0350S REGISTRO_LINKAGE_GE0350S { get; set; } = new LBGE0350_REGISTRO_LINKAGE_GE0350S();

    }
}