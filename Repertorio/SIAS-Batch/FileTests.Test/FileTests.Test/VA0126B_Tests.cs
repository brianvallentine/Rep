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
using Code;
using static Code.VA0126B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0126B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0126B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-10-10"},
                { "WHOST_DATA_REFERENCIA" , "2024-10-11"},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2024-01-01"}
            });
            AppSettings.TestSet.DynamicData.Add("R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1", q1);

            #endregion

            #region VA0126B_CUR_MOVTO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_COD_USUARIO" , "1"},
                { "RELATORI_DATA_SOLICITACAO" , "2024-02-02"},
                { "RELATORI_IDE_SISTEMA" , "2"},
                { "RELATORI_COD_RELATORIO" , "3"},
                { "RELATORI_NUM_COPIAS" , "1"},
                { "RELATORI_QUANTIDADE" , "2"},
                { "RELATORI_PERI_INICIAL" , "2024-01-01"},
                { "RELATORI_PERI_FINAL" , "2024-02-01"},
                { "RELATORI_DATA_REFERENCIA" , "2024-01-01"},
                { "RELATORI_MES_REFERENCIA" , "03"},
                { "RELATORI_ANO_REFERENCIA" , "2024"},
                { "RELATORI_ORGAO_EMISSOR" , "TS"},
                { "RELATORI_COD_FONTE" , "1"},
                { "RELATORI_COD_PRODUTOR" , "12"},
                { "RELATORI_RAMO_EMISSOR" , "VG"},
                { "RELATORI_COD_MODALIDADE" , "4"},
                { "RELATORI_COD_CONGENERE" , "2"},
                { "RELATORI_NUM_APOLICE" , "987456"},
                { "RELATORI_NUM_ENDOSSO" , "123"},
                { "RELATORI_NUM_PARCELA" , "1"},
                { "RELATORI_NUM_CERTIFICADO" , "67567"},
                { "RELATORI_NUM_TITULO" , "1234"},
                { "RELATORI_COD_SUBGRUPO" , "9"},
                { "RELATORI_COD_OPERACAO" , "8"},
                { "RELATORI_COD_PLANO" , "5"},
                { "RELATORI_OCORR_HISTORICO" , "2"},
                { "RELATORI_NUM_APOL_LIDER" , "52639"},
                { "RELATORI_ENDOS_LIDER" , "1"},
                { "RELATORI_NUM_PARC_LIDER" , "1"},
                { "RELATORI_NUM_SINISTRO" , "548752"},
                { "RELATORI_NUM_SINI_LIDER" , "3265"},
                { "RELATORI_NUM_ORDEM" , "1"},
                { "RELATORI_COD_MOEDA" , "2"},
                { "RELATORI_TIPO_CORRECAO" , "1"},
                { "RELATORI_SIT_REGISTRO" , "1"},
                { "RELATORI_IND_PREV_DEFINIT" , "2"},
                { "RELATORI_IND_ANAL_RESUMO" , "2"},
                { "RELATORI_COD_EMPRESA" , "1"},
                { "RELATORI_PERI_RENOVACAO" , "2024-01-01"},
                { "RELATORI_PCT_AUMENTO" , "10"},
                { "RELATORI_TIMESTAMP" , "2024-01-01 11:11:11"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0126B_CUR_MOVTO", q2);

            #endregion

            #region VA0126B_C01_ENDERECO

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("VA0126B_C01_ENDERECO", q3);

            #endregion

            #region R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "123"},
                { "PROPOVA_COD_PRODUTO" , "3"},
                { "PROPOVA_COD_CLIENTE" , "3"},
                { "PROPOVA_OCOREND" , "4"},
                { "PROPOVA_COD_FONTE" , "3"},
                { "PROPOVA_AGE_COBRANCA" , "4"},
                { "PROPOVA_OPCAO_COBERTURA" , "6"},
                { "PROPOVA_DATA_QUITACAO" , "2024-01-01"},
                { "PROPOVA_COD_AGE_VENDEDOR" , "3"},
                { "PROPOVA_OPE_CONTA_VENDEDOR" , "4"},
                { "PROPOVA_NUM_CONTA_VENDEDOR" , "5"},
                { "PROPOVA_DIG_CONTA_VENDEDOR" , "6"},
                { "PROPOVA_NUM_MATRI_VENDEDOR" , "7"},
                { "PROPOVA_COD_OPERACAO" , "3"},
                { "PROPOVA_PROFISSAO" , "ANALISTA"},
                { "PROPOVA_DTINCLUS" , "2024-01-01"},
                { "PROPOVA_DATA_MOVIMENTO" , "2024-01-01"},
                { "PROPOVA_SIT_REGISTRO" , "S"},
                { "PROPOVA_NUM_APOLICE" , "96325"},
                { "PROPOVA_COD_SUBGRUPO" , "4"},
                { "PROPOVA_OCORR_HISTORICO" , "6"},
                { "PROPOVA_NRPRIPARATZ" , "45678"},
                { "PROPOVA_QTDPARATZ" , "1"},
                { "PROPOVA_DTPROXVEN" , "2024-01-01"},
                { "PROPOVA_NUM_PARCELA" , "1"},
                { "PROPOVA_DATA_VENCIMENTO" , "2024-01-01"},
                { "PROPOVA_SIT_INTERFACE" , "7"},
                { "PROPOVA_DTFENAE" , "2024-01-01"},
                { "PROPOVA_COD_USUARIO" , "5"},
                { "PROPOVA_TIMESTAMP" , "2024-01-01 12:12:12"},
                { "PROPOVA_IDADE" , "55"},
                { "PROPOVA_IDE_SEXO" , "M"},
                { "PROPOVA_ESTADO_CIVIL" , "C"},
                { "PROPOVA_APOS_INVALIDEZ" , "S"},
                { "PROPOVA_NOME_ESPOSA" , "NOME ESPOSA"},
                { "PROPOVA_DTNASC_ESPOSA" , "1970-01-01"},
                { "PROPOVA_PROFIS_ESPOSA" , "ANALISTA"},
                { "PROPOVA_DPS_TITULAR" , "1"},
                { "PROPOVA_DPS_ESPOSA" , "1"},
                { "PROPOVA_NUM_MATRICULA" , "34534534"},
                { "PROPOVA_FAIXA_RENDA_IND" , "10000"},
                { "PROPOVA_FAIXA_RENDA_FAM" , "10000"},
                { "PROPOVA_COD_ORIGEM_PROPOSTA" , "2"},
                { "PROPOVA_NUM_PRAZO_FIN" , "2"},
                { "PROPOVA_STA_ANTECIPACAO" , "2"},
                { "PROPOVA_STA_MUDANCA_PLANO" , "3"},
            });
            AppSettings.TestSet.DynamicData.Add("R0170_00_LER_CERTIFICADO_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0200_00_LER_RCAPS_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_PROPOSTA" , ""},
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_VAL_RCAP_PRINCIPAL" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_SIT_REGISTRO" , ""},
                { "RCAPS_COD_OPERACAO" , ""},
                { "RCAPS_NUM_PARCELA" , ""},
                { "RCAPS_NUM_TITULO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
                { "RCAPS_NUM_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0300_00_LER_CLIENTE_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_COD_CLIENTE" , ""},
                { "CLIENTES_NOME_RAZAO" , ""},
                { "CLIENTES_TIPO_PESSOA" , ""},
                { "CLIENTES_CGCCPF" , ""},
                { "CLIENTES_SIT_REGISTRO" , ""},
                { "CLIENTES_DATA_NASCIMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_LER_CLIENTE_DB_SELECT_1_Query1", q6);

            #endregion

            #region VA0126B_C01_CBO

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0126B_C01_CBO", q7);

            #endregion

            #region R0410_00_LER_CBO_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "CBO_COD_CBO" , ""},
                { "CBO_DESCR_CBO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0410_00_LER_CBO_DB_SELECT_1_Query1", q8);

            #endregion

            #region VA0126B_COBERTURAS

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMPSEGUR" , ""},
                { "HISCOBPR_QUANT_VIDAS" , ""},
                { "HISCOBPR_IMPSEGIND" , ""},
                { "HISCOBPR_COD_OPERACAO" , ""},
                { "HISCOBPR_OPCAO_COBERTURA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
                { "HISCOBPR_PRMVG" , ""},
                { "HISCOBPR_PRMAP" , ""},
                { "HISCOBPR_QTDE_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_TIT_CAPITALIZ" , ""},
                { "HISCOBPR_VAL_CUSTO_CAPITALI" , ""},
                { "HISCOBPR_IMPSEGCDG" , ""},
                { "HISCOBPR_VLCUSTCDG" , ""},
                { "HISCOBPR_COD_USUARIO" , ""},
                { "HISCOBPR_TIMESTAMP" , ""},
                { "HISCOBPR_IMPSEGAUXF" , ""},
                { "HISCOBPR_VLCUSTAUXF" , ""},
                { "HISCOBPR_PRMDIT" , ""},
                { "HISCOBPR_QTMDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0126B_COBERTURAS", q9);

            #endregion

            #region R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PRDSIVPF_COD_EMPRESA_SIVPF" , ""},
                { "PRDSIVPF_COD_PRODUTO_SIVPF" , ""},
                { "PRDSIVPF_COD_PRODUTO" , ""},
                { "PRDSIVPF_COD_RELAC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "OPCPAGVI_OPCAO_PAGAMENTO" , ""},
                { "OPCPAGVI_PERI_PAGAMENTO" , ""},
                { "OPCPAGVI_DIA_DEBITO" , ""},
                { "OPCPAGVI_COD_AGENCIA_DEBITO" , ""},
                { "OPCPAGVI_OPE_CONTA_DEBITO" , ""},
                { "OPCPAGVI_NUM_CONTA_DEBITO" , ""},
                { "OPCPAGVI_DIG_CONTA_DEBITO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1", q11);

            #endregion

            #region VA0126B_FUNDOCOMISVA

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG" , ""},
                { "DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA0126B_FUNDOCOMISVA", q12);

            #endregion

            #region VA0126B_C01_AGENCEF

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "DCLAGENCIAS_CEF_COD_AGENCIA" , "0010"},
                { "DCLMALHA_CEF_MALHACEF_COD_FONTE" , "20"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0126B_C01_AGENCEF", q13);

            #endregion

            #region R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "VAL_TARIFA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1", q14);

            #endregion

            #region R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0590_00_LER_PROPOSTA_FIDELIZ_DB_SELECT_1_Query1", q15);

            #endregion

            #region R0620_00_DADOS_RG_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "GEDOCCLI_COD_CLIENTE" , ""},
                { "GEDOCCLI_COD_IDENTIFICACAO" , ""},
                { "GEDOCCLI_NOM_ORGAO_EXP" , ""},
                { "GEDOCCLI_DTH_EXPEDICAO" , ""},
                { "GEDOCCLI_COD_UF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0620_00_DADOS_RG_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1", q17);

            #endregion

            #region R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
                { "RELATORI_IDE_SISTEMA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1", q18);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_VA0126_00.txt")]
        public static void VA0126B_Tests_Theory_Fluxo_InserirDadosRelatorio_ReturnCode_00(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-05-05"},
                { "WHOST_DATA_REFERENCIA" , "2024-07-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);
                #endregion
                #region R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VA0126B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length >= 0);

                //R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1
                var envList1 = AppSettings.TestSet.DynamicData["R1300_00_INSERT_RELATORIO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("RELATORI_DATA_SOLICITACAO", out var val1r) && val1r.Contains("2024-05-05"));
                Assert.True(envList1[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val2r) && val2r.Contains("2024-05-05"));
            }
        }
        [Theory]
        [InlineData("Saida_VA0126_01.txt")]
        public static void VA0126B_Tests_Theory_Fluxo_AtualizarDados_ReturnCode_00(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-07-07"},
                { "WHOST_DATA_REFERENCIA" , "2024-07-01"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);
                #endregion
                #region R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0010_00_BUSCA_ULT_VA0126B_DB_SELECT_1_Query1", q1);

                #endregion
                #endregion
                var program = new VA0126B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
                Assert.True(File.Exists(program.MOVTO_PRP_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_PRP_SASSE.FilePath)?.Length >= 0);

                //R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1
                var envList0 = AppSettings.TestSet.DynamicData["R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList0[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var val1r) && val1r.Contains("2024-07-07"));
            }
        }
        [Theory]
        [InlineData("Saida_VA0126_02.txt")]
        public static void VA0126B_Tests_Theory_Fluxo_ReturnCode_99(string MOVTO_PRP_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_PRP_SASSE_FILE_NAME_P = $"{MOVTO_PRP_SASSE_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                #endregion
                #endregion
                var program = new VA0126B();
                program.Execute(MOVTO_PRP_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
                
            }
        }
    }
}