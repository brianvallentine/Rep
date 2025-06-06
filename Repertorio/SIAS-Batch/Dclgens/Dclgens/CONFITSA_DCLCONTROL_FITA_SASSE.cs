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
    public class CONFITSA_DCLCONTROL_FITA_SASSE : VarBasis
    {
        /*"    10 CONFITSA-NSAS        PIC S9(4) USAGE COMP.*/
        public IntBasis CONFITSA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONFITSA-DATA-GERACAO  PIC X(10).*/
        public StringBasis CONFITSA_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONFITSA-DATA-LANCAMENTO  PIC X(10).*/
        public StringBasis CONFITSA_DATA_LANCAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONFITSA-PGM-GERADOR  PIC X(8).*/
        public StringBasis CONFITSA_PGM_GERADOR { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 CONFITSA-ORIGEM-MOV  PIC X(1).*/
        public StringBasis CONFITSA_ORIGEM_MOV { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 CONFITSA-VER-PGM-GER  PIC S9(4) USAGE COMP.*/
        public IntBasis CONFITSA_VER_PGM_GER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONFITSA-VER-LAYOUT-GER  PIC S9(4) USAGE COMP.*/
        public IntBasis CONFITSA_VER_LAYOUT_GER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONFITSA-QTDE-REG-GER  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITSA_QTDE_REG_GER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITSA-TOT-DEB-GER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_DEB_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITSA-TOT-CRED-GER  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_CRED_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITSA-ULT-NSL-GER  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITSA_ULT_NSL_GER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITSA-QTDE-LANC-DEB-RET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITSA_QTDE_LANC_DEB_RET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITSA-TOT-DEB-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_DEB_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITSA-TOT-DEB-NAO-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_DEB_NAO_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITSA-QTDE-LANC-CRED-RET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITSA_QTDE_LANC_CRED_RET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITSA-TOT-CRED-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_CRED_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITSA-TOT-CRED-NAO-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITSA_TOT_CRED_NAO_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"*/
    }
}