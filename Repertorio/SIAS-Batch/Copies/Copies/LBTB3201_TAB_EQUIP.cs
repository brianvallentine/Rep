using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class LBTB3201_TAB_EQUIP : VarBasis
    {
        /*"     10  TB-EQUIP       PIC X(01)  OCCURS 20 TIMES*/
        public ListBasis<StringBasis, string> TB_EQUIP { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "1", "X(01)"), 20);
        /*"01  TAB-EQUIP-DESC*/
    }
}