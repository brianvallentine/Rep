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
    public class TERMOADE : VarBasis
    {
        /*"01  DCLTERMO-ADESAO.*/
        public TERMOADE_DCLTERMO_ADESAO DCLTERMO_ADESAO { get; set; } = new TERMOADE_DCLTERMO_ADESAO();

    }
}