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
    public class ORDEMCOS_DCLORDEM_COSSEGCED : VarBasis
    {
        /*"    10 ORDEMCOS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis ORDEMCOS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 ORDEMCOS-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis ORDEMCOS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORDEMCOS-COD-COSSEGURADORA  PIC S9(4) USAGE COMP.*/
        public IntBasis ORDEMCOS_COD_COSSEGURADORA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 ORDEMCOS-ORDEM-CEDIDO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis ORDEMCOS_ORDEM_CEDIDO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 ORDEMCOS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis ORDEMCOS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 ORDEMCOS-TIMESTAMP   PIC X(26).*/
        public StringBasis ORDEMCOS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}