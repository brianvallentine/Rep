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
    public class GE411 : VarBasis
    {
        /*"01  DCLGE-STA-REGISTRO-CARTAO.*/
        public GE411_DCLGE_STA_REGISTRO_CARTAO DCLGE_STA_REGISTRO_CARTAO { get; set; } = new GE411_DCLGE_STA_REGISTRO_CARTAO();

    }
}