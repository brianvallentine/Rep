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
    public class VGSOLFAT_DCLVG_SOLICITA_FATURA : VarBasis
    {
        /*"    10 VGSOLFAT-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGSOLFAT-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGSOLFAT-DATA-SOLICITACAO       PIC X(10).*/
        public StringBasis VGSOLFAT_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGSOLFAT-DIA-DEBITO  PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_DIA_DEBITO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGSOLFAT-OPCAOPAG    PIC X(1).*/
        public StringBasis VGSOLFAT_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGSOLFAT-QUANT-VIDAS       PIC S9(9) USAGE COMP.*/
        public IntBasis VGSOLFAT_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VGSOLFAT-CAP-BAS-SEGURADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_CAP_BAS_SEGURADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGSOLFAT-PRM-VG      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGSOLFAT-PRM-AP      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGSOLFAT-DTVENCTO-FATURA       PIC X(10).*/
        public StringBasis VGSOLFAT_DTVENCTO_FATURA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGSOLFAT-COD-FONTE   PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGSOLFAT-NUM-TITULO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGSOLFAT-DT-QUITBCO-TITULO       PIC X(10).*/
        public StringBasis VGSOLFAT_DT_QUITBCO_TITULO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VGSOLFAT-VALOR-TITULO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_VALOR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VGSOLFAT-SIT-SOLICITA       PIC X(1).*/
        public StringBasis VGSOLFAT_SIT_SOLICITA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VGSOLFAT-COD-USUARIO       PIC X(8).*/
        public StringBasis VGSOLFAT_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VGSOLFAT-TIMESTAMP   PIC X(26).*/
        public StringBasis VGSOLFAT_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VGSOLFAT-AGECTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGSOLFAT-OPRCTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VGSOLFAT-NUMCTADEB   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VGSOLFAT_NUMCTADEB { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VGSOLFAT-DIGCTADEB   PIC S9(4) USAGE COMP.*/
        public IntBasis VGSOLFAT_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}