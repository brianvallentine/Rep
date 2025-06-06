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
    public class GETPMOIM : VarBasis
    {
        /*"01  DCLGE-TP-MORAD-IMOVEL.*/
        public GETPMOIM_DCLGE_TP_MORAD_IMOVEL DCLGE_TP_MORAD_IMOVEL { get; set; } = new GETPMOIM_DCLGE_TP_MORAD_IMOVEL();

    }
}