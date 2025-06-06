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
    public class HISLANCT_DCLHIST_LANC_CTA : VarBasis
    {
        /*"    10 HISLANCT-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis HISLANCT_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 HISLANCT-NUM-PARCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-OCORR-HISTORICOCTA       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_OCORR_HISTORICOCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-COD-AGENCIA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_COD_AGENCIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-OPE-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_OPE_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-NUM-CONTA-DEBITO       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis HISLANCT_NUM_CONTA_DEBITO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 HISLANCT-DIG-CONTA-DEBITO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_DIG_CONTA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-DATA-VENCIMENTO       PIC X(10).*/
        public StringBasis HISLANCT_DATA_VENCIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 HISLANCT-PRM-TOTAL   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISLANCT_PRM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISLANCT-SIT-REGISTRO       PIC X(1).*/
        public StringBasis HISLANCT_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 HISLANCT-TIPLANC     PIC X(1).*/
        public StringBasis HISLANCT_TIPLANC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 HISLANCT-TIMESTAMP   PIC X(26).*/
        public StringBasis HISLANCT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 HISLANCT-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-CODCONV     PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_CODCONV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-NSAS        PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-NSL         PIC S9(9) USAGE COMP.*/
        public IntBasis HISLANCT_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISLANCT-NSAC        PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-CODRET      PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISLANCT-COD-USUARIO       PIC X(8).*/
        public StringBasis HISLANCT_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 HISLANCT-NUM-CARTAO-CREDITO       PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis HISLANCT_NUM_CARTAO_CREDITO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"    10 HISLANCT-COD-BANCO   PIC S9(4) USAGE COMP.*/
        public IntBasis HISLANCT_COD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}