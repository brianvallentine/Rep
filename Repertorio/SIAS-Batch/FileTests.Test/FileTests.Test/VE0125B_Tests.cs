using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Dclgens;
using Code;
using static Code.VE0125B;

namespace FileTests.Test
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0125B_Tests")]
    public class VE0125B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1", q1);

            #endregion

            #region VE0125B_CUR_MOVTO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
                { "RELATORI_TIMESTAMP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_CUR_MOVTO", q2);

            #endregion

            #region VE0125B_C01_RCAPCOMP

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , ""},
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_C01_RCAPCOMP", q3);

            #endregion

            #region R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1

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
                { "TERMOADE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_FAIXA_RENDA_IND" , ""},
                { "PROPOVA_FAIXA_RENDA_FAM" , ""},
                { "PROPOVA_STA_ANTECIPACAO" , ""},
                { "PROPOVA_STA_MUDANCA_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1", q5);

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

            #region VE0125B_C01_ENDERECO

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLENDERECOS_ENDERECO_COD_CLIENTE" , ""},
                { "DCLENDERECOS_ENDERECO_COD_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_OCORR_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_ENDERECO" , ""},
                { "DCLENDERECOS_ENDERECO_BAIRRO" , ""},
                { "DCLENDERECOS_ENDERECO_CIDADE" , ""},
                { "DCLENDERECOS_ENDERECO_SIGLA_UF" , ""},
                { "DCLENDERECOS_ENDERECO_CEP" , ""},
                { "DCLENDERECOS_ENDERECO_DDD" , ""},
                { "DCLENDERECOS_ENDERECO_TELEFONE" , ""},
                { "DCLENDERECOS_ENDERECO_FAX" , ""},
                { "DCLENDERECOS_ENDERECO_TELEX" , ""},
                { "DCLENDERECOS_ENDERECO_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_C01_ENDERECO", q9);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , ""},
                { "NOME_RAZAO" , ""},
                { "TIPO_PESSOA" , ""},
                { "CGCCPF" , ""},
                { "SIT_REGISTRO" , ""},
                { "DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PESSOEMA_SEQ_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1", q12);

            #endregion

            #region R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PESSOEMA_EMAIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1", q13);

            #endregion

            #region VE0125B_COBERTURAS

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_COBERTURAS", q14);

            #endregion

            #region R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1", q16);

            #endregion

            #region VE0125B_FUNDOCOMISVA

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_FUNDOCOMISVA", q17);

            #endregion

            #region VE0125B_C01_AGENCEF

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , ""},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VE0125B_C01_AGENCEF", q18);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q19);

            #endregion

            #region R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1", q20);

            #endregion

            #region R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_COPIAS" , ""},
                { "RELATORI_QUANTIDADE" , ""},
                { "RELATORI_PERI_INICIAL" , ""},
                { "RELATORI_PERI_FINAL" , ""},
                { "RELATORI_DATA_REFERENCIA" , ""},
                { "RELATORI_MES_REFERENCIA" , ""},
                { "RELATORI_ANO_REFERENCIA" , ""},
                { "RELATORI_ORGAO_EMISSOR" , ""},
                { "RELATORI_COD_FONTE" , ""},
                { "RELATORI_COD_PRODUTOR" , ""},
                { "RELATORI_RAMO_EMISSOR" , ""},
                { "RELATORI_COD_MODALIDADE" , ""},
                { "RELATORI_COD_CONGENERE" , ""},
                { "RELATORI_NUM_APOLICE" , ""},
                { "RELATORI_NUM_ENDOSSO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_TITULO" , ""},
                { "RELATORI_COD_SUBGRUPO" , ""},
                { "RELATORI_COD_OPERACAO" , ""},
                { "RELATORI_COD_PLANO" , ""},
                { "RELATORI_OCORR_HISTORICO" , ""},
                { "RELATORI_NUM_APOL_LIDER" , ""},
                { "RELATORI_ENDOS_LIDER" , ""},
                { "RELATORI_NUM_PARC_LIDER" , ""},
                { "RELATORI_NUM_SINISTRO" , ""},
                { "RELATORI_NUM_SINI_LIDER" , ""},
                { "RELATORI_NUM_ORDEM" , ""},
                { "RELATORI_COD_MOEDA" , ""},
                { "RELATORI_TIPO_CORRECAO" , ""},
                { "RELATORI_SIT_REGISTRO" , ""},
                { "RELATORI_IND_PREV_DEFINIT" , ""},
                { "RELATORI_IND_ANAL_RESUMO" , ""},
                { "RELATORI_COD_EMPRESA" , ""},
                { "RELATORI_PERI_RENOVACAO" , ""},
                { "RELATORI_PCT_AUMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q21);

            #endregion

            #region R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q22);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("VE0125B_t1")]
        public static void VE0125B_Tests_Theory(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                
                #region VARIAVEIS_TESTE

                #region PARAMETERS

    #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "WHOST_DATA_REFERENCIA" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                #endregion

                #region R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1

    var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2023-12-01" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0010_00_BUSCA_ULT_VE0125B_DB_SELECT_1_Query1", q1);

                #endregion

                #region VE0125B_CUR_MOVTO

    var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "USR123" },
                { "RELATORI_DATA_SOLICITACAO" , "2023-12-01" },
                { "RELATORI_IDE_SISTEMA" , "SIS001" },
                { "RELATORI_COD_RELATORIO" , "RPT001" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "RELATORI_QUANTIDADE" , "100" },
                { "RELATORI_PERI_INICIAL" , "2023-01-01" },
                { "RELATORI_PERI_FINAL" , "2023-12-31" },
                { "RELATORI_DATA_REFERENCIA" , "2023-12-01" },
                { "RELATORI_MES_REFERENCIA" , "12" },
                { "RELATORI_ANO_REFERENCIA" , "2023" },
                { "RELATORI_ORGAO_EMISSOR" , "Org001" },
                { "RELATORI_COD_FONTE" , "FNT001" },
                { "RELATORI_COD_PRODUTOR" , "PRD001" },
                { "RELATORI_RAMO_EMISSOR" , "RAM001" },
                { "RELATORI_COD_MODALIDADE" , "MOD001" },
                { "RELATORI_COD_CONGENERE" , "CON001" },
                { "RELATORI_NUM_APOLICE" , "APL123456" },
                { "RELATORI_NUM_ENDOSSO" , "END123456" },
                { "RELATORI_NUM_PARCELA" , "PAR123" },
                { "RELATORI_NUM_CERTIFICADO" , "CRT123456" },
                { "RELATORI_NUM_TITULO" , "TIT123456" },
                { "RELATORI_COD_SUBGRUPO" , "SUB001" },
                { "RELATORI_COD_OPERACAO" , "OPR001" },
                { "RELATORI_COD_PLANO" , "PLN001" },
                { "RELATORI_OCORR_HISTORICO" , "Histórico de ocorrências" },
                { "RELATORI_NUM_APOL_LIDER" , "APLLDR123" },
                { "RELATORI_ENDOS_LIDER" , "ENDLDR123" },
                { "RELATORI_NUM_PARC_LIDER" , "PARLDR123" },
                { "RELATORI_NUM_SINISTRO" , "SIN123456" },
                { "RELATORI_NUM_SINI_LIDER" , "SINLDR123" },
                { "RELATORI_NUM_ORDEM" , "ORD123456" },
                { "RELATORI_COD_MOEDA" , "BRL" },
                { "RELATORI_TIPO_CORRECAO" , "Correção tipo 1" },
                { "RELATORI_SIT_REGISTRO" , "Ativo" },
                { "RELATORI_IND_PREV_DEFINIT" , "Indefinido" },
                { "RELATORI_IND_ANAL_RESUMO" , "Resumo" },
                { "RELATORI_COD_EMPRESA" , "EMP001" },
                { "RELATORI_PERI_RENOVACAO" , "2024-01-01" },
                { "RELATORI_PCT_AUMENTO" , "10%" },
                { "RELATORI_TIMESTAMP" , "2023-12-01T00:00:00Z" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_CUR_MOVTO");
AppSettings.TestSet.DynamicData.Add("VE0125B_CUR_MOVTO", q2);

                #endregion

                #region VE0125B_C01_RCAPCOMP

    var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO" , "Banco001" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO" , "Agência001" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO" , "AVC123456" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO" , "2023-12-01" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP" , "2023-12-01" },
                { "DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO" , "OPR001" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_C01_RCAPCOMP");
AppSettings.TestSet.DynamicData.Add("VE0125B_C01_RCAPCOMP", q3);

                #endregion

                #region R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1

    var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , "TRM123456" },
                { "TERMOADE_COD_SUBGRUPO" , "SUB001" },
                { "TERMOADE_DATA_ADESAO" , "2023-12-01" },
                { "TERMOADE_COD_AGENCIA_OP" , "AGOP123" },
                { "TERMOADE_NUM_MATRICULA_VEN" , "MATVEN123" },
                { "TERMOADE_CODPDTVEN" , "PDTVEN001" },
                { "TERMOADE_PCCOMVEN" , "5%" },
                { "TERMOADE_PCADIANTVEN" , "2%" },
                { "TERMOADE_COD_AGENCIA_VEN" , "AGVEN123" },
                { "TERMOADE_OPERACAO_CONTA_VEN" , "OPCVEN123" },
                { "TERMOADE_NUM_CONTA_VEN" , "CTAVEN123" },
                { "TERMOADE_DIG_CONTA_VEN" , "00" },
                { "TERMOADE_NUM_MATRICULA_GER" , "MATGER123" },
                { "TERMOADE_CODPDTGER" , "PDTGER001" },
                { "TERMOADE_PCCOMGER" , "3%" },
                { "TERMOADE_COD_AGENCIA_GER" , "AGGER123" },
                { "TERMOADE_OPERACAO_CONTA_GER" , "OPCGER123" },
                { "TERMOADE_NUM_CONTA_GER" , "CTAGER123" },
                { "TERMOADE_DIG_CONTA_GER" , "01" },
                { "TERMOADE_NUM_MATRICULA_SUR" , "MATSUR123" },
                { "TERMOADE_CODPDTSUR" , "PDTSUR001" },
                { "TERMOADE_PCCOMSUR" , "1%" },
                { "TERMOADE_NUM_MATRICULA_GCO" , "MATGCO123" },
                { "TERMOADE_CODPDTGCO" , "PDTGCO001" },
                { "TERMOADE_PCCOMGCO" , "0.5%" },
                { "TERMOADE_MODALIDADE_CAPITAL" , "ModCap001" },
                { "TERMOADE_TIPO_PLANO" , "PlanoTipo1" },
                { "TERMOADE_IND_PLANO_ASSOCIAD" , "Não" },
                { "TERMOADE_COD_PLANO_VGAPC" , "PLNVGAPC001" },
                { "TERMOADE_COD_PLANO_APC" , "PLNAPC001" },
                { "TERMOADE_VAL_CONTRATADO" , "100000" },
                { "TERMOADE_VAL_COMISSAO_ADIAN" , "5000" },
                { "TERMOADE_QUANT_VIDAS" , "100" },
                { "TERMOADE_TIPO_COBERTURA" , "Cobertura Total" },
                { "TERMOADE_PERI_PAGAMENTO" , "Mensal" },
                { "TERMOADE_TIPO_CORRECAO" , "Correção Anual" },
                { "TERMOADE_PERIODO_CORRECAO" , "Anual" },
                { "TERMOADE_COD_MOEDA_IMP" , "USD" },
                { "TERMOADE_COD_MOEDA_PRM" , "EUR" },
                { "TERMOADE_COD_CLIENTE" , "CLT001" },
                { "TERMOADE_OCORR_ENDERECO" , "Endereço Principal" },
                { "TERMOADE_COD_CORRETOR" , "COR001" },
                { "TERMOADE_PCCOMCOR" , "2%" },
                { "TERMOADE_COD_ADMINISTRADOR" , "ADM001" },
                { "TERMOADE_PCCOMADM" , "1%" },
                { "TERMOADE_COD_USUARIO" , "USR123" },
                { "TERMOADE_DATA_INCLUSAO" , "2023-12-01" },
                { "TERMOADE_SITUACAO" , "Ativa" },
                { "TERMOADE_NUM_PROPOSTA" , "PROP123456" },
                { "TERMOADE_NUM_RCAP" , "RCAP123456" },
                { "TERMOADE_DATA_RCAP" , "2023-12-01" },
                { "TERMOADE_VAL_RCAP" , "50000" },
                { "TERMOADE_NUM_APOLICE" , "APL123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1", q4);

                #endregion

                #region R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1

    var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "CRT123456" },
                { "PROPOVA_COD_PRODUTO" , "8205" },
                { "PROPOVA_SIT_REGISTRO" , "3" },
                { "PROPOVA_FAIXA_RENDA_IND" , "Alta" },
                { "PROPOVA_FAIXA_RENDA_FAM" , "Média" },
                { "PROPOVA_STA_ANTECIPACAO" , "Permitida" },
                { "PROPOVA_STA_MUDANCA_PLANO" , "Não Permitida" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0170_00_LER_CERTIFICADO_DB_SELECT_2_Query1", q5);

                #endregion

                #region R0200_00_LER_RCAPS_DB_SELECT_1_Query1

    var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_PROPOSTA" , "PROP123456" },
                { "RCAPS_VAL_RCAP" , "50000" },
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "45000" },
                { "RCAPS_DATA_CADASTRAMENTO" , "2023-12-01" },
                { "RCAPS_DATA_MOVIMENTO" , "2023-12-01" },
                { "RCAPS_SIT_REGISTRO" , "Ativo" },
                { "RCAPS_COD_OPERACAO" , "OPR001" },
                { "RCAPS_NUM_TITULO" , "TIT123456" },
                { "RCAPS_AGE_COBRANCA" , "AGCOB123" },
                { "RCAPS_NUM_RCAP" , "RCAP123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_RCAPS_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_1_Query1", q6);

                #endregion

                #region R0200_00_LER_RCAPS_DB_SELECT_2_Query1

    var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , "FNT001" },
                { "RCAPS_NUM_PROPOSTA" , "PROP123456" },
                { "RCAPS_VAL_RCAP" , "50000" },
                { "RCAPS_VAL_RCAP_PRINCIPAL" , "45000" },
                { "RCAPS_DATA_CADASTRAMENTO" , "2023-12-01" },
                { "RCAPS_DATA_MOVIMENTO" , "2023-12-01" },
                { "RCAPS_SIT_REGISTRO" , "Ativo" },
                { "RCAPS_COD_OPERACAO" , "OPR001" },
                { "RCAPS_NUM_TITULO" , "TIT123456" },
                { "RCAPS_AGE_COBRANCA" , "AGCOB123" },
                { "RCAPS_NUM_RCAP" , "RCAP123456" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_RCAPS_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_2_Query1", q7);

                #endregion

                #region R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1

    var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPCOMP_BCO_AVISO" , "Banco001" },
                { "RCAPCOMP_AGE_AVISO" , "Agência001" },
                { "RCAPCOMP_NUM_AVISO_CREDITO" , "AVC123456" },
                { "RCAPCOMP_DATA_MOVIMENTO" , "2023-12-01" },
                { "RCAPCOMP_DATA_RCAP" , "2023-12-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1", q8);

                #endregion

                #region VE0125B_C01_ENDERECO

    var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "DCLENDERECOS_ENDERECO_COD_CLIENTE" , "CLT001" },
                { "DCLENDERECOS_ENDERECO_COD_ENDERECO" , "END001" },
                { "DCLENDERECOS_ENDERECO_OCORR_ENDERECO" , "Endereço Principal" },
                { "DCLENDERECOS_ENDERECO_ENDERECO" , "Rua Principal, 123" },
                { "DCLENDERECOS_ENDERECO_BAIRRO" , "Centro" },
                { "DCLENDERECOS_ENDERECO_CIDADE" , "Cidade" },
                { "DCLENDERECOS_ENDERECO_SIGLA_UF" , "UF" },
                { "DCLENDERECOS_ENDERECO_CEP" , "12345-678" },
                { "DCLENDERECOS_ENDERECO_DDD" , "11" },
                { "DCLENDERECOS_ENDERECO_TELEFONE" , "4002-8922" },
                { "DCLENDERECOS_ENDERECO_FAX" , "4002-8923" },
                { "DCLENDERECOS_ENDERECO_TELEX" , "40028924" },
                { "DCLENDERECOS_ENDERECO_SIT_REGISTRO" , "Ativo" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_C01_ENDERECO");
AppSettings.TestSet.DynamicData.Add("VE0125B_C01_ENDERECO", q9);

                #endregion

                #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

    var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "COD_CLIENTE" , "CLT001" },
                { "NOME_RAZAO" , "Empresa X" },
                { "TIPO_PESSOA" , "Jurídica" },
                { "CGCCPF" , "12.345.678/0001-99" },
                { "SIT_REGISTRO" , "Ativo" },
                { "DATA_NASCIMENTO" , "1980-01-01" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q10);

                #endregion

                #region R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1

    var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "COD_PESSOA" , "PES001" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0310_00_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1", q11);

                #endregion

                #region R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1

    var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PESSOEMA_SEQ_EMAIL" , "1" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_1_Query1", q12);

                #endregion

                #region R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1

    var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PESSOEMA_EMAIL" , "email@empresa.com" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1");
