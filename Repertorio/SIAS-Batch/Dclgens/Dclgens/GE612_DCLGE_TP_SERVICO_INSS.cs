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
    public class GE612_DCLGE_TP_SERVICO_INSS : VarBasis
    {
        /*"    10 GE612-SEQ-TP-SERVICO-INSS       PIC S9(9) USAGE COMP.*/
        public IntBasis GE612_SEQ_TP_SERVICO_INSS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE612-COD-TP-SERVICO-INSS       PIC X(9).*/
        public StringBasis GE612_COD_TP_SERVICO_INSS { get; set; } = new StringBasis(new PIC("X", "9", "X(9)."), @"");
        /*"    10 GE612-DES-TP-SERVICO-INSS       PIC X(100).*/
        public StringBasis GE612_DES_TP_SERVICO_INSS { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"    10 GE612-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis GE612_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE612-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis GE612_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE612-COD-USUARIO    PIC X(8).*/
        public StringBasis GE612_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE612-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE612_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE612-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE612_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
    }
}