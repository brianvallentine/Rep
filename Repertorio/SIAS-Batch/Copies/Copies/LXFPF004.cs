using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LXFPF004 : VarBasis
    {
        /*"01              REG-BILHETE-AP*/
        public LXFPF004_REG_BILHETE_AP REG_BILHETE_AP { get; set; } = new LXFPF004_REG_BILHETE_AP();

    }
}