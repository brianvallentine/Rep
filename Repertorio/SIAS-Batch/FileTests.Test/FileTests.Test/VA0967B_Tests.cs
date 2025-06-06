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
using static Code.VA0967B;
using System.IO;

namespace FileTests.Test
{
    [Collection("VA0967B_Tests")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.UnitTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0967B_Tests
    {
        //é de extrema importancia que este método seja modificado com cautela, 
        //o melhor é manter aqui apenas os dados que serão COMUM a todos os Theory's criados
        public static void Load_Parameters()
        {
            #region PARAMETERS
            #region R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1

            var q0 = new DynamicData();
            q0.AddDynamic(new Dictionary<string, string>{
                { "SISTEMAS_DATA_MOV_ABERTO" , "2023-01-01"},
                { "WHOST_DT_HOJE" , "2024-01-01"},
            });
            AppSettings.TestSet.DynamicData.Add("R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1", q0);

            #endregion

            #region VA0967B_C01_SINISHIS

            var q1 = new DynamicData();
            q1.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_NUM_APOL_SINISTRO" , "8569"}
            });
            AppSettings.TestSet.DynamicData.Add("VA0967B_C01_SINISHIS", q1);

            #endregion

            #region VA0967B_SINISHIS1

            var q2 = new DynamicData();
            q2.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_OCORR_HISTORICO" , "33"},
                { "SINISHIS_DATA_MOVIMENTO" , "2024-05-05"},
                { "SINISHIS_COD_USUARIO" , "79"},
            });
            AppSettings.TestSet.DynamicData.Add("VA0967B_SINISHIS1", q2);

            #endregion

            #region R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1

            var q3 = new DynamicData();
            q3.AddDynamic(new Dictionary<string, string>{
                { "SINISMES_NUM_CERTIFICADO" , "654123"}
            });
            AppSettings.TestSet.DynamicData.Add("R1100_00_SELECT_SINISMES_DB_SELECT_1_Query1", q3);

            #endregion

            #region R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1

            var q4 = new DynamicData();
            q4.AddDynamic(new Dictionary<string, string>{
                { "SEGURVGA_NUM_APOLICE" , "335657"},
                { "SEGURVGA_COD_SUBGRUPO" , "2"},
                { "SEGURVGA_COD_CLIENTE" , "7689"},
            });
            AppSettings.TestSet.DynamicData.Add("R1200_00_SELECT_SEGURVGA_DB_SELECT_1_Query1", q4);

            #endregion

            #region R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1

            var q5 = new DynamicData();
            q5.AddDynamic(new Dictionary<string, string>{
                { "CLIENTES_NOME_RAZAO" , "FERNANDO SANTOS"},
                { "CLIENTES_CGCCPF" , "852963741"},
            });
            AppSettings.TestSet.DynamicData.Add("R1300_00_SELECT_CLIENTES_DB_SELECT_1_Query1", q5);

            #endregion

            #region R1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1

            var q6 = new DynamicData();
            q6.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , "658"},
                { "PRODUTO_DESCR_PRODUTO" , "DESC PROD ABC"},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PRODUTO_DB_SELECT_1_Query1", q6);

            #endregion

            #region R1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1

            var q7 = new DynamicData();
            q7.AddDynamic(new Dictionary<string, string>{
                { "APOLICES_COD_PRODUTO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PRODUTO_DB_SELECT_2_Query1", q7);

            #endregion

            #region R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1

            var q8 = new DynamicData();
            q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_RAMO" , ""}
            });
            AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);

            #endregion

            #region R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1

            var q9 = new DynamicData();
            q9.AddDynamic(new Dictionary<string, string>{
                { "PRODUTO_COD_PRODUTO" , ""},
                { "PRODUTO_DESCR_PRODUTO" , ""},
            });
            AppSettings.TestSet.DynamicData.Add("R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1", q9);

            #endregion

            #region R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1

            var q10 = new DynamicData();
            q10.AddDynamic(new Dictionary<string, string>{
                { "USUARIOS_NOME_USUARIO" , "MARIO PEREIRA"}
            });
            AppSettings.TestSet.DynamicData.Add("R2100_00_SELECT_USUARIOS_DB_SELECT_1_Query1", q10);

            #endregion

            #region R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1

            var q11 = new DynamicData();
            q11.AddDynamic(new Dictionary<string, string>{
                { "SINISHIS_COD_USUARIO" , "1"},
                { "SINISHIS_DATA_MOVIMENTO" , "2024-06-06"},
            });
            AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q11);

            #endregion

            #endregion
        }

        [Theory]
        [InlineData("Saida_VA0967B.txt")]
        public static void VA0967B_Tests_Theory_SemSolicitacao_ReturnCode_00(string SAI0967B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0967B_FILE_NAME_P = $"{SAI0967B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0967B_AREA_DE_WORK
                var parameters = new VA0967B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2022-11-10";
                parameters.WPAR_PARAMETROS.Value = "M0000000000000000";
                #endregion
                #endregion  
                var program = new VA0967B();
                program.Execute(parameters, SAI0967B_FILE_NAME_P);

                //Assert.True(File.Exists(program._SAI0967B.FilePath));
                //Assert.True(new FileInfo(program._SAI0967B.FilePath)?.Length >= 0);

                Assert.True((program.AREA_DE_WORK.FILLER_0.WPAR_ROTINA == "M") &&
                            (program.AREA_DE_WORK.FILLER_0.WPAR_INICIO == "00000000") &&
                            (program.AREA_DE_WORK.FILLER_0.WPAR_FIM == "00000000") &&
                            (program.RETURN_CODE == 0));
            }
        }
        [Theory]
        [InlineData("Saida_VA0967B.txt")]
        public static void VA0967B_Tests_Theory_ErroData_ReturnCode_99(string SAI0967B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0967B_FILE_NAME_P = $"{SAI0967B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE
                #region VA0967B_AREA_DE_WORK
                var parameters = new VA0967B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2022-11-10";
                parameters.WPAR_PARAMETROS.Value = "M2024010120240931";
                #endregion
                #endregion  
                var program = new VA0967B();
                program.Execute(parameters, SAI0967B_FILE_NAME_P);

                

                Assert.True((program.RETURN_CODE == "99") &&
                            (program.AREA_DE_WORK.WS_ERRO_DATA == "SIM"));
            }
        }
        [Theory]
        [InlineData("Saida_VA0967B.txt")]
        public static void VA0967B_Tests_Theory_FluxoCoberturaAP_ReturnCode_00(string SAI0967B_FILE_NAME_P)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            SAI0967B_FILE_NAME_P = $"{SAI0967B_FILE_NAME_P}_{timestamp}.txt";
            lock (AppSettings.TestSet._lock)
            {
                AppSettings.TestSet.IsTest = true;
                AppSettings.TestSet.Clear();
                Load_Parameters();

                //para testes quando necessário alterar alguma variavel do loadParameter faça assim:
                //AppSettings.TestSet.DynamicData["R0100_00_INICIALIZA_Query1"]["SISTEMAS_DATA_MOV_ABERTO"] = "10";
                //dessa forma, alteramos apenas no necessário para os testes e evitamos alterar testes subsequentes, o region a seguir serve para isso...

                #region VARIAVEIS_TESTE

                #region VA0967B_AREA_DE_WORK
                var parameters = new VA0967B_AREA_DE_WORK();
                parameters.SIST_DT_MOV_ABERTO.Value = "2023-10-14";
                parameters.WPAR_PARAMETROS.Value = "M2024101120241022";
                #endregion

                #region R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1
                var q8 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R1500_00_SELECT_PRODUVG_DB_SELECT_1_Query1", q8);
                q8.AddDynamic(new Dictionary<string, string>{
                { "PRODUVG_RAMO" , "82"}
                 });
                #endregion

                #region R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1
                var q11 = new DynamicData();
                AppSettings.TestSet.DynamicData.Remove("R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1");
                AppSettings.TestSet.DynamicData.Add("R2200_00_SELECT_SINISHIS_DB_SELECT_1_Query1", q11);
                #endregion

                #endregion

                var program = new VA0967B();
                program.Execute(parameters, SAI0967B_FILE_NAME_P);

                Assert.True(File.Exists(program._SAI0967B.FilePath));
                Assert.True(new FileInfo(program._SAI0967B.FilePath)?.Length >= 0);

                Assert.True((program.RETURN_CODE == "00") &&
                            (program.AREA_DE_WORK.WS_ERRO_DATA == "NAO"));
            }
        }
    }
}