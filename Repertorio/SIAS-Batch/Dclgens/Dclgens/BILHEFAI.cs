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
    public class BILHEFAI : VarBasis
    {
        /*"01  DCLBILHETE-FAIXA.*/
        public BILHEFAI_DCLBILHETE_FAIXA DCLBILHETE_FAIXA { get; set; } = new BILHEFAI_DCLBILHETE_FAIXA();

    }
}