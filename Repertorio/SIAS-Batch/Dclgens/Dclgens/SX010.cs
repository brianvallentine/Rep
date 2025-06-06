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
    public class SX010 : VarBasis
    {
        /*"01  DCLSX-APOLICE.*/
        public SX010_DCLSX_APOLICE DCLSX_APOLICE { get; set; } = new SX010_DCLSX_APOLICE();

    }
}