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
    public class JVBKINCL_JV_CONVENIOS : VarBasis
    {
        /*"  05  CVPCV-911241                 PIC S9(009) COMP-5                                               VALUE 912085*/
        public IntBasis CVPCV_911241 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 912085);
        /*"  05  JV1CV-911241                 PIC S9(009) COMP-5                                               VALUE 911241*/
        public IntBasis JV1CV_911241 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 911241);
        /*"  05  CVPCV-911334                 PIC S9(009) COMP-5                                               VALUE 912086*/
        public IntBasis CVPCV_911334 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 912086);
        /*"  05  JV1CV-911334                 PIC S9(009) COMP-5                                               VALUE 911334*/
        public IntBasis JV1CV_911334 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 911334);
        /*"  05  CVPCV-021000                 PIC S9(009) COMP-5                                               VALUE 021000*/
        public IntBasis CVPCV_021000 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 021000);
        /*"  05  JV1CV-021000                 PIC S9(009) COMP-5                                               VALUE 021000*/
        public IntBasis JV1CV_021000 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 021000);
        /*"  05  CVPCV-912014                 PIC S9(009) COMP-5                                               VALUE 912087*/
        public IntBasis CVPCV_912014 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 912087);
        /*"  05  JV1CV-912014                 PIC S9(009) COMP-5                                               VALUE 912014*/
        public IntBasis JV1CV_912014 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 912014);
        /*"  05  CVPCV-695996                 PIC S9(009) COMP-5                                               VALUE 933828*/
        public IntBasis CVPCV_695996 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 933828);
        /*"  05  JV1CV-695996                 PIC S9(009) COMP-5                                               VALUE 976556*/
        public IntBasis JV1CV_695996 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 976556);
        /*"  05  CVPCV-696005                 PIC S9(009) COMP-5                                               VALUE 974800*/
        public IntBasis CVPCV_696005 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 974800);
        /*"  05  JV1CV-696005                 PIC S9(009) COMP-5                                               VALUE 976557*/
        public IntBasis JV1CV_696005 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"), 976557);
        /*"01    JV-AGE-AVISO*/
    }
}