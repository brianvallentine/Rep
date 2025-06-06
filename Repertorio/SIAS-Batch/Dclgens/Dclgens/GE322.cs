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
    public class GE322 : VarBasis
    {
        /*"01  DCLGE-DNE-UNID-OPER.*/
        public GE322_DCLGE_DNE_UNID_OPER DCLGE_DNE_UNID_OPER { get; set; } = new GE322_DCLGE_DNE_UNID_OPER();

    }
}