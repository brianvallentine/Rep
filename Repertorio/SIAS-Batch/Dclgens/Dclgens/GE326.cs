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
    public class GE326 : VarBasis
    {
        /*"01  DCLGE-DNE-CXPST-COM.*/
        public GE326_DCLGE_DNE_CXPST_COM DCLGE_DNE_CXPST_COM { get; set; } = new GE326_DCLGE_DNE_CXPST_COM();

    }
}