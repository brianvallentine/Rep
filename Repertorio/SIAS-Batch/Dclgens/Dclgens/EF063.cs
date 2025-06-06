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
    public class EF063 : VarBasis
    {
        /*"01  DCLEF-APOLICE.*/
        public EF063_DCLEF_APOLICE DCLEF_APOLICE { get; set; } = new EF063_DCLEF_APOLICE();

    }
}