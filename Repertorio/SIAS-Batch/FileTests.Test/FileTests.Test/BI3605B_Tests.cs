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
using static Code.BI3605B;

namespace FileTests.Test
{
    [Collection("BI3605B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI3605B_Tests
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

            #region R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "RELATORI_DATA_SOLICITACAO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1", q1);

            #endregion

            #region R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , ""},
                { "RELATORI_COD_RELATORIO" , ""},
                { "RELATORI_COD_USUARIO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1", q2);

            #endregion

            #region R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_NSAS_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q3);

            #endregion

            #region BI3605B_CBILHETE

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_NUM_BILHETE" , ""},
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_SIT_SINISTRO" , ""},
                { "BILHETE_NUM_APOLICE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI3605B_CBILHETE", q4);

            #endregion

            #region BI3605B_BILHETE_ERROS

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "ERROSBIL_NUM_BILHETE" , ""},
                { "ERROSBIL_COD_ERRO" , ""},
                { "CODERRBI_COD_ERRO_SIVPF" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("BI3605B_BILHETE_ERROS", q5);

            #endregion

            #region R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "CONVERSI_NUM_PROPOSTA_SIVPF" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q6);

            #endregion

            #region R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "ORIGEM_PROPOSTA" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q7);

            #endregion

            #region R0200_00_UPD_BILHETE_DB_UPDATE_1_Update1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "BILHETE_SITUACAO" , ""},
                { "BILHETE_NUM_BILHETE" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0200_00_UPD_BILHETE_DB_UPDATE_1_Update1", q8);

            #endregion

            #region R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "WS_QTDBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1", q9);

            #endregion

            #region R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "WS_QTDBIL" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1", q10);

            #endregion

            #region R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "ARQSIVPF_SIGLA_ARQUIVO" , ""},
                { "ARQSIVPF_SISTEMA_ORIGEM" , ""},
                { "ARQSIVPF_NSAS_SIVPF" , ""},
                { "ARQSIVPF_DATA_GERACAO" , ""},
                { "ARQSIVPF_QTDE_REG_GER" , ""},
                { "ARQSIVPF_DATA_PROCESSAMENTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_BI3605B")]
        public static void BI3605B_Tests_Theory(string MOVTO_STA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_FILE_NAME_P = $"{MOVTO_STA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                var q0 = new DynamicData();
                q0.AddDynamic(new Dictionary<string, string>{
                    { "SISTEMAS_DATA_MOV_ABERTO" , "2020-01-01"}
                });
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                AppSettings.TestSet.DynamicData.Remove("R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1");
                var q1 = new DynamicData();
                q1.AddDynamic(new Dictionary<string, string>{
                    { "RELATORI_DATA_SOLICITACAO" , "2024-01-01"}
                });
                AppSettings.TestSet.DynamicData.Add("R0006_00_OBTER_RELATORI_DB_SELECT_1_Query1", q1);

                AppSettings.TestSet.DynamicData.Remove("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1");
                var q3 = new DynamicData();
                q3.AddDynamic(new Dictionary<string, string>{
                    { "ARQSIVPF_NSAS_SIVPF" , "71"}
                });
                AppSettings.TestSet.DynamicData.Add("R0020_00_OBTER_MAX_NSAS_DB_SELECT_1_Query1", q3);

                AppSettings.TestSet.DynamicData.Remove("BI3605B_CBILHETE");
                var q4 = new DynamicData();
                q4.AddDynamic(new Dictionary<string, string>{
                    { "BILHETE_NUM_BILHETE" , "12572"},
                    { "BILHETE_SITUACAO" , "P"},
                    { "BILHETE_SIT_SINISTRO" , "0"},
                    { "BILHETE_NUM_APOLICE" , "0"},
                });
                q4.AddDynamic(new Dictionary<string, string>{
                    { "BILHETE_NUM_BILHETE" , "12872"},
                    { "BILHETE_SITUACAO" , "P"},
                    { "BILHETE_SIT_SINISTRO" , "0"},
                    { "BILHETE_NUM_APOLICE" , "0"},
                });
                AppSettings.TestSet.DynamicData.Add("BI3605B_CBILHETE", q4);

                AppSettings.TestSet.DynamicData.Remove("R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                var q6 = new DynamicData();
                q6.AddDynamic(new Dictionary<string, string>{
                    { "CONVERSI_NUM_PROPOSTA_SIVPF" , "400"}
                });
                AppSettings.TestSet.DynamicData.Add("R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q6);


                AppSettings.TestSet.DynamicData.Remove("R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1");
                var q7 = new DynamicData();
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ORIGEM_PROPOSTA" , "6"}
                });
                q7.AddDynamic(new Dictionary<string, string>{
                    { "ORIGEM_PROPOSTA" , "6"}
                });
                AppSettings.TestSet.DynamicData.Add("R0181_00_SELECT_FIDELIZ_DB_SELECT_1_Query1", q7);

                AppSettings.TestSet.DynamicData.Remove("BI3605B_BILHETE_ERROS");
                var q5 = new DynamicData();
                q5.AddDynamic(new Dictionary<string, string>{
                    { "ERROSBIL_NUM_BILHETE" , ""},
                    { "ERROSBIL_COD_ERRO" , ""},
                    { "CODERRBI_COD_ERRO_SIVPF" , ""},
                });
                AppSettings.TestSet.DynamicData.Add("BI3605B_BILHETE_ERROS", q5);

                AppSettings.TestSet.DynamicData.Remove("R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1");
                var q9 = new DynamicData();
                q9.AddDynamic(new Dictionary<string, string>{
                    { "WS_QTDBIL" , "0"}
                });
                q9.AddDynamic(new Dictionary<string, string>{
                    { "WS_QTDBIL" , "0"}
                });
                AppSettings.TestSet.DynamicData.Add("R0220_00_VERIFICA_CANCEL_DB_SELECT_1_Query1", q9);

                AppSettings.TestSet.DynamicData.Remove("R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1");
                var q10 = new DynamicData();
                q10.AddDynamic(new Dictionary<string, string>{
                   { "WS_QTDBIL" , "0"}
                });
                q10.AddDynamic(new Dictionary<string, string>{
                    { "WS_QTDBIL" , "0"}
                });
                AppSettings.TestSet.DynamicData.Add("R0220_00_VERIFICA_CANCEL_DB_SELECT_2_Query1", q10);
                #endregion
                var program = new BI3605B();
                program.Execute(MOVTO_STA_FILE_NAME_P);

                Assert.True(true);
            }
        }
        [Theory]
        [InlineData("Saida_BI3605B")]
        public static void BI3605B_Tests_Theory_SemProposta(string MOVTO_STA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_FILE_NAME_P = $"{MOVTO_STA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0180_00_SELECT_CONVERSI_Query1

                var q5 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0180_00_SELECT_CONVERSI_DB_SELECT_1_Query1", q5);

                #endregion

                #region BI3605B_CBILHETE

                var q4 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("BI3605B_CBILHETE");
                q4.AddDynamic(new Dictionary<string, string>{
                    { "BILHETE_NUM_BILHETE" , "12572"},
                    { "BILHETE_SITUACAO" , "F"},
                    { "BILHETE_SIT_SINISTRO" , "0"},
                    { "BILHETE_NUM_APOLICE" , "0"},
                });

                AppSettings.TestSet.DynamicData.Add("BI3605B_CBILHETE", q4);

                #endregion

                #endregion
                var program = new BI3605B();
                program.Execute(MOVTO_STA_FILE_NAME_P);

                //R0200_00_UPD_BILHETE_Update1
                var envList = AppSettings.TestSet.DynamicData["R0200_00_UPD_BILHETE_DB_UPDATE_1_Update1"].DynamicList;
                Assert.True(envList[1].TryGetValue("BILHETE_NUM_BILHETE", out var val5r) && val5r.Contains("12572"));
                Assert.True(envList[1].TryGetValue("BILHETE_SITUACAO", out var val7r) && val7r.Contains("*"));

                Assert.True(program.RETURN_CODE == 00);
            }
        }
        [Theory]
        [InlineData("Saida_BI3605B")]
        public static void BI3605B_Tests_Theory_Erro99(string MOVTO_STA_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            MOVTO_STA_FILE_NAME_P = $"{MOVTO_STA_FILE_NAME_P}_{timestamp}.txt";

            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region R0005_00_OBTER_DATA_DIA_Query1

                var q0 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1", q0);

                #endregion

                #endregion
                var program = new BI3605B();
                program.Execute(MOVTO_STA_FILE_NAME_P);


                Assert.True(program.RETURN_CODE == 9);
            }
        }
    }
}