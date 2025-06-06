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
    public class LBTB3101_TAB_TAXAS : VarBasis
    {
        /*"  10 TB-TAXAS      PIC S9(03)V9(09) COMP-3 OCCURS 20 TIMES*/
        public ListBasis<DoubleBasis, double> TB_TAXAS { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "3", "S9(03)V9(09)"), 20);
        /*"01 TAB-PREMIOS   COMP-3*/
    }
}