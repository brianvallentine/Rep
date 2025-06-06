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
    public class SI239_DCLSI_OPERACAO_EVENTO : VarBasis
    {
        /*"    10 SI239-IDE-SISTEMA    PIC X(2).*/
        public StringBasis SI239_IDE_SISTEMA { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI239-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis SI239_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI239-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis SI239_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis SI239_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-COD-EVENTO-SAP       PIC X(10).*/
        public StringBasis SI239_COD_EVENTO_SAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-COD-EVENTO-SAP-SFH       PIC X(10).*/
        public StringBasis SI239_COD_EVENTO_SAP_SFH { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-COD-EVENTO-SAP-JUD       PIC X(10).*/
        public StringBasis SI239_COD_EVENTO_SAP_JUD { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-COD-EMPRESA-SAP       PIC X(4).*/
        public StringBasis SI239_COD_EMPRESA_SAP { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 SI239-COD-SISTEMA-SAP       PIC X(2).*/
        public StringBasis SI239_COD_SISTEMA_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI239-COD-ORIGEM-SAP       PIC X(4).*/
        public StringBasis SI239_COD_ORIGEM_SAP { get; set; } = new StringBasis(new PIC("X", "4", "X(4)."), @"");
        /*"    10 SI239-COD-MODULO-SAP       PIC X(2).*/
        public StringBasis SI239_COD_MODULO_SAP { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"    10 SI239-COD-OPERACAO-BAIXA       PIC S9(4) USAGE COMP.*/
        public IntBasis SI239_COD_OPERACAO_BAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI239-COD-OPERACAO-CANCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis SI239_COD_OPERACAO_CANCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI239-COD-USUARIO    PIC X(8).*/
        public StringBasis SI239_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SI239-COD-PROGRAMA   PIC X(10).*/
        public StringBasis SI239_COD_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SI239-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis SI239_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 SI239-COD-OPER-CANC-PRE       PIC S9(4) USAGE COMP.*/
        public IntBasis SI239_COD_OPER_CANC_PRE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SI239-COD-FUNCAO-OPERACAO-PRE       PIC X(5).*/
        public StringBasis SI239_COD_FUNCAO_OPERACAO_PRE { get; set; } = new StringBasis(new PIC("X", "5", "X(5)."), @"");
    }
}