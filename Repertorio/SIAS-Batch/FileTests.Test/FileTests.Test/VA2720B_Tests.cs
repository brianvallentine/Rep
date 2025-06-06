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
using static Code.VA2720B;
using Sias.VidaAzul.DB2.VA2720B;

namespace FileTests.Test
{
    [Collection("VA2720B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA2720B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1", q1);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "WS_PERIODO_DE" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q3);

            #endregion

            #region VA2720B_TPROPOVA

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , ""},
                { "PROPOVA_COD_SUBGRUPO" , ""},
                { "PROPOVA_NUM_CERTIFICADO" , ""},
                { "PROPOVA_COD_CLIENTE" , ""},
                { "PROPOVA_OCOREND" , ""},
                { "PROPOVA_AGE_COBRANCA" , ""},
                { "PROPOVA_DATA_MOVIMENTO" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
                { "PROPOVA_COD_PRODUTO" , ""},
                { "PROPOVA_NRCERTIFANT" , ""},
                { "MOVVGAP_DATA_MOVIMENTO" , ""},
                { "MOVVGAP_IMP_MORNATU_ATU" , ""},
                { "MOVVGAP_IMP_MORACID_ATU" , ""},
                { "MOVVGAP_IMP_INVPERM_ATU" , ""},
                { "MOVVGAP_IMP_AMDS_ATU" , ""},
                { "MOVVGAP_IMP_DH_ATU" , ""},
                { "MOVVGAP_IMP_DIT_ATU" , ""},
                { "MOVVGAP_COD_OPERACAO" , ""},
                { "MOVVGAP_DATA_OPERACAO" , ""},
                { "PROPOVA_OCORR_HISTORICO" , ""},
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PRODUVG_ORIG_PRODU" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("VA2720B_TPROPOVA", q4);

            #endregion

            #region R1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_SIT_PROPOSTA" , ""},
                { "PROPFIDH_DATA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_SELECT_HISPROFI_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R1150_SELECT_RELATORIOS_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                { "RELATORI_COD_PLANO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1150_SELECT_RELATORIOS_DB_SELECT_1_Query1", q7);

            #endregion

            #region R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1310_00_SELECT_PROPOFID_DB_SELECT_1_Query1", q10);

            #endregion

            #region R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_DATA_PROPOSTA" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
                { "PROPOFID_CANAL_PROPOSTA" , ""},
                { "PROPOFID_ORIGEM_PROPOSTA" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1315_00_SELECT_PROPOFID_ORIG_DB_SELECT_1_Query1", q11);

            #endregion

            #region R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_ENDOSSOS_DB_SELECT_1_Query1", q12);

            #endregion

            #region R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_SIT_REGISTRO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1401_00_SELECT_HISTCON_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , ""},
                { "SEGURVGA_COD_SUBGRUPO" , ""},
                { "SEGURVGA_NUM_ITEM" , ""},
                { "SEGURVGA_OCORR_HISTORICO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1405_00_OBTER_DADOS_SEGURADO_DB_SELECT_1_Query1", q14);

            #endregion

            #region R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
                { "APOLICOB_NUM_APOLICE" , ""},
                { "APOLICOB_NUM_ITEM" , ""},
                { "APOLICOB_NUM_ENDOSSO" , ""},
                { "APOLICOB_RAMO_COBERTURA" , ""},
                { "APOLICOB_COD_COBERTURA" , ""},
                { "APOLICOB_DATA_INIVIGENCIA" , ""},
                { "APOLICOB_DATA_TERVIGENCIA" , ""},
                { "APOLICOB_IMP_SEGURADA_IX" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1410_00_OBTER_VIGENCIA_DB_SELECT_1_Query1", q15);

            #endregion

            #region R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_VLPREMIO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q16);

            #endregion

            #region R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1

            var q17 = new DynamicData();
            q17.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_IMPAMDS" , ""},
                { "HISCOBPR_IMPDH" , ""},
                { "HISCOBPR_IMPDIT" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1", q17);

            #endregion

            #region R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1

            var q18 = new DynamicData();
            q18.AddDynamic(new Dictionary<string, string>{
                { "WHOST_COUNT" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1600_00_SELECT_PARCEVID_DB_SELECT_1_Query1", q18);

            #endregion

            #region R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1

            var q19 = new DynamicData();
            q19.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1700_00_SELECT_RAMOCOMP_DB_SELECT_1_Query1", q19);

            #endregion

            #region R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

            var q20 = new DynamicData();
            q20.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q20);

            #endregion

            #region R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1

            var q21 = new DynamicData();
            q21.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1", q21);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("AVA2720B_FILE_NAME_P")]
        public static void VA2720B_Tests_Theory_Erro9(string AVA2720B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2720B_FILE_NAME_P = $"{AVA2720B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VG0710S_Tests.Load_Parameters();

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , ""},
                }, new SQLCA(100));
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new VA2720B();
                program.Execute(AVA2720B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
            }
        }
           
        [Theory]
        [InlineData("AVA2720B_FILE_NAME_P")]
        public static void VA2720B_Tests_Theory(string AVA2720B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            AVA2720B_FILE_NAME_P = $"{AVA2720B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                VG0710S_Tests.Load_Parameters();

                #region R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1

                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1", q1);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2006-09-01"},
                { "SISTEMAS_DATA_MOV_ABERTO_30" , "2006-09-30"},
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1", q2);

                #endregion

                #region R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1

                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                { "WS_PERIODO_DE" , "2006-08-10"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1");
                AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1", q3);

                #endregion

                #region VA2720B_TPROPOVA

                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_APOLICE" , "108100000113"},
                { "PROPOVA_COD_SUBGRUPO" , "0"},
                { "PROPOVA_NUM_CERTIFICADO" , "10001827984"},
                { "PROPOVA_COD_CLIENTE" , "3155015"},
                { "PROPOVA_OCOREND" , "1"},
                { "PROPOVA_AGE_COBRANCA" , "630"},
                { "PROPOVA_DATA_MOVIMENTO" , "2006-08-04"},
                { "PROPOVA_SIT_REGISTRO" , "3"},
                { "PROPOVA_COD_PRODUTO" , "8101"},
                { "PROPOVA_NRCERTIFANT" , ""},
                { "MOVVGAP_DATA_MOVIMENTO" , "0001-01-01"},
                { "MOVVGAP_IMP_MORNATU_ATU" , "0.00"},
                { "MOVVGAP_IMP_MORACID_ATU" , "0.00"},
                { "MOVVGAP_IMP_INVPERM_ATU" , "0.00"},
                { "MOVVGAP_IMP_AMDS_ATU" , "0.00"},
                { "MOVVGAP_IMP_DH_ATU" , "0.00"},
                { "MOVVGAP_IMP_DIT_ATU" , "0.00"},
                { "MOVVGAP_COD_OPERACAO" , "390"},
                { "MOVVGAP_DATA_OPERACAO" , "0001-01-01"},
                { "PROPOVA_OCORR_HISTORICO" , "94"},
                { "PROPOVA_DATA_QUITACAO" , "1998-10-01"},
                { "PROPOVA_NUM_PARCELA" , "94"},
                { "PRODUVG_ORIG_PRODU" , "ESPEC"},
                });
                AppSettings.TestSet.DynamicData.Remove("VA2720B_TPROPOVA");
                AppSettings.TestSet.DynamicData.Add("VA2720B_TPROPOVA", q4);

                #endregion

                #region R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1

                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
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
                AppSettings.TestSet.DynamicData.Remove("R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1");
                AppSettings.TestSet.DynamicData.Add("R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1", q6);

                #endregion

                #region R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""},
                { "RELATORI_NUM_CERTIFICADO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_NUM_PARCELA" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q8);

                #endregion

                #region R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1

                var q20 = new DynamicData();
                q20.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                });
                AppSettings.TestSet.DynamicData.Remove("R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1", q20);

                #endregion

                #region R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1

                var q21 = new DynamicData();
                q21.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1");
                AppSettings.TestSet.DynamicData.Add("R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1", q21);

                #endregion

                #endregion
                var program = new VA2720B();
                program.Execute(AVA2720B_FILE_NAME_P);

                //R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R0021_00_INSERT_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var valor) && valor.Contains("0004"));
                Assert.True(envList.Count > 1);

                //R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R1120_00_GRAVA_HISPROFI_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2[1].TryGetValue("PROPFIDH_SIT_MOTIVO_SIVPF", out var valor2) && valor2.Contains("000000731"));
                Assert.True(envList2.Count > 1);

                //R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1
                var envList3 = AppSettings.TestSet.DynamicData["R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("RELATORI_NUM_PARCELA", out var valor3) && valor3.Contains("0"));
                Assert.True(envList3.Count > 1);

                //R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1
                var envList4 = AppSettings.TestSet.DynamicData["R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("SISTEMAS_DATA_MOV_ABERTO", out var valor4) && valor4.Contains("2006-09-01"));
                Assert.True(envList4.Count > 1);

                //R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1
                var envList5 = AppSettings.TestSet.DynamicData["R9989_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList5[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var valor5) && valor5.Contains("000000001"));
                Assert.True(envList5.Count > 1);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
    }
}