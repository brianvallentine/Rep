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
    public class LBTB3100_TAB_EQUIP_DESC : VarBasis
    {
        /*"     10  TB-EQUIP-DESC  PIC X(45)  OCCURS 20 TIMES*/
        public ListBasis<StringBasis, string> TB_EQUIP_DESC { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "45", "X(45)"), 20);
        /*"01 TAB-IMPSEG   COMP-3*/
    }
}