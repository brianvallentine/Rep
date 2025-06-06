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
    public class VG082_DCLVG_HIST_CONT_COBER : VarBasis
    {
        /*"    10 VG082-NUM-CERTIFICADO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis VG082_NUM_CERTIFICADO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 VG082-NUM-PARCELA    PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_NUM_PARCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-NUM-TITULO     PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis VG082_NUM_TITULO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 VG082-OCORR-HISTORICO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-COD-GRUPO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_COD_GRUPO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-RAMO-EMISSOR   PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-COD-MODALIDADE       PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_COD_MODALIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-COD-COBERTURA  PIC S9(4) USAGE COMP.*/
        public IntBasis VG082_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG082-VLR-PREMIO-RAMO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis VG082_VLR_PREMIO_RAMO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 VG082-COD-USUARIO    PIC X(8).*/
        public StringBasis VG082_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 VG082-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis VG082_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}