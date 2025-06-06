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
    public class FC239_DCLFC_PLANO_EMP_PARC : VarBasis
    {
        /*"    10 FC239-NUM-PLANO      PIC S9(4) USAGE COMP.*/
        public IntBasis FC239_NUM_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC239-IDE-CLIENTE    PIC S9(9) USAGE COMP.*/
        public IntBasis FC239_IDE_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FC239-COD-UNIDADE    PIC S9(9) USAGE COMP.*/
        public IntBasis FC239_COD_UNIDADE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 FC239-NUM-MOD-PLANO  PIC S9(4) USAGE COMP.*/
        public IntBasis FC239_NUM_MOD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC239-COD-RAMO       PIC S9(4) USAGE COMP.*/
        public IntBasis FC239_COD_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC239-STA-PARCERIA   PIC X(3).*/
        public StringBasis FC239_STA_PARCERIA { get; set; } = new StringBasis(new PIC("X", "3", "X(3)."), @"");
        /*"    10 FC239-DTH-INI-PARCERIA       PIC X(10).*/
        public StringBasis FC239_DTH_INI_PARCERIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 FC239-STA-RENOVA     PIC X(1).*/
        public StringBasis FC239_STA_RENOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FC239-STA-ATIVACAO   PIC X(1).*/
        public StringBasis FC239_STA_ATIVACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FC239-QTD-DIAS-CANCELA       PIC S9(4) USAGE COMP.*/
        public IntBasis FC239_QTD_DIAS_CANCELA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 FC239-STA-CANCELAMENTO       PIC X(1).*/
        public StringBasis FC239_STA_CANCELAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 FC239-IND-TP-FLUXO-VENDA       PIC X(6).*/
        public StringBasis FC239_IND_TP_FLUXO_VENDA { get; set; } = new StringBasis(new PIC("X", "6", "X(6)."), @"");
        /*"*/
    }
}