AppSettings.TestSet.DynamicData.Add("R0320_00_LER_PESSOA_EMAIL_DB_SELECT_2_Query1", q13);

                #endregion

                #region VE0125B_COBERTURAS

    var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "CRT123456" },
                { "HISCOBPR_OCORR_HISTORICO" , "Histórico de cobertura" },
                { "HISCOBPR_DATA_INIVIGENCIA" , "2023-01-01" },
                { "HISCOBPR_DATA_TERVIGENCIA" , "2023-12-31" },
                { "HISCOBPR_IMP_MORNATU" , "10000" },
                { "HISCOBPR_IMPMORACID" , "5000" },
                { "HISCOBPR_IMPINVPERM" , "15000" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_COBERTURAS");
AppSettings.TestSet.DynamicData.Add("VE0125B_COBERTURAS", q14);

                #endregion

                #region R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1

    var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "SUBGVGAP_COD_SUBGRUPO" , "SUB001" },
                { "SUBGVGAP_COD_CLIENTE" , "CLT001" },
                { "SUBGVGAP_CLASSE_APOLICE" , "Classe 1" },
                { "SUBGVGAP_COD_FONTE" , "FNT001" },
                { "SUBGVGAP_TIPO_FATURAMENTO" , "Mensal" },
                { "SUBGVGAP_FORMA_FATURAMENTO" , "Automática" },
                { "SUBGVGAP_FORMA_AVERBACAO" , "Eletrônica" },
                { "SUBGVGAP_TIPO_PLANO" , "PlanoTipo1" },
                { "SUBGVGAP_PERI_FATURAMENTO" , "Mensal" },
                { "SUBGVGAP_PERI_RENOVACAO" , "Anual" },
                { "SUBGVGAP_PERI_RETROATI_INC" , "30 dias" },
                { "SUBGVGAP_PERI_RETROATI_CAN" , "30 dias" },
                { "SUBGVGAP_OCORR_ENDERECO" , "Endereço Principal" },
                { "SUBGVGAP_OCORR_END_COBRAN" , "Cobrança Principal" },
                { "SUBGVGAP_BCO_COBRANCA" , "Banco001" },
                { "SUBGVGAP_AGE_COBRANCA" , "Agência001" },
                { "SUBGVGAP_DAC_COBRANCA" , "01" },
                { "SUBGVGAP_TIPO_COBRANCA" , "Débito Automático" },
                { "SUBGVGAP_COD_PAG_ANGARIACAO" , "ANG001" },
                { "SUBGVGAP_PCT_CONJUGE_VG" , "50%" },
                { "SUBGVGAP_PCT_CONJUGE_AP" , "25%" },
                { "SUBGVGAP_OPCAO_COBERTURA" , "Total" },
                { "SUBGVGAP_OPCAO_CORRETAGEM" , "Corretagem Fixa" },
                { "SUBGVGAP_IND_CONSISTE_MATRI" , "Sim" },
                { "SUBGVGAP_IND_PLANO_ASSOCIA" , "Não" },
                { "SUBGVGAP_SIT_REGISTRO" , "Ativo" },
                { "SUBGVGAP_OPCAO_CONJUGE" , "Incluído" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1", q15);

                #endregion

                #region R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1

    var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , "1" },
                { "OPCPAGVI_PERI_PAGAMENTO" , "Mensal" },
                { "OPCPAGVI_DIA_DEBITO" , "10" },
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , "AGDEB123" },
                { "OPCPAGVI_OPE_CONTA_DEBITO" , "OPDEB123" },
                { "OPCPAGVI_NUM_CONTA_DEBITO" , "CTADEB123" },
                { "OPCPAGVI_DIG_CONTA_DEBITO" , "00" },
            });
            AppSettings.TestSet.DynamicData.Remove("R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1", q16);

                #endregion

                #region VE0125B_FUNDOCOMISVA

    var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , "CRT123456" },
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , "3000" },
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , "1500" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_FUNDOCOMISVA");
AppSettings.TestSet.DynamicData.Add("VE0125B_FUNDOCOMISVA", q17);

                #endregion

                #region VE0125B_C01_AGENCEF

    var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "AGCEF123" },
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "FNT001" },
            });
            AppSettings.TestSet.DynamicData.Remove("VE0125B_C01_AGENCEF");
