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
    public class LBGE0530_LK_GE0530 : VarBasis
    {
        /*"    05  LK-GE0530-FUNCAO                PIC  X(003) VALUE ' '*/
        public StringBasis LK_GE0530_FUNCAO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
        /*"    05  LK-GE0530-CPF-CNPJ              PIC  9(011) VALUE   0*/
        public IntBasis LK_GE0530_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
        /*"    05  LK-GE0530-SEQ-REGISTRO          PIC  9(009) VALUE   0*/
        public IntBasis LK_GE0530_SEQ_REGISTRO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0530-NOME-PESSOA           PIC  X(070) VALUE ' '*/
        public StringBasis LK_GE0530_NOME_PESSOA { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @" ");
        /*"    05  LK-GE0530-NUM-RAMO-EMISSOR      PIC  9(004) VALUE   0*/
        public IntBasis LK_GE0530_NUM_RAMO_EMISSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  LK-GE0530-COD-PRODUTO           PIC  9(009) VALUE   0*/
        public IntBasis LK_GE0530_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0530-COD-FONTE             PIC  9(004) VALUE   0*/
        public IntBasis LK_GE0530_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  LK-GE0530-NUM-PROPOSTA          PIC  9(009) VALUE   0*/
        public IntBasis LK_GE0530_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05  LK-GE0530-NUM-CERTIFIC-EXT      PIC  9(018) VALUE   0*/
        public IntBasis LK_GE0530_NUM_CERTIFIC_EXT { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    05  LK-GE0530-NUM-APOLICE           PIC  9(018) VALUE   0*/
        public IntBasis LK_GE0530_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    05  LK-GE0530-NUM-ENDOSSO           PIC  9(018) VALUE   0*/
        public IntBasis LK_GE0530_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    05  LK-GE0530-NUM-SINISTRO          PIC  9(018) VALUE   0*/
        public IntBasis LK_GE0530_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "18", "9(018)"));
        /*"    05  LK-GE0530-OCORR-HISTORICO       PIC  9(004) VALUE   0*/
        public IntBasis LK_GE0530_OCORR_HISTORICO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05  LK-GE0530-COD-OPER-SINISTRO     PIC  9(006) VALUE   0*/
        public IntBasis LK_GE0530_COD_OPER_SINISTRO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
        /*"    05  LK-GE0530-COD-USUARIO           PIC  X(008) VALUE ' '*/
        public StringBasis LK_GE0530_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
        /*"    05  LK-GE0530-NOM-PRG-SOLICITA      PIC  X(008) VALUE ' '*/
        public StringBasis LK_GE0530_NOM_PRG_SOLICITA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
        /*"    05  LK-GE0530-GERAL*/
        public LBGE0530_LK_GE0530_GERAL LK_GE0530_GERAL { get; set; } = new LBGE0530_LK_GE0530_GERAL();

        public LBGE0530_LK_GE0530_RELATORIOS LK_GE0530_RELATORIOS { get; set; } = new LBGE0530_LK_GE0530_RELATORIOS();

    }
}