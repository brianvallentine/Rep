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
    public class OD002 : VarBasis
    {
        /*"01  DCLOD-PESSOA-FISICA.*/
        public OD002_DCLOD_PESSOA_FISICA DCLOD_PESSOA_FISICA { get; set; } = new OD002_DCLOD_PESSOA_FISICA();

    }
}