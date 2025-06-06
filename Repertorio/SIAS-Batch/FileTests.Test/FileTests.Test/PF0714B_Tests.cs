using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0714B;
using System.IO;
using Sias.PessoaFisica.DB2.PF0714B;

namespace FileTests.Test
{
    [Collection("PF0714B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0714B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0001_00_INICIALIZAR_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-02"},
                { "WHOST_DATA_REFERENCIA" , "2024-09-02"},
            });
            AppSettings.TestSet.DynamicData.Add("R0001_00_INICIALIZAR_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "79587"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0714B_MOVTO_CEF

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "24"},
                { "PROPOVA_DTINCLUS" , "2008-08-01"},
                { "PROPOVA_DATA_QUITACAO" , "2008-07-31"},
                { "PROPOVA_NUM_APOLICE" , "109300000550"},
                { "PROPOVA_COD_SUBGRUPO" , "12"},
                { "VGCOMTRO_NUM_TERMO" , "1"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                { "PROPOFID_VAL_PAGO" , "300"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "25"},
                { "PROPOVA_DTINCLUS" , "2008-08-01"},
                { "PROPOVA_DATA_QUITACAO" , "2008-07-31"},
                { "PROPOVA_NUM_APOLICE" , "109300000551"},
                { "PROPOVA_COD_SUBGRUPO" , "12"},
                { "VGCOMTRO_NUM_TERMO" , "1"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058961"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                { "PROPOFID_VAL_PAGO" , "300"},
            });
            q2.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_NUM_CERTIFICADO" , "26"},
                { "PROPOVA_DTINCLUS" , "2008-08-01"},
                { "PROPOVA_DATA_QUITACAO" , "2008-07-31"},
                { "PROPOVA_NUM_APOLICE" , "109300000552"},
                { "PROPOVA_COD_SUBGRUPO" , "12"},
                { "VGCOMTRO_NUM_TERMO" , "1"},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058962"},
                { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                { "PROPOFID_VAL_PAGO" , "300"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0714B_MOVTO_CEF", q2);

            #endregion

            #region R0200_00_LER_RCAPS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , "0"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , "0"}
            });
            q3.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , "0"}
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0220_00_LER_TERMO_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , "97010000889"},
                { "TERMOADE_COD_SUBGRUPO" , "660"},
                { "TERMOADE_DATA_ADESAO" , "1992-06-22"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , "97010000889"},
                { "TERMOADE_COD_SUBGRUPO" , "661"},
                { "TERMOADE_DATA_ADESAO" , "1992-06-22"},
            });
            q4.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_APOLICE" , "97010000889"},
                { "TERMOADE_COD_SUBGRUPO" , "662"},
                { "TERMOADE_DATA_ADESAO" , "1992-06-22"},
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_LER_TERMO_DB_SELECT_1_Query1", q4);

            #endregion

            #region PF0714B_COBERTURAS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "1627"},
                { "HISCOBPR_OCORR_HISTORICO" , "1"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
                { "HISCOBPR_IMP_MORNATU" , "0"},
                { "HISCOBPR_IMPMORACID" , "0"},
                { "HISCOBPR_IMPINVPERM" , "0"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "1627"},
                { "HISCOBPR_OCORR_HISTORICO" , "1"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                { "HISCOBPR_IMPMORACID" , "12000.00"},
                { "HISCOBPR_IMPINVPERM" , "24000.00"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "1627"},
                { "HISCOBPR_OCORR_HISTORICO" , "1"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                { "HISCOBPR_IMPMORACID" , "12000.00"},
                { "HISCOBPR_IMPINVPERM" , "24000.00"},
            });
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , "1627"},
                { "HISCOBPR_OCORR_HISTORICO" , "1"},
                { "HISCOBPR_DATA_INIVIGENCIA" , "0001-01-01"},
                { "HISCOBPR_DATA_TERVIGENCIA" , "9999-12-31"},
                { "HISCOBPR_IMP_MORNATU" , "12000.00"},
                { "HISCOBPR_IMPMORACID" , "12000.00"},
                { "HISCOBPR_IMPINVPERM" , "24000.00"},
            });
            AppSettings.TestSet.DynamicData.Add("PF0714B_COBERTURAS", q5);

            #endregion

            #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , "1"}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q6);

            #endregion

            #region PF0714B_TER_NIVEL

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
                { "VGTERNIV_NUM_NIVEL_CARGO" , ""},
                { "VGTERNIV_DTH_FIM_VIGENCIA" , ""},
                { "VGTERNIV_IMP_SEGURADA" , ""},
                { "VGTERNIV_VLR_PRM_INDIVIDUAL" , ""},
                { "VGTERNIV_QTD_VIDAS" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0714B_TER_NIVEL", q7);

            #endregion

            #region R0860_LER_APOLICE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "68"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "11"}
            });
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , "11"}
            });
            AppSettings.TestSet.DynamicData.Add("R0860_LER_APOLICE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0870_LER_RAMOIND_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "1"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "7"}
            });
            q9.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , "1"}
            });
            AppSettings.TestSet.DynamicData.Add("R0870_LER_RAMOIND_DB_SELECT_1_Query1", q9);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q11);

            #endregion

            #region R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1", q12);

            #endregion

            #region R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , "97010000889"},
                { "PROPSSVD_COD_SUBGRUPO" , "4190"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , "97010000889"},
                { "PROPSSVD_COD_SUBGRUPO" , "1949"},
            });
            q13.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , "97010000889"},
                { "PROPSSVD_COD_SUBGRUPO" , "3603"},
            });
            AppSettings.TestSet.DynamicData.Add("R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1_Query1", q13);

            #endregion

            #region R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "PROPSSVD_NUM_APOLICE" , ""},
                { "PROPSSVD_COD_SUBGRUPO" , ""},
                { "PROPSSVD_NUM_IDENTIFICACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1", q14);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_PF0714B.txt")]
        public static void PF0714B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0714B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                var envList1 = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1.Count > 1);
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out var val8r) && val8r.Contains("STASASSE"));
                Assert.True(envList1[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var val9r) && val9r.Contains("4"));

            }
        }
        [Theory]
        [InlineData("Saida_PF0714B.txt")]
        public static void PF0714B_Tests_TheorySemHistorico(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

                //var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q6);

                var q7 = AppSettings.TestSet.DynamicData["PF0714B_TER_NIVEL"];
                q7.AddDynamic(new Dictionary<string, string>{
                    { "VGTERNIV_NUM_PROPOSTA_SIVPF" , ""},
                    { "VGTERNIV_DTH_INI_VIGENCIA" , ""},
                    { "VGTERNIV_NUM_NIVEL_CARGO" , ""},
                    { "VGTERNIV_DTH_FIM_VIGENCIA" , ""},
                    { "VGTERNIV_IMP_SEGURADA" , ""},
                    { "VGTERNIV_VLR_PRM_INDIVIDUAL" , ""},
                    { "VGTERNIV_QTD_VIDAS" , ""},
                });
                AppSettings.TestSet.DynamicData.Remove("PF0714B_TER_NIVEL");
                AppSettings.TestSet.DynamicData.Add("PF0714B_TER_NIVEL", q7);

                var q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , "0"}
                });
                AppSettings.TestSet.DynamicData.Remove("R0200_00_LER_RCAPS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0200_00_LER_RCAPS_DB_SELECT_1_Query1", q8);

                AppSettings.TestSet.DynamicData.Remove("PF0714B_MOVTO_CEF");
                q8 = new DynamicData();
                q8.AddDynamic(new Dictionary<string, string>{
                    { "PROPOVA_NUM_CERTIFICADO" , "24"},
                    { "PROPOVA_DTINCLUS" , "2008-08-01"},
                    { "PROPOVA_DATA_QUITACAO" , "2008-07-31"},
                    { "PROPOVA_NUM_APOLICE" , "109300000550"},
                    { "PROPOVA_COD_SUBGRUPO" , "12"},
                    { "VGCOMTRO_NUM_TERMO" , "1"},
                    { "PROPOFID_NUM_PROPOSTA_SIVPF" , "80021058960"},
                    { "PROPOFID_NUM_IDENTIFICACAO" , "1"},
                    { "PROPOFID_SIT_PROPOSTA" , "EMT"},
                    { "PROPOFID_COD_EMPRESA_SIVPF" , "3"},
                    { "PROPOFID_COD_PRODUTO_SIVPF" , "80"},
                    { "PROPOFID_VAL_PAGO" , "300"},
                });
                AppSettings.TestSet.DynamicData.Add("PF0714B_MOVTO_CEF", q8);

                #endregion
                #endregion
                var program = new PF0714B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 0);

                // R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1
                var envList2 = AppSettings.TestSet.DynamicData["R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2.Count > 1);
                Assert.True(envList2[1].TryGetValue("PROPFIDH_NSAS_SIVPF", out var val4r) && val4r.Contains("79588"));
                Assert.True(envList2[1].TryGetValue("PROPFIDH_SIT_COBRANCA_SIVPF", out var val5r) && val5r.Contains("PAG"));

                //R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1
                var envList = AppSettings.TestSet.DynamicData["R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("PROPOFID_NSAS_SIVPF", out var val8r) && val8r.Contains("79588"));
                Assert.True(envList[1].TryGetValue("PROPOFID_NUM_PROPOSTA_SIVPF", out var val9r) && val9r.Contains("80021058960"));

                //R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1
                var envList1 = AppSettings.TestSet.DynamicData["R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("PROPSSVD_NUM_APOLICE", out var val2r) && val2r.Contains("97010000889"));
                Assert.True(envList1[1].TryGetValue("PROPSSVD_NUM_IDENTIFICACAO", out var val3r) && val3r.Contains("1"));

            }
        }
        [Theory]
        [InlineData("Saida_PF0714B.txt")]
        public static void PF0714B_Tests_TheoryErro99(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_DB_SELECT_1_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

                var q6 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q6);

                #endregion
                #endregion
                var program = new PF0714B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 9);
                Assert.True(program.WABEND.FILLER_3.WSQLCODE == 100);

            }
        }
    }
}