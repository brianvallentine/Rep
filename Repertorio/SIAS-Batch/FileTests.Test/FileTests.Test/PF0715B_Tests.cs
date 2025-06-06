using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0715B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0715B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0715B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        private static void Load_Parameters()
        {
            AppSettings.TestSet.DynamicData.Clear();
            #region PARAMETERS
            #region R0005_00_INICIALIZAR_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "WHOST_DATA_REFERENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_INICIALIZAR_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q1);

            #endregion

            #region PF0715B_TERMO_ADESAO

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "TERMOADE_NUM_TERMO" , ""},
                { "TERMOADE_NUM_APOLICE" , ""},
                { "VGACOTER_NUM_CERTIFICADO" , ""},
                { "VGACOTER_OCORR_HISTORICO" , ""},
                { "VGACOTER_COD_DEVOLUCAO" , ""},
                { "VGACOTER_COD_OPERACAO" , "400"},
                { "VGACOTER_DATA_MOVIMENTO" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
                { "PROPOFID_NUM_IDENTIFICACAO" , ""},
                { "PROPOFID_COD_EMPRESA_SIVPF" , ""},
                { "PROPOFID_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0715B_TERMO_ADESAO", q2);

            #endregion

            #region R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "PROPOVA_DATA_QUITACAO" , ""},
                { "PROPOVA_NUM_PARCELA" , ""},
                { "PROPOVA_SIT_REGISTRO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_LER_PROPOSTAVA_DB_SELECT_1_Query1", q3);

            #endregion

            #region R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "PF037_SIT_MOTIVO_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_OBTER_MOTIVO_VD_DB_SELECT_1_Query1", q4);

            #endregion

            #region PF0715B_COBERTURAS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "HISCOBPR_NUM_CERTIFICADO" , ""},
                { "HISCOBPR_OCORR_HISTORICO" , ""},
                { "HISCOBPR_DATA_INIVIGENCIA" , ""},
                { "HISCOBPR_DATA_TERVIGENCIA" , ""},
                { "HISCOBPR_IMP_MORNATU" , ""},
                { "HISCOBPR_IMPMORACID" , ""},
                { "HISCOBPR_IMPINVPERM" , ""},
                { "HISCOBPR_VLPREMIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0715B_COBERTURAS", q5);

            #endregion

            #region R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            //AppSettings.TestSet.DynamicData.Add("R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q6);

            #endregion

            #region PF0715B_TER_NIVEL

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
            AppSettings.TestSet.DynamicData.Add("PF0715B_TER_NIVEL", q7);

            #endregion

            #region R0860_LER_APOLICE_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_RAMO_EMISSOR" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0860_LER_APOLICE_DB_SELECT_1_Query1", q8);

            #endregion

            #region R0870_LER_RAMOIND_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "RAMOCOMP_PCT_IOCC_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0870_LER_RAMOIND_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0980_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q10);

            #endregion

            #region R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0985_00_LER_H_PROP_FIDEL_DB_SELECT_1_Query1", q11);

            #endregion

            #region PF0715B_PAGAMENTO

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "HISCONPA_NUM_CERTIFICADO" , ""},
                { "HISCONPA_NUM_PARCELA" , ""},
                { "HISCONPA_NUM_TITULO" , ""},
                { "HISCONPA_OCORR_HISTORICO" , ""},
                { "HISCONPA_NUM_APOLICE" , ""},
                { "HISCONPA_COD_SUBGRUPO" , ""},
                { "HISCONPA_PREMIO_VG" , ""},
                { "HISCONPA_PREMIO_AP" , ""},
                { "HISCONPA_COD_OPERACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0715B_PAGAMENTO", q12);

            #endregion

            #region R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_COD_FONTE" , ""},
                { "RCAPS_NUM_RCAP" , ""},
                { "RCAPS_VAL_RCAP" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1", q13);

            #endregion

            #region R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q14);

            #endregion

            #region R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1

            var q15 = new DynamicData();
            q15.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1", q15);

            #endregion

            #region R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1

            var q16 = new DynamicData();
            q16.AddDynamic(new Dictionary<string, string>{
                { "PROPOFID_NSAS_SIVPF" , ""},
                { "PROPOFID_NSL" , ""},
                { "PROPOFID_SIT_PROPOSTA" , ""},
                { "PROPOFID_COD_USUARIO" , ""},
                { "PROPOFID_SITUACAO_ENVIO" , ""},
                { "PROPOFID_NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1_Update1", q16);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("MOVTO_STA_SASSE_FILE_02.txt")]
        public static void PF0715B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_SASSE_FILE_NAME_P = $"{MOVTO_STA_SASSE_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
               
                var program = new PF0715B();

                var fileName = Path.GetFileNameWithoutExtension(MOVTO_STA_SASSE_FILE_NAME_P);
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
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));
                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

                //R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1
                var envList = AppSettings.TestSet.DynamicData["R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList1?.Count > 1);

                Assert.True(envList[1].TryGetValue("ARQSIVPF_SISTEMA_ORIGEM", out var valor) && valor == "0004");
                Assert.True(envList[1].TryGetValue("ARQSIVPF_SIGLA_ARQUIVO", out valor) && valor == "STASASSE");

                Assert.True(envList1[1].TryGetValue("PROPFIDH_SIT_PROPOSTA", out valor) && valor == "REJ");
                Assert.True(envList1[1].TryGetValue("PROPFIDH_NSL", out valor) && valor == "000000001");

            }
        }
    }
}