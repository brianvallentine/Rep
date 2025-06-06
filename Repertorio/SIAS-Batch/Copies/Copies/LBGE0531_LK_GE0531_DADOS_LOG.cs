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
    public class LBGE0531_LK_GE0531_DADOS_LOG : VarBasis
    {
        /*"        10  LK-GE0531-NUM-APOLICE       PIC  9(018) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"        10  LK-GE0531-NUM-ENDOSSO       PIC  9(018) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"        10  LK-GE0531-NUM-SINISTRO      PIC  9(018) VALUE 0.*/
        public IntBasis LK_GE0531_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"        10  LK-GE0531-OCORR-HISTORICO   PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-COD-OPER-SINISTRO PIC  9(006) VALUE 0.*/
        public IntBasis LK_GE0531_COD_OPER_SINISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"        10  LK-GE0531-COD-CARGO         PIC  9(009) VALUE 0.*/
        public IntBasis LK_GE0531_COD_CARGO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"        10  LK-GE0531-DES-CARGO         PIC  X(070) VALUE SPACES*/
        public StringBasis LK_GE0531_DES_CARGO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"        10  LK-GE0531-NOM-ORGAO         PIC  X(070) VALUE SPACES*/
        public StringBasis LK_GE0531_NOM_ORGAO { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
        /*"        10  LK-GE0531-COD-RELACAO-EXT   PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_COD_RELACAO_EXT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-COD-RELACAO-INT   PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_COD_RELACAO_INT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-IND-TIPO-PESSOA   PIC  X(001) VALUE SPACES*/
        public StringBasis LK_GE0531_IND_TIPO_PESSOA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"        10  LK-GE0531-IND-MOVIMENTO     PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_IND_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-IND-EVENTO        PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_IND_EVENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-DTA-INCLUSAO      PIC  X(010) VALUE SPACES*/
        public StringBasis LK_GE0531_DTA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"        10  LK-GE0531-STA-REGISTRO      PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_STA_REGISTRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-COD-ORIGEM        PIC  9(004) VALUE 0.*/
        public IntBasis LK_GE0531_COD_ORIGEM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"        10  LK-GE0531-COD-USUARIO       PIC  X(008) VALUE SPACES*/
        public StringBasis LK_GE0531_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"        10  LK-GE0531-NOM-PROGRAMA      PIC  X(008) VALUE SPACES*/
        public StringBasis LK_GE0531_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"        10  LK-GE0531-DTH-CAD           PIC  X(026) VALUE SPACES*/
        public StringBasis LK_GE0531_DTH_CAD { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"");
        /*"    05  LK-GE0531-GERAL.*/
    }
}