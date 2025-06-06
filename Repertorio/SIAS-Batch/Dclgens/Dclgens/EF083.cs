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
    public class EF083 : VarBasis
    {
        /*"01  DCLEF-IMOVEL.*/
        public EF083_DCLEF_IMOVEL DCLEF_IMOVEL { get; set; } = new EF083_DCLEF_IMOVEL();

    }
}