AppSettings.TestSet.DynamicData.Add("VE0125B_C01_AGENCEF", q18);

                #endregion

                #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

    var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , "50" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q19);

                #endregion

                #region R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1

    var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "VGCOMTRO_NUM_PROPOSTA_SIVPF" , "PROP123456" }
            });
            AppSettings.TestSet.DynamicData.Remove("R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1");
AppSettings.TestSet.DynamicData.Add("R0590_00_LER_COMPL_TERMO_DB_SELECT_1_Query1", q20);

                #endregion

                #region R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

    var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "USR123" },
                { "RELATORI_DATA_SOLICITACAO" , "2023-12-01" },
                { "RELATORI_IDE_SISTEMA" , "SIS001" },
                { "RELATORI_COD_RELATORIO" , "RPT001" },
                { "RELATORI_NUM_COPIAS" , "2" },
                { "RELATORI_QUANTIDADE" , "100" },
                { "RELATORI_PERI_INICIAL" , "2023-01-01" },
                { "RELATORI_PERI_FINAL" , "2023-12-31" },
                { "RELATORI_DATA_REFERENCIA" , "2023-12-01" },
                { "RELATORI_MES_REFERENCIA" , "12" },
                { "RELATORI_ANO_REFERENCIA" , "2023" },
                { "RELATORI_ORGAO_EMISSOR" , "Org001" },
                { "RELATORI_COD_FONTE" , "FNT001" },
                { "RELATORI_COD_PRODUTOR" , "PRD001" },
                { "RELATORI_RAMO_EMISSOR" , "RAM001" },
                { "RELATORI_COD_MODALIDADE" , "MOD001" },
                { "RELATORI_COD_CONGENERE" , "CON001" },
                { "RELATORI_NUM_APOLICE" , "APL123456" },
                { "RELATORI_NUM_ENDOSSO" , "END123456" },
                { "RELATORI_NUM_PARCELA" , "PAR123" },
                { "RELATORI_NUM_CERTIFICADO" , "CRT123456" },
                { "RELATORI_NUM_TITULO" , "TIT123456" },
                { "RELATORI_COD_SUBGRUPO" , "SUB001" },
                { "RELATORI_COD_OPERACAO" , "OPR001" },
                { "RELATORI_COD_PLANO" , "PLN001" },
                { "RELATORI_OCORR_HISTORICO" , "Histórico de ocorrências" },
                { "RELATORI_NUM_APOL_LIDER" , "APLLDR123" },
                { "RELATORI_ENDOS_LIDER" , "ENDLDR123" },
                { "RELATORI_NUM_PARC_LIDER" , "PARLDR123" },
                { "RELATORI_NUM_SINISTRO" , "SIN123456" },
                { "RELATORI_NUM_SINI_LIDER" , "SINLDR123" },
                { "RELATORI_NUM_ORDEM" , "ORD123456" },
                { "RELATORI_COD_MOEDA" , "BRL" },
                { "RELATORI_TIPO_CORRECAO" , "Correção tipo 1" },
                { "RELATORI_SIT_REGISTRO" , "Ativo" },
                { "RELATORI_IND_PREV_DEFINIT" , "Indefinido" },
                { "RELATORI_IND_ANAL_RESUMO" , "Resumo" },
                { "RELATORI_COD_EMPRESA" , "EMP001" },
                { "RELATORI_PERI_RENOVACAO" , "2024-01-01" },
                { "RELATORI_PCT_AUMENTO" , "10%" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1");
AppSettings.TestSet.DynamicData.Add("R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q21);

                #endregion

                #region R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

    var q22 = new DynamicData();
            q22.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "RELATORI_COD_USUARIO" , "USR123" },
                { "RELATORI_IDE_SISTEMA" , "SIS001" },
            });
            AppSettings.TestSet.DynamicData.Remove("R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1");
AppSettings.TestSet.DynamicData.Add("R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q22);

                #endregion

                #endregion

      #endregion
//para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...Assert.True(true);
                var program = new VE0125B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                var updates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE") && x.Value.DynamicList.Count > 1).ToList();
                var allUpdates = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("UPDATE")).ToList();
                Assert.True(updates.Count >= allUpdates.Count / 2);

                var inserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT") && x.Value.DynamicList.Count > 1).ToList();
                var allInserts = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("INSERT")).ToList();
                Assert.True(inserts.Count >= allInserts.Count / 2);

                var selects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT") && x.Value.DynamicList.Count == 0).ToList();
                var allSelects = AppSettings.TestSet.DynamicData.Where(x => x.Key.Contains("SELECT")).ToList();
                Assert.True(selects.Count >= allSelects.Count / 2);

                Assert.True(program.RETURN_CODE == 0);
            }
        }

        [Theory]
        [InlineData("VE0125B_t2")]
        public static void VE0125B_Tests_Theory_Erro99(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-12-01" },
                { "WHOST_DATA_REFERENCIA" , "2023-12-01" },
                }, new SQLCA(999));
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                var program = new VE0125B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}