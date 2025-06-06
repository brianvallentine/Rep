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
    public class RELCHSIV : VarBasis
    {
        /*"01  DCLRELACAO-CHEQ-SIVAT.*/
        public RELCHSIV_DCLRELACAO_CHEQ_SIVAT DCLRELACAO_CHEQ_SIVAT { get; set; } = new RELCHSIV_DCLRELACAO_CHEQ_SIVAT();

    }
}