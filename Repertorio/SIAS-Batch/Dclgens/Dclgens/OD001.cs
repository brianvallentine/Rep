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
    public class OD001 : VarBasis
    {
        /*"01  DCLOD-PESSOA.*/
        public OD001_DCLOD_PESSOA DCLOD_PESSOA { get; set; } = new OD001_DCLOD_PESSOA();

    }
}