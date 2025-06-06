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
    public class VG092 : VarBasis
    {
        /*"01  DCLVG-COMPL-CLI-EMP.*/
        public VG092_DCLVG_COMPL_CLI_EMP DCLVG_COMPL_CLI_EMP { get; set; } = new VG092_DCLVG_COMPL_CLI_EMP();

    }
}