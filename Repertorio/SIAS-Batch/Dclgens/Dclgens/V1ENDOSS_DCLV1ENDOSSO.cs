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
    public class V1ENDOSS_DCLV1ENDOSSO : VarBasis
    {
        /*"    10 V1ENDOSS-CODCLIEN    PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-NUM-APOLICE  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 V1ENDOSS-NRENDOS     PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-NUM-ITEM    PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-CODSUBES    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-MODALIDA    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-ORGAO       PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-RAMO        PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-NUM-APOL-ANTERIOR  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_NUM_APOL_ANTERIOR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 V1ENDOSS-FONTE       PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-NRPROPOS    PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_NRPROPOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-DATPRO      PIC X(10).*/
        public StringBasis V1ENDOSS_DATPRO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-DATA-LIBERACAO  PIC X(10).*/
        public StringBasis V1ENDOSS_DATA_LIBERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-DTEMIS      PIC X(10).*/
        public StringBasis V1ENDOSS_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-NUMBIL      PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_NUMBIL { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 V1ENDOSS-TIPSEGU     PIC X(1).*/
        public StringBasis V1ENDOSS_TIPSEGU { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-TIPAPO      PIC X(1).*/
        public StringBasis V1ENDOSS_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-TIPCALC     PIC X(1).*/
        public StringBasis V1ENDOSS_TIPCALC { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-PODPUBL     PIC X(1).*/
        public StringBasis V1ENDOSS_PODPUBL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-NUM-ATA     PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_NUM_ATA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-ANO-ATA     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_ANO_ATA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-IDEMAN      PIC X(1).*/
        public StringBasis V1ENDOSS_IDEMAN { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-NRRCAP      PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_NRRCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-VLRCAP      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_VLRCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 V1ENDOSS-BCORCAP     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_BCORCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-AGERCAP     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_AGERCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-DACRCAP     PIC X(1).*/
        public StringBasis V1ENDOSS_DACRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-IDRCAP      PIC X(1).*/
        public StringBasis V1ENDOSS_IDRCAP { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-BCOCOBR     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_BCOCOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-AGECOBR     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-DACCOBR     PIC X(1).*/
        public StringBasis V1ENDOSS_DACCOBR { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-DTINIVIG    PIC X(10).*/
        public StringBasis V1ENDOSS_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-DTTERVIG    PIC X(10).*/
        public StringBasis V1ENDOSS_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-CDFRACIO    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_CDFRACIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-PCENTRAD    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_PCENTRAD { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 V1ENDOSS-PCADICIO    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_PCADICIO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 V1ENDOSS-PCDESCON    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_PCDESCON { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 V1ENDOSS-PCIOCC      PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_PCIOCC { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 V1ENDOSS-PRESTA1     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_PRESTA1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-QTPARCEL    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_QTPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-QTPRESTA    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_QTPRESTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-QTITENS     PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_QTITENS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-CODTXT      PIC X(3).*/
        public StringBasis V1ENDOSS_CODTXT { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 V1ENDOSS-CDACEITA    PIC X(1).*/
        public StringBasis V1ENDOSS_CDACEITA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-COD-MOEDA-IMP  PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-COD-MOEDA-PRM  PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-TIPO-ENDOSSO  PIC X(1).*/
        public StringBasis V1ENDOSS_TIPO_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-TPCOSCED    PIC X(1).*/
        public StringBasis V1ENDOSS_TPCOSCED { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-QTCOSSEG    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-PCTCED      PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 V1ENDOSS-OCORR-ENDERECO  PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-COD-USUARIO  PIC X(8).*/
        public StringBasis V1ENDOSS_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 V1ENDOSS-SITUACAO    PIC X(1).*/
        public StringBasis V1ENDOSS_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-DATA-SORTEIO  PIC X(10).*/
        public StringBasis V1ENDOSS_DATA_SORTEIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-DATARCAP    PIC X(10).*/
        public StringBasis V1ENDOSS_DATARCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-CORRECAO    PIC X(1).*/
        public StringBasis V1ENDOSS_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis V1ENDOSS_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 V1ENDOSS-ISENTA-CUSTO  PIC X(1).*/
        public StringBasis V1ENDOSS_ISENTA_CUSTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-TIMESTAMP   PIC X(26).*/
        public StringBasis V1ENDOSS_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 V1ENDOSS-CODPRODU    PIC S9(4) USAGE COMP.*/
        public IntBasis V1ENDOSS_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 V1ENDOSS-TPCORRET    PIC X(1).*/
        public StringBasis V1ENDOSS_TPCORRET { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 V1ENDOSS-DTVENCTO    PIC X(10).*/
        public StringBasis V1ENDOSS_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 V1ENDOSS-CFPREFIX    PIC S9(4)V9(5) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_CFPREFIX { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(4)V9(5)"), 5);
        /*"    10 V1ENDOSS-VLCUSEMI    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis V1ENDOSS_VLCUSEMI { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
    }
}