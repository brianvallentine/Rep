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
    public class VG137_DCLVG_ACOPLADO_HIST : VarBasis
    {
        /*"    10 VG137-IDE-SISTEMA    PIC X(2).*/
        public StringBasis VG137_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 VG137-NUM-CERTIFICADO       PIC S9(18) USAGE COMP.*/
        public IntBasis VG137_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 VG137-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis VG137_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG137-COD-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis VG137_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG137-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis VG137_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 VG137-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis VG137_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG137-STA-ACOPLADO   PIC S9(4) USAGE COMP.*/
        public IntBasis VG137_STA_ACOPLADO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG137-COD-EMPRESA-CAP       PIC S9(9) USAGE COMP.*/
        public IntBasis VG137_COD_EMPRESA_CAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG137-QTD-TITULO     PIC S9(4) USAGE COMP.*/
        public IntBasis VG137_QTD_TITULO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG137-VLR-TITULO     PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG137_VLR_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG137-COD-USUARIO    PIC X(8).*/
        public StringBasis VG137_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG137-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis VG137_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG137-SEQ-REMESSA    PIC S9(9) USAGE COMP.*/
        public IntBasis VG137_SEQ_REMESSA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG137-SEQ-REGISTRO   PIC S9(9) USAGE COMP.*/
        public IntBasis VG137_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}