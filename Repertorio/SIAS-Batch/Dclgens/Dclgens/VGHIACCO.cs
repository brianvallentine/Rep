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
    public class VGHIACCO : VarBasis
    {
        /*"01  DCLVG-HIST-ACESS-COB.*/
        public VGHIACCO_DCLVG_HIST_ACESS_COB DCLVG_HIST_ACESS_COB { get; set; } = new VGHIACCO_DCLVG_HIST_ACESS_COB();

    }
}