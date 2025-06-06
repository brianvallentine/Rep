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
    public class RCAPS_DCLRCAPS : VarBasis
    {
        /*"    10 RCAPS-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPS_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPS-NUM-RCAP       PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPS_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPS-NUM-PROPOSTA   PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPS_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPS-NOME-SEGURADO  PIC X(40).*/
        public StringBasis RCAPS_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 RCAPS-VAL-RCAP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RCAPS_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RCAPS-VAL-RCAP-PRINCIPAL  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RCAPS_VAL_RCAP_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RCAPS-DATA-CADASTRAMENTO  PIC X(10).*/
        public StringBasis RCAPS_DATA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RCAPS-DATA-MOVIMENTO  PIC X(10).*/
        public StringBasis RCAPS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 RCAPS-SIT-REGISTRO   PIC X(1).*/
        public StringBasis RCAPS_SIT_REGISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RCAPS-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPS_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPS-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPS-TIMESTAMP      PIC X(26).*/
        public StringBasis RCAPS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 RCAPS-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RCAPS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RCAPS-NUM-ENDOSSO    PIC S9(9) USAGE COMP.*/
        public IntBasis RCAPS_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 RCAPS-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPS_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPS-NUM-TITULO     PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis RCAPS_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 RCAPS-CODIGO-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPS_CODIGO_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPS-AGE-COBRANCA   PIC S9(4) USAGE COMP.*/
        public IntBasis RCAPS_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 RCAPS-RECUPERA       PIC X(1).*/
        public StringBasis RCAPS_RECUPERA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 RCAPS-VLACRESCIMO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis RCAPS_VLACRESCIMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 RCAPS-NUM-CERTIFICADO  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis RCAPS_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"*/
    }
}