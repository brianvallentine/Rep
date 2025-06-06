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
    public class CONFITCE_DCLCONTROLE_FITAS_CEF : VarBasis
    {
        /*"    10 CONFITCE-NSAC        PIC S9(4) USAGE COMP.*/
        public IntBasis CONFITCE_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONFITCE-DATA-GERACAO  PIC X(10).*/
        public StringBasis CONFITCE_DATA_GERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 CONFITCE-VER-LAYOUT  PIC S9(4) USAGE COMP.*/
        public IntBasis CONFITCE_VER_LAYOUT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 CONFITCE-QTDE-REG    PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITCE_QTDE_REG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITCE-QTDE-LANC-DEB-RET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITCE_QTDE_LANC_DEB_RET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITCE-TOT-DEB-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITCE_TOT_DEB_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITCE-TOT-DEB-NAO-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITCE_TOT_DEB_NAO_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITCE-QTDE-LANC-CRED-RET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITCE_QTDE_LANC_CRED_RET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITCE-TOT-CRED-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITCE_TOT_CRED_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITCE-TOT-CRED-NAO-EFET  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis CONFITCE_TOT_CRED_NAO_EFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 CONFITCE-QTDE-DEB-EFET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITCE_QTDE_DEB_EFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 CONFITCE-QTDE-CRED-EFET  PIC S9(9) USAGE COMP.*/
        public IntBasis CONFITCE_QTDE_CRED_EFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}