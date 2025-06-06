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
    public class SISINCHE_DCLSI_SINI_CHEQUE : VarBasis
    {
        /*"    10 SISINCHE-NUM-APOL-SINISTRO  PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis SISINCHE_NUM_APOL_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 SISINCHE-COD-OPERACAO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINCHE_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINCHE-OCORR-HISTORICO  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINCHE_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINCHE-NUM-CHEQUE-INTERNO  PIC S9(9) USAGE COMP.*/
        public IntBasis SISINCHE_NUM_CHEQUE_INTERNO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SISINCHE-COD-DESPESA  PIC S9(4) USAGE COMP.*/
        public IntBasis SISINCHE_COD_DESPESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SISINCHE-COD-EMPRESA  PIC S9(9) USAGE COMP.*/
        public IntBasis SISINCHE_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"*/
    }
}