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
    public class HISCOBPR_DCLHIS_COBER_PROPOST : VarBasis
    {
        /*"    10 HISCOBPR-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 HISCOBPR-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-DATA-INIVIGENCIA       PIC X(10).*/
        public StringBasis HISCOBPR_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 HISCOBPR-DATA-TERVIGENCIA       PIC X(10).*/
        public StringBasis HISCOBPR_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 HISCOBPR-IMPSEGUR    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-QUANT-VIDAS       PIC S9(9) USAGE COMP.*/
        public IntBasis HISCOBPR_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 HISCOBPR-IMPSEGIND   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-COD-OPERACAO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-OPCAO-COBERTURA       PIC X(1).*/
        public StringBasis HISCOBPR_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 HISCOBPR-IMP-MORNATU       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPMORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPINVPERM  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPAMDS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPDH       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-VLPREMIO    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-PRMVG       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-PRMAP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-QTDE-TIT-CAPITALIZ       PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-VAL-TIT-CAPITALIZ       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-VAL-CUSTO-CAPITALI       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-IMPSEGCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-VLCUSTCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-COD-USUARIO       PIC X(8).*/
        public StringBasis HISCOBPR_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 HISCOBPR-TIMESTAMP   PIC X(26).*/
        public StringBasis HISCOBPR_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 HISCOBPR-IMPSEGAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-VLCUSTAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-PRMDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis HISCOBPR_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 HISCOBPR-QTMDIT      PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-COD-PRODUTO       PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-SEQ-PRODUTO-VRS       PIC S9(4) USAGE COMP.*/
        public IntBasis HISCOBPR_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 HISCOBPR-COD-ACOPLADO       PIC S9(9) USAGE COMP.*/
        public IntBasis HISCOBPR_COD_ACOPLADO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}