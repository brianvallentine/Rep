using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0623B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0623B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0623B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1", q3);

            #endregion

            #region PF0623B_TERMO_ADESAO

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_COD_SUBGRUPO" , ""},
                { "TERMOADE_DATA_ADESAO" , ""},
                { "TERMOADE_COD_AGENCIA_OP" , ""},
                { "TERMOADE_NUM_MATRICULA_VEN" , ""},
                { "TERMOADE_CODPDTVEN" , ""},
                { "TERMOADE_PCCOMVEN" , ""},
                { "TERMOADE_PCADIANTVEN" , ""},
                { "TERMOADE_COD_AGENCIA_VEN" , ""},
                { "TERMOADE_OPERACAO_CONTA_VEN" , ""},
                { "TERMOADE_NUM_CONTA_VEN" , ""},
                { "TERMOADE_DIG_CONTA_VEN" , ""},
                { "TERMOADE_NUM_MATRICULA_GER" , ""},
                { "TERMOADE_CODPDTGER" , ""},
                { "TERMOADE_PCCOMGER" , ""},
                { "TERMOADE_COD_AGENCIA_GER" , ""},
                { "TERMOADE_OPERACAO_CONTA_GER" , ""},
                { "TERMOADE_NUM_CONTA_GER" , ""},
                { "TERMOADE_DIG_CONTA_GER" , ""},
                { "TERMOADE_NUM_MATRICULA_SUR" , ""},
                { "TERMOADE_CODPDTSUR" , ""},
                { "TERMOADE_PCCOMSUR" , ""},
                { "TERMOADE_NUM_MATRICULA_GCO" , ""},
                { "TERMOADE_CODPDTGCO" , ""},
                { "TERMOADE_PCCOMGCO" , ""},
                { "TERMOADE_MODALIDADE_CAPITAL" , ""},
                { "TERMOADE_TIPO_PLANO" , ""},
                { "TERMOADE_IND_PLANO_ASSOCIAD" , ""},
                { "TERMOADE_COD_PLANO_VGAPC" , ""},
                { "TERMOADE_COD_PLANO_APC" , ""},
                { "TERMOADE_VAL_CONTRATADO" , ""},
                { "TERMOADE_VAL_COMISSAO_ADIAN" , ""},
                { "TERMOADE_QUANT_VIDAS" , ""},
                { "TERMOADE_TIPO_COBERTURA" , ""},
                { "TERMOADE_PERI_PAGAMENTO" , ""},
                { "TERMOADE_TIPO_CORRECAO" , ""},
                { "TERMOADE_PERIODO_CORRECAO" , ""},
                { "TERMOADE_COD_MOEDA_IMP" , ""},
                { "TERMOADE_COD_MOEDA_PRM" , ""},
                { "TERMOADE_COD_CLIENTE" , ""},
                { "TERMOADE_OCORR_ENDERECO" , ""},
                { "TERMOADE_COD_CORRETOR" , ""},
                { "TERMOADE_PCCOMCOR" , ""},
                { "TERMOADE_COD_ADMINISTRADOR" , ""},
                { "TERMOADE_PCCOMADM" , ""},
                { "TERMOADE_COD_USUARIO" , ""},
                { "TERMOADE_DATA_INCLUSAO" , ""},
                { "TERMOADE_SITUACAO" , ""},
                { "TERMOADE_NUM_PROPOSTA" , ""},
                { "TERMOADE_NUM_RCAP" , ""},
                { "TERMOADE_DATA_RCAP" , ""},
                { "TERMOADE_VAL_RCAP" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_FAIXA_RENDA_IND" , ""},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_TERMO_ADESAO", q4);

            #endregion

            #region R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0200_00_LER_RCAPS_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0200_00_LER_RCAPS_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_2_Query1", q7);

            #endregion

            #region R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , ""},
                { "RCAPCOMP_AGE_AVISO" , ""},
                { "RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "RCAPCOMP_DATA_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1", q8);

            #endregion

            #region PF0623B_C01_RCAPCOMP

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_C01_RCAPCOMP", q9);

            #endregion

            #region R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , ""},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0350_00_LER_ENDERECO_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDERECO_COD_CLIENTE" , ""},
                { "ENDERECO_COD_ENDERECO" , ""},
                { "ENDERECO_OCORR_ENDERECO" , ""},
                { "ENDERECO_ENDERECO" , ""},
                { "ENDERECO_BAIRRO" , ""},
                { "ENDERECO_CIDADE" , ""},
                { "ENDERECO_SIGLA_UF" , ""},
                { "ENDERECO_CEP" , ""},
                { "ENDERECO_DDD" , ""},
                { "ENDERECO_TELEFONE" , ""},
                { "ENDERECO_FAX" , ""},
                { "ENDERECO_TELEX" , ""},
                { "ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_LER_ENDERECO_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , ""},
                { "SUBGVGAP_COD_CLIENTE" , ""},
                { "SUBGVGAP_CLASSE_APOLICE" , ""},
                { "SUBGVGAP_COD_FONTE" , ""},
                { "SUBGVGAP_TIPO_FATURAMENTO" , ""},
                { "SUBGVGAP_FORMA_FATURAMENTO" , ""},
                { "SUBGVGAP_FORMA_AVERBACAO" , ""},
                { "SUBGVGAP_TIPO_PLANO" , ""},
                { "SUBGVGAP_PERI_FATURAMENTO" , ""},
                { "SUBGVGAP_PERI_RENOVACAO" , ""},
                { "SUBGVGAP_PERI_RETROATI_INC" , ""},
                { "SUBGVGAP_PERI_RETROATI_CAN" , ""},
                { "SUBGVGAP_OCORR_ENDERECO" , ""},
                { "SUBGVGAP_OCORR_END_COBRAN" , ""},
                { "SUBGVGAP_BCO_COBRANCA" , ""},
                { "SUBGVGAP_AGE_COBRANCA" , ""},
                { "SUBGVGAP_DAC_COBRANCA" , ""},
                { "SUBGVGAP_TIPO_COBRANCA" , ""},
                { "SUBGVGAP_COD_PAG_ANGARIACAO" , ""},
                { "SUBGVGAP_PCT_CONJUGE_VG" , ""},
                { "SUBGVGAP_PCT_CONJUGE_AP" , ""},
                { "SUBGVGAP_OPCAO_COBERTURA" , ""},
                { "SUBGVGAP_OPCAO_CORRETAGEM" , ""},
                { "SUBGVGAP_IND_CONSISTE_MATRI" , ""},
                { "SUBGVGAP_IND_PLANO_ASSOCIA" , ""},
                { "SUBGVGAP_SIT_REGISTRO" , ""},
                { "SUBGVGAP_OPCAO_CONJUGE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1", q14);

            #endregion

            #region PF0623B_COBERTURAS

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_COBERTURAS", q15);

            #endregion

            #region PF0623B_FUNDOCOMISVA

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_FUNDOCOMISVA", q16);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q17);

            #endregion

            #region R0860_LER_APOLICE_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0860_LER_APOLICE_DB_SELECT_1_Query1", q18);

            #endregion

            #region R0870_LER_RAMOIND_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0870_LER_RAMOIND_DB_SELECT_1_Query1", q19);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q20);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1", q21);

            #endregion

            #region R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "WHOST_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q22);

            #endregion

            #region R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q23 = new DynamicData();
            q23.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q23);

            #endregion

            #region R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1

            var q24 = new DynamicData();
            q24.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_COD_USUARIO" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1", q24);

            #endregion

            #region R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1

            var q25 = new DynamicData();
            q25.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1", q25);

            #endregion

            #region R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1

            var q26 = new DynamicData();
            q26.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "CGC" , ""},
                { "NOME_FANTASIA" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1", q26);

            #endregion

            #region PF0623B_EMAIL

            var q27 = new DynamicData();
            q27.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_EMAIL_COD_PESSOA" , ""},
                { "DCLPESSOA_EMAIL_SEQ_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_EMAIL" , ""},
                { "DCLPESSOA_EMAIL_SITUACAO_EMAIL" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_EMAIL", q27);

            #endregion

            #region R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q28 = new DynamicData();
            q28.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q28);

            #endregion

            #region R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1

            var q29 = new DynamicData();
            q29.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1", q29);

            #endregion

            #region R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1

            var q30 = new DynamicData();
            q30.AddDynamic(new Dictionary<string, string>{
                { "PESSOA_COD_PESSOA" , ""},
                { "PESSOA_NOME_PESSOA" , ""},
                { "PESSOA_TIPO_PESSOA" , ""},
                { "PESSOA_TIMESTAMP" , ""},
                { "PESSOA_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1", q30);

            #endregion

            #region R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1

            var q31 = new DynamicData();
            q31.AddDynamic(new Dictionary<string, string>{
                { "SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1", q31);

            #endregion

            #region R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1

            var q32 = new DynamicData();
            q32.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "SEQ_EMAIL" , ""},
                { "EMAIL" , ""},
                { "SITUACAO_EMAIL" , ""},
                { "COD_USUARIO" , ""},
                { "TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1", q32);

            #endregion

            #region PF0623B_ENDERECOS

            var q33 = new DynamicData();
            q33.AddDynamic(new Dictionary<string, string>{
                { "DCLPESSOA_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_COD_PESSOA" , ""},
                { "DCLPESSOA_ENDERECO_ENDERECO" , ""},
                { "DCLPESSOA_ENDERECO_TIPO_ENDER" , ""},
                { "DCLPESSOA_ENDERECO_BAIRRO" , ""},
                { "DCLPESSOA_ENDERECO_CEP" , ""},
                { "DCLPESSOA_ENDERECO_CIDADE" , ""},
                { "DCLPESSOA_ENDERECO_SIGLA_UF" , ""},
                { "DCLPESSOA_ENDERECO_SITUACAO_ENDERECO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_ENDERECOS", q33);

            #endregion

            #region R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1

            var q34 = new DynamicData();
            q34.AddDynamic(new Dictionary<string, string>{
                { "OCORR_ENDERECO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1", q34);

            #endregion

            #region R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1

            var q35 = new DynamicData();
            q35.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "OCORR_ENDERECO" , ""},
                { "ENDERECO" , ""},
                { "TIPO_ENDER" , ""},
                { "BAIRRO" , ""},
                { "CEP" , ""},
                { "CIDADE" , ""},
                { "SIGLA_UF" , ""},
                { "SITUACAO_ENDERECO" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1", q35);

            #endregion

            #region R3255_LER_TELEFONE_DB_SELECT_1_Query1

            var q36 = new DynamicData();
            q36.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3255_LER_TELEFONE_DB_SELECT_1_Query1", q36);

            #endregion

            #region R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1

            var q37 = new DynamicData();
            q37.AddDynamic(new Dictionary<string, string>{
                { "SEQ_FONE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1", q37);

            #endregion

            #region R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1

            var q38 = new DynamicData();
            q38.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "TIPO_FONE" , ""},
                { "SEQ_FONE" , ""},
                { "DDI" , ""},
                { "DDD" , ""},
                { "NUM_FONE" , ""},
                { "SITUACAO_FONE" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1", q38);

            #endregion

            #region R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1

            var q39 = new DynamicData();
            q39.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1", q39);

            #endregion

            #region R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1

            var q40 = new DynamicData();
            q40.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1", q40);

            #endregion

            #region R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1

            var q41 = new DynamicData();
            q41.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""},
                { "COD_PESSOA" , ""},
                { "COD_RELAC" , ""},
                { "COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1", q41);

            #endregion

            #region R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1

            var q42 = new DynamicData();
            q42.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1", q42);

            #endregion

            #region R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1

            var q43 = new DynamicData();
            q43.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PESSOA" , ""},
                { "PROPOFID_NUM_SICOB" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_AGECOBR" , ""},
                { "PROPOFID_DIA_DEBITO" , ""},
                { "PROPOFID_OPCAOPAG" , ""},
                { "PROPOFID_AGECTADEB" , ""},
                { "PROPOFID_OPRCTADEB" , ""},
                { "PROPOFID_NUMCTADEB" , ""},
                { "PROPOFID_DIGCTADEB" , ""},
                { "PROPOFID_PERC_DESCONTO" , ""},
                { "PROPOFID_NRMATRVEN" , ""},
                { "PROPOFID_AGECTAVEN" , ""},
                { "PROPOFID_OPRCTAVEN" , ""},
                { "PROPOFID_NUMCTAVEN" , ""},
                { "PROPOFID_DIGCTAVEN" , ""},
                { "PROPOFID_CGC_CONVENENTE" , ""},
                { "PROPOFID_NOME_CONVENENTE" , ""},
                { "PROPOFID_NRMATRCON" , ""},
                { "PROPOFID_DTQITBCO" , ""},
                { "PROPOFID_VAL_PAGO" , ""},
                { "PROPOFID_AGEPGTO" , ""},
                { "PROPOFID_VAL_TARIFA" , ""},
                { "PROPOFID_VAL_IOF" , ""},
                { "PROPOFID_DATA_CREDITO" , ""},
                { "PROPOFID_VAL_COMISSAO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_NSAC_SIVPF" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_OPCAO_COBER" , ""},
                { "PROPOFID_COD_PLANO" , ""},
                { "PROPOFID_NOME_CONJUGE" , ""},
                { "PROPOFID_DATA_NASC_CONJUGE" , ""},
                { "PROPOFID_PROFISSAO_CONJUGE" , ""},
                { "PROPOFID_FAIXA_RENDA_IND" , ""},
                { "PROPOFID_FAIXA_RENDA_FAM" , ""},
                { "PROPOFID_IND_TIPO_CONTA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1", q43);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q44 = new DynamicData();
            q44.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
                { "PROPFIDH_NSAS_SIVPF" , ""},
                { "PROPFIDH_NSL" , ""},
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_SIT_COBRANCA_SIVPF" , ""},
                { "PROPFIDH_SIT_MOTIVO_SIVPF" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q44);

            #endregion

            #region PF0623B_C01_AGENCEF

            var q45 = new DynamicData();
            q45.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "1"},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0623B_C01_AGENCEF", q45);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData(" MOVTO_PRP_SASSE_FILE_00.txt", "MOVTO_STA_SASSE_FILE_00.txt")]
        public static void PF0623B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
               
                var program = new PF0623B();

                var fileName = Path.GetFileNameWithoutExtension(MOVTO_STA_SASSE_FILE_NAME_P);
                MOVTO_STA_SASSE_FILE_NAME_P = MOVTO_STA_SASSE_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                AppSettings.TestSet.IsTest = true;
                Console.WriteLine($"#### Arquivo {MOVTO_STA_SASSE_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                fileName = Path.GetFileNameWithoutExtension(MOVTO_STA_SASSE_FILE_NAME_P);
                MOVTO_STA_SASSE_FILE_NAME_P = MOVTO_STA_SASSE_FILE_NAME_P.Replace(fileName, fileName + DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss"));
                AppSettings.TestSet.IsTest = true;
                Console.WriteLine($"#### Arquivo {MOVTO_STA_SASSE_FILE_NAME_P} em : {AppSettings.Settings.FileFolderPath}");

                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P, MOVTO_STA_SASSE_FILE_NAME_P);


                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length > 0);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                var envList = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                var envList1 = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var valor) && valor == "0004");
                Assert.True(envList[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out valor) && valor == "PRPSASSE");

                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out valor) && valor == "STASASSE");
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out valor) && valor == "000000001");
            }
        }
    }
}