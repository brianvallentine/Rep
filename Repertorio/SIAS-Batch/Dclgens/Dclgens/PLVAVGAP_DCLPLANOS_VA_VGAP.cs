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
    public class PLVAVGAP_DCLPLANOS_VA_VGAP : VarBasis
    {
        /*"    10 NUM-APOLICE          PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 CODSUBES             PIC S9(4) USAGE COMP.*/
        public IntBasis CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 OPCAO-COBER          PIC X(1).*/
        public StringBasis OPCAO_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 DTINIVIG             PIC X(10).*/
        public StringBasis DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 IDADE-INICIAL        PIC S9(4) USAGE COMP.*/
        public IntBasis IDADE_INICIAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 IDADE-FINAL          PIC S9(4) USAGE COMP.*/
        public IntBasis IDADE_FINAL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 PERIPGTO             PIC S9(4) USAGE COMP.*/
        public IntBasis PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DTTERVIG             PIC X(10).*/
        public StringBasis DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 IMPMORNATU           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPMORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
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
        /*"    10 VLPREMIOTOT          PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLPREMIOTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMVG                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMAP                PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TAXAVG               PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXAVG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 TAXAAP               PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis TAXAAP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 QTTITCAP             PIC S9(4) USAGE COMP.*/
        public IntBasis QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VLTITCAP             PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLTITCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLCUSTCAP            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 IMPSEGCDG            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLCUSTCDG            PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CODUSU               PIC X(8).*/
        public StringBasis CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 FAIXA                PIC S9(4) USAGE COMP.*/
        public IntBasis FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TIMESTAMP            PIC X(26).*/
        public StringBasis TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 IMPSEGAUXF           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VLCUSTAUXF           PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 PRMDIT               PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis PRMDIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 QTDIT                PIC S9(4) USAGE COMP.*/
        public IntBasis QTDIT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 COD-PLANO            PIC S9(4) USAGE COMP.*/
        public IntBasis COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 DESCR-PLANO          PIC X(15).*/
        public StringBasis DESCR_PLANO { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"    10 FAIXA-SAL-INI        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FAIXA_SAL_INI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 FAIXA-SAL-FIM        PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis FAIXA_SAL_FIM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}