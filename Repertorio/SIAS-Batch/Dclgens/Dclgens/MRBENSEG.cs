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
    public class MRBENSEG : VarBasis
    {
        /*"01  DCLMR-BENS-SEGURADO.*/
        public MRBENSEG_DCLMR_BENS_SEGURADO DCLMR_BENS_SEGURADO { get; set; } = new MRBENSEG_DCLMR_BENS_SEGURADO();

    }
}