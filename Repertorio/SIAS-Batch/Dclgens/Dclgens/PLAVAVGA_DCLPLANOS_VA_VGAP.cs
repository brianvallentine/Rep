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
    public class PLAVAVGA_DCLPLANOS_VA_VGAP : VarBasis
    {
        /*"    10 PLAVAVGA-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 PLAVAVGA-CODSUBES    PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-OPCAO-COBER  PIC X(1).*/
        public StringBasis PLAVAVGA_OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 PLAVAVGA-DTINIVIG    PIC X(10).*/
        public StringBasis PLAVAVGA_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLAVAVGA-IDADE-INICIAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-IDADE-FINAL  PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-PERIPGTO    PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-DTTERVIG    PIC X(10).*/
        public StringBasis PLAVAVGA_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 PLAVAVGA-IMPMORNATU  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPMORACID  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPMORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPINVPERM  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPINVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPAMDS     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPAMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPDH       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPDH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-VLPREMIOTOT  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_VLPREMIOTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-PRMVG       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-PRMAP       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-TAXAVG      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_TAXAVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 PLAVAVGA-TAXAAP      PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_TAXAAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 PLAVAVGA-QTTITCAP    PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-VLTITCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-VLCUSTCAP   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-IMPSEGCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-VLCUSTCDG   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-CODUSU      PIC X(8).*/
        public StringBasis PLAVAVGA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 PLAVAVGA-FAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-TIMESTAMP   PIC X(26).*/
        public StringBasis PLAVAVGA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 PLAVAVGA-IMPSEGAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-VLCUSTAUXF  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-PRMDIT      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-QTDIT       PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-COD-PLANO   PIC S9(4) USAGE COMP.*/
        public IntBasis PLAVAVGA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PLAVAVGA-DESCR-PLANO  PIC X(15).*/
        public StringBasis PLAVAVGA_DESCR_PLANO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 PLAVAVGA-FAIXA-SAL-INI  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_FAIXA_SAL_INI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-FAIXA-SAL-FIM  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_FAIXA_SAL_FIM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PLAVAVGA-PCT-FAIXA-ETARIA  PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis PLAVAVGA_PCT_FAIXA_ETARIA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"*/
    }
}