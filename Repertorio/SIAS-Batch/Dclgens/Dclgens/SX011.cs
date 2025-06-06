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
    public class SX011 : VarBasis
    {
        /*"01  DCLSX-ORIGEM-CONTRATO.*/
        public SX011_DCLSX_ORIGEM_CONTRATO DCLSX_ORIGEM_CONTRATO { get; set; } = new SX011_DCLSX_ORIGEM_CONTRATO();

    }
}