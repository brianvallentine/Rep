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
    public class GE089_DCLGE_PRODUTO_COMPLEMENTO : VarBasis
    {
        /*"    10 GE089-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-SEQ-PRODUTO-VRS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_SEQ_PRODUTO_VRS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis GE089_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE089-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis GE089_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE089-IND-FLUXO-PARAMTRIZADO       PIC X(1).*/
        public StringBasis GE089_IND_FLUXO_PARAMTRIZADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-COD-PERIOD-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_PERIOD_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-QTD-PERIOD-VIGENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_QTD_PERIOD_VIGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-COD-MOEDA      PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-IND-RENOVA     PIC X(1).*/
        public StringBasis GE089_IND_RENOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-RENOVA-AUTOMATICA       PIC X(1).*/
        public StringBasis GE089_IND_RENOVA_AUTOMATICA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-QTD-RENOVA-AUTOMATICA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_QTD_RENOVA_AUTOMATICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-IND-DPS        PIC X(1).*/
        public StringBasis GE089_IND_DPS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-REENQUADRA-PREMIO       PIC X(1).*/
        public StringBasis GE089_IND_REENQUADRA_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-REAJUSTE-PREMIO       PIC X(1).*/
        public StringBasis GE089_IND_REAJUSTE_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-COD-INDICE-REAJUSTE       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_INDICE_REAJUSTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-COD-PERIOD-REAJUSTE       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_PERIOD_REAJUSTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-COD-INDICE-DEVOLUCAO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE089_COD_INDICE_DEVOLUCAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE089-PCT-JUROS-DEVOLUCAO       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE089_PCT_JUROS_DEVOLUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 GE089-PCT-MULTA-DEVOLUCAO       PIC S9(3)V9(5) USAGE COMP-3.*/
        public DoubleBasis GE089_PCT_MULTA_DEVOLUCAO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(5)"), 5);
        /*"    10 GE089-IND-FLUXO-COMISSAO       PIC X(1).*/
        public StringBasis GE089_IND_FLUXO_COMISSAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-ACOPLADO   PIC X(1).*/
        public StringBasis GE089_IND_ACOPLADO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-FLUXO-SINISTRO       PIC X(1).*/
        public StringBasis GE089_IND_FLUXO_SINISTRO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-IND-CONJUGE    PIC X(1).*/
        public StringBasis GE089_IND_CONJUGE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE089-COD-USUARIO    PIC X(8).*/
        public StringBasis GE089_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE089-NOM-PROGRAMA   PIC X(10).*/
        public StringBasis GE089_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE089-DTH-CADASTRAMENTO       PIC X(26).*/
        public StringBasis GE089_DTH_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"*/
    }
}