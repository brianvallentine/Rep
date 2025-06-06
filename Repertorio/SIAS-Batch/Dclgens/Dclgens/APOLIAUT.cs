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
    public class APOLIAUT : VarBasis
    {
        /*"01  DCLAPOLICE-AUTO.*/
        public APOLIAUT_DCLAPOLICE_AUTO DCLAPOLICE_AUTO { get; set; } = new APOLIAUT_DCLAPOLICE_AUTO();

    }
}