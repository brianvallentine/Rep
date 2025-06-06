using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.PF0634B;
using System.IO;

namespace FileTests.Test
{
    [Collection("PF0634B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0634B_Tests
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
                { "SISTEMAS_DATA_MOV_ABERTO" , "2024-09-16"}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , "2024-09-16"}
            });
            AppSettings.TestSet.DynamicData.Add("R0007_00_OBTER_DT_PROCE_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , "Teste123"}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_INSERT_2_Insert1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_INSERT_2_Insert1", q3);

            #endregion

            #region PF0634B_PROPOSTA_FIDELIZ

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "DCLPROPOSTA_FIDELIZ_NUM_PROPOSTA_SIVPF" , "82118757541"},
                { "DCLPROPOSTA_FIDELIZ_NUM_IDENTIFICACAO" , "5476877"},
                { "DCLPROPOSTA_FIDELIZ_NUM_SICOB" , "82116567540"},
                { "DCLPROPOSTA_FIDELIZ_COD_PRODUTO_SIVPF" , "4"},
                { "DCLPROPOSTA_FIDELIZ_VAL_PAGO" , "75.50"},
                { "DCLPROPOSTA_FIDELIZ_VAL_IOF" , "4.94"},
                { "DCLPROPOSTA_FIDELIZ_SIT_PROPOSTA" , "VNC"},
                { "DCLPROPOSTA_FIDELIZ_COD_USUARIO" , "PF0618B"},
                { "DCLPROPOSTA_FIDELIZ_CANAL_PROPOSTA" , "2"},
                { "DCLPROPOSTA_FIDELIZ_NSAS_SIVPF" , "5987"},
                { "DCLPROPOSTA_FIDELIZ_ORIGEM_PROPOSTA" , "6"},
                { "DCLPROPOSTA_FIDELIZ_NSL" , "2125"},
                { "DCLPROPOSTA_FIDELIZ_NSAC_SIVPF" , "1983"},
                { "DCLPROPOSTA_FIDELIZ_SITUACAO_ENVIO" , "R"},
                { "DCLBILHETE_BILHETE_NUM_BILHETE" , ""},
                { "DCLBILHETE_BILHETE_NUM_APOLICE" , ""},
                { "DCLBILHETE_BILHETE_NUM_APOL_ANTERIOR" , ""},
                { "DCLBILHETE_BILHETE_OPC_COBERTURA" , ""},
                { "DCLBILHETE_BILHETE_DATA_QUITACAO" , ""},
                { "DCLBILHETE_BILHETE_VAL_RCAP" , ""},
                { "DCLBILHETE_BILHETE_RAMO" , ""},
                { "DCLBILHETE_BILHETE_SITUACAO" , ""},
                { "W_DATA_SITUACAO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0634B_PROPOSTA_FIDELIZ", q4);

            #endregion

            #region R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "NSAS_SIVPF" , ""},
                { "NSL" , ""},
                { "SIT_PROPOSTA" , ""},
                { "VAL_IOF" , ""},
                { "COD_USUARIO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1", q5);

            #endregion

            #region R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1

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
            AppSettings.TestSet.DynamicData.Add("R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1", q6);

            #endregion

            #region R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ENDOSSOS_NUM_APOLICE" , ""},
                { "ENDOSSOS_NUM_ENDOSSO" , ""},
                { "ENDOSSOS_NUM_PROPOSTA" , ""},
                { "ENDOSSOS_DATA_PROPOSTA" , ""},
                { "ENDOSSOS_NUM_RCAP" , ""},
                { "ENDOSSOS_VAL_RCAP" , ""},
                { "ENDOSSOS_DATA_INIVIGENCIA" , ""},
                { "ENDOSSOS_DATA_TERVIGENCIA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0230_00_LER_ENDOSSO_DB_SELECT_1_Query1", q7);

            #endregion

            #region PF0634B_BILHETE_COBERTURA

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "DCLBILHETE_COBERTURA_BILCOBER_COD_PRODUTO" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_RAMO_COBERTURA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_MODALI_COBERTURA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_COD_OPCAO_PLANO" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_COD_COBERTURA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_DATA_INIVIGENCIA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_DATA_TERVIGENCIA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_IDE_COBERTURA" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_VAL_COBERTURA_IX" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_PRM_TOTAL" , ""},
                { "DCLBILHETE_COBERTURA_BILCOBER_PCT_IOCC" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("PF0634B_BILHETE_COBERTURA", q8);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1", q9);

            #endregion

            #region R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_REFERENCIA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1", q10);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("saida_PF0634B.txt")]
        public static void PF0634B_Tests_Theory(string MOVTO_STA_SASSE_FILE_NAME_P)
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
                var program = new PF0634B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);

                //var envList = AppSettings.TestSet.DynamicData["R0020_00_OBTER_MAX_NSAS_DB_INSERT_2_Insert1"].DynamicList;
                //Assert.True(envList?.Count > 1);

                var envList1 = AppSettings.TestSet.DynamicData["R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList1[1].TryGetValue("NSAS_SIVPF", out var val2r) && val2r.Contains("5987"));

                var envList2 = AppSettings.TestSet.DynamicData["R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1_Insert1"].DynamicList;
                Assert.True(envList2?.Count > 1);

                var envList3 = AppSettings.TestSet.DynamicData["R0850_00_CONTROLAR_ARQ_ENVIADO_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList3[1].TryGetValue("ARQSIVPF_NSAS_SIVPF", out var val3r) && val3r.Contains("1"));

                var envList4 = AppSettings.TestSet.DynamicData["R1110_00_UPDATE_RELATORIOS_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList4[1].TryGetValue("RELATORI_DATA_REFERENCIA", out var val4r) && val4r.Contains("2024-09-16"));

                Assert.True(program.RETURN_CODE == 0);

                Assert.True(File.Exists(program.MOVTO_STA_SASSE.FilePath));

                Assert.True(new FileInfo(program.MOVTO_STA_SASSE.FilePath)?.Length > 0);

            }
        }

        [Theory]
        [InlineData("saida_PF0634B.txt")]
        public static void PF0634B_Tests_Theory_Error(string MOVTO_STA_SASSE_FILE_NAME_P)
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

                #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

                var q2 = new DynamicData();
                
                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q2);

                #endregion

                #endregion
                var program = new PF0634B();
                program.Execute(MOVTO_STA_SASSE_FILE_NAME_P);
                
                Assert.True(program.RETURN_CODE == 99);

            }
        }
    }
}