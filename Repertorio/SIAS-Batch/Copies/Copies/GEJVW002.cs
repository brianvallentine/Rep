using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Copies
{
    public class GEJVW002 : VarBasis
    {
        /*"01  LK-GEJVW002-COD-USUARIO-ORIGEM    PIC  X(008)*/
        public StringBasis LK_GEJVW002_COD_USUARIO_ORIGEM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01  LK-GEJVW002-NOM-PROG-ORIGEM       PIC  X(010)*/
        public StringBasis LK_GEJVW002_NOM_PROG_ORIGEM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GEJVW002-SIAS-NUM-EMP          PIC S9(009) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_SIAS_NUM_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-GEJVW002-SIAS-DTA-INI          PIC  X(010)*/
        public StringBasis LK_GEJVW002_SIAS_DTA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GEJVW002-SIAS-COD-CGCCPF       PIC S9(15)V USAGE COMP-3*/
        public DoubleBasis LK_GEJVW002_SIAS_COD_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  LK-GEJVW002-SIAS-COD-LIDER        PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_SIAS_COD_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GEJVW002-SIAS-COD-EMP-CAP      PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_SIAS_COD_EMP_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GEJVW002-PREV-NUM-EMP          PIC S9(009) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_PREV_NUM_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-GEJVW002-PREV-DTA-INI          PIC  X(010)*/
        public StringBasis LK_GEJVW002_PREV_DTA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GEJVW002-PREV-COD-CGCCPF       PIC S9(15)V USAGE COMP-3*/
        public DoubleBasis LK_GEJVW002_PREV_COD_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  LK-GEJVW002-PREV-COD-LIDER        PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_PREV_COD_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GEJVW002-PREV-COD-EMP-CAP      PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_PREV_COD_EMP_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GEJVW002-JV-NUM-EMP            PIC S9(009) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_JV_NUM_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  LK-GEJVW002-JV-DTA-INI            PIC  X(010)*/
        public StringBasis LK_GEJVW002_JV_DTA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01  LK-GEJVW002-JV-COD-CGCCPF         PIC S9(15)V USAGE COMP-3*/
        public DoubleBasis LK_GEJVW002_JV_COD_CGCCPF { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  LK-GEJVW002-JV-COD-LIDER          PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_JV_COD_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01  LK-GEJVW002-JV-COD-EMP-CAP        PIC S9(004) USAGE COMP-5*/
        public IntBasis LK_GEJVW002_JV_COD_EMP_CAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"*/
    }
}