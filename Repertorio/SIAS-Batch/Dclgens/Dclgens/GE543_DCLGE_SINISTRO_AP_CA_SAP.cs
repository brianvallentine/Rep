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
    public class GE543_DCLGE_SINISTRO_AP_CA_SAP : VarBasis
    {
        /*"    10 GE543-NUM-IDLG       PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_NUM_IDLG { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-COD-RAMO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-COD-PRODUTO    PIC S9(9) USAGE COMP.*/
        public IntBasis GE543_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE543-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-NUM-SINISTRO   PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-NUM-OCOR-HIST  PIC S9(9) USAGE COMP.*/
        public IntBasis GE543_NUM_OCOR_HIST { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE543-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-DTA-AVISO      PIC X(10).*/
        public StringBasis GE543_DTA_AVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE543-DTA-COMUNICADO       PIC X(10).*/
        public StringBasis GE543_DTA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE543-DTA-COMUNICADO-SENTENCA       PIC X(10).*/
        public StringBasis GE543_DTA_COMUNICADO_SENTENCA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE543-DTA-SENTENCA-JUDICIAL       PIC X(10).*/
        public StringBasis GE543_DTA_SENTENCA_JUDICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE543-COD-PROCESSO-JURIDICO       PIC X(30).*/
        public StringBasis GE543_COD_PROCESSO_JURIDICO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE543-NUM-CPF-CNPJ-BENEFIC       PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_NUM_CPF_CNPJ_BENEFIC { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-COD-SERVICO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_SERVICO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-COD-FONTE-ISS  PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_FONTE_ISS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-NUM-DOCTO-FISCAL       PIC X(30).*/
        public StringBasis GE543_NUM_DOCTO_FISCAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE543-COD-SERIE-DOC-FISCAL       PIC X(30).*/
        public StringBasis GE543_COD_SERIE_DOC_FISCAL { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE543-COD-AGRUPADOR  PIC X(30).*/
        public StringBasis GE543_COD_AGRUPADOR { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 GE543-NUM-CNPJ-TOMADORA-SERV       PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_NUM_CNPJ_TOMADORA_SERV { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-COD-INDICATIVO-CNO       PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_INDICATIVO_CNO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE543-COD-CNO        PIC S9(18) USAGE COMP.*/
        public IntBasis GE543_COD_CNO { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 GE543-DTA-NOTA-FISCAL       PIC X(10).*/
        public StringBasis GE543_DTA_NOTA_FISCAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE543-COD-CNAE       PIC X(8).*/
        public StringBasis GE543_COD_CNAE { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE543-COD-PROCESSO-JUDICIAL       PIC X(21).*/
        public StringBasis GE543_COD_PROCESSO_JUDICIAL { get; set; } = new StringBasis(new PIC("X", "21", "X(21)."), @"");
        /*"    10 GE543-COD-TIPO-SERVICO       PIC X(9).*/
        public StringBasis GE543_COD_TIPO_SERVICO { get; set; } = new StringBasis(new PIC("X", "9", "X(9)."), @"");
        /*"    10 GE543-VLR-DEDUCAO-MEAT       PIC S9(16)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE543_VLR_DEDUCAO_MEAT { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V9(2)"), 2);
        /*"    10 GE543-VLR-RET-NOTA-FISCAL       PIC S9(16)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE543_VLR_RET_NOTA_FISCAL { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V9(2)"), 2);
        /*"    10 GE543-VLR-RETENCAO-PRINCIPAL       PIC S9(16)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE543_VLR_RETENCAO_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("S9", "16", "S9(16)V9(2)"), 2);
        /*"    10 GE543-COD-IMPOSTO-LIMINAR       PIC S9(4) USAGE COMP.*/
        public IntBasis GE543_COD_IMPOSTO_LIMINAR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
    }
}