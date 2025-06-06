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
    public class GETIPIMP : VarBasis
    {
        /*"01  DCLGE-TIPO-IMPOSTO.*/
        public GETIPIMP_DCLGE_TIPO_IMPOSTO DCLGE_TIPO_IMPOSTO { get; set; } = new GETIPIMP_DCLGE_TIPO_IMPOSTO();

    }
}