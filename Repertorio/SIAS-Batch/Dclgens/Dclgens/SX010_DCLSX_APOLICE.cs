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
    public class SX010_DCLSX_APOLICE : VarBasis
    {
        /*"    10 SX010-SEQ-PROP-APOL  PIC S9(9) USAGE COMP.*/
        public IntBasis SX010_SEQ_PROP_APOL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX010-NUM-APOLICE    PIC S9(18) USAGE COMP.*/
        public IntBasis SX010_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "18", "S9(18)"));
        /*"    10 SX010-STA-APOLICE    PIC X(1).*/
        public StringBasis SX010_STA_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-DTA-INI-VIGENCIA       PIC X(10).*/
        public StringBasis SX010_DTA_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-DTA-FIM-VIGENCIA       PIC X(10).*/
        public StringBasis SX010_DTA_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-COD-PROC-SUSEP       PIC X(30).*/
        public StringBasis SX010_COD_PROC_SUSEP { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
        /*"    10 SX010-COD-FONTE      PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-QTD-PRAZO-MAX  PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_QTD_PRAZO_MAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-IND-PERIODICIDADE-COBR       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_IND_PERIODICIDADE_COBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-IND-TP-PAGAMENTO       PIC X(1).*/
        public StringBasis SX010_IND_TP_PAGAMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-VLR-IS-INDIVIDUAL       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis SX010_VLR_IS_INDIVIDUAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 SX010-VLR-PREMIO-INDIVIDUAL       PIC S9(8)V9(2) USAGE COMP-3.*/
        public DoubleBasis SX010_VLR_PREMIO_INDIVIDUAL { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(8)V9(2)"), 2);
        /*"    10 SX010-DTA-FIM-AVERBACAO       PIC X(10).*/
        public StringBasis SX010_DTA_FIM_AVERBACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-VLR-IDADE-LIM-MIN       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_VLR_IDADE_LIM_MIN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-VLR-IDADE-LIM-MAX       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_VLR_IDADE_LIM_MAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-QTD-MES-IDADE-MAX       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_QTD_MES_IDADE_MAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-PCT-JUROS-MORA       PIC S9(2)V9(4) USAGE COMP-3.*/
        public DoubleBasis SX010_PCT_JUROS_MORA { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(4)"), 4);
        /*"    10 SX010-DTA-CADASTRAMENTO       PIC X(10).*/
        public StringBasis SX010_DTA_CADASTRAMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-QTD-MOV-RETROATIVO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_QTD_MOV_RETROATIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-IND-FORMULA-PREMIO       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_IND_FORMULA_PREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-PCT-TOLERANCIA-PREMIO       PIC S9(2)V9(6) USAGE COMP-3.*/
        public DoubleBasis SX010_PCT_TOLERANCIA_PREMIO { get; set; } = new DoubleBasis(new PIC("S9", "2", "S9(2)V9(6)"), 6);
        /*"    10 SX010-COD-IND-CORRECAO       PIC X(20).*/
        public StringBasis SX010_COD_IND_CORRECAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"    10 SX010-IND-CALC-PREMIO       PIC X(1).*/
        public StringBasis SX010_IND_CALC_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-PERIODICIDADE-SD       PIC X(1).*/
        public StringBasis SX010_IND_PERIODICIDADE_SD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-COD-MOEDA      PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-IND-FORMA-COBRANCA       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_IND_FORMA_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-DTA-PROPOSTA   PIC X(10).*/
        public StringBasis SX010_DTA_PROPOSTA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-COD-FORM-CERTIF       PIC X(10).*/
        public StringBasis SX010_COD_FORM_CERTIF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-IND-EMISSAO-CERTIF       PIC X(1).*/
        public StringBasis SX010_IND_EMISSAO_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-MIGRACAO   PIC X(1).*/
        public StringBasis SX010_IND_MIGRACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-POSTAR-CERTIF       PIC X(1).*/
        public StringBasis SX010_IND_POSTAR_CERTIF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-IOF-PREMIO       PIC X(1).*/
        public StringBasis SX010_IND_IOF_PREMIO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-TP-APOLICE       PIC X(1).*/
        public StringBasis SX010_IND_TP_APOLICE { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-IND-FATURA-MANUAL       PIC X(1).*/
        public StringBasis SX010_IND_FATURA_MANUAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-QTD-PRAZO-PROPOSTA       PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_QTD_PRAZO_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 SX010-PCT-REMUNERACAO-ESTIP       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SX010_PCT_REMUNERACAO_ESTIP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SX010-IND-ISENCAO-IOF       PIC X(1).*/
        public StringBasis SX010_IND_ISENCAO_IOF { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-DTA-APOLICE    PIC X(10).*/
        public StringBasis SX010_DTA_APOLICE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 SX010-COD-USUARIO-APOL       PIC X(8).*/
        public StringBasis SX010_COD_USUARIO_APOL { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SX010-COD-USUARIO-PROP       PIC X(8).*/
        public StringBasis SX010_COD_USUARIO_PROP { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 SX010-NUM-PES-ESTIP  PIC S9(9) USAGE COMP.*/
        public IntBasis SX010_NUM_PES_ESTIP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 SX010-IND-ANALISA-IS       PIC X(1).*/
        public StringBasis SX010_IND_ANALISA_IS { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 SX010-PCT-MAX-COMPR-RENDA       PIC S9(3)V9(4) USAGE COMP-3.*/
        public DoubleBasis SX010_PCT_MAX_COMPR_RENDA { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(4)"), 4);
        /*"    10 SX010-COD-EMPRESA    PIC S9(4) USAGE COMP.*/
        public IntBasis SX010_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"*/
    }
}