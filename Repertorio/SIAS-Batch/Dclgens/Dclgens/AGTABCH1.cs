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
    public class AGTABCH1 : VarBasis
    {
        /*"01  DCLAGRUPA-TABELAS-CH1.*/
        public AGTABCH1_DCLAGRUPA_TABELAS_CH1 DCLAGRUPA_TABELAS_CH1 { get; set; } = new AGTABCH1_DCLAGRUPA_TABELAS_CH1();

    }
}