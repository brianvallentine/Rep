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
    public class FCCOMTIT : VarBasis
    {
        /*"01  DCLFC-COMB-TITULOS.*/
        public FCCOMTIT_DCLFC_COMB_TITULOS DCLFC_COMB_TITULOS { get; set; } = new FCCOMTIT_DCLFC_COMB_TITULOS();

    }
}