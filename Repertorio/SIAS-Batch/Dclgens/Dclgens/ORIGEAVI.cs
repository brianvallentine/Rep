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
    public class ORIGEAVI : VarBasis
    {
        /*"01  DCLORIGEM-AVISO.*/
        public ORIGEAVI_DCLORIGEM_AVISO DCLORIGEM_AVISO { get; set; } = new ORIGEAVI_DCLORIGEM_AVISO();

    }
}