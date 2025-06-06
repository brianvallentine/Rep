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
    public class MOVFEDCA : VarBasis
    {
        /*"01  DCLMOVIMEN-FED-CAP-VA.*/
        public MOVFEDCA_DCLMOVIMEN_FED_CAP_VA DCLMOVIMEN_FED_CAP_VA { get; set; } = new MOVFEDCA_DCLMOVIMEN_FED_CAP_VA();

    }
}