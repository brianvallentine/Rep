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
using static Code.PF0711B;

namespace FileTests.Test
{
    [Collection("PF0711B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class PF0711B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

            #endregion

            #region R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "DESCR_ARQUIVO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0110_00_VALIDAR_CONVENIO_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0117_00_OBTER_NSAS_MOVTO_DB_SELECT_1_Query1", q2);

            #endregion

            #region R0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "DATA_CREDITO" , ""},
                { "DTQITBCO" , ""},
                { "VAL_PAGO" , ""},
                { "AGEPGTO" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0250_00_TRATA_EMPRESA_DB_UPDATE_1_Update1", q3);

            #endregion

            #region R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "NUM_IDENTIFICACAO" , "123456"},
                { "COD_EMPRESA_SIVPF" , "1"},
                { "COD_PRODUTO_SIVPF" , "123"},
                { "SIT_PROPOSTA" , "1"},
                { "DTQITBCO" , "2024-01-01"},
                { "VAL_PAGO" , "12.12"},
                { "AGEPGTO" , "1"},
                { "DATA_CREDITO" , "2024-10-10"},
            });
            AppSettings.TestSet.DynamicData.Add("R0270_00_LER_PROP_FIDELIZ_DB_SELECT_1_Query1", q4);

            #endregion

            #region R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_LER_HIST_FIDELIZ_DB_SELECT_1_Query1", q5);

            #endregion

            #region R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0280_00_LER_HIST_FIDELIZ_DB_SELECT_2_Query1", q6);

            #endregion

            #region R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "SITUACAO_ENVIO" , ""},
                { "SIT_PROPOSTA" , ""},
                { "COD_USUARIO" , ""},
                { "NSAS_SIVPF" , ""},
                { "NSL" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0300_00_ATUALIZAR_PRP_FIDELIZ_DB_UPDATE_1_Update1", q7);

            #endregion

            #region R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "VAL_IOF" , ""},
                { "NUM_PROPOSTA_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0330_00_ATUALIZAR_IOF_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PROPFIDH_NUM_IDENTIFICACAO" , ""},
                { "PROPFIDH_COD_EMPRESA_SIVPF" , ""},
                { "PROPFIDH_COD_PRODUTO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0350_00_GERAR_HIST_FIDELIZ_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
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
            AppSettings.TestSet.DynamicData.Add("R0350_00_GERAR_HIST_FIDELIZ_DB_INSERT_1_Insert1", q10);

            #endregion

            #region R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0450_00_OBTER_NSAS_MOV_CEF_DB_SELECT_1_Query1", q11);

            #endregion

            #region R0763_00_LER_RCAP_DB_SELECT_1_Query1

            var q12 = new DynamicData();
            q12.AddDynamic(new Dictionary<string, string>{
                { "RCAPS_VAL_RCAP" , ""},
                { "RCAPS_DATA_CADASTRAMENTO" , ""},
                { "RCAPS_DATA_MOVIMENTO" , ""},
                { "RCAPS_AGE_COBRANCA" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0763_00_LER_RCAP_DB_SELECT_1_Query1", q12);

            #endregion

            #region R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1

            var q13 = new DynamicData();
            q13.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2090_00_ATUALIZAR_ARQSIVPF_DB_INSERT_1_Insert1", q13);

            #endregion

            #region R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1

            var q14 = new DynamicData();
            q14.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_TB_CONTROLE_DB_INSERT_1_Insert1", q14);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Entrada_PF0711B_RETURN_00.txt", "MOV_STA_CEF_FILE_NAME_P", "MOV_STA_FNAE_FILE_NAME_P", "RPF0711B_FILE_NAME_P")]
        public static void PF0711B_Tests_TheoryReturnCode_00(string MOV_STA_MR_FILE_NAME_P, string MOV_STA_CEF_FILE_NAME_P, string MOV_STA_FNAE_FILE_NAME_P, string RPF0711B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_STA_CEF_FILE_NAME_P = $"{MOV_STA_CEF_FILE_NAME_P}_{timestamp}.txt";
            MOV_STA_FNAE_FILE_NAME_P = $"{MOV_STA_FNAE_FILE_NAME_P}_{timestamp}.txt";
            RPF0711B_FILE_NAME_P = $"{RPF0711B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                //#region R0005_00_OBTER_DATA_DIA_Query1
                //var q0 = new DynamicData();
                //q0.AddDynamic(new Dictionary<string, string>{
                //    { "SISTEMAS_DATA_MOV_ABERTO" , ""}
                //});
                //AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_Query1", q0);

                //#endregion
                //#region R0280_00_LER_HIST_FIDELIZ_Query1
                //var q5 = new DynamicData();
                //q5.AddDynamic(new Dictionary<string, string> {
                //    { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
                //});
                //AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_HIST_FIDELIZ_Query1");
                //AppSettings.TestSet.DynamicData.Add("R0280_00_LER_HIST_FIDELIZ_Query1", q5);
                //#endregion
                //#region R0280_00_LER_HIST_FIDELIZ_Query2
                //var q6 = new DynamicData();
                //q6.AddDynamic(new Dictionary<string, string> {
                //    { "PROPFIDH_NUM_IDENTIFICACAO" , ""}
                //});
                //AppSettings.TestSet.DynamicData.Remove("R0280_00_LER_HIST_FIDELIZ_Query2");
                //AppSettings.TestSet.DynamicData.Add("R0280_00_LER_HIST_FIDELIZ_Query2", q6);
                //#endregion
                #endregion
                var program = new PF0711B();
                program.Execute(MOV_STA_MR_FILE_NAME_P, MOV_STA_CEF_FILE_NAME_P, MOV_STA_FNAE_FILE_NAME_P, RPF0711B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Entrada_PF0711B_RETURN_99.txt", "MOV_STA_CEF_FILE_NAME_P", "MOV_STA_FNAE_FILE_NAME_P", "RPF0711B_FILE_NAME_P")]
        public static void PF0711B_Tests_TheoryReturnCode_99(string MOV_STA_MR_FILE_NAME_P, string MOV_STA_CEF_FILE_NAME_P, string MOV_STA_FNAE_FILE_NAME_P, string RPF0711B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOV_STA_CEF_FILE_NAME_P = $"{MOV_STA_CEF_FILE_NAME_P}_{timestamp}.txt";
            MOV_STA_FNAE_FILE_NAME_P = $"{MOV_STA_FNAE_FILE_NAME_P}_{timestamp}.txt";
            RPF0711B_FILE_NAME_P = $"{RPF0711B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #endregion
                var program = new PF0711B();
                program.Execute(MOV_STA_MR_FILE_NAME_P, MOV_STA_CEF_FILE_NAME_P, MOV_STA_FNAE_FILE_NAME_P, RPF0711B_FILE_NAME_P);

                Assert.True(program.RETURN_CODE == 99);
            }
        }
    }
}