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
    public class GE0071W_LK_0071_S_ARR_OCC : VarBasis
    {
        /*"   10 LK-0071-S-A-COD-COBERTURA      PIC S9(004) COMP-5*/
        public IntBasis LK_0071_S_A_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   10 LK-0071-S-A-VLR-IS             PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_0071_S_A_VLR_IS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"   10 LK-0071-S-A-VLR-PREMIO         PIC S9(013)V9(2) COMP-3*/
        public DoubleBasis LK_0071_S_A_VLR_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"   10 LK-0071-S-A-PCT-PARTICIPACAO   PIC S9(010)V9(7) COMP-3*/
        public DoubleBasis LK_0071_S_A_PCT_PARTICIPACAO { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(7)"), 7);
        /*"   10 LK-0071-S-A-IND-TP-COBER       PIC  X(001)*/
        public StringBasis LK_0071_S_A_IND_TP_COBER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"   10 LK-0071-S-A-IND-SINIS-CANC     PIC  X(001)*/
        public StringBasis LK_0071_S_A_IND_SINIS_CANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"   10 LK-0071-S-A-IND-INDNZ-MAISVEZ  PIC  X(001)*/
        public StringBasis LK_0071_S_A_IND_INDNZ_MAISVEZ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"   10 LK-0071-S-A-COD-RAMO-COBER     PIC S9(004) COMP-5*/
        public IntBasis LK_0071_S_A_COD_RAMO_COBER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"   10 LK-0071-S-A-DES-APRES-DOC      PIC  X(100)*/
        public StringBasis LK_0071_S_A_DES_APRES_DOC { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
        /*"  01   LK-0071-IND-ERRO               PIC S9(004) COMP-5*/
    }
}