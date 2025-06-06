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
    public class COBPRPVA_DCLHIS_COBER_PROPOST : VarBasis
    {
        /*"    10 NUM-CERTIFICADO      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 OCORR-HISTORICO      PIC S9(4) USAGE COMP.*/
        public IntBasis OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DATA-INIVIGENCIA     PIC X(10).*/
        public StringBasis DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 DATA-TERVIGENCIA     PIC X(10).*/
        public StringBasis DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 IMPSEGUR             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGUR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 QUANT-VIDAS          PIC S9(9) USAGE COMP.*/
        public IntBasis QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 IMPSEGIND            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGIND { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COD-OPERACAO         PIC S9(4) USAGE COMP.*/
        public IntBasis COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCAO-COBERTURA      PIC X(1).*/
        public StringBasis OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 IMP-MORNATU          PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPMORACID           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPINVPERM           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPAMDS              PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPDH                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPDIT               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLPREMIO             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMVG                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMAP                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 QTDE-TIT-CAPITALIZ   PIC S9(4) USAGE COMP.*/
        public IntBasis QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VAL-TIT-CAPITALIZ    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VAL-CUSTO-CAPITALI   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPSEGCDG            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLCUSTCDG            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 COD-USUARIO          PIC X(8).*/
        public StringBasis COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 IMPSEGAUXF           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLCUSTAUXF           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMDIT               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 QTMDIT               PIC S9(4) USAGE COMP.*/
        public IntBasis QTMDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}