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
    public class LXFPF003 : VarBasis
    {
        /*"01              REG-BIL-RESID    VALUE  SPACES*/
        public LXFPF003_REG_BIL_RESID REG_BIL_RESID { get; set; } = new LXFPF003_REG_BIL_RESID();

    }
}