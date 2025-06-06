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
    public class VG113_DCLVG_C612_INFO_RISCO : VarBasis
    {
        /*"    10 VG113-COD-PESSOA     PIC S9(9) USAGE COMP.*/
        public IntBasis VG113_COD_PESSOA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG113-SEQ-PESSOA-HIST       PIC S9(9) USAGE COMP.*/
        public IntBasis VG113_SEQ_PESSOA_HIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 VG113-COD-CLASSIF-RISCO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG113_COD_CLASSIF_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG113-NUM-SCORE-RISCO       PIC S9(4) USAGE COMP.*/
        public IntBasis VG113_NUM_SCORE_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 VG113-DTA-CLASSIF-RISCO       PIC X(10).*/
        public StringBasis VG113_DTA_CLASSIF_RISCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 VG113-IND-PEND-APROVACAO       PIC X(1).*/
        public StringBasis VG113_IND_PEND_APROVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG113-IND-DECL-AUTOMATICO       PIC X(1).*/
        public StringBasis VG113_IND_DECL_AUTOMATICO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 VG113-IND-ATLZ-FAIXA-RISCO       PIC X(1).*/
        public StringBasis VG113_IND_ATLZ_FAIXA_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
    }
}