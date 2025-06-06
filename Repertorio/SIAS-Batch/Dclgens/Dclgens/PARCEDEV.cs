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
    public class PARCEDEV : VarBasis
    {
        /*"01  DCLPARCELA-DEVEDOR.*/
        public PARCEDEV_DCLPARCELA_DEVEDOR DCLPARCELA_DEVEDOR { get; set; } = new PARCEDEV_DCLPARCELA_DEVEDOR();

    }
}