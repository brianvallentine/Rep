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
    public class PROPESTI_DCLPROP_ESTIPULANTE : VarBasis
    {
        /*"    10 PROPESTI-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis PROPESTI_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPESTI-NUM-PROPOSTA  PIC S9(9) USAGE COMP.*/
        public IntBasis PROPESTI_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 PROPESTI-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PROPESTI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PROPESTI-COD-CCT     PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPESTI_COD_CCT { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPESTI-COD-FROTA   PIC X(15).*/
        public StringBasis PROPESTI_COD_FROTA { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PROPESTI-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PROPESTI_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PROPESTI-NUM-BILHETE  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis PROPESTI_NUM_BILHETE { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 PROPESTI-TIMESTAMP   PIC X(26).*/
        public StringBasis PROPESTI_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}