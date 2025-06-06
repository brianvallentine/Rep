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
    public class LBGE0355 : VarBasis
    {
        /*"01  REGISTRO-LINKAGE-GE0355S*/
        public LBGE0355_REGISTRO_LINKAGE_GE0355S REGISTRO_LINKAGE_GE0355S { get; set; } = new LBGE0355_REGISTRO_LINKAGE_GE0355S();

    }
}