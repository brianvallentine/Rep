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
    public class TERMOADE_DCLTERMO_ADESAO : VarBasis
    {
        /*"    10 TERMOADE-NUM-TERMO   PIC S9(11)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "11", "S9(11)V"), 0);
        /*"    10 TERMOADE-COD-SUBGRUPO       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-DATA-ADESAO       PIC X(10).*/
        public StringBasis TERMOADE_DATA_ADESAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TERMOADE-COD-AGENCIA-OP       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_AGENCIA_OP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-NUM-MATRICULA-VEN       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_MATRICULA_VEN { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TERMOADE-CODPDTVEN   PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_CODPDTVEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMVEN    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMVEN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-PCADIANTVEN       PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCADIANTVEN { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-COD-AGENCIA-VEN       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_AGENCIA_VEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-OPERACAO-CONTA-VEN       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_OPERACAO_CONTA_VEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-NUM-CONTA-VEN       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_CONTA_VEN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 TERMOADE-DIG-CONTA-VEN       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_DIG_CONTA_VEN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-NUM-MATRICULA-GER       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_MATRICULA_GER { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TERMOADE-CODPDTGER   PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_CODPDTGER { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMGER    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMGER { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-COD-AGENCIA-GER       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_AGENCIA_GER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-OPERACAO-CONTA-GER       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_OPERACAO_CONTA_GER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-NUM-CONTA-GER       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_CONTA_GER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"    10 TERMOADE-DIG-CONTA-GER       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_DIG_CONTA_GER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-NUM-MATRICULA-SUR       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_MATRICULA_SUR { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TERMOADE-CODPDTSUR   PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_CODPDTSUR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMSUR    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMSUR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-NUM-MATRICULA-GCO       PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_MATRICULA_GCO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"    10 TERMOADE-CODPDTGCO   PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_CODPDTGCO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMGCO    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMGCO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-MODALIDADE-CAPITAL       PIC X(1).*/
        public StringBasis TERMOADE_MODALIDADE_CAPITAL { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-TIPO-PLANO  PIC X(1).*/
        public StringBasis TERMOADE_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-IND-PLANO-ASSOCIAD       PIC X(1).*/
        public StringBasis TERMOADE_IND_PLANO_ASSOCIAD { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-COD-PLANO-VGAPC       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_COD_PLANO_VGAPC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-COD-PLANO-APC       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_COD_PLANO_APC { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-VAL-CONTRATADO       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_VAL_CONTRATADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TERMOADE-VAL-COMISSAO-ADIAN       PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_VAL_COMISSAO_ADIAN { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TERMOADE-QUANT-VIDAS       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_QUANT_VIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-TIPO-COBERTURA       PIC X(1).*/
        public StringBasis TERMOADE_TIPO_COBERTURA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-PERI-PAGAMENTO       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_PERI_PAGAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-TIPO-CORRECAO       PIC X(1).*/
        public StringBasis TERMOADE_TIPO_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-PERIODO-CORRECAO       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_PERIODO_CORRECAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-COD-MOEDA-IMP       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-COD-MOEDA-PRM       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-COD-CLIENTE       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-OCORR-ENDERECO       PIC S9(4) USAGE COMP.*/
        public IntBasis TERMOADE_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"    10 TERMOADE-COD-CORRETOR       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_COD_CORRETOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMCOR    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMCOR { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-COD-ADMINISTRADOR       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_COD_ADMINISTRADOR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-PCCOMADM    PIC S9(3)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_PCCOMADM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"    10 TERMOADE-COD-USUARIO       PIC X(8).*/
        public StringBasis TERMOADE_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"    10 TERMOADE-DATA-INCLUSAO       PIC X(10).*/
        public StringBasis TERMOADE_DATA_INCLUSAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TERMOADE-SITUACAO    PIC X(1).*/
        public StringBasis TERMOADE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"    10 TERMOADE-TIMESTAMP   PIC X(26).*/
        public StringBasis TERMOADE_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"    10 TERMOADE-NUM-PROPOSTA       PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-NUM-RCAP    PIC S9(9) USAGE COMP.*/
        public IntBasis TERMOADE_NUM_RCAP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(9)"));
        /*"    10 TERMOADE-DATA-RCAP   PIC X(10).*/
        public StringBasis TERMOADE_DATA_RCAP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"    10 TERMOADE-VAL-RCAP    PIC S9(13)V9(2) USAGE COMP-3.*/
        public DoubleBasis TERMOADE_VAL_RCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V9(2)"), 2);
        /*"    10 TERMOADE-NUM-APOLICE       PIC S9(13)V USAGE COMP-3.*/
        public DoubleBasis TERMOADE_NUM_APOLICE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V"), 0);
        /*"*/
    }
}