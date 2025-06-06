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
    public class PLANOVID_DCLPLANOS_VIDAZUL : VarBasis
    {
        /*"    10 PLANOVID-COD-PRODUTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-OPCAO-COBERTURA  PIC X(1).*/
        public StringBasis PLANOVID_OPCAO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PLANOVID-DATA-INIVIGENCIA  PIC X(10).*/
        public StringBasis PLANOVID_DATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLANOVID-IDADE-INICIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-IDADE-FINAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-PERI-PAGAMENTO  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-DATA-TERVIGENCIA  PIC X(10).*/
        public StringBasis PLANOVID_DATA_TERVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLANOVID-IMP-MORNATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPMORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPINVPERM  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPAMDS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPDH       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-VLPREMIOTOT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_VLPREMIOTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-PREMIO-VG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_PREMIO_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-PREMIO-AP   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_PREMIO_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-TAXAVG      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_TAXAVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 PLANOVID-TAXAAP      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_TAXAAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 PLANOVID-QTDE-TIT-CAPITALIZ  PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_QTDE_TIT_CAPITALIZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-VAL-TIT-CAPITALIZ  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_VAL_TIT_CAPITALIZ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-VAL-CUSTO-CAPITALI  PIC S9(13)V9(2) USAGE COMP-3*/
        public DoubleBasis PLANOVID_VAL_CUSTO_CAPITALI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-IMPSEGCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-VLCUSTCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-COD-USUARIO  PIC X(8).*/
        public StringBasis PLANOVID_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PLANOVID-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-TIMESTAMP   PIC X(26).*/
        public StringBasis PLANOVID_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PLANOVID-IMPSEGAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-VLCUSTAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-PRMDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLANOVID_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLANOVID-QTDIT       PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLANOVID_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLANOVID-DESCR-PLANO  PIC X(15).*/
        public StringBasis PLANOVID_DESCR_PLANO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PLANOVID-IDE-FUMANTE  PIC X(1).*/
        public StringBasis PLANOVID_IDE_FUMANTE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"*/
    }
}