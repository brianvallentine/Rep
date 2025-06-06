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
    public class EF064_DCLEF_CONTRATO_SEGURO : VarBasis
    {
        /*"    10 EF064-NUM-CONTRATO-APOL       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF064_NUM_CONTRATO_APOL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF064-NUM-CONTRATO   PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis EF064_NUM_CONTRATO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 EF064-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis EF064_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF064-COD-PESSOA-CONTRTE       PIC S9(9) USAGE COMP.*/
        public IntBasis EF064_COD_PESSOA_CONTRTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF064-COD-PESSOA-SUBCONT       PIC S9(9) USAGE COMP.*/
        public IntBasis EF064_COD_PESSOA_SUBCONT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF064-COD-PESSOA-AGE-FIN       PIC S9(9) USAGE COMP.*/
        public IntBasis EF064_COD_PESSOA_AGE_FIN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF064-COD-DIV-AGE-FIN       PIC S9(9) USAGE COMP.*/
        public IntBasis EF064_COD_DIV_AGE_FIN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 EF064-COD-TIPO-VAR-PROD       PIC S9(4) USAGE COMP.*/
        public IntBasis EF064_COD_TIPO_VAR_PROD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF064-COD-TIPO-CONTR-SEG       PIC S9(4) USAGE COMP.*/
        public IntBasis EF064_COD_TIPO_CONTR_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 EF064-STA-CONTRATO-SEG       PIC X(1).*/
        public StringBasis EF064_STA_CONTRATO_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 EF064-DTH-PRIM-PREMIO       PIC X(10).*/
        public StringBasis EF064_DTH_PRIM_PREMIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 EF064-VLR-RENDA-FAMILIAR       PIC S9(10)V9(2) USAGE COMP-3.*/
        public DoubleBasis EF064_VLR_RENDA_FAMILIAR { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(10)V9(2)"), 2);
        /*"    10 EF064-DTH-CANCEL-SIGPF       PIC X(26).*/
        public StringBasis EF064_DTH_CANCEL_SIGPF { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}