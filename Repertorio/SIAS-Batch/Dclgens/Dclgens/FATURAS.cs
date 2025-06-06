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
    public class FATURAS : VarBasis
    {
        /*"01  DCLFATURAS.*/
        public FATURAS_DCLFATURAS DCLFATURAS { get; set; } = new FATURAS_DCLFATURAS();

    }
}