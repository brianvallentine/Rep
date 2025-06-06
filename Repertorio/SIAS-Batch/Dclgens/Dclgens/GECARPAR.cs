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
    public class GECARPAR : VarBasis
    {
        /*"01  DCLGE-CARTA-PARAMETRO.*/
        public GECARPAR_DCLGE_CARTA_PARAMETRO DCLGE_CARTA_PARAMETRO { get; set; } = new GECARPAR_DCLGE_CARTA_PARAMETRO();

    }
}