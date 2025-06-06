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
    public class FOLLOUP_DCLFOLLOW_UP : VarBasis
    {
        /*"    10 FOLLOUP-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis FOLLOUP_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 FOLLOUP-NUM-ENDOSSO  PIC S9(9) USAGE COMP.*/
        public IntBasis FOLLOUP_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FOLLOUP-NUM-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-DAC-PARCELA  PIC X(1).*/
        public StringBasis FOLLOUP_DAC_PARCELA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis FOLLOUP_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FOLLOUP-HORA-OPERACAO  PIC X(8).*/
        public StringBasis FOLLOUP_HORA_OPERACAO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FOLLOUP-VAL-OPERACAO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FOLLOUP_VAL_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FOLLOUP-BCO-AVISO    PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_BCO_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-AGE-AVISO    PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_AGE_AVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-NUM-AVISO-CREDITO  PIC S9(9) USAGE COMP.*/
        public IntBasis FOLLOUP_NUM_AVISO_CREDITO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FOLLOUP-COD-BAIXA-PARCELA  PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_COD_BAIXA_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-COD-ERRO01   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-ERRO02   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-ERRO03   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-ERRO04   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-ERRO05   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO05 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-ERRO06   PIC X(1).*/
        public StringBasis FOLLOUP_COD_ERRO06 { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-SIT-REGISTRO  PIC X(1).*/
        public StringBasis FOLLOUP_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-SIT-CONTABIL  PIC X(1).*/
        public StringBasis FOLLOUP_SIT_CONTABIL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-DATA-LIBERACAO  PIC X(10).*/
        public StringBasis FOLLOUP_DATA_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FOLLOUP-DATA-QUITACAO  PIC X(10).*/
        public StringBasis FOLLOUP_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FOLLOUP-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis FOLLOUP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FOLLOUP-TIMESTAMP    PIC X(26).*/
        public StringBasis FOLLOUP_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 FOLLOUP-ORDEM-LIDER  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis FOLLOUP_ORDEM_LIDER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 FOLLOUP-TIPO-SEGURO  PIC X(1).*/
        public StringBasis FOLLOUP_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FOLLOUP-NUM-APOL-LIDER  PIC X(15).*/
        public StringBasis FOLLOUP_NUM_APOL_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 FOLLOUP-ENDOS-LIDER  PIC X(15).*/
        public StringBasis FOLLOUP_ENDOS_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 FOLLOUP-COD-LIDER    PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_COD_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-COD-FONTE    PIC S9(4) USAGE COMP.*/
        public IntBasis FOLLOUP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FOLLOUP-NUM-RCAP     PIC S9(9) USAGE COMP.*/
        public IntBasis FOLLOUP_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FOLLOUP-NUM-NOSSO-TITULO  PIC S9(16)V USAGE COMP-3.*/
        public DoubleBasis FOLLOUP_NUM_NOSSO_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V"), 0);
        /*"*/
    }
}