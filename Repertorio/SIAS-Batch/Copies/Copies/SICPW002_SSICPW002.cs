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
    public class SICPW002_SSICPW002 : VarBasis
    {
        /*"    05 LK-SICPW002-COD-USUARIO            PIC  X(008).*/
        public StringBasis LK_SICPW002_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"    05 LK-SICPW002-NOM-PROGRAMA           PIC  X(010).*/
        public StringBasis LK_SICPW002_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"    05 LK-SICPW002-NUM-SINISTRO           PIC S9(013) COMP-3.*/
        public IntBasis LK_SICPW002_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"    05 LK-SICPW002-COD-OPERACAO           PIC S9(004) COMP-5.*/
        public IntBasis LK_SICPW002_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"    05 LK-SICPW002-OCORR-HISTORICO        PIC S9(004) COMP-5.*/
        public IntBasis LK_SICPW002_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"*/
    }
}