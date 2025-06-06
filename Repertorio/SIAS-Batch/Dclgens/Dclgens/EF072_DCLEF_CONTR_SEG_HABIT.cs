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
    public class EF072_DCLEF_CONTR_SEG_HABIT : VarBasis
    {
        /*"    10 EF072-NOM-ARQUIVO    PIC X(8).*/
        public StringBasis EF072_NOM_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 EF072-NUM-CONTRATO   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF072_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF072-NUM-ORDEM-INCLUSAO  PIC S9(4) USAGE COMP.*/
        public IntBasis EF072_NUM_ORDEM_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF072-QTD-UPF-PREMIO  PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF072_QTD_UPF_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF072-QTD-REAJ-PREMIOS  PIC S9(4) USAGE COMP.*/
        public IntBasis EF072_QTD_REAJ_PREMIOS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF072-NUM-CONTRATO-TERC  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF072_NUM_CONTRATO_TERC { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF072-VLR-S-DEV-ULT-REAJ  PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF072_VLR_S_DEV_ULT_REAJ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
    }
}