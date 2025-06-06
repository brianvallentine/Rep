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
    public class GETPLADO : VarBasis
    {
        /*"01  DCLGE-TP-LANC-DOCF.*/
        public GETPLADO_DCLGE_TP_LANC_DOCF DCLGE_TP_LANC_DOCF { get; set; } = new GETPLADO_DCLGE_TP_LANC_DOCF();

    }
}