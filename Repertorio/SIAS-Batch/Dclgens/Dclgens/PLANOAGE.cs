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
    public class PLANOAGE : VarBasis
    {
        /*"01  DCLPLANO-AGENCIAMENTO.*/
        public PLANOAGE_DCLPLANO_AGENCIAMENTO DCLPLANO_AGENCIAMENTO { get; set; } = new PLANOAGE_DCLPLANO_AGENCIAMENTO();

    }
}