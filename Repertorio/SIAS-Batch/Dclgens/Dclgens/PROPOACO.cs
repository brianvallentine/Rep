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
    public class PROPOACO : VarBasis
    {
        /*"01  DCLPROPOSTA-ACOMPANHA.*/
        public PROPOACO_DCLPROPOSTA_ACOMPANHA DCLPROPOSTA_ACOMPANHA { get; set; } = new PROPOACO_DCLPROPOSTA_ACOMPANHA();

    }
}