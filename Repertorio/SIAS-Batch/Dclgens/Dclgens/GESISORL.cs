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
    public class GESISORL : VarBasis
    {
        /*"01  DCLGE-SIS-FUN-OPE-REL.*/
        public GESISORL_DCLGE_SIS_FUN_OPE_REL DCLGE_SIS_FUN_OPE_REL { get; set; } = new GESISORL_DCLGE_SIS_FUN_OPE_REL();

    }
}