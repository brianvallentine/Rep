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
    public class LBTB3101_TAB_PREMIOS : VarBasis
    {
        /*"  10 TB-PREMIOS    PIC S9(10)V99    COMP-3 OCCURS 20 TIMES*/
        public ListBasis<DoubleBasis, double> TB_PREMIOS { get; set; } = new ListBasis<DoubleBasis, double>(new PIC("S9", "10", "S9(10)V99"), 20);
        /*"01 TAB-COEF      COMP-3*/
    }
}