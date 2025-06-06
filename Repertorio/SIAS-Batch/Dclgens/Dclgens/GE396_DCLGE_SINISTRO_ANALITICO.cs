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
    public class GE396_DCLGE_SINISTRO_ANALITICO : VarBasis
    {
        /*"    10 GE396-NUM-ANO-REFER  PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_NUM_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-NUM-MES-REFER  PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_NUM_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-NUM-DIA-REFER  PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_NUM_DIA_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-IND-TIPO-MOVTO       PIC X(1).*/
        public StringBasis GE396_IND_TIPO_MOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE396-NUM-SINISTRO   PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE396_NUM_SINISTRO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE396-NUM-OCORRENCIA       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_NUM_OCORRENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-DTA-MOVIMENTO  PIC X(10).*/
        public StringBasis GE396_DTA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE396-SEQ-OCORR-HIST       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_SEQ_OCORR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-COD-TIPO-OPER  PIC S9(9) USAGE COMP.*/
        public IntBasis GE396_COD_TIPO_OPER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE396-COD-OPERACAO   PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-COD-EMPRESA    PIC S9(9) USAGE COMP.*/
        public IntBasis GE396_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 GE396-IND-TIPO-SEGURO       PIC X(1).*/
        public StringBasis GE396_IND_TIPO_SEGURO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE396-COD-ORGAO-EMIS       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_ORGAO_EMIS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-COD-RAMO-COBERT       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_RAMO_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-DTA-OCORRENCIA       PIC X(10).*/
        public StringBasis GE396_DTA_OCORRENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE396-DTA-COMUNICADO       PIC X(10).*/
        public StringBasis GE396_DTA_COMUNICADO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 GE396-NUM-APOLICE    PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis GE396_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 GE396-NUM-ITEM       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis GE396_NUM_ITEM { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 GE396-NOM-RAZAO      PIC X(40).*/
        public StringBasis GE396_NOM_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE396-NOM-FAVORECIDO       PIC X(40).*/
        public StringBasis GE396_NOM_FAVORECIDO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"    10 GE396-COD-MOEDA-SINI       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_MOEDA_SINI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-VLR-OPERACAO   PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_OPERACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-LIDER      PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_LIDER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-COSSEGURO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_COSSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-RESSEGURO  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_RESSEGURO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-STA-SITUACAO   PIC X(1).*/
        public StringBasis GE396_STA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 GE396-COD-PRODUTO    PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_PRODUTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-COD-RAMO-SUSEP       PIC S9(4) USAGE COMP.*/
        public IntBasis GE396_COD_RAMO_SUSEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 GE396-NOM-PROGRAMA   PIC X(8).*/
        public StringBasis GE396_NOM_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 GE396-DTH-ATUALIZACAO       PIC X(26).*/
        public StringBasis GE396_DTH_ATUALIZACAO { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 GE396-VLR-OPERACAO-JUD       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_OPERACAO_JUD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-LIDER-JUD  PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_LIDER_JUD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-COSSEGURO-JUD       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_COSSEGURO_JUD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-VLR-RESSEGURO-JUD       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis GE396_VLR_RESSEGURO_JUD { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 GE396-PCT-JUD        PIC S9(1)V9(4) USAGE COMP-3.*/
        public DoubleBasis GE396_PCT_JUD { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(1)V9(4)"), 4);
    }
}