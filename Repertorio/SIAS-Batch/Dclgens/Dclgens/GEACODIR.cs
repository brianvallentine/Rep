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
    public class GEACODIR : VarBasis
    {
        /*"01  DCLGE-ACOMP-DIRECIONA.*/
        public GEACODIR_DCLGE_ACOMP_DIRECIONA DCLGE_ACOMP_DIRECIONA { get; set; } = new GEACODIR_DCLGE_ACOMP_DIRECIONA();

    }
}