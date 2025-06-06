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
    public class TPENDER : VarBasis
    {
        /*"01  DCLTIPO-ENDERECO.*/
        public TPENDER_DCLTIPO_ENDERECO DCLTIPO_ENDERECO { get; set; } = new TPENDER_DCLTIPO_ENDERECO();

    }
}